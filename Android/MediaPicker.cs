﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Droid.Services.Media;
using Xamarin.Forms.Labs.Services.Media;

[assembly: Dependency(typeof(MediaPicker))]

namespace sliver.Android
{
	/// <summary>
	///     Class MediaPicker.
	/// </summary>
	public class MediaPicker : IMediaPicker
	{
		private TaskCompletionSource<MediaFile> completionSource;
		private int requestId;

		private static Context Context
		{
			get { return Forms.Context ?? Application.Context; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MediaPicker"/> class.
		/// </summary>
		public MediaPicker()
		{
			IsPhotosSupported = true;
		}

		/// <summary>	
		/// Gets a value indicating whether this instance is camera available.
		/// </summary>
		/// <value><c>true</c> if this instance is camera available; otherwise, <c>false</c>.</value>
		public bool IsCameraAvailable
		{
			get
			{
				var isCameraAvailable = Context.PackageManager.HasSystemFeature(PackageManager.FeatureCamera);

				if (Build.VERSION.SdkInt >= BuildVersionCodes.Gingerbread)
				{
					isCameraAvailable |= Context.PackageManager.HasSystemFeature(PackageManager.FeatureCameraFront);
				}

				return isCameraAvailable;
			}
		}

		/// <summary>
		///     Gets a value indicating whether this instance is photos supported.
		/// </summary>
		/// <value><c>true</c> if this instance is photos supported; otherwise, <c>false</c>.</value>
		public bool IsPhotosSupported { get; private set; }

		/// <summary>
		/// Select a picture from library.
		/// </summary>
		/// <param name="options">The storage options.</param>
		/// <returns>Task with a return type of MediaFile.</returns>
		/// <exception cref="System.NotSupportedException">Throws an exception if feature is not supported.</exception>
		public Task<MediaFile> SelectPhotoAsync(CameraMediaStorageOptions options)
		{
			if (!IsCameraAvailable)
			{
				throw new NotSupportedException();
			}

			options.VerifyOptions();

			return TakeMediaAsync("image/*", Intent.ActionPick, options);
		}

		/// <summary>
		/// Takes the picture.
		/// </summary>
		/// <param name="options">The storage options.</param>
		/// <returns>Task with a return type of MediaFile.</returns>
		/// <exception cref="System.NotSupportedException">Throws an exception if feature is not supported.</exception>
		public Task<MediaFile> TakePhotoAsync(CameraMediaStorageOptions options)
		{
			if (!IsCameraAvailable)
			{
				throw new NotSupportedException();
			}   

			options.VerifyOptions();

			return TakeMediaAsync("image/*", MediaStore.ActionImageCapture, options);
		}

		/// <summary>
		/// Gets or sets the event that fires when media has been selected.
		/// </summary>
		/// <value>The on photo selected.</value>
		public EventHandler<MediaPickerArgs> OnMediaSelected { get; set; }

		/// <summary>
		///     Gets or sets the on error.
		/// </summary>
		/// <value>The on error.</value>
		public EventHandler<MediaPickerErrorArgs> OnError { get; set; }

		/// <summary>
		/// Creates the media intent.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="type">The type of intent.</param>
		/// <param name="action">The action.</param>
		/// <param name="options">The options.</param>
		/// <param name="tasked">if set to <c>true</c> [tasked].</param>
		/// <returns>Intent to create media.</returns>
		private Intent CreateMediaIntent(int id, string type, string action, MediaStorageOptions options, bool tasked = true)
		{
			var pickerIntent = new Intent(Context, typeof(MediaPickerActivity));
			pickerIntent.PutExtra(MediaPickerActivity.EXTRA_ID, id);
			pickerIntent.PutExtra(MediaPickerActivity.EXTRA_TYPE, type);
			pickerIntent.PutExtra(MediaPickerActivity.EXTRA_ACTION, action);
			pickerIntent.PutExtra(MediaPickerActivity.EXTRA_TASKED, tasked);

			if (options != null)
			{
				pickerIntent.PutExtra(MediaPickerActivity.EXTRA_PATH, options.Directory);
				pickerIntent.PutExtra(MediaStore.Images.ImageColumns.Title, options.Name);
			}

			return pickerIntent;
		}

		/// <summary>
		/// Gets the request identifier.
		/// </summary>
		/// <returns>Request id as integer.</returns>
		private int GetRequestId()
		{
			var id = requestId;
			if (requestId == int.MaxValue)
			{
				requestId = 0;
			}
			else
			{
				requestId++;
			}

			return id;
		}

		/// <summary>
		/// Takes the media asynchronous.
		/// </summary>
		/// <param name="type">The type of intent.</param>
		/// <param name="action">The action.</param>
		/// <param name="options">The options.</param>
		/// <returns>Task with a return type of MediaFile.</returns>
		/// <exception cref="System.InvalidOperationException">Only one operation can be active at a time.</exception>
		private Task<MediaFile> TakeMediaAsync(string type, string action, MediaStorageOptions options)
		{
			var id = GetRequestId();

			var ntcs = new TaskCompletionSource<MediaFile>(id);
			if (Interlocked.CompareExchange(ref completionSource, ntcs, null) != null)
			{
				throw new InvalidOperationException("Only one operation can be active at a time");
			}

			Context.StartActivity(CreateMediaIntent(id, type, action, options));

			EventHandler<MediaPickedEventArgs> handler = null;
			handler = (s, e) =>
			{
				var tcs = Interlocked.Exchange(ref completionSource, null);

				MediaPickerActivity.MediaPicked -= handler;

				if (e.RequestId != id)
				{
					return;
				}

				if (e.Error != null)
				{
					tcs.SetException(e.Error);
				} 
				else if (e.IsCanceled)
				{
					tcs.SetCanceled();
				}
				else
				{
					tcs.SetResult(e.Media);
				}
			};

			MediaPickerActivity.MediaPicked += handler;

			return ntcs.Task;
		}
	}
}
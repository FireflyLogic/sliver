using System.Threading.Tasks;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs.Services.Media;
using Xamarin.Forms.Labs.Mvvm;
using Xamarin.Forms;

namespace Xamarin.Forms.Labs.Sample
{
	/// <summary>
	/// Class CameraViewModel.
	/// </summary>
	[ViewType(typeof(CameraPage))]
	public class CameraViewModel : ViewModel
	{
		/// <summary>
		/// The _scheduler.
		/// </summary>
		private readonly TaskScheduler scheduler = TaskScheduler.FromCurrentSynchronizationContext();

		/// <summary>
		/// The _picture chooser.
		/// </summary>
		private IMediaPicker mediaPicker;

		/// <summary>
		/// The _image source.
		/// </summary>
		private ImageSource imageSource;

		/// <summary>
		/// The _take picture command.
		/// </summary>
		private Command takePictureCommand;

		/// <summary>
		/// The _select picture command.
		/// </summary>
		private Command selectPictureCommand;

		private string status;


		////private CancellationTokenSource cancelSource;

		/// <summary>
		/// Initializes a new instance of the <see cref="CameraViewModel" /> class.
		/// </summary>
		public CameraViewModel()
		{
			Setup();
		}

		/// <summary>
		/// Gets or sets the image source.
		/// </summary>
		/// <value>The image source.</value>
		public ImageSource ImageSource
		{
			get
			{
				return imageSource;
			}
			set
			{
				this.ChangeAndNotify(ref imageSource, value);
			}
		}

		/// <summary>
		/// Gets the take picture command.
		/// </summary>
		/// <value>The take picture command.</value>
		public Command TakePictureCommand 
		{
			get
			{
				return takePictureCommand ?? (takePictureCommand = new Command(
					async () => await TakePicture(),
					() => true)); 
			}
		}

		/// <summary>
		/// Gets the select picture command.
		/// </summary>
		/// <value>The select picture command.</value>
		public Command SelectPictureCommand 
		{
			get
			{
				return selectPictureCommand ?? (selectPictureCommand = new Command(
					async () => await SelectPicture(),
					() => true)); 
			}
		}

		/// <summary>
		/// Gets the status.
		/// </summary>
		/// <value>
		/// The status.
		/// </value>
		public string Status
		{
			get { return status; }
			private set { this.ChangeAndNotify(ref status, value); }
		}

		/// <summary>
		/// Setups this instance.
		/// </summary>
		private void Setup()
		{
			if (mediaPicker != null)
			{
				return;
			}

			var device = Resolver.Resolve<IDevice>();

			mediaPicker = DependencyService.Get<IMediaPicker>();
			////RM: hack for working on windows phone? 
			if (mediaPicker == null)
			{
				mediaPicker = device.MediaPicker;
			}
		}

		/// <summary>
		/// Takes the picture.
		/// </summary>
		/// <returns>Take Picture Task.</returns>
		private async Task TakePicture()
		{
			Setup();

			ImageSource = null;

			await this.mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Front, MaxPixelDimension = 400 }).ContinueWith(t =>
				{
					if (t.IsFaulted)
					{
						this.Status = t.Exception.InnerException.ToString();
					}
					else if (t.IsCanceled)
					{
						this.Status = "Canceled";
					}
					else
					{
						var mediaFile = t.Result;

						ImageSource = ImageSource.FromStream(() => mediaFile.Source);

						return mediaFile;
					}

					return null;
				}, scheduler);
		}

		/// <summary>
		/// Selects the picture.
		/// </summary>
		/// <returns>Select Picture Task.</returns>
		private async Task SelectPicture()
		{
			Setup();

			ImageSource = null;
			try
			{
				var mediaFile = await this.mediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions
					{
						DefaultCamera = CameraDevice.Front,
						MaxPixelDimension = 400
					});
				ImageSource = ImageSource.FromStream(() => mediaFile.Source);
			}
			catch (System.Exception ex)
			{
				this.Status = ex.Message;
			}
		}

		private static double ConvertBytesToMegabytes(long bytes)
		{
			return (bytes / 1024f) / 1024f;
		}
	}
}
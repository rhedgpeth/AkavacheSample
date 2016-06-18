using System;
using System.Threading.Tasks;

using UIKit;

using AkavachePCLSample.Services;

namespace AkavachePCLSample.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{ }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Button.AccessibilityIdentifier = "myButton";

			Button.TouchUpInside += GetSecretStuffs;
		}

		void GetSecretStuffs(object sender, EventArgs e)
		{
			Task.Run(async () =>
			{
				var secretThangs = await ExampleService.Instance.GetSecretness();

				if (secretThangs != null)
				{
					// Do something with the results!
				}
			});
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}

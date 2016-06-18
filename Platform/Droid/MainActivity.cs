using Android.App;
using Android.Widget;
using Android.OS;

using System;
using System.Threading.Tasks;

using AkavachePCLSample.Services;

namespace AkavachePCLSample.Droid
{
	[Activity(Label = "AkavachePCLSample", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			Button button = FindViewById<Button>(Resource.Id.myButton);

			button.Click += GetSecretStuffs;
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
	}
}



using Android.App;
using Android.Widget;
using Android.OS;
using AkavacheSample.DAL.Services;

namespace AkavacheSample
{
	[Activity (Label = "AkavacheSample", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Button btnCreateUsers = FindViewById<Button> (Resource.Id.btnCreateUsers);
			Button btnGetUser1 = FindViewById<Button> (Resource.Id.btnGetUser1);
			Button btnGetUser2 = FindViewById<Button> (Resource.Id.btnGetUser2);
			Button btnGetUsers = FindViewById<Button> (Resource.Id.btnGetUsers);
			Button btnDeleteUser = FindViewById<Button> (Resource.Id.btnDeleteUser);
			Button btnClear = FindViewById<Button> (Resource.Id.btnClear);

			var userService = new UserService ();

			btnCreateUsers.Click += async (object sender, System.EventArgs e) => {
				bool success = await userService.CreateUsers();

				if (success)
				{
					btnGetUser1.Enabled = true;
					btnGetUser2.Enabled = true;
					btnGetUsers.Enabled = true;
					btnDeleteUser.Enabled = true;
				}
			};

			btnGetUser1.Click += async (object sender, System.EventArgs e) => {
				var user = await userService.GetUser(1);
				var test = user;
			};

			btnGetUser2.Click += async (object sender, System.EventArgs e) => {
				var user = await userService.GetUser(4, 1);
				var test = user;
			};

			btnGetUsers.Click += async (object sender, System.EventArgs e) => {
				var users = await userService.GetUsers(1);
				var test = users;
			};

			btnDeleteUser.Click += async (object sender, System.EventArgs e) => {
				bool success = await userService.DeleteUser(4);
				var test = success;
			};

			btnClear.Click += async (object sender, System.EventArgs e) => {
				bool success = await userService.DeleteAllUsers();

				if (success)
				{
					btnGetUser1.Enabled = false;
					btnGetUser2.Enabled = false;
					btnGetUsers.Enabled = false;
					btnDeleteUser.Enabled = false;
				}
			};
		}
	}
}



using System.Collections.Generic;
using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Nitty.BL;
using Android.Views;


namespace Nitty.Droid.Screens {
	[Activity (Label = "Welcome Screen", MainLauncher = true)]			
	public class WelcomeScreen : Activity {

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Enable the ActionBar
			RequestWindowFeature(WindowFeatures.ActionBar);

			// set our layout to be the welcome screen
			SetContentView(Resource.Layout.WelcomeScreen);

			//Find our controls
			Button btnBegin = (Button)FindViewById<Button> (Resource.Id.buttonBegin);

			btnBegin.Click += delegate {
				StartActivity(typeof(HomeScreen));
			};
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Nitty.Droid
{
	[Activity (Label = "OptionsScreen")]			
	public class OptionsScreen : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Enable the ActionBar
			RequestWindowFeature(WindowFeatures.ActionBar);

			// set our layout to be the options screen
			SetContentView(Resource.Layout.OptionsScreen);

			//Find our controls
			Button btnTest = (Button)FindViewById<Button> (Resource.Id.buttonTest);
			Button btnResults = (Button)FindViewById<Button> (Resource.Id.buttonResults);
			Button btnProfile = (Button)FindViewById<Button> (Resource.Id.buttonProfile);


		}
	}
}


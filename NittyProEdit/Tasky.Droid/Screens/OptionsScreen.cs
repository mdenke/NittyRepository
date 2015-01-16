
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

			// determine if we are logged in or not
			AppGlobals appState = new AppGlobals ();
			appState = (AppGlobals)Application.Context;
			bool loggedIn = appState.isLoggedIn();

			//Find our controls
			Button btnTest = (Button)FindViewById<Button> (Resource.Id.buttonTest);
			Button btnResults = (Button)FindViewById<Button> (Resource.Id.buttonResults);
			Button btnProfile = (Button)FindViewById<Button> (Resource.Id.buttonProfile);

			//get our context and resource references
			Context context = this;
			// Get the Resources object from our context
			Android.Content.Res.Resources res = context.Resources;

			//set context changes
			if (loggedIn) {
				btnProfile.Text = res.GetString (Resource.String.signOut);
				btnResults.Visibility = ViewStates.Visible;
			} else {
				btnProfile.Text = res.GetString(Resource.String.signIn); 
				btnResults.Visibility = ViewStates.Gone;
			}
		}
	}
}


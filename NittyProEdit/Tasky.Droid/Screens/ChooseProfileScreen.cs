using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Nitty.BL;
using Android.Views;

namespace Nitty.Droid.Screens {
    [Activity (Label = "Choose Profile Screen", MainLauncher = false)]			
	public class ChooseProfileScreen : Activity {
		protected Adapters.ProfileListAdapter profileList;
		protected IList<Profile> profiles;
		protected ListView profileListView = null;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            // Enable the ActionBar
            RequestWindowFeature(WindowFeatures.ActionBar);

			// set our layout to be the ChooseProfileScreen
			SetContentView(Resource.Layout.ChooseProfileScreen);

			//Find our controls
			profileListView = FindViewById<ListView> (Resource.Id.lstProfiles);
			
			// wire up task click handler
			if(profileListView != null) {
				profileListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
					var profileDetails = new Intent (this, typeof (ProfileDetailsScreen));
					profileDetails.PutExtra ("ProfileID", profiles[e.Position].ID);
					StartActivity (profileDetails);
				};
			}
		}
		
		protected override void OnResume ()
		{
			base.OnResume ();

			profiles = Nitty.BL.Managers.ProfileManager.GetProfiles();
			
			// create our adapter
			profileList = new Adapters.ProfileListAdapter(this, profiles);

			//Hook up our adapter to our ListView
			profileListView.Adapter = profileList;
		}

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // Create the actions in the ActionBar.
            MenuInflater.Inflate(Resource.Menu.menu_homescreen, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_add_profile:
                    // The user has tapped the add task button
                    StartActivity(typeof(ProfileDetailsScreen));
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
	}
}
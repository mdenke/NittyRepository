using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Nitty.BL;
using Android.Views;

namespace Nitty.Droid.Screens {
    [Activity (Label = "Nitty", MainLauncher = true)]			
	public class HomeScreen : Activity {
		protected Adapters.ProfileListAdapter taskList;
		protected IList<Profile> tasks;
		protected ListView taskListView = null;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            // Enable the ActionBar
            RequestWindowFeature(WindowFeatures.ActionBar);

			// set our layout to be the home screen
			SetContentView(Resource.Layout.HomeScreen);

			//Find our controls
			taskListView = FindViewById<ListView> (Resource.Id.lstTasks);
			
			// wire up task click handler
			if(taskListView != null) {
				taskListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
					var taskDetails = new Intent (this, typeof (TaskDetailsScreen));
					taskDetails.PutExtra ("TaskID", tasks[e.Position].ID);
					StartActivity (taskDetails);
				};
			}
		}
		
		protected override void OnResume ()
		{
			base.OnResume ();

			tasks = Nitty.BL.Managers.ProfileManager.GetProfiles();
			
			// create our adapter
			taskList = new Adapters.ProfileListAdapter(this, tasks);

			//Hook up our adapter to our ListView
			taskListView.Adapter = taskList;
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
                case Resource.Id.menu_add_task:
                    // The user has tapped the add task button
                    StartActivity(typeof(TaskDetailsScreen));
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }

        }
	}
}
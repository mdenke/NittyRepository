using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Graphics;
using Android.Views;

using Nitty.BL;
using Android.Util;

namespace Nitty.Droid.Screens {
	//TODO: implement proper lifecycle methods
	[Activity (Label = "Profile Details")]			
	public class ProfileDetailsScreen : Activity {
		protected Profile prof = new Profile();
		protected EditText notesTextEdit;
		protected EditText nameTextEdit;
		protected RadioGroup genderRadioEdit;
		protected RadioButton maleButton;
		protected RadioButton femaleButton;
		CheckBox doneCheckbox;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            RequestWindowFeature(WindowFeatures.ActionBar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
			
			int profileID = Intent.GetIntExtra("ProfileID", 0);
			if(profileID > 0) {
				prof = Nitty.BL.Managers.ProfileManager.GetProfile(profileID);
			}
			
			// set our layout to be the home screen
			SetContentView(Resource.Layout.ProfileDetails);
			nameTextEdit = FindViewById<EditText>(Resource.Id.txtName);
			notesTextEdit = FindViewById<EditText>(Resource.Id.txtNotes);
			genderRadioEdit = FindViewById<RadioGroup> (Resource.Id.radGroupGender);
			maleButton = FindViewById<RadioButton> (Resource.Id.radioMale);
			femaleButton = FindViewById<RadioButton> (Resource.Id.radioFemale);
			doneCheckbox = FindViewById<CheckBox>(Resource.Id.chkDone);
						
			// name
			if(nameTextEdit != null) { nameTextEdit.Text = prof.Name; }
			
			// notes
			if(notesTextEdit != null) { notesTextEdit.Text = prof.Notes; }

			//gender
			if (genderRadioEdit != null)
			{
				Console.WriteLine (prof.Gender.ToString ());
				if (prof.Gender == eGender.Female)
					femaleButton.Checked = true;
				if (prof.Gender == eGender.Male)
					maleButton.Checked = true;
			}

			//done box
			if(doneCheckbox != null) { doneCheckbox.Checked = prof.Done; }
		}

		protected void Save()
		{
			prof.Name = nameTextEdit.Text;
			prof.Notes = notesTextEdit.Text;
			if (genderRadioEdit.CheckedRadioButtonId == femaleButton.Id)
				prof.Gender = eGender.Female;
			if (genderRadioEdit.CheckedRadioButtonId == maleButton.Id)
				prof.Gender = eGender.Male;
			prof.Done = doneCheckbox.Checked;
			Nitty.BL.Managers.ProfileManager.SaveProfile(prof);
			Finish();
		}
		
		protected void CancelDelete()
		{
			if(prof.ID != 0) {
				Nitty.BL.Managers.ProfileManager.DeleteProfile(prof.ID);
			}
			Finish();
		}

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_detailsscreen, menu);

            IMenuItem menuItem = menu.FindItem(Resource.Id.menu_delete_profile);
			menuItem.SetTitle(prof.ID == 0 ? "Cancel" : "Delete");

            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_save_profile:
                    Save();
                    return true;

                case Resource.Id.menu_delete_profile:
                    CancelDelete();
                    return true;

                default: 
                    Finish();
                    return base.OnOptionsItemSelected(item);
            }
        }

	}
}
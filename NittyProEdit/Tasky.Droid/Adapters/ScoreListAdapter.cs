using System;
using System.Collections.Generic;
using Android.Widget;
using Nitty.BL;
using Android.App;
using Android;
using Android.Views;

namespace Nitty.Droid.Adapters {
	public class ScoreListAdapter : BaseAdapter<Score> {
		protected Activity context = null;
		protected IList<Score> scores = new List<Score>();

		public ScoreListAdapter (Activity context, IList<Score> scores) : base ()
		{
			this.context = context;
			this.scores = scores;
		}

		public override Score this[int position]
		{
			get { return scores[position]; }
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count
		{
			get { return scores.Count; }
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			// Get our object for position
			var item = scores[position];			
			View view;

			//Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
			// gives us some performance gains by not always inflating a new view
			if (convertView == null)
			{
				view = context.LayoutInflater.Inflate(Resource.Layout.ScoreListItem, null);
			}
			else
			{
				view = convertView;
			}

			//adapt current variables
			/*var nameLabel = view.FindViewById<TextView>(Resource.Id.lblName);
			nameLabel.Text = item.Name;
			var notesLabel = view.FindViewById<TextView>(Resource.Id.lblDescription);
			notesLabel.Text = "Notes: " + item.Notes;
			var checkMark = view.FindViewById<ImageView>(Resource.Id.checkMark);
			checkMark.Visibility = item.Done ? ViewStates.Visible : ViewStates.Gone;*/


			/*
			 * 
			 * 
			 * public int Age { get; set; }
			 * public eGender Gender{ get; set; }
			 * public eEmploymentStatus EmploymentStatus { get; set; }
			 * public eEducationLevel EducationLevel { get; set; }
			 * *public float yearlyIncome { get; set; }
			 * public int siblings{ get; set; }
			 * 
			 */

			//Finally return the view
			return view;
		}
	}
}
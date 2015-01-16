using System;
using Android.App;

namespace Nitty.Droid
{
	class MyApp : Application {

		//todo: needs testing.

		public enum logStatus{
			loggedIn,
			loggedOut
		}
		public logStatus logState = logStatus.loggedOut;
		private int userId;

		public int getUserId(){
			try{
				return userId;
			}
			catch(NullReferenceException){
				Console.WriteLine ("Can not use MyApp.getuserId() without having already logged a user in!");
				return 0;
			}
		}

		public void setUserId(int i){
			try{
				userId = i;
				logState = logStatus.loggedIn;
			}
			catch(NullReferenceException){
				resetUserId ();
			}
		}

		public void resetUserId(){
			logState = logStatus.loggedOut;
		}

		public bool isLoggedIn(){
			if (logState == logStatus.loggedIn)
				return true;
			else
				return false;
		}
	}
}


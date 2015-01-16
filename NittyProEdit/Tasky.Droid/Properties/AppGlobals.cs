using System;
using Android.App;

namespace Nitty.Droid
{
	class AppGlobals : Application {

		//todo: needs testing.

		public enum logStatus{
			loggedIn,
			loggedOut
		}
		private logStatus logState;
		private int userId;

		public AppGlobals(logStatus status=logStatus.loggedOut){
			logState = status;
		}

		public int getUserId(){
			try{
				return userId;
			}
			catch(NullReferenceException){
				Console.WriteLine ("Can not use MyApp.getuserId() without having already logged a user in!");
				return -1;
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


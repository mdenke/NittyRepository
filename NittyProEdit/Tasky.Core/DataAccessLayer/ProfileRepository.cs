using System;
using System.Collections.Generic;
using System.IO;
using Nitty.BL;

namespace Nitty.DAL {
	public class ProfileRepository {
		DL.NittyDatabase db = null;
		protected static string dbLocation;		
		protected static ProfileRepository me;		
		
		static ProfileRepository ()
		{
			me = new ProfileRepository();
		}
		
		protected ProfileRepository()
		{
			// set the db location
			dbLocation = DatabaseFilePath;
			
			// instantiate the database	
			db = new Nitty.DL.NittyDatabase(dbLocation);
		}
		
		public static string DatabaseFilePath {
			get { 
				var sqliteFilename = "NittyDB.db3";

#if NETFX_CORE
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
#else

#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
	            var path = sqliteFilename;
#else

#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
	            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "../Library/"); // Library folder
#endif
				var path = Path.Combine (libraryPath, sqliteFilename);
#endif		

#endif
				return path;	
			}
		}

		//profile CRUDS...
		public static Profile GetProfile(int id)
		{
            return me.db.GetItem<Profile>(id);
		}
		
		public static IEnumerable<Profile> GetProfiles ()
		{
			return me.db.GetItems<Profile>();
		}
		
		public static int SaveProfile (Profile item)
		{
			return me.db.SaveItem<Profile>(item);
		}

		public static int DeleteProfile(int id)
		{
			return me.db.DeleteItem<Profile>(id);
		}


		//score CRUDS
		public static Score GetResult(int id)
		{
			return me.db.GetItem<Score>(id);
		}

		public static IEnumerable<Score> GetResults ()
		{
			return me.db.GetItems<Score>();
		}

		public static int SaveResult (Score item)
		{
			return me.db.SaveItem<Score>(item);
		}

		public static int DeleteResult(int id)
		{
			return me.db.DeleteItem<Score>(id);
		}
	}
}


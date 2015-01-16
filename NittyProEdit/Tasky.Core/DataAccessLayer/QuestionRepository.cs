using System;
using System.Collections.Generic;
using System.IO;
using Nitty.BL;

namespace Nitty.DAL {
	public class QuestionRepository
	{
		//THIS WHOLE THING IS TOTALLY NOT NEEDED AND NEEDS TO BE REMOVED.
		DL.NittyDatabase db = null;
		protected static string dbLocation;		
		protected static QuestionRepository me;		

		static QuestionRepository ()
		{
			me = new QuestionRepository();
		}
			
		protected QuestionRepository()
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
			

		//Qeustion CRUDS
		public static Question GetQuestion(int id)
		{
			return me.db.GetItem<Question>(id);
		}
		public static IEnumerable<Question> GetQuestions ()
		{
			return me.db.GetItems<Question>();
		}
		public static int SaveQuestion (Question item)
		{
			return me.db.SaveItem<Question>(item);
		}
		public static int DeleteQuestion(int id)
		{
			return me.db.DeleteItem<Question>(id);
		}
	
		//Answer CRUDS
		public static Answer GetAnswer(int id)
		{
			return me.db.GetItem<Answer>(id);
		}
	
		public static IEnumerable<Answer> GetAnswers ()
		{
			return me.db.GetItems<Answer>();
		}

		public static int SaveAnswer (Answer item)
		{
			return me.db.SaveItem<Answer>(item);
		}

		public static int DeleteAnswer(int id)
		{
			return me.db.DeleteItem<Answer> (id);
		}
	}
}


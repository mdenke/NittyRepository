using System;
using Nitty.BL.Contracts;
using Nitty.DL.SQLite;


namespace Nitty.BL
{
	//TODO: include variables - date taken, taker profile id, others?  make a data model with dan!
	public class Answer  : IBusinessEntity
	{


		public Answer ()
		{
			CreateDate = DateTime.Now;
			CreateUser = "SYSTEM";
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public int MyQuestion{ get; set; }
		public string Text { get; set; }
		public float Weight { get; set; }
		public int SequenceID { get; set; }
		public DateTime CreateDate{ get; set;}
		public DateTime UpdateDate{ get; set; }
		//this probably shouldn't be a string, but instead be an id that points to an admin user in a table...
		public string CreateUser { get; set; }
		public string UpdateUser { get; set; }


	}
}

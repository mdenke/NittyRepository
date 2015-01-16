using System;
using Nitty.BL.Contracts;
using Nitty.DL.SQLite;


namespace Nitty.BL
{


	public class Question : IBusinessEntity
	{

		public Question ()
		{
			CreateDate = DateTime.Now;
			CreateUser = "SYSTEM";
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string QuestionText { get; set; }
		public int SequenceID { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		//this probably shouldn't be a string, but instead be an id that points to an admin user in a table...
		public string CreateUser { get; set; }
		public string UpdateUser { get; set; }
	}
}


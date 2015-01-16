using System;
using Nitty.BL.Contracts;
using Nitty.DL.SQLite;

namespace Nitty.BL
{

	public class Score  : IBusinessEntity
	{


		public Score ()
		{
			CreateDate = DateTime.Now;
			CreateUser = "SYSTEM";
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public int MyProfile { get; set; }
		public DateTime CreateDate{ get; set; }
		//this probably shouldn't be a string, but instead be an id that points to an admin user in a table...
		public string CreateUser { get; set; }
	}
}


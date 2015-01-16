using System;
using Nitty.BL.Contracts;
using Nitty.DL.SQLite;
//using System.ComponentModel;

namespace Nitty.BL
{
	/// <summary>
	/// Represents a Profile.
	/// </summary>
	//TODO CHANGE NAME TO EMAIL

	public enum eGender{ Female, Male }
	public enum eEmploymentStatus{ Employed, Unemployed }
	public enum eEducationLevel {Primary, Secondary, Highschool, Associate, Bachelor, Master, PHD}

	public class Profile : IBusinessEntity
	{
	
		public Profile ()
		{

		}
			
		[PrimaryKey, AutoIncrement]
        public int ID { get; set; }
		public string Name { get; set; }

		public string Notes { get; set; }
		public bool Done { get; set; }
		public int Age { get; set; }
		public eGender Gender{ get; set; }
		public eEmploymentStatus EmploymentStatus { get; set; }
		public eEducationLevel EducationLevel { get; set; }
		public float yearlyIncome { get; set; }
		public int siblings{ get; set; }

	}
}


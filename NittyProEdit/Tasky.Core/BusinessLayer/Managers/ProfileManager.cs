using System;
using System.Collections.Generic;
using Nitty.BL;

namespace Nitty.BL.Managers
{
	public static class ProfileManager
	{
		static ProfileManager ()
		{
		}
		
		public static Profile GetProfile(int id)
		{
			return DAL.ProfileRepository.GetProfile(id);
		}
		
		public static IList<Profile> GetProfiles ()
		{
			return new List<Profile>(DAL.ProfileRepository.GetProfiles());
		}
		
		public static int SaveProfile (Profile item)
		{
			return DAL.ProfileRepository.SaveProfile(item);
		}
		
		public static int DeleteProfile(int id)
		{
			return DAL.ProfileRepository.DeleteProfile(id);
		}
		
	}
}
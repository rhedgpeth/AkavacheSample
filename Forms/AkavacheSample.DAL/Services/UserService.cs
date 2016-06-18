using System;
using System.Threading.Tasks;
using AkavacheSample.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace AkavacheSample.DAL.Services
{
	public class UserService : BaseService
	{
		public UserService ()
		{ }

		public async Task<bool> CreateUsers()
		{
			try
			{
				// Create users and insert them via Akavache into SQLite
				for (int i = 0; i < 10; i++) 
				{
					var user = new UserDTO 
					{
						UserID = i,
						DepartmentID = i % 2 == 0 ? 1 : 2,
						FirstName = "FirstName_" + i,
						LastName = "LastName_" + i
					};

					await SaveObject ("User_" + i, user);
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<UserDTO> GetUser(int userID)
		{
			return await GetAsync<UserDTO> ("User_" + userID);
		}

		public async Task<UserDTO> GetUser(int userID, int departmentID)
		{
			var allUsers = await GetAllAsync<UserDTO> ();
			return allUsers.Where (x => x.UserID == userID && x.DepartmentID == departmentID).SingleOrDefault ();
		}

		public async Task<List<UserDTO>> GetUsers(int departmentID)
		{
			var allUsers = await GetAllAsync<UserDTO> ();
			return allUsers.Where (x => x.DepartmentID == departmentID).ToList ();
		}

		public async Task<bool> DeleteUser(int userID)
		{
			try 
			{
				await DeleteAsync("User_" + userID);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<bool> DeleteAllUsers()
		{
			try 
			{
				await DeleteEverything();
				return true;
			}
			catch
			{
				return false;
			} 
		}
	}
}


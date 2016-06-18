using System;
using System.Threading.Tasks;
using Akavache;
using System.Reactive.Linq;
using System.Collections.Generic;

namespace AkavacheSample.DAL.Services
{
	public abstract class BaseService
	{
		public BaseService ()
		{ 
			BlobCache.ApplicationName = "AkavacheSample";
		}

		protected async Task DeleteAsync(string key)
		{
			await BlobCache.Secure.Invalidate (key);
		}

		protected async Task DeleteEverything()
		{
			await BlobCache.Secure.InvalidateAll ();
		}

		protected async Task SaveObject<T>(string key, T value)
		{
			await BlobCache.Secure.InsertObject (key, value);
		}

		protected async Task<T> GetAsync<T>(string key)
		{
			try
			{
				return await BlobCache.Secure.GetObject<T>(key);
			}
			catch (KeyNotFoundException) 
			{
				return default(T);
			}
		}

		protected async Task<IEnumerable<T>> GetAllAsync<T>()
		{
			try 
			{
				return await BlobCache.Secure.GetAllObjects<T>();
			}
			catch (KeyNotFoundException) 
			{
				return default(IEnumerable<T>);
			}
		}
	}
}


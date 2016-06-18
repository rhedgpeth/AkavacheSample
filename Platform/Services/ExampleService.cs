using System;
using System.Threading.Tasks;

using Akavache;
using System.Reactive.Linq;

using AkavachePCLSample.Models;

namespace AkavachePCLSample.Services
{
	public class ExampleService
	{
		static readonly ExampleService instance = new ExampleService();

		public static ExampleService Instance
		{
			get { return instance; }
		}

		ExampleService()
		{
			BlobCache.ApplicationName = "AkavachePCLSample";
		}

		public async Task<SuperSecretness> GetSecretness()
		{
			return await BlobCache.Secure.GetOrFetchObject("SuperSecretness",
														   async () => await GetSecretnessMockRequest(),
			                                               new DateTimeOffset(DateTime.Now.AddDays(1)));
		}

		public async Task<SuperSecretness> GetNotSoSecretness()
		{
			return await BlobCache.LocalMachine.GetOrFetchObject("SuperSecretness",
														   async () => await GetSecretnessMockRequest(),
														   new DateTimeOffset(DateTime.Now.AddDays(1)));
		}

		async Task<SuperSecretness> GetSecretnessMockRequest()
		{
			return await Task.Run(() =>
			{
				return new SuperSecretness
				{
					Secret1 = "This is the first secret.",
					Secret2 = "This is the second secret.",
					Secret3 = "This is the third secret."
				};
			});
		}
	}
}


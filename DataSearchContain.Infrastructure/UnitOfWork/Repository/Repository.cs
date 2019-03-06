using DataSearchContain.Domain.UnitOfWork.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataSearchContain.Infrastructure.UnitOfWork.Reposetory
{
    public class Repository : IRepository
    {
		public Task<int> MatchingItems(string word)
		{
			Thread.Sleep(10000);
			return Task.FromResult(24);
		}

		public async Task<bool> WordExist(string word)
        {
			Thread.Sleep(5000);
            return true;
        }
    }
}

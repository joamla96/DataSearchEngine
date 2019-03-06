using DataSearchContain.Domain.UnitOfWork.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataSearchContain.Infrastructure.UnitOfWork.Reposetory
{
    public class Repository : IRepository
    {
		public Task<int> MatchingItems(string word)
		{
			throw new NotImplementedException("This is not working right now");
		}

		public async Task<bool> WordExist(string word)
        {
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebClient.Domain.UnitOfWork.Repository;

namespace WebClient.Infrastructure.UnitOfWorks.Repository
{
    public class Repository : IRepository
    {
        public async Task<bool> WordExist(string word)
        {
            return true;
        }
    }
}

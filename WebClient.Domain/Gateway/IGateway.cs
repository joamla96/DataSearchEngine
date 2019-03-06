using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Domain.Gateway
{
    public interface IGateway
    {
        Task<bool> WordExist(string word);
    }
}

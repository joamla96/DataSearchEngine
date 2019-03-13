using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebClient.Domain.Gateway;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace WebClient.Infrastructure.Gateway
{
    public class SearchContainGateway : IGateway
    {
        private IConfiguration _configuration;

        public SearchContainGateway(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> WordExist(string word)
        {
            var conntectionStr = _configuration.GetConnectionString("DefaultConnection");

			var client = new RestClient(conntectionStr);
			var request = new RestRequest("DataSearchContainLB", Method.POST, DataFormat.Json);
			request.AddJsonBody(new { Quarry = word });

			var response = await client.ExecuteTaskAsync(request);

            if (!response.IsSuccessful)
                throw new Exception("No response");

			var body = response.Content;

            return JsonConvert.DeserializeObject<bool>(body);
        }
    }
}

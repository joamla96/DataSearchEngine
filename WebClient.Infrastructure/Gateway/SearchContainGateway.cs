using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebClient.Domain.Gateway;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace WebClient.Infrastructure.Gateway
{
    public class SearchContainGateway : IGateway
    {
        private HttpClient _client;
        private IConfiguration _configuration;

        public SearchContainGateway(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        public async Task<bool> WordExist(string word)
        {
            var conntectionStr = _configuration.GetConnectionString("DefaultConnection");

            var httpRequestMessage
               = new HttpRequestMessage(HttpMethod.Post, new Uri(conntectionStr + "DataSearchContainLB"));

            var response = await _client.SendAsync(httpRequestMessage);

            if (!response.IsSuccessStatusCode)
                throw new Exception("No response");

            var body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(body);
        }
    }
}

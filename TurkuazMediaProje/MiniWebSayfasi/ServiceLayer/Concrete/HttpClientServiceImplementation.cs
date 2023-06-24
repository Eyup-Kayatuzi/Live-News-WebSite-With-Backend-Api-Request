using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Concrete
{
    public class HttpClientServiceImplementation : IHttpClientServiceImplementation
    {
        private readonly HttpClient _httpClient;
        public HttpClientServiceImplementation()
        {
            _httpClient = new HttpClient();
        }
        public async Task<string> SendRequestDefaultAdj(string address)
        {
            string returnVal = null;
            try
            {
                var response = await _httpClient.GetAsync(address);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                returnVal = content;
            }
            catch (Exception)
            {

                Console.WriteLine("An error has been occured while accessing to api");
            }
            return returnVal;
        }
    }
}

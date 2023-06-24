using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interface;

namespace MiniWebSayfasi.Controllers
{
    public class AccessController : Controller
    {
        private readonly IHelperMethods _helperMethods;
        public AccessController(IHttpClientServiceImplementation httpClientService, IHelperMethods helperMethods)
        {
            _helperMethods = helperMethods;
        }
        public async Task<IActionResult> WebsiteWithHaberApisi()
        {
            return await _helperMethods.ConnectToApi("https://api.tmgrup.com.tr/v1/link/352", "articles");
        }
        public async Task<IActionResult> WebsiteWithVideoApisi()
        {
            return await _helperMethods.ConnectToApi("https://api.tmgrup.com.tr/v1/link/424", "videos");

        }
        public async Task<IActionResult> ExtraContent()
        {
            return await _helperMethods.ConnectToApi("https://api.tmgrup.com.tr/v1/link/352","https://api.tmgrup.com.tr/v1/link/424", "articles", "videos");
        }
    }
}

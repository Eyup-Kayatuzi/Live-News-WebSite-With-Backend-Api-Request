using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Concrete
{
    public class HelperMethods : Controller, IHelperMethods
    {
        private readonly IHttpClientServiceImplementation _httpClientService;
        public HelperMethods(IHttpClientServiceImplementation httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public async Task<IActionResult> ConnectToApi(string apiAddress, string target)
        {
            var returnVal = await _httpClientService.SendRequestDefaultAdj(apiAddress);
            if (returnVal != null)
            {
                var jsonObject = JObject.Parse(returnVal);
                var statusCode = (int)jsonObject["meta"]["status_code"];
                if (statusCode == 200)
                {
                    var contextList = jsonObject["data"][target]["Response"]; // 
                    return View(contextList);
                }
                else
                {
                    return statusCode == 400 ? BadRequest("Status Code 400: Bad Request") :
                        statusCode == 401 ? Unauthorized("Status Code 401: Unauthorized") :
                        statusCode == 403 ? Forbid("Status Code 403: Forbidden") :
                         NotFound("Status Code 404: Not Found");

                }
            }
            else
            {
                return BadRequest("İçeriğe ulaşılamadı");
            }
        }
        public async Task<IActionResult> ConnectToApi(string apiAddress, string apiAddress2, string target, string target2)
        {
            var returnVal = await _httpClientService.SendRequestDefaultAdj(apiAddress);
            var returnVal2 = await _httpClientService.SendRequestDefaultAdj(apiAddress2);
            if (returnVal != null)
            {
                var jsonObject = JObject.Parse(returnVal);
                var jsonObject2 = JObject.Parse(returnVal2);
                var statusCode = (int)jsonObject["meta"]["status_code"];
                var statusCode2 = (int)jsonObject2["meta"]["status_code"];
                if (statusCode == 200 && statusCode2 == 200)
                {
                    List<JToken> total = new();
                    total.Add(jsonObject["data"][target]["Response"]);
                    total.Add(jsonObject2["data"][target2]["Response"]);
                     
                    //var contextList = jsonObject["data"][target]["Response"]; 
                    return View(total);
                }
                else
                {
                    return statusCode == 400 ? BadRequest("Status Code 400: Bad Request") :
                        statusCode == 401 ? Unauthorized("Status Code 401: Unauthorized") :
                        statusCode == 403 ? Forbid("Status Code 403: Forbidden") :
                         NotFound("Status Code 404: Not Found");

                }
            }
            else
            {
                return BadRequest("İçeriğe ulaşılamadı");
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IHelperMethods
    {
        Task<IActionResult> ConnectToApi(string apiAddress, string target);
        Task<IActionResult> ConnectToApi(string apiAddress, string apiAddress2, string target, string target2);
    }
}

using Microsoft.AspNetCore.Mvc;
using System;

namespace sample_docker_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public object Get(string name = null)
        {
            return new
            {
                MachineName = Environment.MachineName,
                Os = Environment.OSVersion.VersionString,
                Request = $"{Request.Host.Value}{Request.Path}{Request.QueryString}"
            };
        }
    }
}

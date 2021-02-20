using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CocAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public ValuesController(IConfiguration config)
        {
            configuration = config;
        }

        // GET api/values/
        [HttpGet()]
        public ActionResult<string> Get()
        {
            return "Add clantag in url to retrieve clan info. Clantag must contain '%23' in place of #-symbol.";
        }

        // GET api/values/%23XX000XX0
        [HttpGet("{tag}")]
        public async Task<ActionResult<string>> GetAsync(string tag)
        {
            HttpClient client = new HttpClient();client.DefaultRequestHeaders.Add("Authorization", "Bearer " + configuration.GetValue<string>("CoCBearer"));
            HttpResponseMessage response = await client.GetAsync("https://api.clashofclans.com/v1/clans/" + tag);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                var error = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{ \"memberList\" : [] }", System.Text.Encoding.UTF8, "application/json")
                };
                return await error.Content.ReadAsStringAsync();
            }
        }
    }
}
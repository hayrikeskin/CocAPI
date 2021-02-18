using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CocAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values/%238L000CQ8
        [HttpGet("{tag}")]
        public async Task<ActionResult<string>> GetAsync(string tag)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjA1OGM3MjU3LWJjZWMtNDAxNi1hNjIxLThhOWQyNDViNTBjOSIsImlhdCI6MTYxMzIwMDkzNywic3ViIjoiZGV2ZWxvcGVyL2QxNGExY2IxLWZlYmEtMDM5OC03NWU2LWZkNGVjMjcwMzhkMSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjgyLjE3My4zOS4yNDgiXSwidHlwZSI6ImNsaWVudCJ9XX0.CUlevIlUQEPWtpZoZbT3lI5oqk9uxMI4tVGW5XyCyIN2yDw2Y4YWE0AgEg3hyuy1-4CEJEKWXivMhY3DNlUx-Q");
            HttpResponseMessage response = await client.GetAsync("https://api.clashofclans.com/v1/clans/" + tag);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}

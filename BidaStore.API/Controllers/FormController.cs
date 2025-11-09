using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BidaStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        public record EquationResult(string Message, double? Solution = null);
        [HttpGet]
        public IActionResult GetForm1(double a, double b)
        {
            if (a == 0)
            {
                if (b == 0)
                {
                    // Vô số nghiệm
                    return Ok(new EquationResult("Phương trình có vô số nghiệm."));
                }
                else
                {
                    // Vô nghiệm
                    return Ok(new EquationResult("Phương trình vô nghiệm."));
                }
            }
            else
            {
                // Có nghiệm duy nhất
                double x = -b / a;
                return Ok(new EquationResult($"Nghiệm của phương trình là: x = {x}", x));
            }
        }
    }
}

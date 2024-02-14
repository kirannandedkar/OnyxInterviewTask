using Microsoft.AspNetCore.Mvc;
using InterviewTask3;

namespace InterviewTask4Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VatController : ControllerBase
    {
        private readonly ILogger<VatController> _logger;

        public VatController(ILogger<VatController> logger)
        {
            _logger = logger;
        }

        [HttpGet("checkvat/{countryCode}/{vatId}", Name = "checkvat")]
        public async Task<ActionResult<APIResponse>> Get(string countryCode, string vatId)
        {
            var result = new APIResponse();
            try
            {
                var vatVerifier = new VatVerifier();
                var apiCall = await vatVerifier.GetVerificationStatus(countryCode, vatId);
                result.Result = apiCall.ToString();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Server Error..!!");
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }
    }

    public class APIResponse
    {
        public string Result { get; set; } = string.Empty;
    }
}

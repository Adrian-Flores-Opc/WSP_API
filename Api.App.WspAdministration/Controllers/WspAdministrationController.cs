using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WSP.ABSTRACTION.ENTITIES.Model;
using WSP.ABSTRACTION.LOGGER;

namespace Api.App.WspAdministration.Controllers
{

    [ApiVersion("1")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WspAdministrationController : ControllerBase
    {
        private readonly ILoggerInfo _logger;
        public WspAdministrationController(ILoggerInfo logger)
        {
            this._logger = logger;
        }

        [ApiExplorerSettings(GroupName = "v1")]
        [HttpPost("ReceivedMessages")]
        [ProducesResponseType(typeof(GenericAnswer), 200)]
        public ActionResult WhatsappReceivedMessages()
        {
            try
            {
                var _response = new GenericAnswer() { message = "procesing complete.", code = 200, state = true };
                this._logger.Debug(string.Format("RESPONSE: {0}", JsonConvert.SerializeObject(_response)));
                return Ok(_response);
            }
            catch (Exception ex)
            {
                this._logger.Debug(string.Format("ERROR: {0}", ex.Message));
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet("webhooks")]
        [ProducesResponseType(typeof(int), 200)]
        public ActionResult webhooks(string _parameter)
        {
            try
            {
                this._logger.Debug(string.Format("ENTRADA: {0}", _parameter));
                var _response = new GenericAnswer() { message = "procesing complete.", code = 200, state = true };
                this._logger.Debug(string.Format("RESPONSE: {0}", JsonConvert.SerializeObject(_response)));
                return Ok(_response);
            }
            catch (Exception ex)
            {
                this._logger.Debug(string.Format("ERROR: {0}", ex.Message));
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

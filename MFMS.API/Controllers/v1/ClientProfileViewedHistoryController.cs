using MFMS.API.Handler;
using MFMS.Application.Abstraction;
using MFMS.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace MFMS.API.Controllers.v1
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ClientProfileViewedHistoryController : ControllerBase
    {
        #region Private member variables
        private readonly IClientProfileViewedHistoryService _clientProfileViewedHistoryService;
        #endregion

        #region Public Constructor
        public ClientProfileViewedHistoryController(IClientProfileViewedHistoryService clientProfileViewedHistoryService)
        {
            _clientProfileViewedHistoryService = clientProfileViewedHistoryService;
        }
        #endregion

        #region Public member methods.

        // GET: api/<ClientProfileViewedHistoryController>
        [HttpGet]
        public IActionResult Get(long id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _clientProfileViewedHistoryService.GetAllClientProfileViewedHistory(id);
                if (response == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, response));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<ClientProfileViewedHistoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _clientProfileViewedHistoryService.GetClientProfileViewedHistoryById(id);
                if (response == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, response));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<ClientProfileViewedHistoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] DTOClientProfileViewedHistory model)
        {
            try
            {
                ResponseType type = ResponseType.NotFound;
                var result = _clientProfileViewedHistoryService.UpdateClientProfileViewedHistory(model);
                if (result != null)
                {
                    type = ResponseType.Success;
                }
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<ClientProfileViewedHistoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _clientProfileViewedHistoryService.DeleteClientProfileViewedHistory(id);
                if (response == false)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, response));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        #endregion
    }
}

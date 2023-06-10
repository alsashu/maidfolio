using MFMS.API.Handler;
using MFMS.Application.Abstraction;
using MFMS.DataTransferObject;
using MFMS.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MFMS.API.Controllers.v1
{

    [Route("v1/api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        #region Private member variables
        private readonly ICountryService _countryService;
        #endregion

        #region Public Constructor
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        #endregion

        #region Public member methods.

        // GET: api/<CountryController>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _countryService.GetAllCountry();
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

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _countryService.GetCountryById(id);
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

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] DTOCountry model)
        {
            try
            {
                ResponseType type = ResponseType.NotFound;
                var result = _countryService.UpdateCountry(model);
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

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _countryService.DeleteCountry(id);
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

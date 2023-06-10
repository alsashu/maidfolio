using MFMS.API.Handler;
using MFMS.Application.Abstraction;
using MFMS.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace MFMS.API.Controllers.v1
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class MaidReviewController : ControllerBase
    {
        #region Private member variables
        private readonly IMaidReviewService _maidReviewService;
        #endregion

        #region Public Constructor
        public MaidReviewController(IMaidReviewService maidReviewService)
        {
            _maidReviewService = maidReviewService;
        }
        #endregion

        #region Public member methods.

        // GET: api/<MaidReviewController>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _maidReviewService.GetAllMaidReview();
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

        // GET api/<MaidReviewController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _maidReviewService.GetMaidReviewById(id);
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

        // PUT api/<MaidReviewController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] DTOMaidReview model)
        {
            try
            {
                ResponseType type = ResponseType.NotFound;
                var result = _maidReviewService.UpdateMaidReview(model);
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

        // DELETE api/<MaidReviewController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _maidReviewService.DeleteMaidReview(id);
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

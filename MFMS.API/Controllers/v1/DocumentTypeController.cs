using MFMS.API.Handler;
using MFMS.Application.Abstraction;
using MFMS.DataTransferObject;
using MFMS.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MFMS.API.Controllers.v1
{

    [Route("v1/api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        #region Private member variables
        private readonly IDocumentTypeService _documentTypeService;
        #endregion

        #region Public Constructor
        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }
        #endregion

        #region Public member methods.

        // GET: api/<DocumentTypeController>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _documentTypeService.GetAllDocumentType();
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

        // GET api/<DocumentTypeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _documentTypeService.GetDocumentTypeById(id);
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

        // PUT api/<DocumentTypeController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] DTODocumentType model)
        {
            try
            {
                ResponseType type = ResponseType.NotFound;
                var result = _documentTypeService.UpdateDocumentType(model);
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

        // DELETE api/<DocumentTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _documentTypeService.DeleteDocumentType(id);
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

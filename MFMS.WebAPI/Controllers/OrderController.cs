using MFMS.WebAPI.EFCore;
using MFMS.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MFMS.WebAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DbHelper _db;
        public OrderController(EF_DataContext ef_DataContext)
        {
            _db = new DbHelper(ef_DataContext);
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<ProductModel> response = _db.GetProducts();
                if (!response.Any())
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

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                ProductModel response = _db.GetProductById(id);
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

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveOrder(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut]
        public IActionResult Put([FromBody] OrderModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveOrder(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleatOrder(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Deleted"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}

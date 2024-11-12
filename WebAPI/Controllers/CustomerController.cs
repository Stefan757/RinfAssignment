using Application.BusinessServices;
using Application.DataTransferObjects.Transaction;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController(ICustomerService customerService) : Controller
    {

        [HttpGet]
        public ActionResult<List<TransactionDto>> GetAll()
        {
            return Ok(customerService.GetAll());
        }
    }
}

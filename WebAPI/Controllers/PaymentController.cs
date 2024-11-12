using Application.BusinessServices;
using Application.DataTransferObjects.Payment;
using Application.DataTransferObjects.Transaction;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController(IPaymentService paymentService) : Controller
    {

        [HttpPost]
        public ActionResult<TransactionDto> Create([FromBody] PaymentCreationDto paymentCreationDto)
        {
            try
            {
                Result<PaymentDto> result = paymentService.CreatePayment(paymentCreationDto);

                if (!result.Success)
                {
                    return BadRequest(result.Error!.Message);
                }

                return Ok(result.Value);
            }
            catch
            {
                //logg error
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

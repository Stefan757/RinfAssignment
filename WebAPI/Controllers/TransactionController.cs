using Application.DataTransferObjects.Transaction;
using Application.Interfaces;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController(ITransactionService transactionService) : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<TransactionDto>> GetAll()
        {
            return Ok(transactionService.GetAll());
        }

        [HttpPost]
        public ActionResult<TransactionDto> Create([FromBody] TransactionCreationDto transactionCreationDto) 
        { 
            var result = transactionService.CreateTransaction(transactionCreationDto);

            if (!result.Success)
            {
                return BadRequest(result.Error!.Message);
            }

            return Ok(result.Value);
        }
    }
}

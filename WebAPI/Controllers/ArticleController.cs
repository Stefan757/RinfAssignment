using Application.BusinessServices;
using Application.DataTransferObjects.Transaction;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController(IArticleService articleService) : Controller
    {

        [HttpGet]
        public ActionResult<List<TransactionDto>> GetAll()
        {
            return Ok(articleService.GetAll());
        }
    }
}

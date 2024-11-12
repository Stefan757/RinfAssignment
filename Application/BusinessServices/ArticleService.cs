using Application.DataTransferObjects.Article;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessServices
{
    public class ArticleService(IMapper mapper, IArticleRepository articleRepository) : IArticleService
    {
        public List<ArticleDto> GetAll()
        {
            return mapper.Map<List<ArticleDto>>(articleRepository.GetAll());
        }

    }
}

using Application.BusinessServices;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Test
{
    [TestFixture]
    public class ArticleService_GetAllShould
    {
        IMapper mapper;
        IArticleRepository repository;
        ArticleService articleService;

        [SetUp]
        public void Setup()
        {
            mapper = MapperConfig.InitializeAutomapper();
            repository = new MockArticleRepository();
            articleService = new ArticleService(mapper, repository);
        }

        [Test]
        public void GetAll_ReturnCount5()
        {
            var result = articleService.GetAll();

            Assert.That(result.Count == 5, "Result should contain 5 ArticleDtos.");
        }

        private class MockArticleRepository() : IArticleRepository
        {
            public bool Delete(int id)
            {
                throw new NotImplementedException();
            }

            public bool Exists(int id)
            {
                throw new NotImplementedException();
            }

            public Article? Get(int id)
            {
                throw new NotImplementedException();
            }

            public List<Article> GetAll()
            {
                return new List<Article> 
                {
                    new Article { Id = 1, Author = "John Hersey", Title = "Hiroshima", Price = 45, Stock = 80},
                    new Article { Id = 2, Author = "Rachel Carson", Title = "Silent Spring", Price = (decimal)29.50, Stock = 120 },
                    new Article { Id = 3, Author = "Edward R. Murrow", Title = "This is London", Price = 63, Stock = 55 },
                    new Article { Id = 4, Author = "Ida Tarbell", Title = "The History of the Standard Oil Company", Price = (decimal)56.50, Stock = 79 },
                    new Article { Id = 5, Author = "Lincoln Steffens", Title = "The Shame of the Cities", Price = (decimal)35.50, Stock = 37 }
                };
            }
        }
    }
}
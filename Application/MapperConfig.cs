using Application.DataTransferObjects.Article;
using Application.DataTransferObjects.Customer;
using Application.DataTransferObjects.Payment;
using Application.DataTransferObjects.Transaction;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleDto>();
                cfg.CreateMap<ArticleDto, Article>();


                cfg.CreateMap<Transaction, TransactionDto>();
                cfg.CreateMap<TransactionDto, Transaction>();


                cfg.CreateMap<ArticleTransaction, ArticleTransactionDto>();
                cfg.CreateMap<ArticleTransactionDto, ArticleTransaction>();
                cfg.CreateMap<NewArticleTransactionDto, ArticleTransaction>();


                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<CustomerDto, Customer>();


                cfg.CreateMap<Payment, PaymentDto>();
                cfg.CreateMap<PaymentDto, Payment>();
            });

            return new Mapper(config);
        }
    }
}

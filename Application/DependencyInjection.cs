using Application.BusinessServices;
using Application.DataTransferObjects.Payment;
using Application.DataTransferObjects.Transaction;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(MapperConfig.InitializeAutomapper());

            services.AddScoped<IValidator<TransactionCreationDto>, TransactionCreationDtoValidator>();
            services.AddScoped<IValidator<PaymentCreationDto>, PaymentCreationDtoValidator>();

            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICustomerService, CustomerService>();

        }
    }
}

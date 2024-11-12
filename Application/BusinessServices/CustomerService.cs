using Application.DataTransferObjects.Customer;
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
    public class CustomerService(IMapper mapper, ICustomerRepository customerRepository) : ICustomerService
    {
        public List<CustomerDto> GetAll()
        {
            return mapper.Map<List<CustomerDto>>(customerRepository.GetAll());
        }
    }
}

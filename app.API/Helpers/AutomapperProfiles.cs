using app.API.DTOs;
using app.API.models;
using AutoMapper;

namespace app.API.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Customer, CustomerDetailDTO>();
            CreateMap<Customer, CustomerOrders>();
            CreateMap<Order, OrderDTO>();
            
        }
        
    }
}
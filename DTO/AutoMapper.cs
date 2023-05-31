using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO.Repository;
using DAL.Models;

namespace DTO
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CategoriesDTO, CategoriesTbl>();
            CreateMap<CategoriesTbl, CategoriesDTO>();

            CreateMap<ProductsDTO, ProductsTbl>();
            CreateMap<ProductsTbl, ProductsDTO>().ForMember(dest => 
            dest.CategoryName, opt =>
            opt.MapFrom(src => src.Category.CategoryName));

            CreateMap<UsersDTO, UsersTbl>();
            CreateMap<UsersTbl, UsersDTO>();

            CreateMap<OrdersDTO, OrdersTbl>();
            CreateMap<OrdersTbl, OrdersDTO>();

            CreateMap<BuyingsDetailsDTO, BuyingsDetailsTbl>();
            CreateMap<BuyingsDetailsTbl, BuyingsDetailsDTO>();
        }
    }
}

﻿using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CategoryMappingProfile:Profile
    {
        public CategoryMappingProfile()
        {
           CreateMap<Category,CreateCategoryRequest>().ReverseMap();
           CreateMap<Category,CreatedCategoryResponse>().ReverseMap();

            CreateMap<Category, GetListCategoryResponse>().ReverseMap();
            CreateMap<Paginate<Category>, Paginate<GetListCategoryResponse>>().ReverseMap();
        }
 
    }
}

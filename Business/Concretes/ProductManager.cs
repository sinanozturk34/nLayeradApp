﻿
using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        IMapper _mapper;

        public ProductManager(IProductDal productDal,IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }


        public async Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest)
        {
            Product product = _mapper.Map<Product>(createProductRequest);
            Product createdProduct = await _productDal.AddAsync(product);
            CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(createdProduct);
            return createdProductResponse;
        }

        public async Task<IPaginate<GetListProductResponse>> GetListAsync()
        {
            // return await _productDal.GetListAsync();
            var data =await _productDal.GetListAsync(
                 include: p => p.Include(p => p.Category)
                );
            var result = _mapper.Map<Paginate<GetListProductResponse>>(data); 
            return result;

        }
    }
}

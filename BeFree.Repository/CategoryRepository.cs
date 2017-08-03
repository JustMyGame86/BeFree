﻿using AutoMapper;
using BeFree.DAL.Model;
using BeFree.Model;
using BeFree.Model.Common;
using BeFree.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BeFree.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        protected IRepository Repository { get; private set; }

        public CategoryRepository(IRepository repository)
        {
            this.Repository = repository;
        }

        public Task<int> AddAsync(ICategory category)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<ICategory>> GetAsync()
        {
            //return Mapper.Map<IEnumerable<CategoryPOCO>>(await Repository.GetAsync<Category>());
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryPOCO>().ReverseMap();
            });
            return Mapper.Map<IEnumerable<CategoryPOCO>>(await Repository.GetWhere<Category>().ToListAsync());
        }

        public virtual async Task<ICategory> GetAsync(int id)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryPOCO>().ReverseMap();
                cfg.CreateMap<ICategory, CategoryPOCO>().ReverseMap();
            });
            var category = await Repository.GetWhere<Category>().Where(n => n.id == id).FirstOrDefaultAsync();
            var catpoco = Mapper.Map<CategoryPOCO>(category);
            return catpoco;
        }
    }
}

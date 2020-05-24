using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Products.WebApi.Config;
using Products.WebApi.Entities;

namespace Products.WebApi.Repository
{
    public class ProductRepository
    {
        private readonly ProductsApiDbContext _context;

        private readonly DbSet<ProductEntity> _productEntity;
        
        public ProductRepository(ProductsApiDbContext context)
        {
            _context = context;
            _productEntity = context.ProductEntitie;
        }

        public ProductEntity Create(ProductEntity productEntitie)
        {
            _productEntity.Add(productEntitie);

            try
            {
                _context.SaveChanges();
            }
            catch (DataException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return productEntitie;
        }
        
        public ProductEntity Update(ProductEntity productEntity)
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DataException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return productEntity;
        }

        public List<ProductEntity> All()
        {
            return _productEntity.ToList();
        }
        
        public ProductEntity Get(int id)
        {
            return _productEntity.Find(id);
        }
        
        public bool Delete(ProductEntity productEntitie)
        {
            _productEntity.Remove(productEntitie);

            try
            {
                _context.SaveChanges();
            }
            catch (DataException e)
            {
                Console.WriteLine(e.Message);

                return false;
            }

            return true;
        }
    }
}
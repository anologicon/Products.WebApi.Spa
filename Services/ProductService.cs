using System;
using System.Collections.Generic;
using Products.WebApi.Entities;
using Products.WebApi.Model;
using Products.WebApi.Repository;

namespace Products.WebApi.Services
{
    public class ProductService
    {
        protected readonly ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public ProductEntity NewProduct(ProductModel productModel)
        {
            ProductEntity entity = new ProductEntity
            {
                Name = productModel.Name,
                Price = productModel.Price,
                Stock = productModel.Stock
            };
            
            try
            {
                _repository.Create(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return entity;
        }
        
        public List<ProductEntity> Get()
        {
            return _repository.All();
        }

        public ProductEntity Get(int id)
        {
            return _repository.Get(id);
        }

        public ProductEntity Update(ProductEntity productEntity, ProductModel productModel)
        {
            productEntity.Name = productModel.Name;
            productEntity.Price = productModel.Price;
            productEntity.Stock = productModel.Stock;
            
            try
            {
                _repository.Update(productEntity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return productEntity;
        }

        public bool Remove(ProductEntity productEntity)
        {
            return _repository.Delete(productEntity);
        }
    }
}
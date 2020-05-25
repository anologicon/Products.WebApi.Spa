using System;
using System.Collections.Generic;
using Products.WebApi.Entities;
using Products.WebApi.Integration;
using Products.WebApi.Model;
using Products.WebApi.Repository;

namespace Products.WebApi.Services
{
    public class ProductService
    {
        protected readonly ProductRepository _repository;
        protected readonly SyncApiIntegration _integration;

        
        public ProductService(ProductRepository repository, SyncApiIntegration integration)
        {
            _repository = repository;
            _integration = integration;
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

            try
            {
                _integration.CreateProductSync(entity);
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
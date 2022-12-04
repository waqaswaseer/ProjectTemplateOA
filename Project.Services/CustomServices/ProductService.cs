using Microsoft.EntityFrameworkCore.Storage;
using Project.Domain.Models;
using Project.Repositary.IRepositary;
using Project.Services.ICustomServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.CustomServices
{
    public class ProductService : ICustomService<Product>
    {
        private readonly IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> studentRepository)
        {
            _productRepository = studentRepository;
        }
        public void Delete(Product entity)
        {
            try
            {
                if (entity != null)
                {
                    _productRepository.Delete(entity);
                    _productRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Product Get(int Id)
        {
            try
            {
                var obj = _productRepository.Get(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Product> GetAll()
        {
            try
            {
                var obj = _productRepository.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Insert(Product entity)
        {
            try
            {
                if (entity != null)
                {
                    _productRepository.Insert(entity);
                    _productRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(Product entity)
        {
            try
            {
                if (entity != null)
                {
                    _productRepository.Remove(entity);
                    _productRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Product entity)
        {
            try
            {
                if (entity != null)
                {
                    _productRepository.Update(entity);
                    _productRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        Product ICustomService<Product>.Get(int Id)
        {
            try
            {
                Product data = new Product();
                data = Get(Id);
                return data;
            }
            catch( Exception)
            {
                throw;
            }
        }

        IEnumerable<Product> ICustomService<Product>.GetAll()
        {
            try
            {
                IEnumerable<Product> data = _productRepository.GetAll();
                return data.ToList();
            }
            catch(Exception)
            {
                throw; 
            }   
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COREAPI.DATA.Domain;
using COREAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace COREAPI.Services.Imp
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void CreateProduct([FromBody] ProductModel model)
        {
            IRepository<Product> productRepository = unitOfWork.Get<Product>();
            Product product = new Product();
            product.ProductName = model.ProductName;
            product.ProductCode = model.ProductCode;
            product.ProductType = model.ProductType;
            product.SKU = model.SKU;
            product.Brand = model.Brand;
            product.Size = model.Size;
            product.Color = model.Color;
            product.Weight = model.Weight;
            product.Active = model.Active;
            product.BarCode = model.BarCode;
            product.OutofStock = model.OutofStock;
            product.MinimumStockQty = model.MinimumStockQty;
            product.ProductDescription = model.ProductDescription;
            product.ProductSummary = model.ProductSummary;
            productRepository.Add(product);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            IRepository<Product> productRepository = unitOfWork.Get<Product>();
            var product = productRepository.Query().Select(x => new
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                SKU = x.SKU,
                ProductCode = x.ProductCode,
                OutofStock = x.OutofStock,
                Status = x.Status,
                IsDeleted = x.IsDeleted
            }).ToList().Select(a => new ProductModel()
            {
                ProductID = a.ProductID,
                ProductName = a.ProductName,
                SKU = a.SKU,
                ProductCode = a.ProductCode,
                OutofStock = a.OutofStock,
                Status = a.Status,
                IsDeleted = a.IsDeleted
            });
            return product;
        }

        public ProductModel EditProducts(int id)
        {
            IRepository<Product> productRepository = unitOfWork.Get<Product>();
            var product = productRepository.One(x => x.ProductID == id);
            ProductModel model = new ProductModel();
            if (product != null)
            {
                model.ProductID = product.ProductID;
                model.ProductName = product.ProductName;
                model.ProductCode = product.ProductCode;
                model.ProductType = product.ProductType;
                model.SKU = product.SKU;
                model.Brand = product.Brand;
                model.Size = product.Size;
                model.Color = product.Color;
                model.Weight = product.Weight;
                model.Active = product.Active;
                model.BarCode = product.BarCode;
                model.OutofStock = product.OutofStock;
                model.MinimumStockQty = product.MinimumStockQty;
                model.ProductDescription = product.ProductDescription;
                model.ProductSummary = product.ProductSummary;
            }
            return model;
        }

        public void UpdateProduct([FromBody] ProductModel model)
        {
            IRepository<Product> productRepository = unitOfWork.Get<Product>();
            var product = productRepository.One(x => x.ProductID == model.ProductID);
            if(product != null)
            {
                product.ProductName = model.ProductName;
                product.ProductCode = model.ProductCode;
                product.ProductType = model.ProductType;
                product.SKU = model.SKU;
                product.Brand = model.Brand;
                product.Size = model.Size;
                product.Color = model.Color;
                product.Weight = model.Weight;
                product.Active = model.Active;
                product.BarCode = model.BarCode;
                product.OutofStock = model.OutofStock;
                product.MinimumStockQty = model.MinimumStockQty;
                product.ProductDescription = model.ProductDescription;
                product.ProductSummary = model.ProductSummary;
                unitOfWork.SaveChanges();
            }
           
        }
    }
}

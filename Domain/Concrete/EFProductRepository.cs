using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

    //    public IEnumerable<Product> Products => context.Products;

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
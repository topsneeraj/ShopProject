using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SHOP.DL;
namespace SHOP.Repo
{
   public class UnitOfWork :IUnitOfWork
    {
        private ISellerRegistration _sellerRegistraton;
        public ISellerRegistration SellerRegistration { get; private set; }
        private ShopEntity _dbcontext;
        public UnitOfWork(ShopEntity dbcontext)
        {
            _dbcontext = dbcontext;
            SellerRegistration = new SellerRegistrationRepository(_dbcontext);

        }

        public int complete()
        {
           return _dbcontext.SaveChanges();
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}

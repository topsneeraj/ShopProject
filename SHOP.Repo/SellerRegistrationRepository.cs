using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHOP.DL;
namespace SHOP.Repo
{
    public class SellerRegistrationRepository : Repository<SellerRegistration>, ISellerRegistration
    {

        public SellerRegistrationRepository(ShopEntity dbcontext) : base(dbcontext) { }

      public  IEnumerable<SellerRegistration> getTopSeller()
        {
         return   dbContex.sellerRegistrations.ToList();
        }
        public ShopEntity dbcontext
        {
            get
            {
                return dbContex;
            }
        }

    }
}

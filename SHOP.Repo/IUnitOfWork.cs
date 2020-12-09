using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHOP.DL;

namespace SHOP.Repo
{
   public interface IUnitOfWork :IDisposable
    {
        ISellerRegistration SellerRegistration { get; }
        int complete();
    }
}

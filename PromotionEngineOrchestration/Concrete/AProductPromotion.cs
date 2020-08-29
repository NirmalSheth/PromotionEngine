using PromotionEngineOrchestration.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineOrchestration.Concrete
{
  public class AProductPromotion : IPromotion
    {
        public string CurrentName => "A";
        
        public decimal GetPrice(int ProductsQuantity)
        {
            return 130 * (ProductsQuantity / 3) + 50 * (ProductsQuantity % 3);
        }
    }
}

using PromotionEngineOrchestration.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineOrchestration.Concrete
{
    public class DProductPromotion : IPromotion
    {
        public string CurrentName => "D";
      
        public decimal GetPrice(int ProductsQuantity)
        {
            return 15 * ProductsQuantity;
        }
    }
}

using PromotionEngineOrchestration.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineOrchestration.Concrete
{
    public class BProductPromotion : IPromotion
    {
        public string CurrentName => "B";      
        public decimal GetPrice(int ProductsQuantity)
        {
            return 45 * (ProductsQuantity / 2)  + 30 * (ProductsQuantity % 2 );
        }
    }
}

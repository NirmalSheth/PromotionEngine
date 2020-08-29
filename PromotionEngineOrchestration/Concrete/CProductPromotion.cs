using PromotionEngineOrchestration.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineOrchestration.Concrete
{
    public class CProductPromotion : IPromotion
    {
        public string CurrentName => "C";      
        public decimal GetPrice(int ProductsQuantity)
        {
            return 20 * ProductsQuantity;
        }
    }
}

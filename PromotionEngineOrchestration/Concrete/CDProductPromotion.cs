using PromotionEngineOrchestration.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineOrchestration.Concrete
{
    public class CDProductPromotion : IcombinePromotion
    {
        public decimal GetPrice(int CProductQuantity, int dProductQuantity)
        {
            if (CProductQuantity == dProductQuantity)
            {
                return CProductQuantity * 30;
            }
            return 0;
        }
    }
}

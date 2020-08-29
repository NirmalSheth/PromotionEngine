using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineOrchestration.Abstract
{
    public interface IPromotion
    {
        string CurrentName { get; }       
        decimal GetPrice(int ProductsQuantity);
    }
}

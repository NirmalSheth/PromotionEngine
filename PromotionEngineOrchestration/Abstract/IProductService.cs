using PromotionEngine.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineOrchestration.Abstract
{
   public interface IProductService
    {
        List<Product> PlaceProductOrder();      
        decimal GetTotalPrice(List<Product> products);
    }
}

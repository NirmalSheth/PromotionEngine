using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineOrchestration.Abstract
{
  public  interface IcombinePromotion
    {
        decimal GetPrice(int cProductQuantity, int dProductQuantity);
    }
}

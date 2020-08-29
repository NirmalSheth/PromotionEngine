using PromotionEngineOrchestration.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using PromotionEngine.Entity;
using System.Linq;

namespace PromotionEngineOrchestration.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IEnumerable<IPromotion> _promotion;
        private readonly IcombinePromotion _combinePromotion;
        public ProductService(IEnumerable<IPromotion> promotion, IcombinePromotion combinePromotion)
        {
            _promotion = promotion;
            _combinePromotion = combinePromotion;
        }
        public List<Product> PlaceProductOrder()
        {
            var products = new List<Product>();
            Console.WriteLine("total number of order");
            int totalOrder = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < totalOrder; i++)
            {
                Console.WriteLine("Enter the product name: i.e A,B,C,D");
                string productName = Console.ReadLine();
                if(!ValidateProductName(productName))
                {
                    Console.WriteLine("Not a Valid Product Name.It should be Between A to D.Please Try again");
                    productName = Console.ReadLine();
                }
                Console.WriteLine($"Enter the quantity of product:{productName}");
                string productQuantity = Console.ReadLine();
                if (!ValidateOrderIsNumeric(productQuantity))
                {
                    productQuantity = Console.ReadLine();
                }
                products.Add(new Product()
                {
                    Id = productName.ToUpper(),
                    Quantity = Convert.ToInt32(productQuantity)

                });
            }          
            return products;
        }

        public decimal GetTotalPrice(List<Product> products)
        {
            if (products?.Count == 0)
                return 0;
            var totalProductPrice = 0.0m;
            var getPtoductAPromotion = _promotion.FirstOrDefault(h => h.CurrentName == "A");
            var getProductAQuantity = products.Where(x => x.Id == "A")?.Sum(x => x.Quantity) ?? 0;

            var getPtoductBPromotion = _promotion.FirstOrDefault(h => h.CurrentName == "B");
            var getProductBQuantity = products.Where(x => x.Id == "B")?.Sum(x => x.Quantity) ?? 0;

            var getPtoductCPromotion = _promotion.FirstOrDefault(h => h.CurrentName == "C");
            var getProductCQuantity = products.Where(x => x.Id == "C")?.Sum(x => x.Quantity) ?? 0;

            var getPtoductDPromotion = _promotion.FirstOrDefault(h => h.CurrentName == "D");
            var getProductDQuantity = products.Where(x => x.Id == "D")?.Sum(x => x.Quantity) ?? 0;

            var getCombinedProductPromotion = _combinePromotion.GetPrice(getProductCQuantity, getProductDQuantity);
            if (getCombinedProductPromotion == 0)
                getCombinedProductPromotion = getPtoductCPromotion.GetPrice(getProductCQuantity) + getPtoductDPromotion.GetPrice(getProductDQuantity);
            totalProductPrice = getPtoductAPromotion.GetPrice(getProductAQuantity)
                + getPtoductBPromotion.GetPrice(getProductBQuantity)
                + getCombinedProductPromotion;

            return totalProductPrice;

        }

        private bool ValidateOrderIsNumeric(string orderCount)
        {
            int orderQuantity;
            while (!Int32.TryParse(orderCount, out orderQuantity))
            {
                Console.WriteLine("Not a valid number.It should be numeriac, try again.");
                return false;
            }
            return true;
        }
        private bool ValidateProductName(string productname)
        {
            if(productname.ToUpper() =="A" || productname.ToUpper() == "B"
                || productname.ToUpper() == "C" || productname.ToUpper() == "D")
            {
                return true;
            }
            return false;
        }
    }
}


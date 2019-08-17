using System;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Pricing.Discounts
{
    public readonly struct ProductDiscount : IEquatable<ProductDiscount>
    {
        public ProductUnit ProductUnit { get; }
        public Discount Discount { get; }

        public static ProductDiscount Of(ProductUnit productUnit, Discount discount) =>
            new ProductDiscount(productUnit, discount);
        
        private ProductDiscount(ProductUnit productUnit, Discount discount)
        {
            ProductUnit = productUnit;
            Discount = discount;
        }

        public bool Equals(ProductDiscount other) => (ProductUnit, Discount)
            .Equals((other.ProductUnit, other.Discount));
        public override bool Equals(object obj) => obj is ProductDiscount other && Equals(other);
        public override int GetHashCode() => (ProductUnit, Discount).GetHashCode();

        public override string ToString() => $"{Discount.ToString()} for {ProductUnit.ToString()}";
    }
}
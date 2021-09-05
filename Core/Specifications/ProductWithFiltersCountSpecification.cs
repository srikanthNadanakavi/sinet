using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersCountSpecification:  BaseSpecification<Product>
    {
       public ProductWithFiltersCountSpecification(ProductSpecParams  productParams): 
                 base(x =>  (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
                            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId) &&
                            ( string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)))
        { 
        }
    }
}
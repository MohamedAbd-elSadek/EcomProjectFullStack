using EcomProject.BL.DTOs.Common;
using EcomProject.BL.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.Manager.Product
{
    public interface IProductManager
    {
        Task<ProductReadDTO> GetProductById(Guid productId);
        Task<List<ProductReadDTO>> GetAllProducts();
        Task<List<ProductReadDTO>> GetAllProducts(string sort);

        Task<GeneralResult> AddProduct(ProductAddDTO productAddDTO);
        Task<GeneralResult> DeleteProduct(Guid productId);
        Task<GeneralResult> UpdateProduct(ProductUpdateDTO updateDTO);

    }
}

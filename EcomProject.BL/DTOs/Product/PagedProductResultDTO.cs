namespace EcomProject.BL.DTOs.Product
{
    public class PagedProductResultDTO
    {
        public List<ProductReadDTO> Data { get; set; }
        public int TotalCount { get; set; }
    }
} 
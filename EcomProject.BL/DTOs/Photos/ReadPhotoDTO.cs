using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.DTOs.Photos
{
    public class ReadPhotoDTO
    {
        public Guid PhotoId { get; set; }

        public string PhotoPath { get; set; } = string.Empty;

        public Guid ProductId { get; set; }
    }
}

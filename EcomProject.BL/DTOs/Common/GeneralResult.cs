using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.DTOs.Common
{
    public class GeneralResult
    {
        public bool IsValid { get; set; }

        public Results[] Errors { get; set; } = [];


    }

    public class GeneralResult<T> where T:class
    {
        public T? Data { get; set; }

    }

    public class Results
    {
        public string? Code { get; set; }
        public string? Message { get; set; }

    }


}

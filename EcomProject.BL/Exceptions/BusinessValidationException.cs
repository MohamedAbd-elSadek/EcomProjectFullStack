using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.Exceptions
{
    public class BusinessValidationException :Exception
    {
        private readonly List<ValidationFailure> errors;

        public BusinessValidationException(List<ValidationFailure> errors)
        {
            this.errors = errors;
        }

        
    }
}

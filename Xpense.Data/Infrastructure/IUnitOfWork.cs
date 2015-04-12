using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Xpense.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        ICollection<ValidationResult> Commit();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using Xpense.Data.DataContext;

namespace Xpense.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private XpenseEntities dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected XpenseEntities DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        public ICollection<ValidationResult> Commit()
        {
            var validationResults = new List<ValidationResult>();

            try
            {
                DataContext.SaveChanges();
            }
            catch (DbEntityValidationException dbe)
            {
                foreach (DbEntityValidationResult validation in dbe.EntityValidationErrors)
                {
                    IEnumerable<ValidationResult> validations = validation.ValidationErrors.Select(
                        error => new ValidationResult(
                                     error.ErrorMessage,
                                     new[]
                                         {
                                             error.PropertyName
                                         }));

                    validationResults.AddRange(validations);

                    return validationResults;
                }
            }
            return validationResults;
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }
    }
}

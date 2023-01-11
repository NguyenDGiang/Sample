using Sample.Shared.Dtos;
using Sample.Shared.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Extensions
{
    public static class ValidationExtension
    {
        public static ApiResult<T> CheckValidation<T>(this T entity)
        {
            var getProperties = typeof(T).GetProperties();
            foreach (var property in getProperties)
            {
                var value = property.GetValue(entity);
                if (property.IsDefined(typeof(ValidationAttribute), true))
                {
                    if (property.GetValue(entity) == "")
                    {
                        var displayName = ((ValidationAttribute)property.GetCustomAttributes(typeof(ValidationAttribute), true).FirstOrDefault()).Name;
                        return new ApiResult<T>(false, 400, displayName);

                    }
                }
            }
            return new ApiResult<T>(true, 400, "loi");
        }
    } 
}

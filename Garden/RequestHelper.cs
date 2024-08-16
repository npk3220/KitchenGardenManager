using System.ComponentModel.DataAnnotations;

namespace Garden
{
    public static class RequestHelper
    {
        public static bool IsValid(DTO dto)
        {
            var validationContext = new ValidationContext(dto, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            if (validationResults.Count != 0)
            {
                foreach (var item in validationResults)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }
            return Validator.TryValidateObject(dto, validationContext, validationResults, validateAllProperties: true);
        }
    }
}

/*using Garden.List;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Garden.Show
{
    public class ShowGardenService : IShowGardenService
    {
        public ShowGardenRequestDTO? GetDtoFromQuery(HttpRequest request)
        {
            GetGardensRequestDTO? result = null;

            try
            {
                var query = request.Query;

                var isManagementEnded = query.ContainsKey("isManagementEnded") ? query["isManagementEnded"].ToString() : null;
                // var registrationDateString = query.ContainsKey("registrationDate") ? query["registrationDate"].ToString() : null;

                result = new GetGardensRequestDTO
                {
                    UserName = query.ContainsKey("userName") ? query["userName"].ToString() : null,
                    GardenName = query.ContainsKey("gardenName") ? query["gardenName"].ToString() : null,
                    IsManagementEnded = (isManagementEnded is not null) ?
                        RequestHelper.StringToBool(isManagementEnded) : null,
                    *//*RegistrationDate = !string.IsNullOrEmpty(registrationDateString)
                           ? DateTime.Parse(registrationDateString)
                           : null*//*
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
*/
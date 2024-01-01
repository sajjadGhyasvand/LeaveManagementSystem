using HR_Management.MVC.Contracts;
using System.Net.Http.Headers;

namespace HR_Management.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected readonly IClient _client;
        protected readonly ILocalStorageService _localStorageService;

        public BaseHttpService(ILocalStorageService localStorageService, IClient client)
        {
            _localStorageService = localStorageService;
            _client = client;
        }
        protected Response<Guid> ConvertApiExcepion<Guid>(ApiException excepion)
        {
            if (excepion.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation Errors have occured.", ValidationErrors = excepion.Response, Success = false };
            }
            else if (excepion.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "Not Found ...", Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "Something Wrong , try again ...", Success = false };

            }
        }

        protected void AddBearerToken()
        {
            if (_localStorageService.Exsists("token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _localStorageService.GetStorageValue<string>("token"));
            }
        }
    }
}

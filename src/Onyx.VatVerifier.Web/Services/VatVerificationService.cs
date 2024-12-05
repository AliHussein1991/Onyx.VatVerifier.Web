using Onyx.VatVerifier.Web.Models;

namespace Onyx.VatVerifier.Web.Services
{
    public class VatVerificationService
    {
        private readonly HttpClient _httpClient;

        public VatVerificationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<VerificationResponse> VerifyVatIdAsync(VatVerificationRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/VatVerification", request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<VerificationResponse>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest) 
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return new VerificationResponse
                {
                    Status = "ValidationError",
                    Message = errorContent 
                };
            }
            else
            {
                return new VerificationResponse
                {
                    Status = "Error",
                    Message = "Unable to validate VAT ID."
                };
            }
        }
    }

}

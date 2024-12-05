using Onyx.VatVerifier.Web.Models;
using Onyx.VatVerifier.Web.Services;

namespace Onyx.VatVerifier.Web.Components.Pages
{
    public partial class Home
    {
        private string countryCode = string.Empty;
        private string vatId = string.Empty;
        public VatVerificationRequest vatVerificationRequest = new VatVerificationRequest();
        private VerificationResponse verificationResponse = new VerificationResponse();
        private string alertClass = "alert-info";
        private bool isLoading = false;

        private async Task HandleSubmit()
        {
            vatVerificationRequest.CountryCode = countryCode;
            vatVerificationRequest.VatId = vatId;

            isLoading = true;
            try
            {
                verificationResponse = await VatVerificationService.VerifyVatIdAsync(vatVerificationRequest);

                alertClass = verificationResponse.Status switch
                {
                    "Valid" => "alert-success",
                    "Invalid" => "alert-danger",
                    "ValidationError" => "alert-warning",
                    _ => "alert-warning"
                };
            }
            catch (Exception ex)
            {
                alertClass = "alert-danger";
            }
            finally
            {
                isLoading = false;
            }
        }
    }
}

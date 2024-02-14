using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask3
{
    public class VatVerifier
    {
        public enum VerificationStatus
        {
            Valid,
            Invalid,
            // Unable to get status (e.g. service unavailable)
            Unavailable
        }

        /// <summary>
        /// Verifies the given VAT ID for the given country using the EU VIES web service.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="vatId"></param>
        /// <returns>Verification status</returns>
        // TODO: Implement Verify method

        public async Task<VerificationStatus> GetVerificationStatus(string countryCode, string vatId)
        {
            try
            {
                using ServiceReference1.checkVatPortTypeClient client = new ServiceReference1.checkVatPortTypeClient();
                var result = await client.checkVatAsync(new ServiceReference1.checkVatRequest(countryCode, vatId));
                if (result != null && result.valid) return VerificationStatus.Valid;
                else return VerificationStatus.Invalid;
            }
            catch (Exception)
            {
                return VerificationStatus.Unavailable;
            }
        }
    }
}

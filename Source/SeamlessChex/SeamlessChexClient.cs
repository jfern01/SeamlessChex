namespace SeamlessChex
{
    using System;
    using System.Net;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading;
    using System.Threading.Tasks;
    using RestSharp;
    using RestSharp.Authenticators;
    using RestSharp.Serializers.SystemTextJson;
    using SeamlessChex.Converters;
    using SeamlessChex.Models;

    /// <summary>
    /// This is the client used to interact with the SeamlessChex API.
    /// </summary>
    public class SeamlessChexClient
    {
        /// <summary>
        /// Live API base url.
        /// </summary>
        public const string LiveBaseUrl = "https://api.seamlesschex.com/v1/";

        /// <summary>
        /// Sandbox API base url.
        /// </summary>
        public const string SandboxBaseUrl = "https://sandbox.seamlesschex.com/v1/";

        private readonly IRestClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeamlessChexClient"/> class.
        /// </summary>
        /// <param name="apiKey">API key.</param>
        /// <param name="live">API live mode.</param>
        public SeamlessChexClient(string apiKey, bool live = true)
        {
            if (apiKey == null)
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            this.client = new RestClient(live ? LiveBaseUrl : SandboxBaseUrl)
            {
                Authenticator = new JwtAuthenticator(apiKey),
                ThrowOnAnyError = true,
            };

            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                Converters =
                {
                    new DateTimeOffsetConverter(),
                    new CheckStatusConverter(),
                    new RecurringCycleConverter(),
                },
            };

            _ = this.client.UseSystemTextJson(jsonSerializerOptions);
        }

        /// <summary>
        /// Create check.
        /// </summary>
        /// <param name="checkRequest">Check object to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task{Check}"/> representing the result of the asynchronous operation.</returns>
        public async Task<Check> CreateCheckAsync(CreateCheckRequest checkRequest, CancellationToken cancellationToken = default)
        {
            var request = new RestRequest("check/create").AddJsonBody(checkRequest);

            var response = await this.client.ExecutePostAsync<CheckResponse>(request, cancellationToken)
                .ConfigureAwait(false);

            if (!response.IsSuccessful)
            {
                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    if (response.Data.Message.Equals("Fund Confirmation Limit Reached", StringComparison.Ordinal))
                    {
                        throw new FundConfirmationException();
                    }

                    // This *should* handle Basic Verification Limit Reached error
                    throw new BasicVerificationException();
                }

                throw new RequestException(response.StatusDescription);
            }

            if (response.Data.Error)
            {
                throw new RequestException(response.Data.Message);
            }

            return response.Data.Check;
        }

        /// <summary>
        /// Create check.
        /// </summary>
        /// <param name="checkRequest">Check object to create.</param>
        /// <returns>Created check.</returns>
        public Check CreateCheck(CreateCheckRequest checkRequest)
        {
            var request = new RestRequest("check/create").AddJsonBody(checkRequest);

            var response = this.client.Post<CheckResponse>(request);

            if (!response.IsSuccessful)
            {
                throw new RequestException(response.StatusDescription);
            }

            if (response.Data.Error)
            {
                throw new RequestException(response.Data.Message);
            }

            return response.Data.Check;
        }

        /// <summary>
        /// Update check.
        /// </summary>
        /// <param name="checkRequest">Check object to update.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task{Check}"/> representing the result of the asynchronous operation.</returns>
        public async Task<Check> UpdateCheckAsync(UpdateCheckRequest checkRequest, CancellationToken cancellationToken = default)
        {
            var request = new RestRequest("check/edit").AddJsonBody(checkRequest);

            var response = await this.client.ExecutePostAsync<CheckResponse>(request, cancellationToken)
                .ConfigureAwait(false);

            if (!response.IsSuccessful)
            {
                throw new RequestException(response.StatusDescription);
            }

            if (response.Data.Error)
            {
                throw new RequestException(response.Data.Message);
            }

            return response.Data.Check;
        }

        /// <summary>
        /// Update check.
        /// </summary>
        /// <param name="checkRequest">Check object to create.</param>
        /// <returns>Created check.</returns>
        public Check UpdateCheck(UpdateCheckRequest checkRequest)
        {
            var request = new RestRequest("check/edit").AddJsonBody(checkRequest);

            var response = this.client.Post<CheckResponse>(request);

            if (!response.IsSuccessful)
            {
                throw new RequestException(response.StatusDescription);
            }

            if (response.Data.Error)
            {
                throw new RequestException(response.Data.Message);
            }

            return response.Data.Check;
        }

        /// <summary>
        /// Retrive check.
        /// </summary>
        /// <param name="checkId">Unique ID for the check to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task{Check}"/> representing the result of the asynchronous operation.</returns>
        public async Task<Check> GetCheckAsync(string checkId, CancellationToken cancellationToken = default)
        {
            if (checkId == null)
            {
                throw new ArgumentNullException(nameof(checkId));
            }

            var request = new RestRequest("check/{checkId}", DataFormat.Json)
                .AddUrlSegment("checkId", checkId);

            var response = await this.client.ExecuteGetAsync<CheckResponse>(request, cancellationToken)
                .ConfigureAwait(false);

            if (!response.IsSuccessful)
            {
                throw new RequestException(response.StatusDescription);
            }

            if (response.Data.Error)
            {
                throw new RequestException(response.Data.Message);
            }

            return response.Data.Check;
        }

        /// <summary>
        /// Retrive check.
        /// </summary>
        /// <param name="checkId">Unique ID for the check to retrieve.</param>
        /// <returns>Retrieved check.</returns>
        public Check GetCheck(string checkId)
        {
            if (checkId == null)
            {
                throw new ArgumentNullException(nameof(checkId));
            }

            var request = new RestRequest("check/{checkId}", DataFormat.Json)
                .AddUrlSegment("checkId", checkId);

            var response = this.client.Get<CheckResponse>(request);

            if (!response.IsSuccessful)
            {
                throw new RequestException(response.StatusDescription);
            }

            if (response.Data.Error)
            {
                throw new RequestException(response.Data.Message);
            }

            return response.Data.Check;
        }

        /// <summary>
        /// Void check.
        /// </summary>
        /// <param name="checkId">Unique ID for the check to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<bool> VoidCheckAsync(string checkId, CancellationToken cancellationToken = default)
        {
            if (checkId == null)
            {
                throw new ArgumentNullException(nameof(checkId));
            }

            var request = new RestRequest("check/{checkId}", DataFormat.Json)
                .AddUrlSegment("checkId", checkId);

            request.Method = Method.DELETE;

            var response = await this.client.ExecuteAsync<GenericResponse>(request, cancellationToken)
                .ConfigureAwait(false);

            if (!response.IsSuccessful)
            {
                throw new RequestException(response.StatusDescription);
            }

            if (response.Data.Error)
            {
                throw new RequestException(response.Data.Message);
            }

            return response.Data.Success;
        }

        /// <summary>
        /// Void check.
        /// </summary>
        /// <param name="checkId">Unique ID for the check to retrieve.</param>
        /// <returns>Wheter request was successful.</returns>
        public bool VoidCheck(string checkId)
        {
            if (checkId == null)
            {
                throw new ArgumentNullException(nameof(checkId));
            }

            var request = new RestRequest("check/{checkId}", DataFormat.Json)
                .AddUrlSegment("checkId", checkId);

            request.Method = Method.DELETE;

            var response = this.client.Delete<GenericResponse>(request);

            if (!response.IsSuccessful)
            {
                throw new RequestException(response.StatusDescription);
            }

            if (response.Data.Error)
            {
                throw new RequestException(response.Data.Message);
            }

            return response.Data.Success;
        }

        /// <summary>
        /// Retrive checks.
        /// </summary>
        /// <param name="parameters">Collection parameters.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="Task{CheckCollection}"/> representing the result of the asynchronous operation.</returns>
        public async Task<CheckCollection> GetChecksAsync(GetChecksParameters parameters = null, CancellationToken cancellationToken = default)
        {
            if (parameters == null)
            {
                parameters = new GetChecksParameters();
            }

            var request = new RestRequest("check/list", DataFormat.Json);

            request = parameters.Apply(request);

            var response = await this.client.ExecuteGetAsync<CheckCollectionResponse>(request, cancellationToken)
                .ConfigureAwait(false);

            if (!response.IsSuccessful)
            {
                throw new RequestException(response.StatusDescription);
            }

            if (response.Data.Error)
            {
                throw new RequestException(response.Data.Message);
            }

            return response.Data.List;
        }

        /// <summary>
        /// Retrive checks.
        /// </summary>
        /// <param name="parameters">Collection parameters.</param>
        /// <returns>Retrieved checks.</returns>
        public CheckCollection GetChecks(GetChecksParameters parameters = null)
        {
            if (parameters == null)
            {
                parameters = new GetChecksParameters();
            }

            var request = new RestRequest("check/list", DataFormat.Json);

            request = parameters.Apply(request);

            var response = this.client.Get<CheckCollectionResponse>(request);

            if (!response.IsSuccessful)
            {
                throw new RequestException(response.StatusDescription);
            }

            if (response.Data.Error)
            {
                throw new RequestException(response.Data.Message);
            }

            return response.Data.List;
        }
    }
}

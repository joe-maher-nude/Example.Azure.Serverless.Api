using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Example.Azure.Serverless.Api;

public class Api
{
    [Function(nameof(SampleEndpoint))]
    public async Task<HttpResponseData> SampleEndpoint(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "sample-endpoint")]
        HttpRequestData request,
        FunctionContext _
    ) {

        var response = request.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json");
        await response.WriteStringAsync("Successfully returned from sample endpoint");
        return response;
    }
}

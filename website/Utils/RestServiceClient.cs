using dotenv.net;
using RestSharp;

namespace website.Utils;

public static class RestServiceClient
{
    public static RestClient Create()
    {
        DotEnv.Load();
        var envVars = DotEnv.Read();

        if (envVars.Count == 0)
        {
            envVars["REST_SERVICE_IP"] = System.Environment.GetEnvironmentVariable(
                "REST_SERVICE_IP"
            );
            envVars["REST_SERVICE_PORT"] = System.Environment.GetEnvironmentVariable(
                "REST_SERVICE_PORT"
            );
        }

        var restServiceIp = envVars["REST_SERVICE_IP"];
        var restServicePort = envVars["REST_SERVICE_PORT"];
        var options = new RestClientOptions($"http://{restServiceIp}:{restServicePort}");
        return new RestClient(options);
    }
}


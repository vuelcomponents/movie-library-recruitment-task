using Newtonsoft.Json;
using RestSharp;

namespace MovieLibraryServer.Infrastructure.Clients;

public abstract class BaseClient
{
    protected abstract RestClient Client { get; } 
    
    public virtual T Get<T>(string path, Action<Exception>? onException = null, CancellationToken? cancellationToken = null)
    {
        var request = new RestRequest($"{path}");

        var r = CollectRequestSensitiveData(request, path);

        var response = Client.Execute(r);

        if (response.ErrorException != null)
        {
            if (onException != null)
            {
                onException(response.ErrorException);
                return default!;
            }
            ThrowException(response.ErrorException);
        }
        var responseData = response.Content!;
        return JsonConvert.DeserializeObject<T>(responseData)!;
    }

    public virtual async Task<T> GetAsync<T>(string path, Action<Exception>? onException = null,  CancellationToken? cancellationToken = null)
    {
        var request = new RestRequest($"{path}");

        var r = CollectRequestSensitiveData(request, path);

        var response = await Client.ExecuteAsync(r);

        if (response.ErrorException != null)
        {
            if (onException != null)
            {
                onException(response.ErrorException);
                return default!;
            }
            ThrowException(response.ErrorException);
        }
        var responseData = response.Content!;
        return JsonConvert.DeserializeObject<T>(responseData)!;
    }

    public virtual async Task CallAsync(string path, Action<Exception>? onException = null,  CancellationToken? cancellationToken = null)
    {
        var request = new RestRequest($"{path}");

        var r = CollectRequestSensitiveData(request, path);

        var response = await Client.ExecuteAsync(r);

        if (response.ErrorException != null)
        {
            if (onException != null)
            {
               onException(response.ErrorException);
               return;
            }
            ThrowException(response.ErrorException);
        }
    }
    protected virtual void ThrowException(Exception e)
    {
        Console.WriteLine(e.Message);
        throw e;
    }

    protected virtual RestRequest CollectRequestSensitiveData(RestRequest request, string? cookiePath = null)
    {
        return request;
    }
}
using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using GrpcClientSamples.Console.Interceptors;
using GrpcSamples.Web.Protos.v1;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static GrpcSamples.Web.Protos.v1.PersonService;

namespace GrpcClientSamples.Console;
public class GrpcCaller
{
    private readonly PersonServiceClient _personServiceClient;
    public GrpcCaller(ILoggerFactory factory)
    {

        var handler = new SocketsHttpHandler
        {
            KeepAlivePingDelay = TimeSpan.FromSeconds(20),
            PooledConnectionIdleTimeout = TimeSpan.FromMinutes(10),
            KeepAlivePingTimeout = TimeSpan.FromSeconds(10),
            EnableMultipleHttp2Connections = true
        };
        var channel = GrpcChannel.ForAddress("https://localhost:7151", new GrpcChannelOptions
        {
            LoggerFactory = factory,
            MaxReceiveMessageSize= 5_242_880,
            MaxSendMessageSize = 5_242_880,
            HttpHandler = handler,
           
        });
        _personServiceClient = new(channel.Intercept(new TraceInterceptor()));
    }

    public async Task ServerStreaming()
    {
        using var serverStreamingCall = _personServiceClient.GetAll(new Google.Protobuf.WellKnownTypes.Empty());
        await foreach (var item in serverStreamingCall.ResponseStream.ReadAllAsync())
        {
            System.Console.WriteLine($"{item.ID}\t {item.FirstName}\t{item.LastName}");
        }
        var trailers = serverStreamingCall.GetTrailers();
        var header = await serverStreamingCall.ResponseHeadersAsync;
        System.Console.ReadLine();
    }

    public async Task ClientStreaming()
    {
        using var clientStreamingCall = _personServiceClient.DeletePerson();
        List<PersonByIdRequest> peopleForDelete = new()
        {
            new PersonByIdRequest{ID = 1},
            new PersonByIdRequest{ID = 2},
        };
        foreach (var item in peopleForDelete)
        {
            await clientStreamingCall.RequestStream.WriteAsync(item);
            System.Console.WriteLine($"Request for delete person {item.ID} sent");
        }

        await clientStreamingCall.RequestStream.CompleteAsync();

        var response = await clientStreamingCall.ResponseAsync;

    }

    public async Task BidirectionalStreaming()
    {
        using var biDirectionalCall = _personServiceClient.CreatePerson();

        List<CreatePersonRequest> personRequests = new()
        {
            new CreatePersonRequest
            {
                FirstName = "Masoud",
                LastName = "Ramezani"
            },
            new CreatePersonRequest
            {
                FirstName = "Ali",
                LastName = "Hosseini"
            }
        };

        foreach (var item in personRequests)
        {
            await biDirectionalCall.RequestStream.WriteAsync(item);
            System.Console.WriteLine($"Request sent for {item.FirstName} {item.LastName}");
        }
        await biDirectionalCall.RequestStream.CompleteAsync();

        await foreach (var item in biDirectionalCall.ResponseStream.ReadAllAsync())
        {
            System.Console.WriteLine($"***** {item.ID}\t{item.FirstName}\t{item.LastName}");
        }

        var header = await biDirectionalCall.ResponseHeadersAsync;
        var trailers = biDirectionalCall.GetTrailers();
        System.Console.ReadLine();
    }

    public async Task Unary()
    {
        try
        {
            var unaryCall = _personServiceClient.GetPersonByIdAsync(new PersonByIdRequest
            {
                ID = 1
            }, deadline: DateTime.UtcNow.AddSeconds(10));
            var personReply = await unaryCall.ResponseAsync;
            System.Console.WriteLine($"{personReply.ID}\t {personReply.FirstName}\t{personReply.LastName}\t");
            System.Console.ReadLine();
        }
        catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded)
        {
            System.Console.WriteLine("Deadline");            
            throw;
        }
        catch (RpcException ex)
        {
            System.Console.WriteLine($"other ex: {ex.Message}");

        }


    }
}

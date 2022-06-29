using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ProtobufsSamples;

namespace ProtobufsSamples.Services;
public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        HelloReply hr = new HelloReply();

        request.MyAnyType = Any.Pack(hr);


        foreach (var item in request.Age)
        {
            Console.WriteLine(item);
        }
        if(request.IsRequiered)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name,
                Lenght = 100
            });;
        }
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name,
            Lenght = 200
        });
    }
}

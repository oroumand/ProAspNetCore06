using Grpc.Core;
using Grpc.Core.Interceptors;

namespace StudentsService.Grpc.Interceptors;

public class ExceptionInterceptor : Interceptor
{
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(request, context);
        }
        catch (Exception ex)
        {
            var correlationId = Guid.NewGuid().ToString();
            Metadata trailers = new Metadata();
            trailers.Add("CorrelationId", correlationId);
            trailers.Add("Interceptor", "True");
            throw new RpcException(new Status(StatusCode.Internal, ex.Message), trailers, "Serverside Excetption Message");
        }
    }
    public override async Task<TResponse> ClientStreamingServerHandler<TRequest, TResponse>(IAsyncStreamReader<TRequest> requestStream, ServerCallContext context, ClientStreamingServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(requestStream, context);
        }
        catch (Exception ex)
        {
            var correlationId = Guid.NewGuid().ToString();
            Metadata trailers = new Metadata();
            trailers.Add("CorrelationId", correlationId);
            trailers.Add("Interceptor", "True");
            throw new RpcException(new Status(StatusCode.Internal, ex.Message), trailers, "Serverside Excetption Message");
        }
    }
    public override async Task ServerStreamingServerHandler<TRequest, TResponse>(TRequest request, IServerStreamWriter<TResponse> responseStream, ServerCallContext context, ServerStreamingServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            await continuation(request, responseStream, context);
        }
        catch (Exception ex)
        {
            ExceptionHandle(ex);

        }
    }
    public override async Task DuplexStreamingServerHandler<TRequest, TResponse>(IAsyncStreamReader<TRequest> requestStream, IServerStreamWriter<TResponse> responseStream, ServerCallContext context, DuplexStreamingServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            await continuation(requestStream, responseStream, context);
        }
        catch (Exception ex)
        {
            ExceptionHandle(ex);
        }
    }

    private static void ExceptionHandle(Exception ex)
    {
        var correlationId = Guid.NewGuid().ToString();
        Metadata trailers = new Metadata();
        trailers.Add("CorrelationId", correlationId);
        trailers.Add("Interceptor", "True");
        throw new RpcException(new Status(StatusCode.Internal, ex.Message), trailers, "Serverside Excetption Message");
    }
}

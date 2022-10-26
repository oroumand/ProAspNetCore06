using Grpc.Core;
using Grpc.Core.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClientSamples.Console.Interceptors;

public class TraceInterceptor : Interceptor
{
    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context, AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {

        System.Console.WriteLine($"Start at {DateTime.Now}");
        return continuation(request, context);

    }
}
public class ExceptionHandelingInterceptor : Interceptor
{
    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context, AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        try
        {
            return continuation(request, context);

        }
        catch (RpcException ex) when (ex.StatusCode == StatusCode.DeadlineExceeded)
        {
            System.Console.WriteLine("Deadline");
            throw;
        }
        catch (RpcException ex)
        {
            System.Console.WriteLine($"other ex: {ex.Message}");
            throw;

        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"other ex: {ex.Message}");
            throw;
        }
    }
}

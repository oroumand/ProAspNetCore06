using Grpc.Core;
using Grpc.Net.Client;
using GrpcClientSamples.Console;
using Microsoft.Extensions.Logging;
using static GrpcSamples.Web.Protos.v1.PersonService;
var loggerFactory = LoggerFactory.Create(c =>
{
    c.AddConsole();
    c.SetMinimumLevel(LogLevel.Trace);
});


var caller = new GrpcCaller(loggerFactory);

await caller.Unary();

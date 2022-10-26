using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcSamples.Web.Protos.v1;
using static GrpcSamples.Web.Protos.v1.PersonService;

namespace GrpcSamples.Web.Services.v1;

public class PersonGrpcService : PersonServiceBase
{
    private List<PersonReply> _people = new List<PersonReply>
    {
        new PersonReply
        {
            ID = 1,
            FirstName = "Alireza",
            LastName = "Oroumand"
        },
        new PersonReply
        {
            ID = 2,
            FirstName = "OmidAli",
            LastName = "Ghorbani"
        },
                new PersonReply
        {
            ID = 3,
            FirstName = "Farid",
            LastName = "Taheri"
        },
        new PersonReply
        {
            ID = 4,
            FirstName = "Hamid",
            LastName = "Saberi"
        },
    };

    public override async Task CreatePerson(IAsyncStreamReader<CreatePersonRequest> requestStream, IServerStreamWriter<PersonReply> responseStream, ServerCallContext context)
    {
        int id = _people.Count();
        await foreach (var person in requestStream.ReadAllAsync())
        {
            PersonReply personReply = new PersonReply
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                ID = ++id
            };
            _people.Add(personReply);
            await responseStream.WriteAsync(personReply);
        }
    }

    public override async Task<Empty> UpdatePerson(UpdatePersonRequest request, ServerCallContext context)
    {
        var personForUpdate = _people.Where(c => c.ID == request.ID).FirstOrDefault();
        personForUpdate.FirstName = request.FirstName;
        personForUpdate.LastName = request.LastName;
        return new Empty();
    }

    public override async Task<Empty> DeletePerson(IAsyncStreamReader<PersonByIdRequest> requestStream, ServerCallContext context)
    {
        await foreach (var person in requestStream.ReadAllAsync())
        {
            var personForDelete = _people.Where(c => c.ID == person.ID).FirstOrDefault();
            if (personForDelete != null)
            {
                _people.Remove(personForDelete);
            }

        }
        return new Empty();
    }
    public override async Task GetAll(Empty request, IServerStreamWriter<PersonReply> responseStream, ServerCallContext context)
    {
        foreach (var item in _people)
        {
            await responseStream.WriteAsync(item);
        }
    }

    public override async Task<PersonReply> GetPersonById(PersonByIdRequest request, ServerCallContext context)
    {
        var personForResponse = _people.Where(c => c.ID == request.ID).FirstOrDefault();

        if (personForResponse != null)
            return personForResponse;
        throw new RpcException(new Status(StatusCode.NotFound, $"Person with ID {request.ID} Not Found"), "Person Not Found Servier Layer");

    }
}

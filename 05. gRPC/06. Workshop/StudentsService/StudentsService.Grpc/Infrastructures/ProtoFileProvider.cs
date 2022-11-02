namespace StudentsService.Grpc.Infrastructures;

public class ProtoFileProvider
{
    private readonly string _contentRootPath;
    public ProtoFileProvider(IWebHostEnvironment webHostEnvironment)
    {
        _contentRootPath = webHostEnvironment.ContentRootPath;
    }


    public Dictionary<string, IEnumerable<string>> GetAll()
    {
        return Directory.GetDirectories($"{_contentRootPath}/Protos").
            Select(c => new
            {
                version = c,
                protos = Directory.GetFiles(c).Select(Path.GetFileName)
            }).ToDictionary(c => Path.GetRelativePath("protos", c.version), c => c.protos);
    }

    public async Task<string> GetContent(int version, string protoName)
    {
        var filePath = $"{_contentRootPath}/Protos/v{version}/{protoName}";
        var exists = File.Exists(filePath);
        return exists ? await File.ReadAllTextAsync(filePath) : string.Empty;
    }

    public string GetPath(int version, string protoName)
    {
        var filePath = $"{_contentRootPath}/Protos/v{version}/{protoName}";
        var exists = File.Exists(filePath);

        return exists ? filePath : string.Empty;

    }
}

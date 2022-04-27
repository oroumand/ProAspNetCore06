using CourseStore.BLL.Framework;
using CourseStore.DAL.Contexts;
using CourseStore.Model.Tags.Dtos;
using CourseStore.Model.Tags.Queries;
using CourseStore.DAL.Tags;
namespace CourseStore.BLL.Tags.Queries;

public class FilterByNameHandler : BaseApplicationServiceHandler<FilterByName, List<TagQr>>
{
    public FilterByNameHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
    {
    }

    protected override async Task HandleRequest(FilterByName request, CancellationToken cancellationToken)
    {
        var result = await _courseStoreDbContext.Tags.WhereOver(request.TagName).ToTagQrAsync();
        AddRsult(result);
    }
}
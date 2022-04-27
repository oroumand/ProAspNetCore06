using CourseStore.BLL.Framework;
using CourseStore.DAL.Contexts;
using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Entities;

namespace CourseStore.BLL.Tags.Commands;

public class CreateTagHandler : BaseApplicationServiceHandler<CreateTag, Tag>
{
    public CreateTagHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
    {
    }

    protected override async Task HandleRequest(CreateTag request, CancellationToken cancellationToken)
    {
        Tag tag = new()
        {
            TagName = request.TagName
        };
        await _courseStoreDbContext.Tags.AddAsync(tag);
        await _courseStoreDbContext.SaveChangesAsync();
        AddRsult(tag);
    }
}




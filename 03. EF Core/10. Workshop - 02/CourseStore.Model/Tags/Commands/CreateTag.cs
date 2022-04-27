using CourseStore.Model.Framework;
using CourseStore.Model.Tags.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CourseStore.Model.Tags.Commands;

public class CreateTag : IRequest<ApplicationServiceResponse<Tag>>
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string TagName { get; set; }
}

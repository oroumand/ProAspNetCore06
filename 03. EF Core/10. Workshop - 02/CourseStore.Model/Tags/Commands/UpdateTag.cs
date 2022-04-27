using CourseStore.Model.Framework;
using CourseStore.Model.Tags.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CourseStore.Model.Tags.Commands;

public class UpdateTag : IRequest<ApplicationServiceResponse<Tag>>
{
    [Required]
    [Range(1,int.MaxValue)]
    public int Id { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string TagName { get; set; }
}
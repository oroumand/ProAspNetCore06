using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSamples.TagHelpers;

[HtmlTargetElement("Authorize")]
public class AuthorizeTagHelper : TagHelper
{
    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext Context { get; set; }
    public string ValidRole { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (!Context.HttpContext.User.IsInRole("ValidRole"))
            output.SuppressOutput();
    }
}
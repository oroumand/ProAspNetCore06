using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSamples.TagHelpers;

[HtmlTargetElement("ViewContextData")]
public class ViewContextDataTagHelper:TagHelper
{
    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext Context { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        string content = Context.ActionDescriptor.DisplayName;

        output.TagName = "H1";
        output.Content.Append(content);
    }
}

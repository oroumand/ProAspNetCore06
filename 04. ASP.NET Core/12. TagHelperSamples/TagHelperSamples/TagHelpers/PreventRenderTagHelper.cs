using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSamples.TagHelpers;
[HtmlTargetElement("PreventRender")]
public class PreventRenderTagHelper : TagHelper
{
    public bool AllowRender { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (!AllowRender)
            output.SuppressOutput();
    }
}

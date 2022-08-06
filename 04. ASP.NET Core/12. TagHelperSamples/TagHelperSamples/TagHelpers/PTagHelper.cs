using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSamples.TagHelpers;

//[HtmlTargetElement("p",Attributes = "aro-text-bg-color")]
[HtmlTargetElement("p", Attributes = "aro-text-bg-color")]
[HtmlTargetElement("span", Attributes = "aro-text-bg-color")]
//[HtmlTargetElement("*", Attributes = "aro-text-bg-color")]
public class PTagHelper:TagHelper
{
    public string AroTextBgColor { get; set; } = "text-bg-primary";
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.Attributes.Add("class",AroTextBgColor);
    }
    
}

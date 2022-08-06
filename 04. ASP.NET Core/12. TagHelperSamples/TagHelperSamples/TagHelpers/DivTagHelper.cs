using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSamples.TagHelpers;

public class DivTagHelper:TagHelper
{
    public string AroAlertColor { get; set; } = "danger";
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.Attributes.Add("class", $"alert alert-{AroAlertColor}");
        output.PreElement.Append("Text Before Danger Alert");
        output.PostElement.Append("Text After Danger Alert");

        output.PreContent.Append("Text Before Danger Content Alert");
        output.PostContent.Append("Text After Danger Content Alert");
    }
}

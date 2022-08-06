using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSamples.TagHelpers;

[HtmlTargetElement("Alert")]
public class AlertTagHelper:TagHelper
{
    public string AroAllertHeaderText { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.Add("class", "alert alert-success");
        output.Attributes.Add("role", "alert");
        TagBuilder h4 = new TagBuilder("h5");
        h4.InnerHtml.Append(AroAllertHeaderText);
        output.PreContent.AppendHtml(h4);

        TagBuilder hr = new TagBuilder("hr");
        output.PreContent.AppendHtml(hr);
    }
}

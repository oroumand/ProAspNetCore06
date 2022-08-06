using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSamples.TagHelpers;

public class TableTagHelper:TagHelper
{
    public string AroBgColor { get; set; } = "info";
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.Attributes.Add("class", $"table table-bordered table-striped table-{AroBgColor}");

    }
}

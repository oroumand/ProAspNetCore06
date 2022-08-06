using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSamples.TagHelpers;

public class TdTagHelper:TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var text = context.Items["CellText"].ToString();

        output.Content.Append(text);
    }
}

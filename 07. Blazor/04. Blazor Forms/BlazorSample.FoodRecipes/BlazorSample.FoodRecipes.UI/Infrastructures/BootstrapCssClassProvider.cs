using Microsoft.AspNetCore.Components.Forms;

namespace BlazorSample.FoodRecipes.UI.Infrastructures;

public class BootstrapCssClassProvider:FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
    {
        var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

        if(editContext.IsModified(fieldIdentifier))
        {
            return isValid ? "is-valid" : "is-invalid";
        }
        return isValid ? "" : "is-invalid";
    }
}

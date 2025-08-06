using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.Syncfusion.JsonForms.Components;

namespace Orbyss.Blazor.Syncfusion.JsonForms.ComponentInstances
{
    public class SyncfusionDropdownInstance : DropdownFormComponentInstance<SyncfusionDropdown>
    {
        public string? Width { get; set; }

        protected override IDictionary<string, object?> GetDropdownParameters()
        {
            return new Dictionary<string, object?>
            {
                [nameof(Width)] = Width
            };
        }
    }
}
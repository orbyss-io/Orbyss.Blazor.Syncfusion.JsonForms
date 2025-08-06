using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.Syncfusion.JsonForms.Components;

namespace Orbyss.Blazor.Syncfusion.JsonForms.ComponentInstances
{
    public class SyncfusionDropdownMultiSelectInstance : DropdownFormComponentInstance<SyncfusionDropdownMultiSelect>
    {
        public string? Width { get; set; }

        public MultiSelectOptions MultiSelectOptions { get; set; } = new();

        protected override IDictionary<string, object?> GetDropdownParameters()
        {
            return new Dictionary<string, object?>
            {
                [nameof(Width)] = Width,
                [nameof(MultiSelectOptions)] = MultiSelectOptions
            };
        }
    }
}
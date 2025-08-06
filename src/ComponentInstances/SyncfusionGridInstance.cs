using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.Syncfusion.JsonForms.Components;

namespace Orbyss.Blazor.Syncfusion.JsonForms.ComponentInstances
{
    public sealed class SyncfusionGridInstance : FormComponentInstance<SyncfusionGrid>
    {
        public string? MinimumHeight { get; set; }

        public string? MaximumHeight { get; set; }

        protected override IDictionary<string, object?> GetParametersCore()
        {
            return new Dictionary<string, object?>
            {
                [nameof(SyncfusionGrid.MaximumHeight)] = MaximumHeight,
                [nameof(SyncfusionGrid.MaximumHeight)] = MinimumHeight
            };
        }
    }
}
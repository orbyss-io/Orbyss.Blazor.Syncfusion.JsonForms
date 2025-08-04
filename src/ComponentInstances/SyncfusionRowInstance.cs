using Orbyss.Components.JsonForms.ComponentInstances;
using Orbyss.Blazor.Syncfusion.JsonForms.Components;

namespace Orbyss.Blazor.Syncfusion.JsonForms.ComponentInstances
{
    public sealed class SyncfusionRowInstance : FormComponentInstance<SyncfusionRow>
    {
        public bool WrapChildContentInColumn { get; set; }

        protected override IDictionary<string, object?> GetParametersCore()
        {
            return new Dictionary<string, object?>
            {
                [nameof(WrapChildContentInColumn)] = WrapChildContentInColumn
            };
        }
    }
}

using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.Syncfusion.JsonForms.Components;

namespace Orbyss.Blazor.Syncfusion.JsonForms.ComponentInstances
{
    public sealed class SyncfusionIntegerInputInstance : InputFormComponentInstance<SyncfusionIntegerInput>
    {
        public SyncfusionIntegerInputInstance() : base(t => (int?)t)
        {
        }

        public string? Width { get; set; }

        public bool Clearable { get; set; }

        protected override IDictionary<string, object?> GetFormInputParameters()
        {
            return new Dictionary<string, object?>
            {
                [nameof(SyncfusionTextInput.Width)] = Width,
                [nameof(SyncfusionTextInput.Clearable)] = Clearable
            };
        }
    }
}
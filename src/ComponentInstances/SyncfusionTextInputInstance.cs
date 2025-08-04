using Orbyss.Components.JsonForms.ComponentInstances;
using Orbyss.Blazor.Syncfusion.JsonForms.Components;
using Syncfusion.Blazor.Inputs;


namespace Orbyss.Blazor.Syncfusion.JsonForms.ComponentInstances
{
    public sealed class SyncfusionTextInputInstance : InputFormComponentInstance<SyncfusionTextInput>
    {
        public SyncfusionTextInputInstance() : base(t => t?.ToString())
        {
        }

        public string? Width { get; set; }

        public InputType InputType { get; set; } = InputType.Text;

        public bool Clearable { get; set; }

        protected override IDictionary<string, object?> GetFormInputParameters()
        {
            return new Dictionary<string, object?>
            {
                [nameof(SyncfusionTextInput.InputType)] = InputType,
                [nameof(SyncfusionTextInput.Width)] = Width,
                [nameof(SyncfusionTextInput.Clearable)] = Clearable
            };
        }
    }
}

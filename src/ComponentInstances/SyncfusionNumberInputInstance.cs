using Newtonsoft.Json.Linq;
using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.Syncfusion.JsonForms.Components;

namespace Orbyss.Blazor.Syncfusion.JsonForms.ComponentInstances
{
    public sealed class SyncfusionNumberInputInstance : InputFormComponentInstanceBase
    {
        public string? Width { get; set; }

        public bool Clearable { get; set; }

        public override Type ComponentType => typeof(SyncfusionNumberInput);

        protected override object? ConvertValue(JToken? value)
        {
            if (double.TryParse($"{value}", Culture, out var doubleValue))
            {
                return doubleValue;
            }

            return null;
        }

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
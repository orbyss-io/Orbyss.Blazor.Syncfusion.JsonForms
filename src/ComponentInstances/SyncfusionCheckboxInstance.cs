using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.Syncfusion.JsonForms.Components;
using Syncfusion.Blazor.Buttons;

namespace Orbyss.Blazor.Syncfusion.JsonForms.ComponentInstances
{
    public class SyncfusionCheckboxInstance : InputFormComponentInstance<SyncfusionCheckbox>
    {
        public SyncfusionCheckboxInstance() : base(t => (bool?)t)
        {
        }

        public bool Clearable { get; set; }

        public LabelPosition LabelPosition { get; set; }

        protected override IDictionary<string, object?> GetFormInputParameters()
        {
            return new Dictionary<string, object?>
            {
                [nameof(SyncfusionCheckbox.Clearable)] = Clearable,
                [nameof(SyncfusionCheckbox.LabelPosition)] = LabelPosition
            };
        }
    }
}
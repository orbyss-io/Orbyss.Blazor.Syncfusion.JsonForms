using Orbyss.Components.JsonForms.ComponentInstances;
using Orbyss.Blazor.Syncfusion.JsonForms.Components;
using Syncfusion.Blazor.Buttons;

namespace Orbyss.Blazor.Syncfusion.JsonForms.ComponentInstances
{
    public class SyncfusionButtonInstance : ButtonFormComponentInstance<SyncfusionButton>
    {
        public SyncfusionButtonInstance(IDictionary<string, string> textTranslations) : base(textTranslations)
        {
        }

        public SyncfusionButtonInstance(string text) : base(text)
        {
        }

        public string IconClass { get; set; } = string.Empty;

        public IconPosition IconPosition { get; set; }

        public bool CanToggle { get; set; }

        protected override IDictionary<string, object?> GetButtonParameters()
        {
            return new Dictionary<string, object?>
            {                
                [nameof(SyncfusionButton.IconClass)] = IconClass,
                [nameof(SyncfusionButton.IconPosition)] = IconPosition,
                [nameof(SyncfusionButton.CanToggle)] = CanToggle
            };
        }
    }
}

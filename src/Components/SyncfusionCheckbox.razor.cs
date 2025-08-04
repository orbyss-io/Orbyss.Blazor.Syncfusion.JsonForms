using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Buttons;

namespace Orbyss.Blazor.Syncfusion.JsonForms.Components
{
    public partial class SyncfusionCheckbox
    {
        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public bool Clearable { get; set; }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public bool Value { get; set; }

        [Parameter]
        public string? HelperText { get; set; }

        [Parameter]
        public LabelPosition LabelPosition { get; set; }

        [Parameter]
        public EventCallback<bool> OnValueChanged { get; set; }
    }
}

using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Inputs;

namespace Orbyss.Blazor.Syncfusion.JsonForms.Components
{
    public partial class SyncfusionTextInput
    {
        private readonly string id = $"{Guid.NewGuid()}";

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public bool Clearable { get; set; }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public string? Value { get; set; }

        [Parameter]
        public string? HelperText { get; set; }

        [Parameter]
        public EventCallback<string> OnValueChanged { get; set; }

        [Parameter]
        public string? Width { get; set; }

        [Parameter]
        public InputType InputType { get; set; } = InputType.Text;
    }
}

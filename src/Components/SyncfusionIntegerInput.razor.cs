using Microsoft.AspNetCore.Components;

namespace Orbyss.Blazor.Syncfusion.JsonForms.Components
{
    public partial class SyncfusionIntegerInput
    {
        private readonly string id = $"{Guid.NewGuid()}";

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public int? Value { get; set; }

        [Parameter]
        public bool Clearable { get; set; }

        [Parameter]
        public string? HelperText { get; set; }

        [Parameter]
        public EventCallback<int?> ValueChanged { get; set; }

        [Parameter]
        public string? Width { get; set; }
    }
}

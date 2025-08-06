using Microsoft.AspNetCore.Components;

namespace Orbyss.Blazor.Syncfusion.JsonForms.Components
{
    public partial class SyncfusionSwitch
    {
        private readonly string id = $"{Guid.NewGuid()}";
        private bool HasError => !string.IsNullOrWhiteSpace(ErrorHelperText);
        private Dictionary<string, object> htmlAttributes = [];

        [Parameter]
        public bool Value { get; set; }

        [Parameter]
        public string? Class { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public string? LabelInlineStyle { get; set; }

        [Parameter]
        public string? ErrorHelperText { get; set; }

        [Parameter]
        public string? HelperText { get; set; }

        [Parameter]
        public string? OnLabel { get; set; }

        [Parameter]
        public string? OffLabel { get; set; }

        [Parameter]
        public EventCallback<bool> OnValueChanged { get; set; }

        protected override void OnParametersSet()
        {
            htmlAttributes = new Dictionary<string, object>
            {
                ["id"] = id
            };

            base.OnParametersSet();
        }
    }
}
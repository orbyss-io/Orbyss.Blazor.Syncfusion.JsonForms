using Microsoft.AspNetCore.Components;
using Orbyss.Components.Json.Models;

namespace Orbyss.Blazor.Syncfusion.JsonForms.Components
{
    public partial class SyncfusionDropdown
    {
        private readonly string id = $"{Guid.NewGuid()}";

        protected override void OnInitialized()
        {
            var hasDelegate = OnValueChanged.HasDelegate;
            if (Items?.All(x => string.IsNullOrWhiteSpace(x.Value) && string.IsNullOrWhiteSpace(x.Label)) == true)
            {
                HelperText = "There are no items to select for this dropdown";
                Disabled = true;
            }
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (Items?.All(x => string.IsNullOrWhiteSpace(x.Value) && string.IsNullOrWhiteSpace(x.Label)) == true)
            {
                HelperText = "There are no items to select for this dropdown";
                Disabled = true;
            }
        }

        private async Task ChangeValue(string selectedValue)
        {
            Value = selectedValue;

            await OnValueChanged.InvokeAsync(Value);
        }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public string? HelperText { get; set; }

        [Parameter]
        public string? Value { get; set; }

        [Parameter]
        public string? Width { get; set; }

        [Parameter]
        public bool Searchable { get; set; }

        [Parameter]
        public bool Clearable { get; set; }

        [Parameter]
        public MultiSelectOptions? MultiSelectOptions { get; set; }

        [Parameter]
        public IEnumerable<TranslatedEnumItem> Items { get; set; } = Array.Empty<TranslatedEnumItem>();

        [Parameter]
        public EventCallback<string> OnValueChanged { get; set; }

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public bool Disabled { get; set; }
    }
}
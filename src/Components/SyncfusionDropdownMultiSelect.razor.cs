using Microsoft.AspNetCore.Components;
using Orbyss.Components.Json.Models;

namespace Orbyss.Blazor.Syncfusion.JsonForms.Components
{
    public partial class SyncfusionDropdownMultiSelect
    {
        private readonly string id = $"{Guid.NewGuid()}";
        private readonly object valuesLock = new();
        private readonly List<string> values = [];

        protected override void OnInitialized()
        {
            if (Value is not null && Value.Any())
            {
                values.AddRange(Value);
            }

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

        private Task ChangeSelectedValues(List<string> selectedValues)
        {
            lock (valuesLock)
            {
                values.Clear();
                values.AddRange(selectedValues);
                return OnValueChanged.InvokeAsync(selectedValues);
            }
        }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public string? HelperText { get; set; }

        [Parameter]
        public IEnumerable<string>? Value { get; set; }

        [Parameter]
        public string? Width { get; set; }

        [Parameter]
        public bool Searchable { get; set; }

        [Parameter]
        public bool Clearable { get; set; }

        [Parameter]
        public MultiSelectOptions MultiSelectOptions { get; set; } = new();

        [Parameter]
        public IEnumerable<TranslatedEnumItem> Items { get; set; } = [];

        [Parameter]
        public EventCallback<IEnumerable<string>> OnValueChanged { get; set; }

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public bool Disabled { get; set; }
    }
}
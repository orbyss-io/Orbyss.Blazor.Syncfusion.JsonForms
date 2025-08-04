using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbyss.Blazor.Syncfusion.JsonForms.Components
{
    public partial class SyncfusionNumberInput
    {
        private readonly string id = $"{Guid.NewGuid()}";

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public string? Value { get; set; }

        [Parameter]
        public CultureInfo? Culture { get; set; }

        [Parameter]
        public bool Clearable { get; set; }

        [Parameter]
        public string? HelperText { get; set; }

        [Parameter]
        public EventCallback<double?> OnValueChanged { get; set; }

        [Parameter]
        public string? Width { get; set; }

        private Task ValueChangedHandler(string? value)
        {
            if (double.TryParse(value, Culture, out var doubleValue))
            {
                return OnValueChanged.InvokeAsync(doubleValue);
            }

            return OnValueChanged.InvokeAsync(null);
        }
    }
}

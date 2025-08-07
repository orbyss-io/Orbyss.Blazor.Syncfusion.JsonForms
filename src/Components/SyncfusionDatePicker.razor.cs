using Microsoft.AspNetCore.Components;

namespace Orbyss.Blazor.Syncfusion.JsonForms.Components
{
    public partial class SyncfusionDatePicker<TDate>
    {
        private readonly string id = $"{Guid.NewGuid()}";
        private DateTime? value;

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public bool AllowManualInput { get; set; }

        [Parameter]
        public TDate Value { get; set; } = default!;

        [Parameter]
        public DateTime? MinimumDate { get; set; }

        [Parameter]
        public DateTime? MaximumDate { get; set; }

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string? HelperText { get; set; }

        [Parameter]
        public EventCallback<TDate> OnValueChanged { get; set; }

        [Parameter]
        public Func<DateTime?, TDate>? ConvertFromDateTime { get; set; }

        [Parameter]
        public Func<TDate, DateTime?>? ConvertToDateTime { get; set; }

        private Task OnChanged(DateTime? value)
        {
            if (this.value.HasValue)
            {
                this.value = value;
            }

            if (!value.HasValue || ConvertToDateTime is null)
            {
                return OnValueChanged.InvokeAsync(default);
            }

            if (ConvertFromDateTime is not null)
            {
                return OnValueChanged.InvokeAsync(
                    ConvertFromDateTime.Invoke(value)
                );
            }

            return Task.CompletedTask;
        }

        protected override void OnParametersSet()
        {
            if (ConvertToDateTime is null)
            {
                value = null;
            }
            else
            {
                value = ConvertToDateTime(Value);
            }

            base.OnParametersSet();
        }
    }
}
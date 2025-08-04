using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Buttons;

namespace Orbyss.Blazor.Syncfusion.JsonForms.Components
{
    public partial class SyncfusionButton
    {
        [Parameter]
        public string Text { get; set; } = string.Empty;

        [Parameter]
        public string Class { get; set; } = string.Empty;

        [Parameter]
        public string IconClass { get; set; } = string.Empty;

        [Parameter]
        public string Style { get; set; } = string.Empty;

        [Parameter]
        public IconPosition IconPosition { get; set; }

        [Parameter]
        public bool CanToggle { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public EventCallback OnClicked { get; set; }

        readonly Dictionary<string, object> customAttributes = [];

        protected override void OnInitialized()
        {
            if (!string.IsNullOrWhiteSpace(IconClass) && Class?.Contains("e-icon-btn") != true)
            {
                Class = $"e-icon-btn {Class}".TrimEnd(' ');
            }

            if (!string.IsNullOrWhiteSpace(Style))
            {
                customAttributes.Add("style", Style);
            }

            base.OnInitialized();
        }
    }
}

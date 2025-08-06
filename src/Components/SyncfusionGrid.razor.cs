using Microsoft.AspNetCore.Components;

namespace Orbyss.Blazor.Syncfusion.JsonForms.Components
{
    public partial class SyncfusionGrid
    {
        [Parameter]
        public string Class { get; set; } = string.Empty;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public string? MinimumHeight { get; set; }

        [Parameter]
        public string? MaximumHeight { get; set; }

        [Parameter]
        public string BottomMargin { get; set; } = "1.5rem";

        [Parameter]
        public bool NotFluid { get; set; }

        private string? FullClass;
        private string? FullStyle;

        protected override void OnParametersSet()
        {
            var containerClassName = NotFluid ? "container" : "container-fluid";
            if (!string.IsNullOrWhiteSpace(Class) && !Class.Contains(containerClassName))
            {
                FullClass = $"{containerClassName} " + Class;
            }
            else if (!string.IsNullOrWhiteSpace(Class))
            {
                FullClass = Class;
            }
            else
            {
                FullClass = containerClassName;
            }

            FullStyle = string.Empty;

            if (!string.IsNullOrWhiteSpace(BottomMargin))
            {
                FullStyle += $"margin-bottom:{BottomMargin};";
            }
            if (!string.IsNullOrWhiteSpace(MaximumHeight))
            {
                FullStyle += $"max-height:{MaximumHeight};";
            }
            if (!string.IsNullOrWhiteSpace(MinimumHeight))
            {
                FullStyle += $"min-height:{MinimumHeight};";
            }
        }
    }
}
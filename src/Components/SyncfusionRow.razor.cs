using Microsoft.AspNetCore.Components;

namespace Orbyss.Blazor.Syncfusion.JsonForms.Components
{
    public partial class SyncfusionRow
    {
        [Parameter]
        public string? Class { get; set; }

        [Parameter]
        public bool WrapChildContentInColumn { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        private string? FullClass;

        protected override void OnParametersSet()
        {
            var cssClass = "form-row";
            if (!string.IsNullOrWhiteSpace(Class))
            {
                cssClass += " " + Class;
            }

            // var justifyContentClass = GetClass(JustifyContent);
            // cssClass += " " + justifyContentClass;

            FullClass = cssClass;
        }
    }
}
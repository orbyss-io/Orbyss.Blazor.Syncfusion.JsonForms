using Microsoft.AspNetCore.Components;

namespace Orbyss.Blazor.Syncfusion.JsonForms.Components
{
    public partial class SyncfusionColumn
    {
        [Parameter]
        public string? Class { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        string? FullClass;

        protected override void OnParametersSet()
        {
            var cssClasses = Class?.Split(' ')?.ToList() ?? [];

            if (!cssClasses.Contains("form-fixed-column"))
            {
                cssClasses.Add("form-column");
            }

            FullClass = string.Join(' ', cssClasses);

            base.OnParametersSet();
        }
    }
}

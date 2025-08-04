using Microsoft.AspNetCore.Components;

namespace Orbyss.Blazor.Syncfusion.JsonForms.Components
{
    public partial class SyncfusionFormList
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public EventCallback OnAddClicked { get; set; }

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string? Error { get; set; }
    }
}

using Microsoft.AspNetCore.Components;
using Orbyss.Components.JsonForms.Context.Interfaces;

namespace Orbyss.Blazor.Syncfusion.JsonForms.Components
{
    public partial class SyncfusionFormListItem
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public EventCallback OnRemoveClicked { get; set; }

        [CascadingParameter]
        public IJsonFormContext? FormContext { get; set; }

        [Parameter]
        public bool ReadOnly { get; set; }
    }
}

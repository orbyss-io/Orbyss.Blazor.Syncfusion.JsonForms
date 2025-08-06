using Syncfusion.Blazor.DropDowns;

namespace Orbyss.Blazor.Syncfusion.JsonForms
{
    public sealed record MultiSelectOptions(
        VisualMode Mode = VisualMode.Box,
        bool ShowDropdownIcon = true,
        bool ShowSelectAll = true,
        bool EnableSelectionOrder = false,
        int MaximumSelection = 1000
    );
}
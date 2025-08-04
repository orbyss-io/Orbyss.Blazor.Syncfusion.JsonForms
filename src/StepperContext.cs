using Syncfusion.Blazor.Navigations;

namespace Orbyss.Blazor.Syncfusion.JsonForms
{
    public sealed class StepperContext(StepContext[] steps)
    {
        public StepContext[] Steps { get; } = steps;
    }

    public sealed class StepContext(int index, Guid pageId)
    {
        public bool? IsValid { get; set; }

        public StepperStatus Status { get; set; } = StepperStatus.NotStarted;

        public int Index { get; } = index;

        public Guid PageId { get; } = pageId;
    }
}

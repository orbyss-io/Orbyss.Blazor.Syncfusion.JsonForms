using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.SyncFusion.Blazor.JsonForms.Components;
using Syncfusion.Blazor.Navigations;

namespace Orbyss.Blazor.Syncfusion.JsonForms.ComponentInstances
{
    public sealed class SyncfusionStepperInstance : NavigationFormComponentInstance<SyncfusionStepper>
    {
        public SyncfusionStepperAnimationSettings? AnimationSettings { get; set; }

        public StepperOrientation Orientation { get; set; }

        public StepperLabelPosition LabelPosition { get; set; } = StepperLabelPosition.Bottom;

        public string? MinimumHeight { get; set; }

        public string? MaximumHeight { get; set; }

        protected override IDictionary<string, object?> GetParametersCore()
        {
            return new Dictionary<string, object?>
            {
                [nameof(SyncfusionStepper.OnSubmitClicked)] = OnSubmitClicked,
                [nameof(SyncfusionStepper.MaximumHeight)] = MaximumHeight,
                [nameof(SyncfusionStepper.MinimumHeight)] = MinimumHeight,
                [nameof(SyncfusionStepper.AnimationSettings)] = AnimationSettings,
                [nameof(SyncfusionStepper.Orientation)] = Orientation,
                [nameof(SyncfusionStepper.LabelPosition)] = LabelPosition
            };
        }
    }
}
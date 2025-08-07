using Orbyss.Blazor.JsonForms;
using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.JsonForms.ComponentInstances.Interfaces;
using Orbyss.Blazor.JsonForms.Context.Interfaces;
using Orbyss.Blazor.JsonForms.Context.Models;
using Orbyss.Blazor.JsonForms.Interpretation;
using Orbyss.Blazor.Syncfusion.JsonForms.ComponentInstances;
using Orbyss.Blazor.Syncfusion.JsonForms.Components;
using Syncfusion.Blazor.Buttons;

namespace Orbyss.Blazor.Syncfusion.JsonForms
{
    public class SyncfusionFormComponentInstanceProvider(SyncfusionFormComponentInstanceProviderOptions? options = null)
        : IFormComponentInstanceProvider
    {
        private static readonly SyncfusionButtonInstance DefaultAddButton = new(
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["EN"] = "Add",
                ["ES"] = "Añadir",
                ["DE"] = "Hinzufügen",
                ["NL"] = "Toevoegen",
                ["FR"] = "Ajouter"
            }
        );

        private static readonly SyncfusionButtonInstance DefaultUpdateButton = new(
           new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
           {
               ["EN"] = "Update",
               ["ES"] = "Actualizar",
               ["DE"] = "Aktualisieren",
               ["NL"] = "Bijwerken",
               ["FR"] = "Actualiser"
           }
        );

        private static readonly SyncfusionButtonInstance DefaultNextButton = new(
           new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
           {
               ["EN"] = "Next",
               ["ES"] = "Siguiente",
               ["DE"] = "Folgende",
               ["NL"] = "Volgende",
               ["FR"] = "Suivant"
           }
        )
        {
            Class = "e-primary",
            IconClass = Constants.SyncfusionButtonIconsCss.ArrowRight,
            IconPosition = IconPosition.Right
        };

        private static readonly SyncfusionButtonInstance DefaultPreviousButton = new(
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["EN"] = "Previous",
                ["ES"] = "Anterior",
                ["DE"] = "Vorherige",
                ["NL"] = "Vorige",
                ["FR"] = "Précédent"
            }
        )
        {
            IconClass = Constants.SyncfusionButtonIconsCss.ArrowLeft,
            IconPosition = IconPosition.Left
        };

        private static readonly SyncfusionButtonInstance DefaultSubmitButton = new(
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["EN"] = "Submit",
                ["ES"] = "Enviar",
                ["DE"] = "Einreichen",
                ["NL"] = "Indienen",
                ["FR"] = "Soumettre"
            }
        )
        {
            Class = "e-primary"
        };

        private SyncfusionButtonInstance GetSubmitButton()
        {
            var formType = options?.FormType ?? FormType.Submit;

            return formType switch
            {
                FormType.Add => DefaultAddButton,
                FormType.Update => DefaultUpdateButton,
                _ => DefaultSubmitButton
            };
        }

        public virtual ButtonFormComponentInstanceBase GetButton(FormButtonType type, IJsonFormContext? form = null)
        {
            return GetButtonInternal(type, form);
        }

        private SyncfusionButtonInstance GetButtonInternal(FormButtonType type, IJsonFormContext? form = null)
        {
            return type switch
            {
                FormButtonType.Submit => GetSubmitButton(),
                FormButtonType.Previous => DefaultPreviousButton,
                FormButtonType.Next => DefaultNextButton,

                _ => throw new NotSupportedException($"Form button type '{type}' is not supported")
            };
        }

        public virtual IFormComponentInstance GetGrid(IJsonFormContext? form = null, FormPageContext? page = null)
        {
            var result = new SyncfusionGridInstance();
            if (options?.ConfigureGrid is not null)
            {
                return options.ConfigureGrid(result, form, page);
            }

            return result;
        }

        public virtual IFormComponentInstance GetGridColumn(IFormElementContext? column = null)
        {
            var result = new FormComponentInstance<SyncfusionColumn>
            {
                Class = column is null ? "form-fixed-column" : null
            };

            if (options?.ConfigureColumn is not null)
            {
                return options.ConfigureColumn(result, column);
            }

            return result;
        }

        public virtual IFormComponentInstance GetGridRow(IFormElementContext? row)
        {
            int? columnCountInRow = null;
            if (row is FormHorizontalLayoutContext rowWithColumns)
            {
                columnCountInRow = rowWithColumns.Columns.Count();
            }
            else if (row is not null)
            {
                columnCountInRow = 1;
            }

            var result = new SyncfusionRowInstance
            {
                WrapChildContentInColumn = columnCountInRow == 1,
                Class = row is null ? "align-right" : null
            };

            if (options?.ConfigureRow is not null)
            {
                return options.ConfigureRow(result, row);
            }

            return result;
        }

        public virtual InputFormComponentInstanceBase GetInputField(IJsonFormContext context, FormControlContext control)
        {
            var type = control.Interpretation.ControlType;

            return type switch
            {
                ControlType.Boolean => GetBooleanField(control),
                ControlType.String => GetTextField(control),
                ControlType.Enum => GetDropDownField(control),
                ControlType.EnumList => GetMultiDropDownField(control),
                ControlType.DateTime => GetDateTimeField(control),
                ControlType.DateTimeUtcTicks => GetDateTimeUtcTicksField(control),
                ControlType.DateOnly => GetDateOnlyField(control),
                ControlType.DateOnlyUtcTicks => GetDateUtcTicksField(control),

                ControlType.Integer => GetIntegerField(control),
                ControlType.Number => GetNumberField(control),

                _ => throw new NotSupportedException($"Cannot create an input field for type '{type}'")
            };
        }

        public virtual ListFormComponentInstanceBase GetList(FormListContext? list = null)
        {
            var result = new ListFormComponentInstance<SyncfusionFormList>();
            if (options?.ConfigureList is not null)
            {
                return options.ConfigureList(result, list);
            }
            return result;
        }

        public virtual ListItemFormComponentInstance GetListItem(IFormElementContext? listItem = null)
        {
            var result = new ListItemFormComponentInstance<SyncfusionFormListItem>();
            if (options?.ConfigureListItem is not null)
            {
                return options.ConfigureListItem(result, listItem);
            }
            return result;
        }

        public virtual NavigationFormComponentInstanceBase GetNavigation(IJsonFormContext formContext)
        {
            var result = new SyncfusionStepperInstance()
            {
                AnimationSettings = new SyncfusionStepperAnimationSettings
                {
                    Delay = 1000,
                    Duration = 5000,
                    Enable = true
                },
                MinimumHeight = "12rem"
            };

            if (options?.ConfigureNavigation is not null)
            {
                return options.ConfigureNavigation(result, formContext);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetTextField(FormControlContext control)
        {
            var result = new SyncfusionTextInputInstance()
            {
                Width = "100%"
            };

            if (options?.ConfigureTextInput is not null)
            {
                return options.ConfigureTextInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetDropDownField(FormControlContext control)
        {
            var result = new SyncfusionDropdownInstance()
            {
                Width = "100%"
            };

            if (options?.ConfigureDropdownInput is not null)
            {
                return options.ConfigureDropdownInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetMultiDropDownField(FormControlContext control)
        {
            var result = new SyncfusionDropdownMultiSelectInstance()
            {
                Width = "100%"
            };

            if (options?.ConfigureMultiDropdownInput is not null)
            {
                return options.ConfigureMultiDropdownInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetDateTimeField(FormControlContext control)
        {
            var result = new DateTimeInputFormComponentInstance(typeof(SyncfusionDateTimePicker<>));

            if (options?.ConfigureDateTimeInput is not null)
            {
                return options.ConfigureDateTimeInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetDateOnlyField(FormControlContext control)
        {
            var result = new DateOnlyInputFormComponentInstance(typeof(SyncfusionDatePicker<>));

            if (options?.ConfigureDateOnlyInput is not null)
            {
                return options.ConfigureDateOnlyInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetDateTimeUtcTicksField(FormControlContext control)
        {
            var result = new DateTimeUtcTicksInputFormComponentInstance(typeof(SyncfusionDateTimePicker<>));

            if (options?.ConfigureDateTimeUtcTicksInput is not null)
            {
                return options.ConfigureDateTimeUtcTicksInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetDateUtcTicksField(FormControlContext control)
        {
            var result = new DateOnlyUtcTicksInputFormComponentInstance(typeof(SyncfusionDatePicker<>));

            if (options?.ConfigureDateUtcTicksInput is not null)
            {
                return options.ConfigureDateUtcTicksInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetIntegerField(FormControlContext control)
        {
            var result = new SyncfusionIntegerInputInstance()
            {
                Width = "100%"
            };

            if (options?.ConfigureIntegerInput is not null)
            {
                return options.ConfigureIntegerInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetNumberField(FormControlContext control)
        {
            var result = new SyncfusionNumberInputInstance()
            {
                Width = "100%"
            };

            if (options?.ConfigureNumberInput is not null)
            {
                return options.ConfigureNumberInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetBooleanField(FormControlContext control)
        {
            var result = new SyncfusionCheckboxInstance
            {
                LabelPosition = LabelPosition.After
            };

            if (options?.ConfigureBooleanInput is not null)
            {
                return options.ConfigureBooleanInput(result, control);
            }
            return result;
        }
    }
}
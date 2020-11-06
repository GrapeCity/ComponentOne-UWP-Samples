using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C1.Xaml;
using Windows.UI.Xaml;

namespace BasicLibrarySamples
{
    /// <summary>
    /// Selects a data template depending on the business object.
    /// If the business object represents a Department it gets the DepartmentTemplate.
    /// If the business object represents an Employee, then it selects the MaleEmployeeTemplate
    /// or the FemaleEmployeeTemplate depending on the Gender property of each employee.
    /// </summary>
    public class DragDropCustomTemplateSelector : C1DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is Department)
            {
                return Resources["DepartmentTemplate"] as DataTemplate;
            }
            else
            {
                Employee employee = (Employee)item;
                string templateKey = (employee.Gender == 'M') ? "MaleEmployeeTemplate" : "FemaleEmployeeTemplate";
                return Resources[templateKey] as DataTemplate;
            }
        }

        public override ResourceDictionary Resources { get; set; }
    }
}

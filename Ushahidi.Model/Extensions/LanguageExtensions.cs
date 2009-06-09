using System.Reflection;
using System.Windows.Forms;
using Ushahidi.Common.Controls;

namespace Ushahidi.Model.Extensions
{
    public static class LanguageExtensions
    {
        public static string Translate(this string name)
        {
            return DataManager.Translate(name);
        }

        public static void Translate(this Control control)
        {
            control.Translate(control.Name);
        }

        public static void Translate(this Control control, string name)
        {
            control.Text = Translate(name) ?? control.Text;
        }

        public static void Translate(this LabelCheckBox labelCheckBox, string name, string checkbox)
        {
            labelCheckBox.Text = Translate(name) ?? labelCheckBox.Text;
            labelCheckBox.CheckBox = Translate(checkbox) ?? labelCheckBox.CheckBox;
        }

        public static void Translate(this MenuItem menuItem, string name)
        {
            menuItem.Text = Translate(name) ?? menuItem.Text;
        }

        public static void Translate(this MenuItem menuItem, Form form)
        {
            foreach (FieldInfo field in form.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance))
            {
                if (field.GetValue(form) == menuItem)
                {
                    menuItem.Text = Translate(field.Name) ?? menuItem.Text;
                    return;
                }
            }
        }
    }
}

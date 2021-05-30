using DataBaseComponentFiller.Model.Components;
using DataBaseComponentFiller.Model.DataBase;
using DataBaseComponentFiller.ViewController;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseComponentFiller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            componentsComboBox.SelectedIndex = 0;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            Form nextForm;
            switch (componentsComboBox.Text)
            {
                case "Процессор":
                    nextForm = new ProcessorForm();
                    break;
                case "Материнская плата":
                    nextForm = new MotherboardForm();
                    break;
                case "Видеокарта":
                    nextForm = new VideoCardForm();
                    break;
                case "Оперативная память":
                    nextForm = new RAMForm();
                    break;
                case "Блок питания":
                    nextForm = new PowerModuleForm();
                    break;
                case "Охлаждение процессора":
                    nextForm = new ProcessorCoolingForm();
                    break;
                case "Корпус":
                    nextForm = new CaseForm();
                    break;
                case "Память (HDD/SSD)":
                    nextForm = new StorageForm();
                    break;
                case "M2":
                    nextForm = new M2Form();
                    break;
                case "Охлаждение корпуса":
                    nextForm = new CaseCoolingForm();
                    break;
                default:
                    nextForm = new Form();
                    break;
            }
            nextForm.MinimumSize = nextForm.Size;
            nextForm.MaximumSize = nextForm.Size;
            nextForm.FormClosed += (s, a) => Show();
            Hide();
            nextForm.Show();
        }

        private void outputButton_Click(object sender, EventArgs e)
        {
            using (var context = new ComponentsContext())
            {
                var tables = typeof(ComponentsContext).GetProperties()
                                                      .Where(x => x.GetCustomAttributes(true)
                                                                   .Any(x => x.GetType() == typeof(TableAttribute)));
                var path = "Output\\";
                foreach (var table in tables)
                {
                    File.Delete(path + table.Name + ".txt");
                    foreach (var component in (IEnumerable<IComponent>)table.GetValue(context))
                    {
                        File.AppendAllText(path + table.Name + ".txt", component.GetCharacteristics() + "\n");
                    }
                }
            }
        }

        private void deleteDataBase_Click(object sender, EventArgs e)
        {
            using (var context = new ComponentsContext())
            {
                var tables = typeof(ComponentsContext).GetProperties()
                                                      .Where(x => x.GetCustomAttributes(true)
                                                                   .Any(x => x.GetType() == typeof(TableAttribute)))
                                                      .Select(x => x.GetValue(context) as IEnumerable);
                foreach (var table in tables)
                {
                    var method = table.GetType().GetMethod("Remove");
                    foreach (var component in table)
                    {
                        method?.Invoke(table, new[] { component });
                    }
                }
                context.SaveChanges();
            }
        }

        private void deleteRecordButton_Click(object sender, EventArgs e)
        {
            using (var context = new ComponentsContext())
            {
                var propertyInfo = typeof(ComponentsContext).GetProperties().FirstOrDefault(property => property.GetCustomAttributes(true).Any(attribute => attribute.GetType() == typeof(TableAttribute) && (attribute as TableAttribute).Name == componentsComboBox.Text));
                var table = propertyInfo.GetValue(context) as IEnumerable<IComponent>;
                var id = int.Parse(textBox1.Text);
                var component = table.FirstOrDefault(component => component.Id == id);
                var method = table.GetType().GetMethod("Remove");
                method?.Invoke(table, new[] { component });
                context.SaveChanges();
            }
        }

        private void deleteLastComponent_Click(object sender, EventArgs e)
        {
            using (var context = new ComponentsContext())
            {
                var propertyInfo = typeof(ComponentsContext).GetProperties().FirstOrDefault(property => property.GetCustomAttributes(true).Any(attribute => attribute.GetType() == typeof(TableAttribute) && (attribute as TableAttribute).Name == componentsComboBox.Text));
                var table = propertyInfo.GetValue(context) as IEnumerable<IComponent>;
                var id = table.Max(x => x.Id);
                var component = table.FirstOrDefault(component => component.Id == id);
                var method = table.GetType().GetMethod("Remove");
                method?.Invoke(table, new[] { component });
                context.SaveChanges();
            }
        }
    }
}

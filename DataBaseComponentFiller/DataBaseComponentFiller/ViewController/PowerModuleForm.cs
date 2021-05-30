using DataBaseComponentFiller.Model.Components;
using DataBaseComponentFiller.Model.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseComponentFiller.ViewController
{
    public partial class PowerModuleForm : Form
    {
        public PowerModuleForm()
        {
            InitializeComponent();
            powerModules = new List<PowerModule>();
        }

        private List<PowerModule> powerModules;

        private void addButton_Click(object sender, EventArgs e)
        {
            var powerModule = new PowerModule
            {
                Name = textBox1.Text,
                Cost = int.Parse(textBox2.Text),
                Rating = int.Parse(textBox3.Text),
                Power = int.Parse(textBox4.Text),
                PinPowerCP = textBox5.Text,
                PinPowerVideoCard = textBox6.Text,
                SataCount = int.Parse(textBox7.Text)
            };
            powerModules.Add(powerModule);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (powerModules.Count > 0)
                powerModules.RemoveAt(powerModules.Count - 1);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            using (var context = new ComponentsContext())
            {
                foreach (var powerModule in powerModules)
                {
                    context.PowerModules.Add(powerModule);
                }
                context.SaveChanges();
            }
            powerModules.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var isDelete = MessageBox.Show("Точно удалить таблицу?", "", MessageBoxButtons.YesNo);
            if (isDelete != DialogResult.Yes)
                return;
            using (var context = new ComponentsContext())
            {
                foreach (var powerModule in powerModules)
                {
                    context.PowerModules.Remove(powerModule);
                }
                context.SaveChanges();
            }
            powerModules.Clear();
        }
    }
}

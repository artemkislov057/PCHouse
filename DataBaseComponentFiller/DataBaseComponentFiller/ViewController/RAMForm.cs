using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBaseComponentFiller.Model.Components;
using DataBaseComponentFiller.Model.DataBase;

namespace DataBaseComponentFiller.ViewController
{
    public partial class RAMForm : Form
    {
        public RAMForm()
        {
            InitializeComponent();
            rAMs = new List<RAM>();
        }

        List<RAM> rAMs;

        private void addButton_Click(object sender, EventArgs e)
        {
            var ram = new RAM
            {
                Name = textBox1.Text,
                Cost = int.Parse(textBox2.Text),
                Rating = int.Parse(textBox3.Text),
                TypeMemory = textBox4.Text,
                Frequency = int.Parse(textBox5.Text),
                Timings = textBox6.Text,
                EnergyConsumption = int.Parse(textBox7.Text)
            };
            rAMs.Add(ram);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (rAMs.Count > 0)
                rAMs.RemoveAt(rAMs.Count - 1);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            using (var context = new ComponentsContext())
            {
                foreach (var ram in rAMs)
                {
                    context.RAMs.Add(ram);
                }
                context.SaveChanges();
            }
            rAMs.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var isDelete = MessageBox.Show("Точно удалить таблицу?", "", MessageBoxButtons.YesNo);
            if (isDelete != DialogResult.Yes)
                return;
            using (var context = new ComponentsContext())
            {
                foreach (var ram in context.RAMs)
                {
                    context.RAMs.Remove(ram);
                }
                context.SaveChanges();
            }
            rAMs.Clear();
        }
    }
}

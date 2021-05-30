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
    public partial class ProcessorForm : Form
    {
        public ProcessorForm()
        {
            InitializeComponent();
            processors = new List<Processor>();
        }

        private List<Processor> processors;

        private void addButton_Click(object sender, EventArgs e)
        {
            var processor = new Processor
            {
                Name = textBox1.Text,
                Cost = int.Parse(textBox2.Text),
                Rating = int.Parse(textBox3.Text),
                Socket = textBox4.Text,
                RamFrequency = double.Parse(textBox5.Text),
                EnergyConsumption = int.Parse(textBox6.Text)
            };
            processors.Add(processor);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (processors.Count > 0)
                processors.RemoveAt(processors.Count - 1);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            using (var context = new ComponentsContext())
            {
                foreach (var processor in processors)
                {
                    context.Processors.Add(processor);
                }
                context.SaveChanges();
            }
            processors.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var isDelete = MessageBox.Show("Точно удалить таблицу?", "", MessageBoxButtons.YesNo);
            if (isDelete != DialogResult.Yes)
                return;
            using (var context = new ComponentsContext())
            {
                foreach (var processor in context.Processors)
                    context.Processors.Remove(processor);
                context.SaveChanges();
            }
            processors.Clear();
        }
    }
}

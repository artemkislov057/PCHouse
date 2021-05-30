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
    public partial class ProcessorCoolingForm : Form
    {
        public ProcessorCoolingForm()
        {
            InitializeComponent();
            processorCoolings = new List<ProcessorCooling>();
        }

        List<ProcessorCooling> processorCoolings;

        private void addButton_Click(object sender, EventArgs e)
        {
            var processorCooling = new ProcessorCooling
            {
                Name = textBox1.Text,
                Cost = int.Parse(textBox2.Text),
                Rating = int.Parse(textBox3.Text),
                Socket = textBox4.Text,
                Power = textBox5.Text,
                CoolerHeight = int.Parse(textBox6.Text),
                CoolerWidth = int.Parse(textBox7.Text),
                CoolerLength = int.Parse(textBox8.Text)
            };
            processorCoolings.Add(processorCooling);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (processorCoolings.Count > 0)
                processorCoolings.RemoveAt(processorCoolings.Count - 1);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            using (var context = new ComponentsContext())
            {
                foreach (var processorCooling in processorCoolings)
                {
                    context.ProcessorCoolings.Add(processorCooling);
                }
                context.SaveChanges();
            }
            processorCoolings.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var isDelete = MessageBox.Show("Точно удалить таблицу?", "", MessageBoxButtons.YesNo);
            if (isDelete != DialogResult.Yes)
                return;
            using (var context = new ComponentsContext())
            {
                foreach (var processorCooling in context.ProcessorCoolings)
                {
                    context.ProcessorCoolings.Remove(processorCooling);
                }
                context.SaveChanges();
            }
            processorCoolings.Clear();
        }
    }
}

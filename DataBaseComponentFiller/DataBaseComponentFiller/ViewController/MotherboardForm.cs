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
    public partial class MotherboardForm : Form
    {
        public MotherboardForm()
        {
            InitializeComponent();
            motherboards = new List<Motherboard>();
        }

        private List<Motherboard> motherboards;

        private void addButton_Click(object sender, EventArgs e)
        {
            var motherboard = new Motherboard
            {
                Name = textBox1.Text,
                Cost = int.Parse(textBox2.Text),
                Rating = int.Parse(textBox3.Text),
                Socket = textBox4.Text,
                RAM = textBox5.Text,
                RAMFrequency = int.Parse(textBox6.Text),
                RAMTimings = textBox7.Text,
                ARRAY_ProcessorCoolings = richTextBox1.Text,
                ARRAY_CaseCoolings = richTextBox2.Text,
                SataInterfaceCount = int.Parse(textBox8.Text),
                M2Length = int.Parse(textBox9.Text),
                FormFactor = textBox10.Text
            };
            motherboards.Add(motherboard);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (motherboards.Count > 0)
                motherboards.RemoveAt(motherboards.Count - 1);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            using (var context = new ComponentsContext())
            {
                foreach (var motherboard in motherboards)
                {
                    context.Motherboards.Add(motherboard);
                }
                context.SaveChanges();
            }
            motherboards.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var isDelete = MessageBox.Show("Точно удалить таблицу?", "", MessageBoxButtons.YesNo);
            if (isDelete != DialogResult.Yes)
                return;
            using (var context = new ComponentsContext())
            {
                foreach (var motherboard in context.Motherboards)
                {
                    context.Motherboards.Remove(motherboard);
                }
                context.SaveChanges();
            }
            motherboards.Clear();
        }
    }
}

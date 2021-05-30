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
    public partial class CaseForm : Form
    {
        public CaseForm()
        {
            InitializeComponent();
            cases = new List<Case>();
        }

        private List<Case> cases;

        private void addButton_Click(object sender, EventArgs e)
        {
            var body = new Case()
            {
                Name = textBox1.Text,
                Cost = int.Parse(textBox2.Text),
                Rating = int.Parse(textBox3.Text),
                ARRAY_FormFactor = richTextBox1.Text,
                ARRAY_FanSlotsAndSize = richTextBox2.Text,
                PossibilityOfInstallationWaterCooling = checkBox1.Checked,
                MaximumHeightOfTowerCooler = int.Parse(textBox4.Text),
                MaximumWidthOfVideoCard = int.Parse(textBox5.Text),
                MaximumHeightOfVideoCard = int.Parse(textBox6.Text),
                MaximumLengthOfVideoCard = int.Parse(textBox7.Text)
            };
            cases.Add(body);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (cases.Count > 0)
                cases.RemoveAt(cases.Count - 1);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            using (var context = new ComponentsContext())
            {
                var arr = context.Cases.ToArray();
                foreach (var body in cases)
                {
                    context.Cases.Add(body);
                }
                context.SaveChanges();
            }
            cases.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var isDelete = MessageBox.Show("Точно удалить таблицу?", "", MessageBoxButtons.YesNo);
            if (isDelete != DialogResult.Yes)
                return;
            using (var context = new ComponentsContext())
            {
                foreach (var body in context.Cases)
                    context.Cases.Remove(body);
                context.SaveChanges();
            }
            cases.Clear();
        }
    }
}

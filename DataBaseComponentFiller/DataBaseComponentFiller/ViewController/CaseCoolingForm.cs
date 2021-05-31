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
    public partial class CaseCoolingForm : Form
    {
        public CaseCoolingForm()
        {
            InitializeComponent();
            caseCoolings = new List<CaseCooling>();
        }

        private List<CaseCooling> caseCoolings;

        private void addButton_Click(object sender, EventArgs e)
        {
            var caseCooling = new CaseCooling
            {
                Name = textBox1.Text.ToLower(),
                Cost = int.Parse(textBox2.Text),
                Rating = int.Parse(textBox3.Text),
                FanSize = int.Parse(textBox4.Text),
                TypeOfPowerSupply = textBox5.Text.ToLower(),
                EnergyConsumption = int.Parse(textBox6.Text)
            };
            caseCoolings.Add(caseCooling);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (caseCoolings.Count > 0)
                caseCoolings.RemoveAt(caseCoolings.Count - 1);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            using (var context = new ComponentsContext())
            {
                foreach (var caseCooling in caseCoolings)
                {
                    context.CaseCoolings.Add(caseCooling);
                }
                context.SaveChanges();
            }
            caseCoolings.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var isDelete = MessageBox.Show("Точно удалить таблицу?", "", MessageBoxButtons.YesNo);
            if (isDelete != DialogResult.Yes)
                return;
            using (var context = new ComponentsContext())
            {
                foreach (var caseCooling in context.CaseCoolings)
                {
                    context.CaseCoolings.Remove(caseCooling);
                }
                context.SaveChanges();
            }
            caseCoolings.Clear();
        }
    }
}

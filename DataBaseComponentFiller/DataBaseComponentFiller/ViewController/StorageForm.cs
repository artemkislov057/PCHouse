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
    public partial class StorageForm : Form
    {
        public StorageForm()
        {
            InitializeComponent();
        }

        List<Storage> storages = new List<Storage>();

        private void addButton_Click(object sender, EventArgs e)
        {
            var storage = new Storage
            {
                Name = textBox1.Text,
                Cost = int.Parse(textBox2.Text),
                Rating = int.Parse(textBox3.Text),
                EnergyConsumption = int.Parse(textBox4.Text)
            };
            storages.Add(storage);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (storages.Count > 0)
                storages.RemoveAt(storages.Count - 1);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            using (var context = new ComponentsContext())
            {
                foreach (var storage in storages)
                {
                    context.Storages.Add(storage);
                }
                context.SaveChanges();
            }
            storages.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var isDelete = MessageBox.Show("Точно удалить таблицу?", "", MessageBoxButtons.YesNo);
            if (isDelete != DialogResult.Yes)
                return;
            using (var context = new ComponentsContext())
            {
                foreach (var storage in storages)
                {
                    context.Storages.Remove(storage);
                }
                context.SaveChanges();
            }
            storages.Clear();
        }
    }
}

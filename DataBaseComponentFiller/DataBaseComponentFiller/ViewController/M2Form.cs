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
    public partial class M2Form : Form
    {
        public M2Form()
        {
            InitializeComponent();
            m2s = new List<M2>();
        }

        private List<M2> m2s;

        private void addButton_Click(object sender, EventArgs e)
        {
            var m2 = new M2
            {
                Name = textBox1.Text.ToLower(),
                Cost = int.Parse(textBox2.Text),
                Rating = int.Parse(textBox3.Text),
                Length = int.Parse(textBox4.Text)
            };
            m2s.Add(m2);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (m2s.Count > 0)
                m2s.RemoveAt(m2s.Count - 1);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            using (var context = new ComponentsContext())
            {
                foreach (var m2 in m2s)
                {
                    context.M2Collection.Add(m2);
                }
                context.SaveChanges();
            }
            m2s.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var isDelete = MessageBox.Show("Точно удалить таблицу?", "", MessageBoxButtons.YesNo);
            if (isDelete != DialogResult.Yes)
                return;
            using (var context = new ComponentsContext())
            {
                foreach (var m2 in context.M2Collection)
                {
                    context.Remove(m2);
                }
                context.SaveChanges();
            }
            m2s.Clear();
        }
    }
}

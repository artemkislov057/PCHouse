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
    public partial class VideoCardForm : Form
    {
        public VideoCardForm()
        {
            InitializeComponent();
        }

        List<VideoCard> videoCards = new List<VideoCard>();

        private void addButton_Click(object sender, EventArgs e)
        {
            var videoCard = new VideoCard
            {
                Name = textBox1.Text,
                Cost = int.Parse(textBox2.Text),
                Rating = int.Parse(textBox3.Text),
                Length = int.Parse(textBox4.Text),
                Width = int.Parse(textBox5.Text),
                Height = int.Parse(textBox6.Text),
                EnergyConsumption = int.Parse(textBox7.Text),
                PinPowerVideoCard = textBox8.Text
            };
            videoCards.Add(videoCard);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (videoCards.Count > 0)
                videoCards.RemoveAt(videoCards.Count - 1);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            using (var context = new ComponentsContext())
            {
                foreach (var videoCard in videoCards)
                {
                    context.VideoCards.Add(videoCard);
                }
                context.SaveChanges();
            }
            videoCards.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var isDelete = MessageBox.Show("Точно удалить таблицу?", "", MessageBoxButtons.YesNo);
            if (isDelete != DialogResult.Yes)
                return;
            using (var context = new ComponentsContext())
            {
                foreach (var videoCard in videoCards)
                {
                    context.VideoCards.Remove(videoCard);
                }
                context.SaveChanges();
            }
            videoCards.Clear();
        }
    }
}

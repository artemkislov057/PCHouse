using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillerDataBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
        }

        private List<Configuration> configurations = new List<Configuration>();

        private void button1_Click(object sender, EventArgs e)
        {
            var configuration = new Configuration();
            configuration.Processor = this.textBox1.Text;
            configuration.Motherboard = this.textBox2.Text;
            configuration.Videocard = this.textBox3.Text;
            configuration.RAM = this.textBox4.Text;
            configuration.HDD = this.textBox5.Text;
            configuration.SSD = this.textBox6.Text;
            configuration.Cooling = this.textBox7.Text;
            configuration.PowerModule = this.textBox8.Text;
            configuration.Case = this.textBox9.Text;
            configuration.Target = this.comboBox1.Text;
            configuration.Budget = this.comboBox2.Text;
            configurations.Add(configuration);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                foreach (var conf in configurations)
                {
                    context.Configurations.Add(conf);
                }
                context.SaveChanges();
                configurations.RemoveAll(x => true);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var isDelete = MessageBox.Show("Точно удалить БД?", "", MessageBoxButtons.YesNo);
            if (isDelete != DialogResult.Yes)
                return;
            using (var context = new ApplicationContext())
            {
                foreach (var conf in context.Configurations)
                    context.Configurations.Remove(conf);
                context.SaveChanges();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                if (context.Configurations.Any())
                {
                    File.Delete("Output\\OUTPUT_DATA_BASE.txt");
                    foreach (var conf in context.Configurations)
                        OutputConfiguration(conf);
                }
                else
                    MessageBox.Show("База данных пустая");
            }
        }

        private static void OutputConfiguration(Configuration configuration)
        {
            var text = $"Процессор: {configuration.Processor}\n" +
                $"Материнская плата: {configuration.Motherboard}\n" +
                $"Видеокарта: {configuration.Videocard}\n" +
                $"RAM: {configuration.RAM}\n" +
                $"HDD: {configuration.HDD}\n" +
                $"SSD: {configuration.SSD}\n" +
                $"Охлаждение: {configuration.Cooling}\n" +
                $"Блок питания: {configuration.PowerModule}\n" +
                $"Корпус: {configuration.Case}\n" +
                $"Цель:  {configuration.Target}\n" +
                $"Бюджет: {configuration.Budget}\n\n";
            File.AppendAllText("Output\\OUTPUT_DATA_BASE.txt", text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (configurations.Count > 0)
                configurations.RemoveAt(configurations.Count - 1);
        }
    }
}
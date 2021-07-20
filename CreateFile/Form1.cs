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

namespace CreateFile
{
    public partial class Form1 : Form
    {
        string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // шлях до робочого столу

        public Form1()
        {
            InitializeComponent();
            var dirInfo = new DirectoryInfo(pathToDesktop); // створюємо обєкт, через який будео доступатись до файлів робочого столу
            var files = dirInfo.GetFiles(); // повертає файли з робочого столу
            listBox1.DataSource = files; //додаємо в список listBox назви всіх файлів
            listBox1.ValueMember = "FullName"; // виводить весь шлях з назвою файла
            listBox1.DisplayMember = "Name"; // обрізаємо шлях і виводимо тільки назву файла
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = Path.GetFileNameWithoutExtension((listBox1.SelectedItem as FileInfo).FullName); // виводимо повне імя файла
            textBox2.Text = (listBox1.SelectedItem as FileInfo).Extension; // виводимо розширення файла
            textBox3.Text = ((listBox1.SelectedItem as FileInfo).Length/1024).ToString(); // виводимо розмір та переводимо в кілобайти
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //File.Create($"{pathToDesktop}\\{textBox4.Text}");
            File.Create(Path.Combine(pathToDesktop,textBox4.Text)); //Path.Combine - зєднує стрінгу з правильними роздільником шляху
        }
    }
}

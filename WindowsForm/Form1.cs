using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Gestionnaire d'événement
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"La date actuelle est {DateTime.Now}");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show($"Le jour est {DateTime.Now.DayOfWeek}");
        }
    }
}

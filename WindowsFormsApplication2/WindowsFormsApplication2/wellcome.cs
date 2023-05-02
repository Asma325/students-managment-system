using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class wellcome : Form
    {
        public wellcome()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            students ss = new students();
            ss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            department dd = new department();
            dd.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Exam E = new Exam();
            E.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            students_marks sm = new students_marks();
            sm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            subjects sb = new subjects();
            sb.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            subject_lectures sl = new subject_lectures();
            sl.Show();
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

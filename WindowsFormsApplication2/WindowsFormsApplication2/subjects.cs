using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication2
{
    public partial class subjects : Form
    {
        public subjects()
        {
            InitializeComponent();
        }
        SqlConnection cccc = new SqlConnection("Data Source=DESKTOP-2G198UA\\SQLEXPRESS;Initial Catalog=students;Integrated Security=True");
        SqlCommand ccc;
        SqlCommand cccr;
        string sqlll;
        string r;
        bool modeee = true;
        DataTable ddd = new DataTable();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void subjects_Load(object sender, EventArgs e)
        {
           
            sqlll = "select * from subject";
            SqlDataAdapter cnd = new SqlDataAdapter(sqlll, cccc);
            cccc.Open();

            cnd.Fill(ddd);
            dataGridView1.DataSource = ddd;
            cccc.Close();
            cccc.Open();
            SqlCommand c = new SqlCommand("select Department_name from department", cccc);
            SqlDataReader rea = c.ExecuteReader();
            while (rea.Read())
            {
                comboBox3.Items.Add(rea["Department_name"].ToString());
            }
            cccc.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int max = Convert.ToInt32(textBox2.Text);
            int term = Convert.ToInt32(textBox3.Text);
            int year = Convert.ToInt32(textBox4.Text);
            string dept = comboBox3.Text;

            if (modeee == true)
            {
                
                cccc.Open();
                r = "select ID from department where Department_name = @name ";
                cccr = new SqlCommand(r,cccc);
                cccr.Parameters.AddWithValue("@name", comboBox3.SelectedItem.ToString());
                int id = Convert.ToInt32(cccr.ExecuteScalar());


                sqlll = "insert into subject (name,maximum_Degree,term,year,id_department)values (@name,@max,@term,@year,@id)";
                ccc = new SqlCommand(sqlll, cccc);
                ccc.Parameters.AddWithValue("@name", name);
                ccc.Parameters.AddWithValue("@max", max);
                ccc.Parameters.AddWithValue("@term", term);
                ccc.Parameters.AddWithValue("@year", year);
                ccc.Parameters.AddWithValue("@id", id);

                ccc.ExecuteNonQuery();
                cccc.Close();
                MessageBox.Show("subject added!!!!");
                textBox1.Clear();
                textBox1.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cccc.Open();
            SqlCommand cmd = new SqlCommand("delete from subject where ID = @id", cccc);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            cmd.ExecuteNonQuery();
            MessageBox.Show("deleted");
            DataTable table = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select *from subject", cccc);
            adapt.Fill(table);
            dataGridView1.DataSource = table;
            cccc.Close();
        }
    }
}
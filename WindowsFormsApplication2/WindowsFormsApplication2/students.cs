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
    public partial class students : Form
    {
        public students()
        {
            InitializeComponent();
           

        }
        SqlConnection cc = new SqlConnection("Data Source=DESKTOP-2G198UA\\SQLEXPRESS;Initial Catalog=students;Integrated Security=True");
        SqlCommand c;
        string sql;
        bool mode = true;
        DataTable d = new DataTable();

        int cnt = 4;
     

        private void students_Load(object sender, EventArgs e)
        {
            sql = "select * from student";
            SqlDataAdapter cnd = new SqlDataAdapter(sql, cc);
            cc.Open();

            cnd.Fill(d);
            dataGridView1.DataSource = d;
            cc.Close();

            cc.Open();
            SqlCommand cmd = new SqlCommand("select Department_name from department",cc);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["Department_name"].ToString());
            }
            cc.Close(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            string lname = textBox5.Text;
         // string dept = comboBox2.SelectedItem.ToString();
            string email = textBox4.Text;

            string i;
            SqlCommand ss;
            if (mode == true)
            {
                cc.Open();

                i = "select ID from department where Department_name = @name ";
                ss = new SqlCommand(i, cc);
                ss.Parameters.AddWithValue("@name", comboBox2.SelectedItem.ToString());
                int id = Convert.ToInt32(ss.ExecuteScalar());


                sql = "insert into student(first_name,last_name,email,register_date,id_department)values (@fname,@lname,@email,@date,@id)";
                c = new SqlCommand(sql, cc);
                c.Parameters.AddWithValue("@fname",fname);
                c.Parameters.AddWithValue("@lname", lname);
                c.Parameters.AddWithValue("@email", email);
                c.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                c.Parameters.AddWithValue("@id", id);
                c.ExecuteNonQuery();
                cc.Close();
                MessageBox.Show("student added!!!!");
                textBox1.Clear();
                textBox4.Clear();
                textBox5.Clear();

                textBox1.Focus();
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
          //abel8 = cnt.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cc.Open();
            SqlCommand cmd = new SqlCommand("delete from student where ID = @id", cc);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            cmd.ExecuteNonQuery();
            MessageBox.Show("deleted");
            DataTable table = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select *from student", cc);
            adapt.Fill(table);
            dataGridView1.DataSource = table;
            cc.Close();
        }
    }
}

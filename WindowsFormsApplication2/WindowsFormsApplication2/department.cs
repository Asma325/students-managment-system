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
    public partial class department : Form
    {
        public department()
        {
            InitializeComponent();
        }
        SqlConnection ccc = new SqlConnection("Data Source=DESKTOP-2G198UA\\SQLEXPRESS;Initial Catalog=students;Integrated Security=True");
        SqlCommand cc;
        string sqll;
        bool modee = true;
        DataTable dd = new DataTable();
       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string name = textBox1.Text;
            if (modee == true)
            {
                ccc.Open();
                int id = 1;
                sqll = "insert into department (ID,Department_name)values (@id,@name)";
                cc = new SqlCommand(sqll, ccc);
                cc.Parameters.AddWithValue("@name", name);
                cc.Parameters.AddWithValue("@id", id);

                cc.ExecuteNonQuery();
                MessageBox.Show("department added!!!!");
                textBox1.Clear();
                textBox1.Focus();
                DataTable table = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter("select *from department", ccc);
                adapt.Fill(table);
                dataGridView1.DataSource = table;
                id++;

            }
        }

        private void department_Load(object sender, EventArgs e)
        {
            sqll = "select * from department";
            SqlDataAdapter cnd = new SqlDataAdapter(sqll, ccc);
            ccc.Open();

            cnd.Fill(dd);
            dataGridView1.DataSource = dd;
            ccc.Close();
            ccc.Open();
            SqlCommand c = new SqlCommand("select Department_name from department", ccc);
            SqlDataReader rea = c.ExecuteReader();
            while (rea.Read())
            {
                comboBox1.Items.Add(rea["Department_name"].ToString());
            }
            ccc.Close();
        }


        DataTable ddd = new DataTable();
        private void button3_Click(object sender, EventArgs e)
        {
            ccc.Open();
          
            sqll = string.Format("select first_name ,last_name from student join department on id_department = department.ID where Department_name ='{0}' ", comboBox1.SelectedItem.ToString()); 
            SqlCommand b = new SqlCommand(sqll,ccc);
           // b.Parameters.AddWithValue("@name", comboBox1.SelectedItem.ToString());

           SqlDataAdapter cnd = new SqlDataAdapter(sqll, ccc);
            cnd.Fill(ddd);
            dataGridView2.DataSource = ddd; 
            ccc.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ccc.Open();
            SqlCommand cmd = new SqlCommand("delete from department where ID = @id", ccc);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            cmd.ExecuteNonQuery();
            MessageBox.Show("deleted");
            DataTable table = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select *from department", ccc);
            adapt.Fill(table);
            dataGridView1.DataSource = table;
            ccc.Close();
        }
    }
}

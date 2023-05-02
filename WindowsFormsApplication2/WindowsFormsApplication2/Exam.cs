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
    public partial class Exam : Form
    {
        public Exam()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2G198UA\\SQLEXPRESS;Initial Catalog=students;Integrated Security=True");
        SqlCommand s;
        SqlCommand ss;
        string sqls;
       
        bool modde = true;
        DataTable t = new DataTable();


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Exam_Load(object sender, EventArgs e)
        {
            sqls = "select * from exam";
            SqlDataAdapter cnd = new SqlDataAdapter(sqls, conn);
            conn.Open();

            cnd.Fill(t);
            dataGridView1.DataSource = t;
            conn.Close();
            conn.Open();
            SqlCommand c = new SqlCommand("select name from subject", conn);
            SqlDataReader rea = c.ExecuteReader();
            while (rea.Read())
            {
                comboBox1.Items.Add(rea["name"].ToString());
            }
            conn.Close();
        }
        string i;
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (modde == true)
            {
                conn.Open();
         
                i = "select ID from subject where name = @name ";
                ss = new SqlCommand(i, conn);
                ss.Parameters.AddWithValue("@name", comboBox1.SelectedItem.ToString());
                int id = Convert.ToInt32(ss.ExecuteScalar());



                sqls = "insert into exam (date,term,subject_id)values (@date,@term,@id)";
                s = new SqlCommand(sqls, conn);
                s.Parameters.AddWithValue("@term",textBox2.Text );
                s.Parameters.AddWithValue("@date",dateTimePicker1.Value);
                 s.Parameters.AddWithValue("@id", id);

                s.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Exam added!!!!");
          
                textBox2.Clear();

              
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from exam where ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            cmd.ExecuteNonQuery();
            MessageBox.Show("deleted");
            DataTable table = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select *from exam", conn);
            adapt.Fill(table);
            dataGridView1.DataSource = table;
            conn.Close();
        }
    }
}

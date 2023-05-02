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
    public partial class subject_lectures : Form
    {
        public subject_lectures()
        {
            InitializeComponent();
        }
        SqlConnection cck = new SqlConnection("Data Source=DESKTOP-2G198UA\\SQLEXPRESS;Initial Catalog=students;Integrated Security=True");
        SqlCommand ck;
        string sqlk;
        bool modek = true;
        DataTable dk = new DataTable();

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void subject_lectures_Load(object sender, EventArgs e)
        {
            sqlk = "select * from lectures";
            SqlDataAdapter cnd = new SqlDataAdapter(sqlk, cck);
            cck.Open();

            cnd.Fill(dk);
            dataGridView1.DataSource = dk;
            cck.Close();
            cck.Open();
            SqlCommand c = new SqlCommand("select name from subject", cck);
            SqlDataReader rea= c.ExecuteReader();
            while (rea.Read())
            {
                comboBox1.Items.Add(rea["name"].ToString());
            }
            cck.Close();
        }
        string i;
        SqlCommand ss;

        private void button1_Click(object sender, EventArgs e)
        {

            string title = textBox2.Text;
            string content = textBox1.Text;
            if (modek == true)
            {
                cck.Open();


                i = "select ID from subject where name = @name ";
                ss = new SqlCommand(i, cck);
                ss.Parameters.AddWithValue("@name", comboBox1.SelectedItem.ToString());
                int id = Convert.ToInt32(ss.ExecuteScalar());


                sqlk = "insert into lectures(title,content,subject_id)values (@title,@content,@id)";
                ck = new SqlCommand(sqlk, cck);
                ck.Parameters.AddWithValue("@title", title);
                ck.Parameters.AddWithValue("@content", content);
                ck.Parameters.AddWithValue("@id", id);


                ck.ExecuteNonQuery();
                cck.Close();
                MessageBox.Show("lecture added!!!!");
                textBox1.Clear();
               
                textBox1.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cck.Open();
            SqlCommand cmd = new SqlCommand("delete from lectures where ID = @id", cck);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            cmd.ExecuteNonQuery();
            MessageBox.Show("deleted");
            DataTable table = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select *from lectures", cck);
            adapt.Fill(table);
            dataGridView1.DataSource = table;
            cck.Close();
        }
    }
}

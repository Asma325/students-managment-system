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
    public partial class students_marks : Form
    {
        public students_marks()
        {
            InitializeComponent();
        }
        SqlConnection ccj = new SqlConnection("Data Source=DESKTOP-2G198UA\\SQLEXPRESS;Initial Catalog=students;Integrated Security=True");
        DataTable t = new DataTable();

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            students_marks_2 sm = new students_marks_2();
            sm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void students_marks_Load(object sender, EventArgs e)
        {
            ccj.Open();
            SqlCommand cm = new SqlCommand("select first_name ,last_name from student", ccj);
            SqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                comboBox4.Items.Add(reader["first_name"].ToString()+" "+reader["last_name"].ToString());
                comboBox1.Items.Add(reader["first_name"].ToString()+" "+reader["last_name"].ToString());
            }
            ccj.Close();
            ccj.Open();
            SqlCommand c = new SqlCommand("select name from subject", ccj);
            SqlDataReader reade = c.ExecuteReader();
            while (reade.Read())
            {
                comboBox3.Items.Add(reade["name"].ToString());
                comboBox2.Items.Add(reade["name"].ToString());
            }
            ccj.Close();


         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ccj.Open();

            

         string i = "select ID from student where first_name = @fname and last_name=@lname";
            SqlCommand  ss = new SqlCommand(i, ccj);
            ss.Parameters.AddWithValue("@fname", comboBox4.SelectedItem.ToString().Split()[0]);
            ss.Parameters.AddWithValue("@lname", comboBox4.SelectedItem.ToString().Split()[1]);
            int id = Convert.ToInt32(ss.ExecuteScalar());


            string ii= "select subject.ID from subject where subject.name = @name ";
            SqlCommand sss = new SqlCommand(ii, ccj);
            ss.Parameters.AddWithValue("@name", comboBox4.SelectedItem.ToString());
            int eid = Convert.ToInt32(ss.ExecuteScalar());


            string  sqls = "insert into student_marks (mark,student_id,subject_id) values (@mark,@sid,@eid)";
            SqlCommand s = new SqlCommand(sqls, ccj);
            if (checkBox1.Checked)
            {
               
                s.Parameters.AddWithValue("@mark", 10000);
            }
            else
            {
                s.Parameters.AddWithValue("@mark", Convert.ToInt32(textBox1.Text));

            }
          
            s.Parameters.AddWithValue("@sid", id);
            s.Parameters.AddWithValue("@eid", eid);

            s.ExecuteNonQuery();
            ccj.Close();

            MessageBox.Show("mark added!!!!");

            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ccj.Open();
            string sqls = "select mark ,subject_id from student_marks join student on student_id = student.ID where first_name ='{0}' ";
            SqlCommand v = new SqlCommand(sqls, ccj);
            SqlDataAdapter cnd = new SqlDataAdapter(sqls, ccj);
            cnd.Fill(t);
            dataGridView1.DataSource = t;
            ccj.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ccj.Open();
            string sqls = "select sum(mark) from student_marks join student on student_id = student.ID where first_name ='{0}' ";
            SqlCommand v = new SqlCommand(sqls, ccj);
            textBox2.Text = v.ExecuteScalar().ToString();
            ccj.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked=true)
            {
                textBox1.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text)>100)
            {
                MessageBox.Show("tooomuch");
            }
        }
        DataTable o = new DataTable();
        DataTable oo = new DataTable();
        private void button6_Click(object sender, EventArgs e)
        {
            ccj.Open();
            string i = string.Format("select first_name,last_name from student_marks join student on student_id = student.ID join subject on subject_id = subject.ID where mark<>10000 and subject.name ='{0}'", comboBox3.SelectedItem.ToString());
            //    SqlCommand ss = new SqlCommand(i, ccj);
            //   ss.Parameters.AddWithValue("@name", comboBox3.SelectedItem.ToString());
            //  ss.ExecuteNonQuery();
            string ii = string.Format("select first_name,last_name from student_marks join student on student_id = student.ID join subject on subject_id = subject.ID where mark=10000 and subject.name ='{0}'", comboBox3.SelectedItem.ToString());

            SqlDataAdapter cnd = new SqlDataAdapter(i, ccj);
            cnd.Fill(o);
            dataGridView2.DataSource = o;
            SqlDataAdapter cnnd = new SqlDataAdapter(i, ccj);
            cnnd.Fill(oo);
            dataGridView3.DataSource = oo;
            ccj.Close();
        }
    }
}

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
    public partial class students_marks_2 : Form
    {
        public students_marks_2()
        {
            InitializeComponent();
        }
        SqlConnection cccl = new SqlConnection("Data Source=DESKTOP-2G198UA\\SQLEXPRESS;Initial Catalog=students;Integrated Security=True");
        string sqll2;
        DataTable o = new DataTable();
        private void students_marks_2_Load(object sender, EventArgs e)
        {
            sqll2 = "select * from student_marks";
            SqlDataAdapter cnd = new SqlDataAdapter(sqll2, cccl);
            cccl.Open();

            cnd.Fill(o);
            dataGridView1.DataSource = o;
            cccl.Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            cccl.Open();
            SqlCommand cmd = new SqlCommand("delete from student_marks where ID = @id", cccl);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            cmd.ExecuteNonQuery();
            MessageBox.Show("deleted");
            DataTable table = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select *from student_marks", cccl);
            adapt.Fill(table);
            dataGridView1.DataSource = table;
            cccl.Close();
        }
    }
}

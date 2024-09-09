using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hms_Web
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblindicator1.ForeColor =  System.Drawing.Color.BlueViolet;
            lblindicator2.ForeColor = System.Drawing.Color.Black;
            lblindicator3.ForeColor = System.Drawing.Color.Black;
            lblindicator4.ForeColor = System.Drawing.Color.Black;

          
            panel2.Visible = true; 
            panel3.Visible = false; 
            panel4.Visible = false;
            pictureBox5.Visible = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblindicator2.ForeColor = System.Drawing.Color.BlueViolet;
            lblindicator1.ForeColor = System.Drawing.Color.Black;
            lblindicator3.ForeColor = System.Drawing.Color.Black;
            lblindicator4.ForeColor = System.Drawing.Color.Black;
          
            panel3.Visible = true;
            panel4.Visible = false;
            pictureBox5.Visible = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblindicator3.ForeColor = System.Drawing.Color.BlueViolet;
            lblindicator2.ForeColor = System.Drawing.Color.Black;
            lblindicator1.ForeColor = System.Drawing.Color.Black;
            lblindicator4.ForeColor = System.Drawing.Color.Black;
          
            panel4.Visible = true;


            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-8UITBRBH;Initial Catalog=hospital;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = " SELECT * FROM [dbo].[tbl_AddPat] inner join  [dbo].[PatientMore] on [dbo].[tbl_AddPat] .pid = [dbo].[PatientMore].pid";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            dataGridView2.DataSource = ds.Tables[0];

            pictureBox5.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            lblindicator4.ForeColor = System.Drawing.Color.BlueViolet;
            lblindicator1.ForeColor = System.Drawing.Color.Black;
            lblindicator2.ForeColor = System.Drawing.Color.Black;
            lblindicator3.ForeColor = System.Drawing.Color.Black;
           
            pictureBox5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
        private void DashBoard_Load(object sender, EventArgs e)
        {
           
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            pictureBox5.Visible = false;

        }

    
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel2.Visible=false;
            pictureBox2.Visible=false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try { 
            String nombre = textBox1.Text;
            String address = textBox2.Text;
            Int64 contact = Convert.ToInt64(textBox3.Text);
            int age = Convert.ToInt32(textBox4.Text);
            String genero = comboBox1.Text;
            String blood = textBox5.Text;
            String any = textBox6.Text;
            int pid = Convert.ToInt32(textBox7.Text);
                //conexion  a la base de datos

             SqlConnection connection = new SqlConnection("Data Source=LAPTOP-8UITBRBH;Initial Catalog=hospital;Integrated Security=True");
             SqlCommand cmd = new SqlCommand();
             cmd.Connection = connection;
             cmd.CommandText = " INSERT INTO[dbo].[tbl_AddPat] VALUES ('" + nombre + "','" + address + "'," + contact + "," + age + ",'" + genero + "','" + blood + "','" + any + "'," + pid + ")";
             SqlDataAdapter adapter = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             adapter.Fill(ds);
             }
            catch (Exception ex)
            { 
            MessageBox.Show("NO SE GUARDO informacion");
            }
            //mesnaje de guardado y limpiar los campos
            MessageBox.Show("Paciente guardado");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.ResetText();




        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel3.Visible = false;
            panel2.Visible = false;
            pictureBox5.Visible = false;
            pictureBox3.Visible = false;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            if (textBox8.Text != "" ) { 
            int pid = Convert.ToInt32(textBox8.Text);
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-8UITBRBH;Initial Catalog=hospital;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            //SELECT * FROM [dbo].[PatientMore]
            cmd.CommandText = "SELECT * FROM [dbo].[PatientMore] where pid = " + pid + "";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0]; 

            }



        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int pid = Convert.ToInt32(textBox8.Text);
                String sysmp = textBox9.Text;
                String diag = textBox10.Text;
                 String medicine = textBox11.Text;
                String habitacion = comboBox2.Text;
                String tipohabitacion = comboBox3.Text;

                SqlConnection connection = new SqlConnection("Data Source=LAPTOP-8UITBRBH;Initial Catalog=hospital;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                
                cmd.CommandText = "INSERT INTO [dbo].[PatientMore] VALUES (" +pid + ",'" + sysmp + "','" + diag + "','" + medicine + "','" + habitacion + "','" + tipohabitacion + "')";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Datos no guardados");
             
            }
            MessageBox.Show("Datos guardados");
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            comboBox2.ResetText();
            comboBox3.ResetText();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel3.Visible = false;
            panel2.Visible = false;
            pictureBox3.Visible = false;
        }
    }
}

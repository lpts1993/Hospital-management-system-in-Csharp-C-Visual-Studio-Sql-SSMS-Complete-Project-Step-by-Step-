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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            String username = txtU.Text;
            string password = txtP.Text;

                    
            if (username == "Usuario" || password == "pass123")
            {
                MessageBox.Show("Bienvenid@  " + txtU.Text);
                this.Hide();
                DashBoard das = new DashBoard();
                das.Show();
            }
            else
            {
                MessageBox.Show("Error, usuario o contraseña erroneo ");

            }
        }
    }
}

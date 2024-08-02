using BilliardMangement.DAL___Data_Access_Layer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilliardMangement
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            string password = txbPassword.Text;
            BilliardFacade billiardFacade = new BilliardFacade();
            billiardFacade.Login_Click(username, password);
        }

       

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            BilliardFacade billiardFacade = new BilliardFacade();
            billiardFacade.Form_Closing(e);
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

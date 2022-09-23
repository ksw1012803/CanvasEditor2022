﻿using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationAndLogin
{
    public partial class Registration : Form
    {

        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;

        public Registration()
        {
            InitializeComponent();
            
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\wodnr\OneDrive\바탕 화면\CanvasEditor\RegistrationAndLogin\Database.mdf"";Integrated Security=True");
            cn.Open();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (txtconfirmpassword.Text != string.Empty || txtpassword.Text != string.Empty || txtusername.Text != string.Empty)
            {
                if (txtpassword.Text == txtconfirmpassword.Text)
                {
                    cmd = new SqlCommand("select * from LoginTable where username='" + txtusername.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into LoginTable values(@username,@password)", cn);
                        cmd.Parameters.AddWithValue("username", txtusername.Text);
                        cmd.Parameters.AddWithValue("password", txtpassword.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox6.Dispose();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox7.Dispose();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox8.Dispose();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

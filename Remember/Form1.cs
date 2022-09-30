using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Remember
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Mat khau hoac ten dang nhap khong duoc de trong", MessageBoxIcon.Error.ToString());

            }
            else
            {
                DialogResult = DialogResult.OK;
                MessageBox.Show("Dang Nhap Thanh Cong");

                FileStream fs = new FileStream("BK.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                if (checkacc.Checked == true)
                {
                    Properties.Settings.Default.UserName = txtuser.Text;
                    Properties.Settings.Default.Password = txtPass.Text;
                    sw.WriteLine(txtuser.Text);
                    sw.WriteLine(txtPass.Text);
                    Properties.Settings.Default.Save();
                }
                sw.Close();
                fs.Close();
                if (checkacc.Checked == false)
                {
                    Properties.Settings.Default.UserName = " ";
                    Properties.Settings.Default.Password = " ";
                    Properties.Settings.Default.Save();
                    
                }
                checkacc.Enabled = true;
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.UserName!=string.Empty)
            {
                txtuser.Text = Properties.Settings.Default.UserName;
                txtPass.Text = Properties.Settings.Default.Password;
            }
        }
    }
}

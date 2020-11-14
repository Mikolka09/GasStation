using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form2 : Form
    {
        User user = new User();
        List<User> list = new List<User>();
        Form2 f2;
        public Form2()
        {
            InitializeComponent();
            loadUsers();
            if (list.Count == 0)
            {
                Form3 f3 = new Form3();
                f3.Text = "Регистрация Администратора";
                f3.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            if (list.Count != 0)
            {
                Form3 f3 = new Form3();
                f3.Text = "Регистрация Пользователя";
                if (f3.ShowDialog() == DialogResult.OK)
                {
                    f2 = new Form2();
                    f2.ShowDialog();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class User
        {
            public string name;
            public string login;
            public string pass;

            public User()
            {
                name = "";
                login = "";
                pass = "";
            }
        }

        public void loadUsers()
        {
            if (File.Exists("users.bin"))
            {
                list.Clear();
                using (FileStream fs = new FileStream("users.bin", FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(fs, Encoding.Unicode))
                    {
                        while (br.PeekChar() > -1)
                        {
                            user = new User();
                            user.name = br.ReadString();
                            user.login = br.ReadString();
                            user.pass = br.ReadString();
                            list.Add(user);
                        }
                    }
                }
            }
        }

        public void administratorLogin()
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        public void userLogin()
        {
            Form5 f5 = new Form5();
            f5.Text = "Пользовательское меню";
            f5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadUsers();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                foreach (var item in list)
                {
                    if (item.login == textBox1.Text && item.pass == textBox2.Text && item.login == "admin")
                    { 
                        administratorLogin();
                        break;
                    }
                    else if (item.login == textBox1.Text && item.pass == textBox2.Text && item.login == "user")
                    { 
                        userLogin();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите Логин и Пароль!!!");
                this.Update();
            }
            if (this.DialogResult == DialogResult.OK)
                this.Close();
        }

    }


}

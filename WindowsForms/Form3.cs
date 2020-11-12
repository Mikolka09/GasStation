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
using static WindowsForms.Form2;

namespace WindowsForms
{
    public partial class Form3 : Form
    {
        public User user;
        public List<User> list = new List<User>();
        public Form3()
        {
            InitializeComponent();
            loadUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            user = new User();
            user.name = textBox1.Text;
            bool step = true;
            if (list.Count == 0)
            {
                user.login = textBox2.Text;
                step = true;
            }
            else
            {
                foreach (var item in list)
                {
                    if (item.login != textBox2.Text)
                    {
                        user.login = textBox2.Text;
                        step = true;
                    }
                    else
                    {
                        if (MessageBox.Show("Такой логин уже существует!\n" +
                                           "Попробуйте еще раз!") == DialogResult.OK)
                        {
                            textBox1.Text = user.name;
                            textBox2.Clear();
                            f3.Update();
                            step = false;
                            break;
                        }
                    }
                }
            }

            if (textBox3.Text == textBox4.Text && step == true)
            {
                if (textBox3.Text.Length < 8)
                {
                    if (MessageBox.Show("Пароль меньше 8 символов\n" +
                                       "Попробуйте еще раз!") == DialogResult.OK)
                    {
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox1.Text = user.name;
                        textBox2.Text = user.login;
                        f3.Update();
                        step = false;
                    }
                }
                user.pass = textBox3.Text;
                if (step == true)
                {

                    saveUsers(user);
                    MessageBox.Show("Регистрация прошла УСПЕШНО!!!");
                }
            }
            else if (step == true)
            {
                if (MessageBox.Show("Повторный пароль введен не верно!\n" +
                   "Попробуйте еще раз!") == DialogResult.OK)
                {
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox1.Text = user.name;
                    textBox2.Text = user.login;
                    f3.Update();
                }
            }
            this.DialogResult=DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void saveUsers(User user)
        {
            using (FileStream fs = new FileStream("users.bin", FileMode.Append, FileAccess.Write))
            {
                using (BinaryWriter bw = new BinaryWriter(fs, Encoding.Unicode))
                {
                    bw.Write(user.name);
                    bw.Write(user.login);
                    bw.Write(user.pass);
                }
            }
        }

        public void loadUsers()
        {
            if (File.Exists("users.bin"))
            {
                using (FileStream fs = new FileStream("users.bin", FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs, Encoding.Unicode))
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
}


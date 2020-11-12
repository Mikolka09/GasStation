﻿using System;
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
            if (list == null)
            {
                Form3 f3 = new Form3();
                f3.Text = "Регистрация Администратора";
                if (f3.ShowDialog() == DialogResult.OK)
                {
                    f2 = new Form2();
                    if (f2.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var item in list)
                        {
                            if (textBox1.Text == item.login && item.login == "Admin")
                                if (item.pass == textBox2.Text)
                                    administratorLogin();
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            if (list != null)
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
                using (FileStream fs = new FileStream("users.bin", FileMode.Open))
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

        public void administratorLogin()
        {

        }

        public void userLogin()
        {
            Form1 f1 = new Form1();
            f1.us = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (list != null)
            {
                if (DialogResult == DialogResult.OK)
                {
                    foreach (var item in list)
                    {
                        if (textBox1.Text == item.login && item.login == "Admin")
                            if (item.pass == textBox2.Text)
                                administratorLogin();
                            else if (textBox1.Text == item.login && item.pass == textBox2.Text)
                                userLogin();
                    }
                }
            }
        }
    }


}

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
using static WindowsForms.Form1;

namespace WindowsForms
{

    public partial class Form4 : Form
    {
        List<Gas> gas;
        List<Product> products;
        public bool var;
        public string pole;
        public Form4()
        {
            InitializeComponent();

            gas = new List<Gas>();
            using (var f = new StreamReader("gas.txt", Encoding.GetEncoding(1251)))
            {
                while (!(f.EndOfStream))
                {
                    Gas g = new Gas();
                    g.Name = f.ReadLine();
                    g.Coast = decimal.Parse(f.ReadLine());
                    gas.Add(g);
                }
            }
            foreach (var item in gas)
            {
                comboBox1.Items.Add(item.Name);
            }
            comboBox1.SelectedIndex = 0;

            products = new List<Product>();
            using (var f = new StreamReader("products.txt", Encoding.GetEncoding(1251)))
            {
                while (!(f.EndOfStream))
                {
                    Product p = new Product();
                    p.Name = f.ReadLine();
                    p.Price = decimal.Parse(f.ReadLine());
                    products.Add(p);
                }
            }

            foreach (var item in products)
            {
                comboBox2.Items.Add(item.Name);
            }
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = gas[comboBox1.SelectedIndex].Name.ToString();
            textBox2.Text = gas[comboBox1.SelectedIndex].Coast.ToString();
            var = false;
            pole = "gas";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = products[comboBox2.SelectedIndex].Name.ToString();
            textBox2.Text = products[comboBox2.SelectedIndex].Price.ToString();
            var = false;
            pole = "products";
        }


        public void saveKaffe(List<Product> products, bool var)
        {
            using (StreamWriter sw = new StreamWriter("products.txt", var, System.Text.Encoding.Default))
            {
                foreach (var item in products)
                {
                    sw.WriteLine(item.Name);
                    sw.WriteLine(item.Price);
                }
            }
        }

        public void saveGas(List<Gas> gas, bool var)
        {
            using (StreamWriter sw = new StreamWriter("gas.txt", var, System.Text.Encoding.Default))
            {
                foreach (var item in gas)
                {
                    sw.WriteLine(item.Name);
                    sw.WriteLine(item.Coast);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Gas new_g = new Gas();
                new_g.Name = textBox1.Text;
                new_g.Coast = Convert.ToDecimal(textBox2.Text);
                gas.Add(new_g);
                var = true;
                pole = "gas";
            }
            else
            {
                MessageBox.Show("Заполните Данные!!!");
                this.Update();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Product new_p = new Product();
                new_p.Name = textBox1.Text;
                new_p.Price = Convert.ToDecimal(textBox2.Text);
                products.Add(new_p);
                var = true;
                pole = "products";
            }
            else
            {
                MessageBox.Show("Заполните Данные!!!");
                this.Update();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pole == "gas" && var == false)
            {
                gas[comboBox1.SelectedIndex].Name = textBox1.Text;
                gas[comboBox1.SelectedIndex].Coast = Convert.ToDecimal(textBox2.Text);
                saveGas(gas, var);
                MessageBox.Show("Редактирование выполнено!!!");
            }
            else if (pole == "gas" && var == true)
            { 
                saveGas(gas, var);
                MessageBox.Show("Добавление выполнено!!!");
            }
            if (pole == "products" && var == false)
            {
                products[comboBox1.SelectedIndex].Name = textBox1.Text;
                products[comboBox1.SelectedIndex].Price = Convert.ToDecimal(textBox2.Text);
                saveKaffe(products, var);
                MessageBox.Show("Редактирование выполнено!!!");
            }
            else if (pole == "products" && var == true)
            { 
                saveKaffe(products, var);
                MessageBox.Show("Добавление выполнено!!!");
            }
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            Application.Restart();
        }
    }
}

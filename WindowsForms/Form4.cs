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
        public int index;
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
            index = comboBox1.SelectedIndex;
            pole = "gas_edit";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = products[comboBox2.SelectedIndex].Name.ToString();
            textBox2.Text = products[comboBox2.SelectedIndex].Price.ToString();
            index = comboBox2.SelectedIndex;
            pole = "products_edit";
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
                MessageBox.Show("Добавление выполнено!!!");
                pole = "gas_add";
                textBox1.Clear();
                textBox2.Clear();
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
                MessageBox.Show("Добавление выполнено!!!");
                pole = "products_add";
                textBox1.Clear();
                textBox2.Clear();
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
            if (pole == "gas_edit")
            {
                gas[index].Name = textBox1.Text;
                gas[index].Coast = Convert.ToDecimal(textBox2.Text);
                saveGas(gas, false);
                MessageBox.Show("Редактирование выполнено!!!");
            }
            else if (pole == "gas_add")
            {
                saveGas(gas, false);
            }
            if (pole == "products_edit")
            {
                products[index].Name = textBox1.Text;
                products[index].Price = Convert.ToDecimal(textBox2.Text);
                saveKaffe(products, false);
                MessageBox.Show("Редактирование выполнено!!!");
            }
            else if (pole == "products_add")
            {
                saveKaffe(products, false);
            }
            this.Close();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pole == "gas_edit")
            {
                gas.RemoveAt(index);
                saveGas(gas, false);
            }
            else
            {
                products.RemoveAt(index);
                saveKaffe(products, false);
            }
            MessageBox.Show("Удаление выполнено!!!");
            this.Close();
            Form4 f4 = new Form4();
            f4.Show();
        }
    }
}

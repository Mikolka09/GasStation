using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        List<Gas> gas;
        List<Product> products;
        List<CheckBox> checkBoxes;
        List<TextBox> textBoxes;
        List<NumericUpDown> numericUpDowns;
        public Form1()
        {
            InitializeComponent();

            gas = new List<Gas>
            {
                new Gas{Name = "A-95", Coast = 22.40M},
                new Gas{Name = "A-98", Coast = 25.20M},
                new Gas{Name = "Disel", Coast = 18.80M},
                new Gas{Name = "Gas", Coast = 12.80M}
            };
            foreach (var item in gas)
            {
                comboBox1.Items.Add(item.Name);
            }
            comboBox1.SelectedIndex = 0;

            radioButton1.Checked = true;

            products = new List<Product>
            {
                new Product{Name = "Кофе", Price = 4.50M},
                new Product{Name = "Гамбургер", Price = 20.50M},
                new Product{Name = "Чай", Price = 2.50M},
                new Product{Name = "Сендвич", Price = 15.50M},
                new Product{Name = "Салат", Price = 10.50M},
                new Product{Name = "Хлеб", Price = 5.50M},
                new Product{Name = "Вода", Price = 8.50M},
                new Product{Name = "Пиво", Price = 12.50M},
            };

            checkBoxes = new List<CheckBox>(products.Count);
            textBoxes = new List<TextBox>(products.Count);
            numericUpDowns = new List<NumericUpDown>(products.Count);

            for (int i = 0; i < products.Count; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Location = new System.Drawing.Point(13, 13 + 30 * i);
                checkBox.Size = new System.Drawing.Size(98, 21);
                checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
                checkBox.Text = products[i].Name;
                panel1.Controls.Add(checkBox);
                checkBoxes.Add(checkBox);

                TextBox textBox = new TextBox();
                textBox.Location = new System.Drawing.Point(115, 13 + 30 * i);
                textBox.Size = new System.Drawing.Size(35, 22);
                textBox.Text = products[i].Price.ToString();
                textBox.TextAlign = HorizontalAlignment.Right;
                textBox.Enabled = false;
                textBoxes.Add(textBox);
                panel1.Controls.Add(textBox);

                NumericUpDown numericUpDown = new NumericUpDown();
                numericUpDown.Location = new System.Drawing.Point(155, 13 + 30 * i);
                numericUpDown.Size = new System.Drawing.Size(42, 22);
                numericUpDown.Enabled = false;
                numericUpDown.ValueChanged += new EventHandler(GetSumCafe);
                numericUpDowns.Add(numericUpDown);
                panel1.Controls.Add(numericUpDown);
            }


        }

        class Gas
        {
            public string Name { get; set; }
            public decimal Coast { get; set; }
        }

        class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = gas[comboBox1.SelectedIndex].Coast.ToString();
            GetTotalSum();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox2.Text = "";
            GetTotalSum();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox1.Text = "";
            GetTotalSum();
        }

        void GetTotalSum()
        {
            decimal summ = 0M;
            if(textBox1.Text == "")
                textBox1.Text = "0";
            summ = Math.Round(int.Parse(textBox1.Text) * (decimal.Parse(label1.Text)), 2);
            label2.Text = summ.ToString();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            numericUpDowns[checkBoxes.IndexOf(checkBox)].Enabled = checkBox.Checked;
            numericUpDowns[checkBoxes.IndexOf(checkBox)].Value = 0;
        }

        private void GetSumCafe(object sender, EventArgs e)
        {
            decimal sum = 0M;
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                sum += Math.Round(decimal.Parse(textBoxes[i].Text) * numericUpDowns[i].Value, 2);
            }
            label3.Text = sum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal summa = 0M;
            summa = Math.Round(decimal.Parse(label2.Text) + decimal.Parse(label3.Text), 2);
            label12.Text = summa.ToString();
        }
    }
}

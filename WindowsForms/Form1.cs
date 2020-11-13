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
    public partial class Form1 : Form
    {
        Form2 f2;
        public bool us { get; set;}
        public List<Gas> gas;
        public List<Product> products;
        public List<CheckBox> checkBoxes;
        List<TextBox> textBoxes;
        List<NumericUpDown> numericUpDowns;
        public Form1()
        {
            
                InitializeComponent();
          
            button2.Visible = us;


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

            radioButton1.Checked = true;

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

        public class Gas
        {
            public string Name { get; set; }
            public decimal Coast { get; set; }
        }

        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = gas[comboBox1.SelectedIndex].Coast.ToString();
            GetTotalSum();
            GetTotalKol();
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

        private void GetTotalKol()
        {
            if (textBox2.Text != "")
            {
                decimal kol = 0M;
                kol = Math.Round(decimal.Parse(textBox2.Text) / decimal.Parse(label1.Text), 2);
                textBox1.Text = kol.ToString();
            }
        }

        private void GetTotalSum()
        {
            if (textBox1.Enabled == true)
            {
                decimal summ = 0M;
                if (textBox1.Text == "")
                    textBox1.Text = "0,00";
                summ = Math.Round(decimal.Parse(textBox1.Text) * (decimal.Parse(label1.Text)), 2);
                label2.Text = summ.ToString();
            }
            else
            {
                if (textBox2.Text == "")
                    textBox2.Text = "0,00";
                label2.Text = Math.Round(decimal.Parse(textBox2.Text), 2).ToString();
            }
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
            ChekToPrint();
        }

        private void ChekToPrint()
        {
           
            string chek = $" ЧЕК № {DateTime.Now.Minute}/{DateTime.Now.Second} от {DateTime.Now.ToString()}\n" +
                $"=======================\n" +
                $"  АВТОЗАВПРАВКА:\n" +
                $"  {label5.Text} марка - {comboBox1.Text}\n" +
                $"  {label6.Text} за литр - {label1.Text} грн.\n" +
                $"  Кол-во литров - {textBox1.Text} л\n" +
                $"  К оплату - {label2.Text} грн.\n" +
                $"=======================\n" +
                $"  МИНИ-КАФЕ:\n" +
                $"  К оплате - {label3.Text} грн.\n" +
                $"=======================\n" +
                $"  ВСЕГО к оплате:\n" +
                $"  {label12.Text} грн.\n" +
                $"=======================\n" +
                $" СПАСИБО ЗА ПОКУПКИ!!!";
            MessageBox.Show(chek);
            //if (MessageBox.Show(chek) ==DialogResult.OK)
            //{
            //    SaveChek(chek);
            //}

        }

        private void SaveChek(string chek)
        {
            using (StreamWriter sw = new StreamWriter("cheks.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(chek);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            f2 = new Form2();
            f2.Show();
            this.DialogResult = DialogResult.OK;
        }
    }
}

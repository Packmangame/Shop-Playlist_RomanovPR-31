using System;
using System.Windows.Forms;

namespace Shop
{
    public partial class Form1 : Form
    {
        Product product;
        public Form1()
        {
            InitializeComponent();
        }

        private void MenuStrip1music(object sender, EventArgs e)
        {
            this.Text = "Music";
            //panel2.Visable = true;панель задани€ прак 3
            panel1.Visible = false;
        }

        private void MenuStrip1Shop(object sender, EventArgs e)
        {
            this.Text = "WhiteRoad";
            //panel2.Visable = false;панель задани€ прак 3
            panel1.Visible = true;

            dataGridView1.Columns.Add("Column1", "ID");
            dataGridView1.Columns.Add("Column2", "Name");
            dataGridView1.Columns.Add("Column3", "Count");
            dataGridView1.Columns.Add("Column4", "Price");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }
        int i = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;

            //проверка на вводимых данных
            if (IsLitterals(textBox1.Text) && textBox1.Text != "" &&
                IsDecimals(textBox2.Text) == true &&
                StringIsDigits(textBox3.Text) == true)
            {
                //отдельна€ проверка что количество >0 и < чем верхн€€ граница типа Int
                if (int.Parse(textBox3.Text) > 0 && int.Parse(textBox3.Text) < 2147483647)
                {
                    dataGridView1.Rows.Add(i, textBox1.Text, textBox2.Text, textBox3.Text);
                    Shop pyaterochka = new Shop();
                    pyaterochka.CreateProduct(textBox1.Text, Convert.ToDecimal(textBox2.Text), int.Parse(textBox3.Text));
                    i++;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show("Error", "If count<0 we're can't add");
                }
            }
            else
            {
                MessageBox.Show("Error", "Sytax error");
            }


        }

        bool IsDecimals(string input)
        {
            decimal result;
            if (decimal.TryParse(input, out result))
            {
                //input €вл€етс€ допустимым значением decimal
                return true;
            }
            else
            {
                //input не €вл€етс€ допустимым значением decimal
                return false;
            }

        }

        bool IsLitterals(string value)
        {
            bool OnlyLetters = true;
            // ключ. слово value - это то, что хот€т свойству присвоить
            foreach (var ch in value)
            {
                if (!char.IsLetter(ch))
                {
                    OnlyLetters = false;
                }
            }
            return OnlyLetters;
        }

        bool StringIsDigits(string s)
        {
            foreach (var item in s)
            {
                if (!char.IsDigit(item))
                    return false; //если хоть один символ не число, то выкидываешь "ложь"
            }
            return true; //если ни разу не выбило в цикле, значит, все символы - это цифры
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;

            Shop shesterocka = new Shop();
            for (int y = 0; y < dataGridView1.Rows.Count; y++)
            {
                comboBox1.Items.Add(dataGridView1[1,y].Value);
            }
            label9.Text=product.Price.ToString();


            textBox4.Clear();
        }
    }
}

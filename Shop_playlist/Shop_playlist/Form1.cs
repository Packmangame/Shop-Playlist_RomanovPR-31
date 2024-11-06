using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Shop_playlist
{
    public partial class Form1 : Form
    {
        Shop shop = new Shop();
        Product product;
        public Form1()
        {
            InitializeComponent();
            panel1.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
        }

        private void MenuStrip1music(object sender, EventArgs e)
        {
            this.Text = "Music";
            panel1.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
        }

        private void MenuStrip1Shop(object sender, EventArgs e)
        {
            this.Text = "WhiteRoad";
            panel1.Visible = true;
            panel4.Visible = false;

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
            panel5.Visible = false;
            panel6.Visible = false;
            panel2.Visible = false;
            try
            {
                //добавление айтемов в таблицу + библиотеку класса Shop
                //проверка на вводимых данных
                if (IsLitterals(textBox1.Text) &&
                    IsDecimals(textBox2.Text) == true &&
                    StringIsDigits(textBox3.Text) == true)
                {
                    //отдельная проверка что количество >0 и < чем верхняя граница типа Int
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
            catch
            {
                MessageBox.Show("Check the entered data", "Error");
            }


        }

        bool IsDecimals(string input)
        {
            decimal result;
            if (decimal.TryParse(input, out result))
            {
                //input является допустимым значением decimal
                return true;
            }
            else
            {
                //input не является допустимым значением decimal
                return false;
            }

        }

        bool IsLitterals(string value)
        {
            bool OnlyLetters = true;
            // ключ. слово value - это то, что хотят свойству присвоить
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
            for (int y = 0; y < dataGridView1.Rows.Count; y++)
            {
                comboBox1.Items.Add(dataGridView1[1, y].Value);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;

            Shop shesterocka = new Shop();

            textBox4.Clear();
        }

       private void item(object sender, EventArgs e)
        {
            try
            {
                string name = comboBox1.Text;
                label9.Text = name;
                Product product = shop.FindByName(comboBox1.SelectedItem.ToString());
                label9.Text = $"{product.Price}";
            }
            catch
            { MessageBox.Show("Error", "Such an object doesn't exist"); }
        }




                                        //Ex3 Music






        private void playlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Playlist";
            panel1.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
        }

        private void addSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "AddSong";
            panel1.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }


        //coздание объекта класса
        Playlist playlist= new Playlist();
        string deleteSong = "";


        //метод добавления песен в плейлист
        private void button7_Click(object sender, EventArgs e)
        {
            string author = textBox5.Text;
            string title = textBox6.Text;
            string filename = textBox7.Text;

            try
            {
                playlist.AddSong(author, title, filename);
                listBox2.Items.Add($"{ author}, {title}");
                MessageBox.Show("Добавлена песня '" + title + "'");
                //очищаем поля для нового ввода
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
               
            }
            catch
            {
                MessageBox.Show("Error", "Sytax error");
            }
        }
        //del items in listbox and playlist
        private void button11_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            playlist.Clear();
            label16.Text = "";
        }

        //del only 1 song
        private void button9_Click(object sender, EventArgs e)
        {
            playlist.RemoveSong(listBox2.SelectedIndex);
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }


        //переход между песнями вперед
        private void button8_Click(object sender, EventArgs e)
        {
            try { 
            listBox2.SelectedIndex++;
            label16.Text = listBox2.Text;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        //переход между песнями назад
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                listBox2.SelectedIndex--;
                label16.Text = listBox2.Text;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = 0;
            label16.Text=listBox2.Text;
        }
    }
   
}

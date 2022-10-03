using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Opakovani_LIST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<char> listek = new List<char>();
        List<char> listek2 = new List<char>();
        List<char> specialniznaky = new List<char>();
        List<int> hodnoty = new List<int>();


        private void metoda(List<char> list,Label lbl1, Label lbl2, Label lbl3)
        {
            int pocetA = 0;
            int pocetE = 0;
            bool mezera = false;
            foreach(char znaky in list)
            {
                if (znaky == 'a') pocetA++;
                if (znaky == 'e') pocetE++;
                if (znaky == ' ') mezera = true;
            }
            lbl1.Text = "pocet a =" + pocetA;
            lbl2.Text = "pocet e =" + pocetE;
            lbl3.Text = "Vyskytuje se zde mezera ? " + (mezera? "Ano" : "Ne");
        }


        private void vypis(List <char> list,ListBox listecek)
        {
            string veta = new string(list.ToArray());

            string[] slova = veta.Split(' ');
            foreach(string neco in slova)
            {
                listecek.Items.Add(neco);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listek2.Clear();
            listek.Clear();
            int N = (int)numericUpDown1.Value;
            int pocetE = 0;
            int pocetA = 0;

            Random rnd = new Random();
            for(int i = 0;i < N; i++)
            {
                char znak = (char)rnd.Next(32, 128);
                listek2.Add(znak);

                if(znak <= '9' && znak >= '0')
                {
                    hodnoty.Add(znak - 48);
                }
                if(znak <= '9' && znak >= '0' || znak <= 'Z' && znak >= 'A' || znak <= 'z' && znak >= 'a' || znak == ' ')
                {

                }else specialniznaky.Add(znak);

                //if (znak == 'a') pocetA++;
               // if (znak == 'e') pocetE++;

               // listBox1.Items.Add(znak);
            }

            foreach(char znaky in listek2)
            {
                listek.Add(znaky);
            }

            /*string pepa = new string(listek.ToArray());

            MessageBox.Show("lol " + pepa);*/

            vypis(listek, listBox1);

            listek2.RemoveAll(a => a == ' ');

            foreach(char znaky in listek2)
            {
                textBox1.Text += znaky;
            }


            double pocet = 0;
            double soucet = 0;
            foreach(int cislo in hodnoty)
            {
                soucet += cislo;
                pocet++;
            }
            double vysledek = soucet / pocet;
            if (pocet != 0) MessageBox.Show("Median :" + vysledek);
            else MessageBox.Show("Nejsou zde zadne cisla");


            foreach(char znaky in specialniznaky)
            {
                listBox2.Items.Add(znaky);
            }

            metoda(listek, label4, label5, label6);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

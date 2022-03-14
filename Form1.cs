using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace NetZad2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txtA = textBox1.Text;
            string txtB = textBox2.Text;

            textBox3.Text = textBox1.Text + " " + textBox2.Text;
            textBox4.Text = textBox7.Text;
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
           
            Osoba p = new Osoba();
            p.Imie = textBox3.Text;
            p.Wiek = textBox7.Text;

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Osoba.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, p);
            stream.Close();

            textBox5.Text = "Ukończono Serializacje";
            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream readStream = new FileStream("Osoba.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            Osoba p2 = (Osoba)formatter.Deserialize(readStream);
            readStream.Close();

            textBox5.Text = "Ukończono Deserializacje";
            textBox6.Text = p2.Imie + " Lat: " + p2.Wiek;
        }

        [Serializable]
        class Osoba
        {
            private string imie;
            private string wiek;
          
            public string Imie
            {
                set { imie = value; }
                get { return imie; }            
            }

            public string Wiek
            {
                set { wiek = value; }
                get { return wiek; }

            }


        }

        
    }
}

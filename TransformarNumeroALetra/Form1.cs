using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransformarNumeroALetra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int numero;

            int.TryParse(txtNumero.Text,out numero);

            String response = Util.NumberToWord(numero);

            ListViewItem item = new ListViewItem();

            item.Text = numero.ToString();

            item.SubItems.Add(response);

            listView.Items.Add(item);

        }
    }
}

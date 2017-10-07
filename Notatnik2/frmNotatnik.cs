using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Notatnik
{
    public partial class frmNotatnik : Form
    {
        public frmNotatnik()
        {
            InitializeComponent();
        }
        string plik = "";
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtTresc.Text != "")
            {
                DialogResult odp = czyzapisac();
                if (odp == DialogResult.Cancel)
                    return;
                plik = "";
                txtTresc.Clear();
            }
        }
        private DialogResult czyzapisac()
        {
            DialogResult odp = MessageBox.Show("Chcesz zapisać zmiany?", "Notatnik",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            if (odp == DialogResult.Yes)
                zapiszToolStripMenuItem_Click(null, null);
            return odp;
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtTresc.Text != "")
            {
                DialogResult odp = czyzapisac();
                if (odp == DialogResult.Cancel)
                    return;
                plik = "";
                txtTresc.Clear();
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Plik tekstowy (*.txt)|*.txt";
            dialog.Multiselect = false;
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                plik = dialog.FileName;
                StreamReader f = new StreamReader(plik);
                txtTresc.Text = f.ReadToEnd();
                f.Close();
            }
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (plik != "")
            {
                StreamWriter f = new StreamWriter(plik);
                f.Write(txtTresc.Text);
                f.Close();
            }
            else zapiszJakoToolStripMenuItem_Click(sender, e);
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Plik tekstowy (*.txt)|*.txt";
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                plik = dialog.FileName;
                StreamWriter f = new StreamWriter(plik);
                f.Write(txtTresc.Text);
                f.Close();
            }
        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtTresc.Text != "")
            {
                DialogResult odp = czyzapisac();
                if (odp == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
       
       

        private void txtTresc_TextChanged(object sender, EventArgs e)
        {

        }

        private void formatujToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
           
        }

        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
         MessageBox.Show("Dariusz Ghaemi 2017 inspired by CentrumXP.pl");
        }

        private void zmieńTłoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtTresc.BackColor = colorDialog1.Color; 
            }
        }

        private void formatujToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Font font = fontDialog.Font;
                this.txtTresc.Text = string.Format("");
                this.txtTresc.Font = font;
            }
        }

       
       
    }
}

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
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContenClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mVCDBDataSet.Book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.mVCDBDataSet.Book);
            using (MVCDBDataSet db = new MVCDBDataSet())
            {
             bookBindingSource.DataSource = db.Book.ToList();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0,0);

        }
        Bitmap bmp;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Graphics g=this.CreateGraphics();
            bmp = new Bitmap(this.Size.Height,this.Size.Width,g);
            Graphics mg=Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }

        private void dataGridView2_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {

        }
    }
}

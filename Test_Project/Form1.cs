using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.MVVM;
using DevExpress.XtraPrinting;
using Test_Project.Entity;

namespace Test_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MalKodu();
        }


        void Listele()
        {
            TestEntities db = new TestEntities();

            DateTime dt = Convert.ToDateTime(textEdit2.Text);
            int baslangic = Convert.ToInt32(dt.ToOADate());

            DateTime dt2 = Convert.ToDateTime(textEdit1.Text);
            int bitis = Convert.ToInt32(dt2.ToOADate());

            gridControl1.DataSource = db.TestProcedure("", baslangic, bitis).ToList();
            gridView1.Columns["MalKodu"].Visible = false;
        }

        void Ara()
        {
            TestEntities db = new TestEntities();
            var malKodu = lookUpEdit1.Text;
            gridControl1.DataSource = db.TestProcedure(malKodu, null, null).ToList();
            gridView1.Columns["MalKodu"].Visible = false;
        }

        void MalKodu()
        {
            TestEntities db = new TestEntities();
            var malKodu = (from x in db.STK select new { x.MalKodu }).ToList();
            lookUpEdit1.Properties.DisplayMember = "MalKodu";
            lookUpEdit1.Properties.DataSource = malKodu;
            
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Ara();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = gridControl1; 
            link.Landscape = true; 
            link.ShowPreview();
        }
    }
}

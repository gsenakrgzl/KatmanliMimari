using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using entitylayer;
using dataaccesslayer;
using businesslayer;

namespace katman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void listele()
        {
            dataGridView1.DataSource = DataMusteri.musteriListele();
            tbid.Text = "";
            tbAd.Text = "";
            tbSoyad.Text = "";
            tbAdres.Text = "";
            tbTel.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if(tbAd.Text == "" && tbSoyad.Text == "")
            {
                MessageBox.Show("Tüm alanları Giriniz.", "Hata");
            }
            else
            {
                EntityMusteri musteri = new EntityMusteri();
                musteri.ad = tbAd.Text;
                musteri.soyad = tbSoyad.Text;
                musteri.adres = tbAdres.Text;
                musteri.tel =int.Parse( tbTel.Text);
                BusinessMusteri.musteriEkle(musteri);
                MessageBox.Show("Kayıt Tamamlandı.");
            }
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(tbid.Text == null)
            {
                MessageBox.Show("Silinecek Kişiyi Seçiniz.");
            }
            else
            {
                EntityMusteri musteri = new EntityMusteri();
                musteri.id = int.Parse(tbid.Text);
                BusinessMusteri.musteriSil(musteri);
                MessageBox.Show("Silme İşlemi Başarılı.");
            }
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbAdres.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbTel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (tbAd.Text == "" && tbSoyad.Text == "")
            {
                MessageBox.Show("Güncellenecek Kişiyi Seçiniz.", "Hata");
            }
            else
            {
                EntityMusteri musteri = new EntityMusteri();
                musteri.id = int.Parse(tbid.Text) ;
                musteri.ad = tbAd.Text;
                musteri.soyad = tbSoyad.Text;
                musteri.adres = tbAdres.Text;
                musteri.tel = int.Parse(tbTel.Text);
                BusinessMusteri.musteriGuncelle(musteri);
                MessageBox.Show("Güncelleme Tamamlandı.");
            }
            listele();
        }

        private void tbid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

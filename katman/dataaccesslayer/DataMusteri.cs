using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitylayer;
using MySql.Data.MySqlClient;

namespace dataaccesslayer
{
    public class DataMusteri
    {
        public static int musteriEkle(EntityMusteri p)
        {
            MySqlCommand komut = new MySqlCommand("Insert Into musteri (ad, soyad, adres, tel) values (@p1, @p2, @p3, @p4)",baglanti.baglan);
            if(komut.Connection.State!= System.Data.ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@p1", p.ad);
            komut.Parameters.AddWithValue("@p2", p.soyad);
            komut.Parameters.AddWithValue("@p3", p.adres);
            komut.Parameters.AddWithValue("@p4", p.tel);
            return komut.ExecuteNonQuery();
        }

        public static int musteriSil(EntityMusteri p)
        {
            MySqlCommand komut = new MySqlCommand("Delete from musteri where id = @p1", baglanti.baglan);
            if (komut.Connection.State != System.Data.ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@p1", p.id);

            return komut.ExecuteNonQuery();
        }

        public static int musteriGuncelle(EntityMusteri p)
        {
            MySqlCommand komut = new MySqlCommand("Update musteri set ad = @p1, soyad = @p2, adres = @p3, tel = @p4 where id = @p5", baglanti.baglan);
            if (komut.Connection.State != System.Data.ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@p1", p.ad);
            komut.Parameters.AddWithValue("@p2", p.soyad);
            komut.Parameters.AddWithValue("@p3", p.adres);
            komut.Parameters.AddWithValue("@p4", p.tel);
            komut.Parameters.AddWithValue("@p5", p.id);

            return komut.ExecuteNonQuery();
        }

        public static List<EntityMusteri> musteriListele()
        {
            MySqlCommand komut = new MySqlCommand("Select * from musteri", baglanti.baglan);
            if (komut.Connection.State != System.Data.ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            MySqlDataReader dataread = komut.ExecuteReader();
            List< EntityMusteri> musteriler = new List<EntityMusteri> ();
            while(dataread.Read())
            {
                EntityMusteri ent = new EntityMusteri ();
                ent.id = int.Parse(dataread[0].ToString());
                ent.ad = dataread[1].ToString();
                ent.soyad = dataread[2].ToString();
                ent.adres = dataread[3].ToString();
                ent.tel = int.Parse(dataread[4].ToString());
                musteriler.Add (ent);
            }
            dataread.Close();
            return musteriler;
        }
    }   
}


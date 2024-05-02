using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitylayer;
using dataaccesslayer;

namespace businesslayer
{
    public class BusinessMusteri
    {
        public static int musteriEkle(EntityMusteri p)
        {
            if(p.ad!=null && p.soyad!=null && p.ad.Length >2 && p.ad.Length < 15 && p.adres!=null && p.tel!=null)
            {
               return DataMusteri.musteriEkle(p);
            }
            else
            {
                return -1;
            }
        }
        public static int musteriSil(EntityMusteri p)
        {
            if(p.id>0)
            {
                return DataMusteri.musteriSil(p);
            }
            else
            {
                return -1;
            }
        }
        public static int musteriGuncelle(EntityMusteri p)
        {
            if (p.ad != null && p.soyad != null && p.ad.Length > 2 && p.ad.Length < 15 && p.adres != null && p.tel != null)
            {
                return DataMusteri.musteriGuncelle(p);
            }
            else
            {
                return -1;
            }
        }
        public static List<EntityMusteri> musteriListele()
        {
            return DataMusteri.musteriListele();
        }
    }
}

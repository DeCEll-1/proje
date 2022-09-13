using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.sql_stuff;
using System.Runtime.InteropServices.WindowsRuntime;

namespace DataAccessLayer
{
    internal class DataModel
    {
        IDbConnection dbConnection = new SqlConnection(ConnectionString.ConStrLocal);
        #region Validasyonlar
        public string EpostaValidasyon(string Eposta)
        {
            string validEposta = "";
            int sayac = 0;
            try
            {
                foreach (char item in Eposta)
                {
                    bool s = true;
                    if (!s)
                    {
                        break;
                    }
                    for (int i = 0; i < Eposta.Length; i++)
                    {
                        if (item != ' ' && item != '@' && item != '.')
                        {
                            validEposta += item;
                            break;
                        }
                        else if (item == '@' && sayac == 0)
                        {
                            sayac += 1;
                            validEposta += item;
                            break;
                        }
                        else if (item == '.')
                        {
                            validEposta += ".com";

                            break;
                        }
                    }
                }

                return validEposta;

            }
            catch (Exception)
            {

                return null;
            }



        }
        public string NullVeBoslukKontrol(string text)
        {
            string securedtxt = "";
            foreach (char item in text)
            {
                if (item != ' ')
                {
                    securedtxt += item;
                }
            }
            return securedtxt;
        }
        public bool UniqueEposta(string Eposta)
        {
            try
            {
                dbConnection.Open();

                int sayi = dbConnection.ExecuteScalar<int>("SELECT * FROM Kullaniciler WHERE Eposta = @Eposta", new { Eposta });
                if (sayi != 1)
                {
                    sayi = dbConnection.ExecuteScalar<int>("SELECT * FROM Yoneticiler WHERE Eposta = @Eposta", new { Eposta });
                    if (sayi != 1)
                    {
                        return true;
                    }
                }
                return false;

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public bool UniqueKategori(string Kategori)
        {
            try
            {
                int sayi = dbConnection.ExecuteScalar<int>("ELECT * FROM Kategoriler " +
                    "WHERE KategoriAdi = @Kategori", new { Kategori });
                if (sayi != 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                dbConnection.Close();
            }

        }
        #endregion
        #region Giriş Metotları
        public Yoneticiler GirisYap(string Eposta, string Sifre)
        {
            try
            {
                dbConnection.Open();
                int sayi = dbConnection.ExecuteScalar<int>("SELECT COUNT(*) FROM Yoneticiler WHERE Eposta = @Eposta AND Sifre = @Sifre AND IsDeleted = 0", new { Eposta, Sifre} );
                if (sayi == 1)
                {
                    Yoneticiler y = dbConnection.QueryFirst<Yoneticiler>("SELECT yon.ID, yon.YetkiID, yet.YetkiAdi, yon.Adi ,yon.SoyAdi, yon.KullaniciAdi, yon.Eposta , yon.Sifre, yon.IsDeleted  FROM Yoneticiler AS yon JOIN Yetkiler AS yet ON Yon.YetkiID = yet.ID WHERE Yon.Eposta = @Eposta", new { Eposta });
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch 
            {
                return null;
            }
            finally { dbConnection.Close(); }
        }

        public Kullaniciler KullaniciGirisiYap(string Eposta, string Sifre)
        {
            try
            {
                dbConnection.Open();
                int sayi = dbConnection.ExecuteScalar<int>("SELECT COUNT(*) FROM Kullaniciler WHERE Eposta = @Eposta AND Sifre = @Sifre AND IsDeleted = 0", new { Eposta, Sifre });
                if (sayi == 1)
                {
                    Kullaniciler y = dbConnection.QueryFirst<Kullaniciler>("SELECT ID, KullaniciAdi, Eposta, Sifre, UyelikTarihi, DogunTarihi, IsDeleted FROM Kullaniciler WHERE Eposta = @Eposta", new { Eposta });
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally { dbConnection.Close(); }
        }
        #endregion
        #region Yönetici CRUD +listnget
        public List<Yoneticiler> YoneticiListele(bool IsDeleted)
        {
            try
            {
                dbConnection.Open();
                List<Yoneticiler> yoneticiler = dbConnection.Query<Yoneticiler>("SELECT yon.ID, yon.YetkiID, yet.YetkiAdi, yon.Adi ,yon.SoyAdi, yon.KullaniciAdi, yon.Eposta , yon.Sifre, yon.IsDeleted  FROM Yoneticiler AS yon JOIN Yetkiler AS yet ON Yon.YetkiID = yet.ID WHERE Yon.IsDeleted = @IsDelete", new { IsDeleted }).ToList();
                return yoneticiler;
            }
            catch (Exception)
            {
                return null;
            }
            finally { dbConnection.Close(); }
        }
        public bool YoneticiEkle(Yoneticiler y)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Yoneticiler(YetkiID,Adi,SoyAdi,KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogunTarihi,IsDeleted) VALUES(@YetkiID,@Adi,@SoyAdi,@KullaniciAdi,@Eposta,@Sifre,@UyelikTarihi,@DogunTarihi,@IsDeleted)", new { y });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { dbConnection.Close(); }
        }
        public bool YoneticiSilGuncelle(int IsDeleted,int ID)
        {

            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Yoneticiler SET IsDeleted = @IsDeleted WHERE ID = @ID", new { ID });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { dbConnection.Close(); }
        }
        public Yoneticiler GetYonetici(int ID)
        {
            try
            {
                Yoneticiler y = dbConnection.QueryFirst<Yoneticiler>("SELECT yon.ID, yon.YetkiID, yet.YetkiAdi, yon.Adi ,yon.SoyAdi, yon.KullaniciAdi, yon.Eposta , yon.Sifre, yon.IsDeleted  FROM Yoneticiler AS yon JOIN Yetkiler AS yet ON Yon.YetkiID = yet.ID WHERE Yon.ID = @ID", new { ID });
                return y;
            }
            catch (Exception)
            {
                return null;
            }
            finally { dbConnection.Close(); }
        }
        public bool YoneticiGuncelle(Yoneticiler y)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Yoneticiler SET YetkiID=@YetkiID, Adi=@Adi,SoyAdi=@SoyAdi,KullaniciAdi=@KullaniciAdi,Eposta=@Eposta,Sifre=@Sifre WHERE ID=@ID", new { y });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { dbConnection.Close(); }
        }
        #endregion
        #region kategori CRUD+listnget
        /// <summary>
        /// true ise silinenleri gösterir
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public List<Kategoriler> KategoriListele(bool a)
        {
            try
            {
                if (a)
                {
                    int IsDeleted = 1;
                }
                else
                {
                    int IsDeleted = 0;
                }
                dbConnection.Open();
                List<Yoneticiler> kategoriler = dbConnection.Query<Kategoriler>("SELECT * FROM Kategoriler WHERE IsDeleted = @IsDeleted", new {IsDeleted}).ToList();
                return kategoriler;
            }
            catch (Exception)
            {
                return null;
            }
            finally { dbConnection.Close(); }
        }
        public bool KategoriEkle(Yoneticiler y)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Kategoriler(KategoriAdi,IsDeleted) VALUES(@KategoriAdi,@IsDeleted)", new { y });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { dbConnection.Close(); }
        }
        public bool KategoriSilGuncelle(int IsDeleted,int ID)
        {

            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Kategoriler SET IsDeleted = @IsDeleted WHERE ID = @ID", new { IsDeleted, ID });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { dbConnection.Close(); }
        }
        public Kategori GetKategori(int ID)
        {
            try
            {
                Kategori y = dbConnection.QueryFirst<Kategori>("SELECT * FROM Kategoriler WHERE IsDeleted = @IsDeleted", new { ID });
                return y;
            }
            catch (Exception)
            {
                return null;
            }
            finally { dbConnection.Close(); }
        }
        public bool KategoriGuncelle(Yoneticiler y)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Kategoriler SET KategoriAdi=@KategoriAdi WHERE ID = @ID", new { y });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { dbConnection.Close(); }
        }
        #endregion
        #region Makale CRUD+listnget
        public List<Makaleler> MakaleListele(bool IsDeleted)
        {
            try
            {
                dbConnection.Open();
                List<Yoneticiler> kategoriler = dbConnection.Query<Kategori>("mak.YoneticiID,mak.Baslik,mak.ID, mak.KategoriID,mak.Ozet,mak.Tamicerik,mak.ThumbnailAdi,TamResimAdi,mak.YuklemeTarihi,mak.Okundu,mak.IsDeleted,kat.KategoriAdi,yon.Adi,yet.YetkiAdi FROM Makaleler AS mak JOIN Yoneticiler AS yon ON Mak.YoneticiID = yon.ID JOIN Kategoriler AS kat ON Mak.KategoriID = kat.ID JOIN Yetkiler AS yet ON Yon.YetkiID = Yet.ID WHERE mak.IsDeleted =@IsDeleted", new { IsDeleted });
                return kategoriler;
            }
            catch (Exception)
            {
                return null;
            }
            finally { dbConnection.Close(); }
        }
        public bool MakaleEkle(Kategoriler y)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Makaleler(KategoriID,YoneticiID,Baslik,Ozet,Tamicerik,ThumbnailAdi,TamResimAdi,YuklemeTarihi,Okundu,IsDeleted) VALUES(@KategoriID,@YoneticiID,@Baslik,@Ozet,@TamIcerik,@ThumbnailAdi,@TamResimAdi,@YuklemeTarih,@Okundu, @IsDeleted)", new { y });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { dbConnection.Close(); }
        }
        public bool MakaleSilGuncelle(int IsDeleted,int ID)
        {

            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Makaleler SET IsDeleted = @IsDeleted WHERE ID=@ID", new {IsDeleted, ID });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { dbConnection.Close(); }
        }
        public Kategoriler GetKategori(int ID)
        {
            try
            {
                Kategoriler y = dbConnection.QueryFirst<Kategoriler>("SELECT * FROM Kategoriler WHERE IsDeleted = @IsDeleted", new { ID });
                return y;
            }
            catch (Exception)
            {
                return null;
            }
            finally { dbConnection.Close(); }
        }
        public bool KategoriGuncelle(Yoneticiler y)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Kategoriler SET KategoriAdi=@KategoriAdi WHERE ID = @ID", new { y });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { dbConnection.Close(); }
        }

        #endregion


    }
}

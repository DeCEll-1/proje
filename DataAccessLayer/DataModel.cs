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
    public class DataModel
    {
        IDbConnection dbConnection = new SqlConnection(ConnectionString.ConStrLocal);
        //tamam
        #region Validasyonlar
        public bool ValidEposta(string eposta)
        {
            int sayac = 0;
            string trueeposta = "";
            foreach (char item in eposta)
            {
                if (item != '@' && item != '.' && item != ' ')
                {
                    trueeposta += item;
                }
                else if (item == '@' && sayac == 0)
                {
                    sayac = 1;
                    trueeposta += item;
                }
                else if (item == '.')
                {
                    trueeposta += ".com";
                }
            }
            sayac = 0;
            foreach (char item in trueeposta)
            {
                if (item == '@')
                {
                    sayac++;
                }
                else if (item == '.')
                {
                    sayac++;
                }
            }
            if (sayac == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// boşsa true gönderir
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool NullVeBoslukKontrol(string text)
        {
            bool a = true;
            if (text == "")
            {
                return false;
            }
            foreach (char item in text)
            {
                if (item == ' ')
                {
                    a = false;
                }
            }
            return a;
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
        //tamam
        #region Giriş Metotları
        public Yoneticiler GirisYap(string Eposta, string Sifre)
        {
            try
            {
                dbConnection.Open();
                int sayi = dbConnection.ExecuteScalar<int>("SELECT COUNT(*) FROM Yoneticiler WHERE Eposta = @Eposta AND Sifre = @Sifre AND IsDeleted = 0", new { Eposta, Sifre });
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
        //tamam
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
        public bool YoneticiSilGuncelle(int IsDeleted, int ID)
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
        //tamam
        #region Like CRUD
        //tamam
        public bool LikeEkle(Likelar l)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Likelar(YorumID,KullaniciID,Tur) VALUES(@YorumID,@KullaniciID,@Tur)", l);
                return true;
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
        //tamam
        public List<Likelar> LikeListele(int ID)
        {
            try
            {
                dbConnection.Open();
                List<Likelar> like = dbConnection.Query<Likelar>("SELECT li.Tur FROM Likelar AS li WHERE li.YorumID = @ID", new { ID }).ToList();
                return like;
            }
            catch (Exception)
            {
                return null;
            }
            finally { dbConnection.Close(); }
        }
        #endregion
        //tamam
        #region kategori CRUD+listnget
        //tamam
        public List<Kategoriler> KategoriListele(bool IsDeleted)
        {
            try
            {

                dbConnection.Open();
                List<Kategoriler> kategoriler = dbConnection.Query<Kategoriler>("SELECT * FROM Kategoriler WHERE IsDeleted = @IsDeleted", new { IsDeleted }).ToList();
                return kategoriler;
            }
            catch (Exception)
            {
                return null;
            }
            finally { dbConnection.Close(); }
        }
        //tamam
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
        //tamam
        public bool KategoriSilGuncelle(int IsDeleted, int ID)
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
        //tamam
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
        //tamam
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
        //tamam
        #region Makale CRUD+listnget
        //tamam
        public List<Makaleler> MakaleListele(bool IsDeleted)
        {
            try
            {
                dbConnection.Open();
                List<Makaleler> kategoriler = dbConnection.Query<Makaleler>("mak.YoneticiID,mak.Baslik,mak.ID, mak.KategoriID,mak.Ozet,mak.Tamicerik,mak.ThumbnailAdi,TamResimAdi,mak.YuklemeTarihi,mak.Okundu,mak.IsDeleted,kat.KategoriAdi,yon.Adi,yet.YetkiAdi FROM Makaleler AS mak JOIN Yoneticiler AS yon ON Mak.YoneticiID = yon.ID JOIN Kategoriler AS kat ON Mak.KategoriID = kat.ID JOIN Yetkiler AS yet ON Yon.YetkiID = Yet.ID WHERE mak.IsDeleted =@IsDeleted", new { IsDeleted }).ToList();
                return kategoriler;
            }
            catch (Exception)
            {
                return null;
            }
            finally { dbConnection.Close(); }
        }
        public List<Makaleler> MakaleListele()
        {
            try
            {
                dbConnection.Open();
                List<Makaleler> kategoriler = dbConnection.Query<Makaleler>("mak.YoneticiID,mak.Baslik,mak.ID, mak.KategoriID,mak.Ozet,mak.Tamicerik,mak.ThumbnailAdi,mak.TamResimAdi,mak.YuklemeTarihi,mak.Okundu,mak.IsDeleted,kat.KategoriAdi,yon.Adi,yet.YetkiAdi FROM Makaleler AS mak JOIN Yoneticiler AS yon ON Mak.YoneticiID = yon.ID JOIN Kategoriler AS kat ON Mak.KategoriID = kat.ID JOIN Yetkiler AS yet ON Yon.YetkiID = Yet.ID").ToList();
                return kategoriler;
            }
            catch (Exception)
            {
                return null;
            }
            finally { dbConnection.Close(); }
        }
        //tamam
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
        //tamam
        public bool MakaleSilGuncelle(bool IsDeleted, int ID)
        {

            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Makaleler SET IsDeleted = @IsDeleted WHERE ID=@ID", new { IsDeleted, ID });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { dbConnection.Close(); }
        }
        //tamam
        public Makaleler GetMakale(int ID)
        {
            try
            {
                dbConnection.Open();
                Makaleler m = dbConnection.QueryFirst<Makaleler>("SELECT Mak.ID,Mak.KategoriID,Kat.KategoriAdi,Mak.YoneticiID,Yon.Adi,Yet.YetkiAdi,Mak.Baslik,Mak.Ozet,Mak.Tamicerik,Mak.ThumbnailAdi,Mak.TamResimAdi,Mak.YuklemeTarihi,Mak.Okundu,Mak.IsDeleted FROM Makaleler AS Mak JOIN Yoneticiler AS Yon ON Mak.YoneticiID = Yon.ID JOIN Kategoriler AS Kat ON Mak.KategoriID = Kat.ID JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE Mak.ID = @ID", new { ID });
                return m;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        //tamam
        public bool MakaleGuncelle(Makaleler m)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Makaleler SET KategoriID=@KategoriID,Baslik=@Baslik,Ozet=@Ozet,Tamicerik=@Tamicerik,ThumbnailAdi=@ThumbnailAdi,TamResimAdi=@TamResimAdi,IsDeleted =@IsDeleted WHERE ID = @ID", m);
                return true;
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
        //tamam
        #region Kullanıcı CRUD
        //tamam
        public bool KullaniciEkle(Kullaniciler k)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Kullaniciler(KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogunTarihi,OzelSoru,IsDeleted) VALUES(@KullaniciAdi,@Eposta,@Sifre,@UyelikTarihi,@DogunTarihi,@OzelSoru,@IsDeleted)", k);
                return true;
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
        //tamam
        public bool KullaniciGuncelle(Kullaniciler k)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Kullaniciler SET KullaniciAdi = @KullaniciAdi,Eposta = @Eposta,Sifre = @Sifre,IsDeleted = @IsDeleted WHERE ID = @ID", k);
                return true;
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
        //tamam
        public bool KullaniciSil(int ID, bool IsDeleted)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Kullaniciler SET IsDeleted = @IsDeleted WHERE ID = @ID", new { IsDeleted, ID });
                return true;
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
        //tamam
        public List<Kullaniciler> KullaniciListele(bool IsDeleted)
        {
            try
            {
                dbConnection.Open();
                List<Kullaniciler> kullanicilar = dbConnection.Query<Kullaniciler>("SELECT ID,KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogunTarihi,IsDeleted FROM Kullaniciler WHERE IsDeleted = @isDeleted", new { IsDeleted }).ToList();
                return kullanicilar;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        //tamam
        public List<Kullaniciler> KullaniciListele()
        {
            try
            {
                dbConnection.Open();
                List<Kullaniciler> kullanicilar = dbConnection.Query<Kullaniciler>("SELECT ID,KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogunTarihi,IsDeleted FROM Kullaniciler").ToList();
                return kullanicilar;

            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        //tamam
        public Kullaniciler KullaniciGetir(int ID)
        {
            try
            {
                dbConnection.Open();
                Kullaniciler k = dbConnection.QueryFirstOrDefault<Kullaniciler>("SELECT ID,KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogunTarihi,IsDeleted FROM Kullaniciler WHERE ID = @ID", new { ID });
                return k;

            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        #endregion
        //tamam
        #region Yorum CRUD
        //tamam
        public bool YorumEkle(Yorumlar y)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Yorumlar(MakaleID,KullaniciAdi,KullaniciID,Icerik,YorumTarihi,YorumLike,IsDeleted) VALUES(@MakaleID,@KullaniciAdi,@KullaniciID,@Icerik,@YorumTarihi,@YorumLike,@IsDeleted)", y);
                return true;
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
        //tamam
        public List<Yorumlar> YorumListele()
        {
            try
            {
                dbConnection.Open();
                List<Yorumlar> yorumlar = dbConnection.Query<Yorumlar>("SELECT yor.MakaleID, kul.KullaniciAdi, yor.KullaniciID, mak.Baslik, yor.Icerik, yor.YorumTarihi, yor.YorumLike, yor.IsDeleted FROM Yorumlar AS yor JOIN Kullaniciler AS kul ON yor.KullaniciID = kul.ID JOIN Makaleler AS mak ON yor.MakaleID = mak.ID").ToList();
                return yorumlar;

            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        //tamam
        public List<Yorumlar> YorumListele(int IsDeleted, int MakID)
        {
            try
            {
                dbConnection.Open();
                List<Yorumlar> yorumlar = dbConnection.Query<Yorumlar>("SELECT yor.MakaleID, kul.KullaniciAdi, yor.KullaniciID, mak.Baslik, yor.Icerik, yor.YorumTarihi, yor.YorumLike, yor.IsDeleted FROM Yorumlar AS yor JOIN Kullaniciler AS kul ON yor.KullaniciID = kul.ID JOIN Makaleler AS mak ON yor.MakaleID = mak.ID WHERE yor.IsDeleted = @IsDeleted AND mak.ID=@MakID", new { IsDeleted, MakID }).ToList();
                return yorumlar;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        //tamam
        public List<Yorumlar> YorumListele(bool IsDeleted)
        {
            try
            {
                dbConnection.Open();
                List<Yorumlar> yorumlar = dbConnection.Query<Yorumlar>("SELECT yor.MakaleID, kul.KullaniciAdi, yor.KullaniciID, mak.Baslik, yor.Icerik, yor.YorumTarihi, yor.YorumLike, yor.IsDeleted FROM Yorumlar AS yor JOIN Kullaniciler AS kul ON yor.KullaniciID = kul.ID JOIN Makaleler AS mak ON yor.MakaleID = mak.ID WHERE yor.IsDeleted = @IsDeleted", new { IsDeleted }).ToList();
                return yorumlar;

            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        //tamam
        public bool YorumSil(int ID, bool IsDeleted)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Yorumlar SET IsDeleted = @IsDeleted WHERE ID = @ID", new { IsDeleted, ID});
                return true;
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
        //tamam
        public bool YorumKaliciSil(int ID)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Yorumlar WHERE ID=@id", new { ID });
                return true;
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

    }
}

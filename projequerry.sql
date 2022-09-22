--listeleler start
-------------------
--listele yönetici
SELECT Yon.ID,Yon.YetkiID,Yet.YetkiAdi,Yon.Adi,Yon.Soyadi,Yon.KullaniciAdi,Yon.Eposta,Yon.Sifre,Yon.UyelikTarihi,Yon.DogunTarihi,Yon.IsDeleted FROM Yoneticiler AS Yon JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE IsDeleted = @IsDeleted
--listele kategori
SELECT * FROM Kategoriler WHERE IsDeleted = 0
--listele makaleler
SELECT Mak.ID,Mak.KategoriID,Kat.KategoriAdi,Mak.YoneticiID,Yon.Adi,Yet.YetkiAdi,Mak.Baslik,Mak.Ozet,Mak.Tamicerik,Mak.ThumbnailAdi,Mak.TamResimAdi,YuklemeTarihi,Mak.Okundu,Mak.IsDeleted FROM Makaleler AS Mak JOIN Yoneticiler AS Yon ON Mak.YoneticiID = Yon.ID JOIN Kategoriler AS Kat ON Mak.KategoriID = Kat.ID JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE Mak.IsDeleted =0 AND Mak.KategoriID=1
--listele kullanýcýlar
SELECT ID,KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogunTarihi,IsDeleted FROM Kullaniciler WHERE IsDeleted = 1
--listele yorum
SELECT yor.MakaleID,yor.KullaniciAdi, yor.KullaniciID, yor.Icerik,yor.YorumTarihi,yor.YorumLike,yor.IsDeleted  FROM Yorumlar AS yor JOIN Makaleler AS mak ON  yor.MakaleID = mak.ID JOIN Kullaniciler AS kul ON yor.KullaniciID = kul.ID JOIN Kategoriler AS kat ON mak.KategoriID = kat.ID WHERE yor.IsDeleted = 1
--listele like
SELECT li.Tur FROM Likelar AS li WHERE li.YorumID = @ID
-------------------
--listeleler end
--/////////////////////////
--ekleler start
-------------------
--ekle yönetici
INSERT INTO Yoneticiler(YetkiID,Adi,Soyadi,KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogunTarihi,IsDeleted) VALUES(1,'root','root','root','root@gmail.com','root',2020-08-08,2020-08-08,0)
--ekle kategori
INSERT INTO Kategoriler(KategoriAdi,IsDeleted) VALUES('çaylý yemekler',0)
--ekle makale
INSERT INTO Makaleler(KategoriID,YoneticiID,Baslik,Ozet,Tamicerik,ThumbnailAdi,TamResimAdi,YuklemeTarihi,Okundu,IsDeleted) VALUES(1,2,'test','amogus','<instert full text here>',NULL,NULL,2020-08-08,0,0)
--ekle kullanýcý
INSERT INTO Kullaniciler(KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogunTarihi,OzelSoru,IsDeleted) VALUES('hacý','HacýnýnÞalgamý@gmail.com','gýrmýzý',2020-08-08,2020-08-08,'þalgam',0)
--ekle yorum
INSERT INTO Yorumlar(MakaleID,KullaniciID,Icerik,YorumTarihi,YorumLike,IsDeleted,KullaniciAdi) VALUES(4,1,'çok iyi',2020-08-08,0,0,'hacý')
--ekle like
INSERT INTO Likelar(YorumID,KullaniciID,Tur) VALUES(5,1,0)
-------------------
--ekleler end
--/////////////////////////
--giriþler start
-------------------
--giriþ yonetici 
SELECT Yon.ID,Yon.YetkiID,Yet.YetkiAdi,Yon.Adi,Yon.Soyadi,Yon.KullaniciAdi,Yon.Eposta,Yon.Sifre,Yon.UyelikTarihi,Yon.DogunTarihi,Yon.IsDeleted FROM Yoneticiler AS Yon JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE Yon.Eposta = @Eposta
--giriþ kullanýcý 
SELECT ID,KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogunTarihi,OzelSoru,IsDeleted FROM Kullaniciler WHERE Eposta = @Eposta
-------------------
--giriþler end
--/////////////////////////
--güncelle start
-------------------
--güncelle yönetici 
UPDATE Yoneticiler SET YetkiID=2,Adi='hacýnýn',Soyadi='þalgamý',KullaniciAdi = 'hacýnýnþalgamý1234',Eposta = 'þalgam@gmail.com',Sifre = 'hurdacigeliyý',IsDeleted = 0 WHERE ID = 21
--güncelle kategori
UPDATE Kategoriler SET KategoriAdi='hamuruna çay katýlan yemekler' WHERE ID = 1002
--güncelle makale
UPDATE Makaleler SET KategoriID=4,Baslik='123',Ozet='1234',Tamicerik='(insert text here)',ThumbnailAdi=NULL,TamResimAdi=NULL,IsDeleted =0 WHERE ID = 2
--güncelle kullanýcý
UPDATE Kullaniciler SET KullaniciAdi = 'mahmutiye',Eposta = 'mahmut@1234.com',Sifre = 'þalgam',IsDeleted = 1 WHERE ID = 2
-------------------
--güncelle end
--/////////////////////////
--özeller star
-------------------
--özel eposta
SELECT COUNT(*) FROM Yoneticiler WHERE Eposta = 'cry@cry.com'
--özel kategori
SELECT COUNT(*) FROM Kategoriler WHERE KategoriAdi = @KategoriAdi
-------------------
--özeller end
--/////////////////////////
--validasyonlar start
-------------------
--validasyon kullanýcý giriþ 
SELECT COUNT(*) FROM Kullaniciler WHERE Eposta = @eposta AND Sifre = @sifre AND IsDeleted = 0
--validasyon yönetici giriþ 
SELECT COUNT(*) FROM Yoneticiler WHERE Eposta = 'cry@cry.com' AND Sifre = 'crycry' AND IsDeleted = 0
-------------------
--/////////////////////////
--siller start
-------------------
--sil yönetici
UPDATE Yoneticiler SET IsDeleted = 0 WHERE ID = 20
--sil kategori
UPDATE Kategoriler SET IsDeleted = 1 WHERE ID = 1002
--sil makale
UPDATE Makaleler SET IsDeleted = 1 WHERE ID = 2
--sil kullanýcý
UPDATE Kullaniciler SET IsDeleted = 1 WHERE ID = 1
--sil yorum
UPDATE Yorumlar SET IsDeleted = 0 WHERE ID = 1
--sil harddelete yorum
DELETE FROM Yorumlar WHERE ID=@ID
-------------------
--siller end
--/////////////////////////
--getler start
-------------------
--get kategori
SELECT * FROM Kategoriler WHERE ID = 1002
--get yönetici
SELECT Yon.ID,Yon.YetkiID,Yet.YetkiAdi,Yon.Adi,Yon.Soyadi,Yon.KullaniciAdi,Yon.Eposta,Yon.Sifre,Yon.IsDeleted FROM Yoneticiler AS Yon JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE IsDeleted = 0 AND Yon.ID = 20
--get makale
SELECT Mak.ID,Mak.KategoriID,Kat.KategoriAdi,Mak.YoneticiID,Yon.Adi,Yet.YetkiAdi,Mak.Baslik,Mak.Ozet,Mak.Tamicerik,Mak.ThumbnailAdi,Mak.TamResimAdi,Mak.YuklemeTarihi,Mak.Okundu,Mak.IsDeleted FROM Makaleler AS Mak JOIN Yoneticiler AS Yon ON Mak.YoneticiID = Yon.ID JOIN Kategoriler AS Kat ON Mak.KategoriID = Kat.ID JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE Mak.ID = 1
--get kullanýcý
SELECT ID,KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogunTarihi,IsDeleted FROM Kullaniciler WHERE ID = 1
-------------------
--getler end
--/////////////////////////

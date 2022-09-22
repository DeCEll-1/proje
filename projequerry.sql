--listeleler start
-------------------
--listele y�netici
SELECT Yon.ID,Yon.YetkiID,Yet.YetkiAdi,Yon.Adi,Yon.Soyadi,Yon.KullaniciAdi,Yon.Eposta,Yon.Sifre,Yon.UyelikTarihi,Yon.DogunTarihi,Yon.IsDeleted FROM Yoneticiler AS Yon JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE IsDeleted = @IsDeleted
--listele kategori
SELECT * FROM Kategoriler WHERE IsDeleted = 0
--listele makaleler
SELECT Mak.ID,Mak.KategoriID,Kat.KategoriAdi,Mak.YoneticiID,Yon.Adi,Yet.YetkiAdi,Mak.Baslik,Mak.Ozet,Mak.Tamicerik,Mak.ThumbnailAdi,Mak.TamResimAdi,YuklemeTarihi,Mak.Okundu,Mak.IsDeleted FROM Makaleler AS Mak JOIN Yoneticiler AS Yon ON Mak.YoneticiID = Yon.ID JOIN Kategoriler AS Kat ON Mak.KategoriID = Kat.ID JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE Mak.IsDeleted =0 AND Mak.KategoriID=1
--listele kullan�c�lar
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
--ekle y�netici
INSERT INTO Yoneticiler(YetkiID,Adi,Soyadi,KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogunTarihi,IsDeleted) VALUES(1,'root','root','root','root@gmail.com','root',2020-08-08,2020-08-08,0)
--ekle kategori
INSERT INTO Kategoriler(KategoriAdi,IsDeleted) VALUES('�ayl� yemekler',0)
--ekle makale
INSERT INTO Makaleler(KategoriID,YoneticiID,Baslik,Ozet,Tamicerik,ThumbnailAdi,TamResimAdi,YuklemeTarihi,Okundu,IsDeleted) VALUES(1,2,'test','amogus','<instert full text here>',NULL,NULL,2020-08-08,0,0)
--ekle kullan�c�
INSERT INTO Kullaniciler(KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogunTarihi,OzelSoru,IsDeleted) VALUES('hac�','Hac�n�n�algam�@gmail.com','g�rm�z�',2020-08-08,2020-08-08,'�algam',0)
--ekle yorum
INSERT INTO Yorumlar(MakaleID,KullaniciID,Icerik,YorumTarihi,YorumLike,IsDeleted,KullaniciAdi) VALUES(4,1,'�ok iyi',2020-08-08,0,0,'hac�')
--ekle like
INSERT INTO Likelar(YorumID,KullaniciID,Tur) VALUES(5,1,0)
-------------------
--ekleler end
--/////////////////////////
--giri�ler start
-------------------
--giri� yonetici 
SELECT Yon.ID,Yon.YetkiID,Yet.YetkiAdi,Yon.Adi,Yon.Soyadi,Yon.KullaniciAdi,Yon.Eposta,Yon.Sifre,Yon.UyelikTarihi,Yon.DogunTarihi,Yon.IsDeleted FROM Yoneticiler AS Yon JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE Yon.Eposta = @Eposta
--giri� kullan�c� 
SELECT ID,KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogunTarihi,OzelSoru,IsDeleted FROM Kullaniciler WHERE Eposta = @Eposta
-------------------
--giri�ler end
--/////////////////////////
--g�ncelle start
-------------------
--g�ncelle y�netici 
UPDATE Yoneticiler SET YetkiID=2,Adi='hac�n�n',Soyadi='�algam�',KullaniciAdi = 'hac�n�n�algam�1234',Eposta = '�algam@gmail.com',Sifre = 'hurdacigeliy�',IsDeleted = 0 WHERE ID = 21
--g�ncelle kategori
UPDATE Kategoriler SET KategoriAdi='hamuruna �ay kat�lan yemekler' WHERE ID = 1002
--g�ncelle makale
UPDATE Makaleler SET KategoriID=4,Baslik='123',Ozet='1234',Tamicerik='(insert text here)',ThumbnailAdi=NULL,TamResimAdi=NULL,IsDeleted =0 WHERE ID = 2
--g�ncelle kullan�c�
UPDATE Kullaniciler SET KullaniciAdi = 'mahmutiye',Eposta = 'mahmut@1234.com',Sifre = '�algam',IsDeleted = 1 WHERE ID = 2
-------------------
--g�ncelle end
--/////////////////////////
--�zeller star
-------------------
--�zel eposta
SELECT COUNT(*) FROM Yoneticiler WHERE Eposta = 'cry@cry.com'
--�zel kategori
SELECT COUNT(*) FROM Kategoriler WHERE KategoriAdi = @KategoriAdi
-------------------
--�zeller end
--/////////////////////////
--validasyonlar start
-------------------
--validasyon kullan�c� giri� 
SELECT COUNT(*) FROM Kullaniciler WHERE Eposta = @eposta AND Sifre = @sifre AND IsDeleted = 0
--validasyon y�netici giri� 
SELECT COUNT(*) FROM Yoneticiler WHERE Eposta = 'cry@cry.com' AND Sifre = 'crycry' AND IsDeleted = 0
-------------------
--/////////////////////////
--siller start
-------------------
--sil y�netici
UPDATE Yoneticiler SET IsDeleted = 0 WHERE ID = 20
--sil kategori
UPDATE Kategoriler SET IsDeleted = 1 WHERE ID = 1002
--sil makale
UPDATE Makaleler SET IsDeleted = 1 WHERE ID = 2
--sil kullan�c�
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
--get y�netici
SELECT Yon.ID,Yon.YetkiID,Yet.YetkiAdi,Yon.Adi,Yon.Soyadi,Yon.KullaniciAdi,Yon.Eposta,Yon.Sifre,Yon.IsDeleted FROM Yoneticiler AS Yon JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE IsDeleted = 0 AND Yon.ID = 20
--get makale
SELECT Mak.ID,Mak.KategoriID,Kat.KategoriAdi,Mak.YoneticiID,Yon.Adi,Yet.YetkiAdi,Mak.Baslik,Mak.Ozet,Mak.Tamicerik,Mak.ThumbnailAdi,Mak.TamResimAdi,Mak.YuklemeTarihi,Mak.Okundu,Mak.IsDeleted FROM Makaleler AS Mak JOIN Yoneticiler AS Yon ON Mak.YoneticiID = Yon.ID JOIN Kategoriler AS Kat ON Mak.KategoriID = Kat.ID JOIN Yetkiler AS Yet ON Yon.YetkiID = Yet.ID WHERE Mak.ID = 1
--get kullan�c�
SELECT ID,KullaniciAdi,Eposta,Sifre,UyelikTarihi,DogunTarihi,IsDeleted FROM Kullaniciler WHERE ID = 1
-------------------
--getler end
--/////////////////////////

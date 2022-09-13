USE master
GO
DROP DATABASE IF EXISTS Yemek_DB 
GO
CREATE DATABASE Yemek_DB
GO
USE Yemek_DB
GO
CREATE TABLE Kategoriler(
	ID int IDENTITY(1,1)NOT NULL,
	KategoriAdi NVARCHAR(63) NOT NULL,
	IsDeleted bit NOT NULL,
	CONSTRAINT pk_kategoriler PRIMARY KEY (ID),
);



CREATE TABLE Yetkiler(
	ID int IDENTITY(1,1)NOT NULL,
	YetkiAdi NVARCHAR(64)NOT NULL,
	CONSTRAINT pk_yetkiler PRIMARY KEY (ID),
);



CREATE TABLE Kullaniciler(
	ID int IDENTITY(1,1)NOT NULL,
	KullaniciAdi nvarchar(64)NOT NULL,
	Eposta nvarchar(64)NOT NULL,
	Sifre nvarchar(64)NOT NULL,
	UyelikTarihi datetime NOT NULL,
	DogunTarihi datetime NOT NULL,
	OzelSoru nvarchar(126)NOT NULL,
	IsDeleted bit NOT NULL,
	CONSTRAINT pk_kullaniciler PRIMARY KEY (ID),
);



CREATE TABLE Yoneticiler(
	ID int IDENTITY (1,1)NOT NULL,
	YetkiID int NOT NULL,
	Adi nvarchar(64)NOT NULL,
	SoyAdi nvarchar(64)NOT NULL,
	KullaniciAdi nvarchar(64)NOT NULL,
	Eposta nvarchar(64)NOT NULL,
	Sifre nvarchar(64)NOT NULL,
	UyelikTarihi datetime NOT NULL,
	DogunTarihi datetime NOT NULL,
	IsDeleted bit NOT NULL,
	CONSTRAINT pk_yoneticiler PRIMARY KEY (ID),
	CONSTRAINT fk_yoneticilerYetkiler FOREIGN KEY (YetkiID) REFERENCES Yetkiler (ID),
);



CREATE TABLE Makaleler(
	ID int IDENTITY(1,1)NOT NULL,
	KategoriID int NOT NULL,
	YoneticiID int NOT NULL,
	Baslik nvarchar(255)NOT NULL,
	Ozet nvarchar(255)NOT NULL,
	Tamicerik nvarchar(max)NOT NULL,
	ThumbnailAdi nvarchar(255),
	TamResimAdi nvarchar(255),
	YuklemeTarihi datetime NOT NULL,
	Okundu int,
	MakaleLike int,
	IsDeleted bit NOT NULL,
	CONSTRAINT pk_makaleler PRIMARY KEY (ID),
	CONSTRAINT fk_makalelerKategori FOREIGN KEY (KategoriID) REFERENCES Kategoriler(ID),
	CONSTRAINT fk_makalelerYonetici FOREIGN KEY (YoneticiID) REFERENCES Yoneticiler(ID)
);



CREATE TABLE Yorumlar(
	ID int IDENTITY(1,1)NOT NULL,
	MakaleID int NOT NULL,
	KullaniciID Int NOT NULL,
	Icerik nvarchar(300)NOT NULL,
	YorumTarihi datetime NOT NULL,
	YorumLike int,
	IsDeleted bit NOT NULL,
	CONSTRAINT pk_yorumlar PRIMARY KEY (ID),
	CONSTRAINT fk_yorumlarMakale FOREIGN KEY (MakaleID) REFERENCES Makaleler(ID),
	CONSTRAINT fk_yorumlarKullanici FOREIGN KEY (KullaniciID) REFERENCES Kullaniciler(ID),
);



CREATE TABLE Likelar(
	ID int IDENTITY(1,1)NOT NULL,
	YorumID int NOT NULL,
	KullaniciID int NOT NULL,
	Tur bit NOT NULL,
	CONSTRAINT fk_likelarKullanici FOREIGN KEY (KullaniciID) REFERENCES Kullaniciler(ID),
	CONSTRAINT fk_likelarYorumlar FOREIGN KEY (YorumID) REFERENCES Yorumlar(ID),
)
USE master

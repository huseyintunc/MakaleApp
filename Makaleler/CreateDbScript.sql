USE [master]
GO
/****** Object:  Database [MakalelerDb]    Script Date: 23.8.2019 04:02:11 ******/
CREATE DATABASE [MakalelerDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MakalelerDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MakalelerDb.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MakalelerDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MakalelerDb_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MakalelerDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MakalelerDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MakalelerDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MakalelerDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MakalelerDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MakalelerDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MakalelerDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [MakalelerDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MakalelerDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MakalelerDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MakalelerDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MakalelerDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MakalelerDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MakalelerDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MakalelerDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MakalelerDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MakalelerDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MakalelerDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MakalelerDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MakalelerDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MakalelerDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MakalelerDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MakalelerDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MakalelerDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MakalelerDb] SET RECOVERY FULL 
GO
ALTER DATABASE [MakalelerDb] SET  MULTI_USER 
GO
ALTER DATABASE [MakalelerDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MakalelerDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MakalelerDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MakalelerDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MakalelerDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MakalelerDb', N'ON'
GO
USE [MakalelerDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23.8.2019 04:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kategori]    Script Date: 23.8.2019 04:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategori](
	[KategoriId] [int] IDENTITY(1,1) NOT NULL,
	[KategoriAdi] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Kategori] PRIMARY KEY CLUSTERED 
(
	[KategoriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Makale]    Script Date: 23.8.2019 04:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Makale](
	[MakaleId] [int] IDENTITY(1,1) NOT NULL,
	[MakaleBaslik] [nvarchar](max) NOT NULL,
	[KisaIcerik] [nvarchar](max) NOT NULL,
	[Icerik] [nvarchar](max) NOT NULL,
	[EklenmeTarihi] [datetime2](7) NOT NULL,
	[GuncellenmeTarihi] [datetime2](7) NULL,
	[KategoriId] [int] NOT NULL,
	[YazarId] [int] NOT NULL,
	[Goruntulenme] [int] NOT NULL,
	[Aktif] [bit] NOT NULL,
 CONSTRAINT [PK_Makale] PRIMARY KEY CLUSTERED 
(
	[MakaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Yazar]    Script Date: 23.8.2019 04:02:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Yazar](
	[YazarId] [int] IDENTITY(1,1) NOT NULL,
	[PasswordHash] [varbinary](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[Username] [nvarchar](150) NOT NULL,
	[LastName] [nvarchar](150) NOT NULL DEFAULT (N''),
	[Name] [nvarchar](150) NOT NULL DEFAULT (N''),
 CONSTRAINT [PK_Yazar] PRIMARY KEY CLUSTERED 
(
	[YazarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190822015853_initialCreate', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190822141554_addColumnTableYazarNameandSurname', N'3.0.0-preview.19074.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190822201946_updateMakaleTableKategoriId', N'3.0.0-preview.19074.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190822210516_updateMakaleTableFormat', N'3.0.0-preview.19074.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190822210619_updateMakaleTableFormat2', N'3.0.0-preview.19074.3')
GO
SET IDENTITY_INSERT [dbo].[Kategori] ON 

GO
INSERT [dbo].[Kategori] ([KategoriId], [KategoriAdi]) VALUES (1, N'Spor')
GO
INSERT [dbo].[Kategori] ([KategoriId], [KategoriAdi]) VALUES (2, N'Magazin')
GO
SET IDENTITY_INSERT [dbo].[Kategori] OFF
GO
SET IDENTITY_INSERT [dbo].[Makale] ON 

GO
INSERT [dbo].[Makale] ([MakaleId], [MakaleBaslik], [KisaIcerik], [Icerik], [EklenmeTarihi], [GuncellenmeTarihi], [KategoriId], [YazarId], [Goruntulenme], [Aktif]) VALUES (1, N'(ÖZET 1) AEK - Trabzonspor maç sonucu: 1-3', N'UEFA Avrupa Ligi 3. eleme turunda Çekya ekibi Sparta Prag’ı eleyerek adını play-off turuna yazdıran Trabzonspor, gruplara kalma yolunda ilk maçında AEK''e konuk oldu. Henüz 4. dakikada geriye düşen Fırtına, Yunan ekibine 28, 44 ve 71''de Ekuban''la karşılık verdi ve sahadan 3-1 galip ayrıldı, avantajı cebine koydu.', N'TR UEFA Avrupa Ligi 3. eleme turunda Çekya ekibi Sparta Prag’ı eleyerek adını play-off turuna yazdıran Trabzonspor, gruplara kalma yolunda ilk maçında AEK''e konuk oldu.Henüz 4. dakikada Livaja''nın golüyle geriye düşen Fırtına, maçı bırakmadı. Ekuban''la 28, 44 ve 71''de golleri bulan Trabzonspor, sahadan 3-1 galip ayrıldı, rövanş öncesi büyük avantaj sağladı. Karşılaşmada temsilcimiz, Sosa''nın ayağından 24. dakikada bir de penaltı atışından yararlanamadı.Karşılaşmanın rövanşı 29 Ağustos Perşembe günü Trabzon’da oynanacak ve gruplara kalan takım belli olacak. MAÇTAN DAKİKALAR:Spyros Louis Stadı''nda oynanan karşılaşmayı Almanya Futbol Federasyonu’ndan Daniel Siebert yönetti.Maçın hemen başında geriye düştük. 4. dakikada sol kanattan tehlikeli gelen Helder Lopes, ceza sahasına ortasını gönderdi. Gelen topa tek vuruş yapan Livaja, Uğurcan''ı avladı ve AEK öne geçti. 1-07. dakikada Abdülkadir, kaleyi yokladı. Ceza sahasının hemen önünde AEK savunmasına zor anlar yaşatan genç yıldız, şutunu gönderdi. Kaleci Vargas, güçlükle topu önledi.12. dakikada AEK tehlikeli geldi. Savunma arkasına kaçan Oliveira''nın sert şutu Uğurcan''da kaldı.17. dakikada Trabzonspor, Ekuban''la gole çok yaklaştı. Kalabalıktan çıkan Nwakaeme, AEK savunmasının arkasına harika bir pas attı ve Ekuban topla buluştu. Açısını kaybeden Ekuban, şutunu attı, fakan kaleyi tutturamadı.', CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), CAST(N'2019-08-23 00:24:50.6307547' AS DateTime2), 1, 1, 0, 1)
GO
INSERT [dbo].[Makale] ([MakaleId], [MakaleBaslik], [KisaIcerik], [Icerik], [EklenmeTarihi], [GuncellenmeTarihi], [KategoriId], [YazarId], [Goruntulenme], [Aktif]) VALUES (2, N'(ÖZET 2) AEK - Trabzonspor maç sonucu: 1-3', N'UEFA Avrupa Ligi 3. eleme turunda Çekya ekibi Sparta Prag’ı eleyerek adını play-off turuna yazdıran Trabzonspor, gruplara kalma yolunda ilk maçında AEK''e konuk oldu. Henüz 4. dakikada geriye düşen Fırtına, Yunan ekibine 28, 44 ve 71''de Ekuban''la karşılık verdi ve sahadan 3-1 galip ayrıldı, avantajı cebine koydu.', N'TR UEFA Avrupa Ligi 3. eleme turunda Çekya ekibi Sparta Prag’ı eleyerek adını play-off turuna yazdıran Trabzonspor, gruplara kalma yolunda ilk maçında AEK''e konuk oldu.Henüz 4. dakikada Livaja''nın golüyle geriye düşen Fırtına, maçı bırakmadı. Ekuban''la 28, 44 ve 71''de golleri bulan Trabzonspor, sahadan 3-1 galip ayrıldı, rövanş öncesi büyük avantaj sağladı. Karşılaşmada temsilcimiz, Sosa''nın ayağından 24. dakikada bir de penaltı atışından yararlanamadı.Karşılaşmanın rövanşı 29 Ağustos Perşembe günü Trabzon’da oynanacak ve gruplara kalan takım belli olacak. MAÇTAN DAKİKALAR:Spyros Louis Stadı''nda oynanan karşılaşmayı Almanya Futbol Federasyonu’ndan Daniel Siebert yönetti.Maçın hemen başında geriye düştük. 4. dakikada sol kanattan tehlikeli gelen Helder Lopes, ceza sahasına ortasını gönderdi. Gelen topa tek vuruş yapan Livaja, Uğurcan''ı avladı ve AEK öne geçti. 1-07. dakikada Abdülkadir, kaleyi yokladı. Ceza sahasının hemen önünde AEK savunmasına zor anlar yaşatan genç yıldız, şutunu gönderdi. Kaleci Vargas, güçlükle topu önledi.12. dakikada AEK tehlikeli geldi. Savunma arkasına kaçan Oliveira''nın sert şutu Uğurcan''da kaldı.17. dakikada Trabzonspor, Ekuban''la gole çok yaklaştı. Kalabalıktan çıkan Nwakaeme, AEK savunmasının arkasına harika bir pas attı ve Ekuban topla buluştu. Açısını kaybeden Ekuban, şutunu attı, fakan kaleyi tutturamadı.', CAST(N'2019-08-23 00:32:57.4556621' AS DateTime2), NULL, 1, 1, 0, 1)
GO
INSERT [dbo].[Makale] ([MakaleId], [MakaleBaslik], [KisaIcerik], [Icerik], [EklenmeTarihi], [GuncellenmeTarihi], [KategoriId], [YazarId], [Goruntulenme], [Aktif]) VALUES (3, N'(ÖZET 3) AEK - Trabzonspor maç sonucu: 1-3', N'UEFA Avrupa Ligi 3. eleme turunda Çekya ekibi Sparta Prag’ı eleyerek adını play-off turuna yazdıran Trabzonspor, gruplara kalma yolunda ilk maçında AEK''e konuk oldu. Henüz 4. dakikada geriye düşen Fırtına, Yunan ekibine 28, 44 ve 71''de Ekuban''la karşılık verdi ve sahadan 3-1 galip ayrıldı, avantajı cebine koydu.', N'TR UEFA Avrupa Ligi 3. eleme turunda Çekya ekibi Sparta Prag’ı eleyerek adını play-off turuna yazdıran Trabzonspor, gruplara kalma yolunda ilk maçında AEK''e konuk oldu.Henüz 4. dakikada Livaja''nın golüyle geriye düşen Fırtına, maçı bırakmadı. Ekuban''la 28, 44 ve 71''de golleri bulan Trabzonspor, sahadan 3-1 galip ayrıldı, rövanş öncesi büyük avantaj sağladı. Karşılaşmada temsilcimiz, Sosa''nın ayağından 24. dakikada bir de penaltı atışından yararlanamadı.Karşılaşmanın rövanşı 29 Ağustos Perşembe günü Trabzon’da oynanacak ve gruplara kalan takım belli olacak. MAÇTAN DAKİKALAR:Spyros Louis Stadı''nda oynanan karşılaşmayı Almanya Futbol Federasyonu’ndan Daniel Siebert yönetti.Maçın hemen başında geriye düştük. 4. dakikada sol kanattan tehlikeli gelen Helder Lopes, ceza sahasına ortasını gönderdi. Gelen topa tek vuruş yapan Livaja, Uğurcan''ı avladı ve AEK öne geçti. 1-07. dakikada Abdülkadir, kaleyi yokladı. Ceza sahasının hemen önünde AEK savunmasına zor anlar yaşatan genç yıldız, şutunu gönderdi. Kaleci Vargas, güçlükle topu önledi.12. dakikada AEK tehlikeli geldi. Savunma arkasına kaçan Oliveira''nın sert şutu Uğurcan''da kaldı.17. dakikada Trabzonspor, Ekuban''la gole çok yaklaştı. Kalabalıktan çıkan Nwakaeme, AEK savunmasının arkasına harika bir pas attı ve Ekuban topla buluştu. Açısını kaybeden Ekuban, şutunu attı, fakan kaleyi tutturamadı.', CAST(N'2019-08-23 00:33:10.4588533' AS DateTime2), NULL, 2, 1, 0, 1)
GO
INSERT [dbo].[Makale] ([MakaleId], [MakaleBaslik], [KisaIcerik], [Icerik], [EklenmeTarihi], [GuncellenmeTarihi], [KategoriId], [YazarId], [Goruntulenme], [Aktif]) VALUES (4, N'(ÖZET 4) AEK - Trabzonspor maç sonucu: 1-3', N'UEFA Avrupa Ligi 3. eleme turunda Çekya ekibi Sparta Prag’ı eleyerek adını play-off turuna yazdıran Trabzonspor, gruplara kalma yolunda ilk maçında AEK''e konuk oldu. Henüz 4. dakikada geriye düşen Fırtına, Yunan ekibine 28, 44 ve 71''de Ekuban''la karşılık verdi ve sahadan 3-1 galip ayrıldı, avantajı cebine koydu.', N'TR UEFA Avrupa Ligi 3. eleme turunda Çekya ekibi Sparta Prag’ı eleyerek adını play-off turuna yazdıran Trabzonspor, gruplara kalma yolunda ilk maçında AEK''e konuk oldu.Henüz 4. dakikada Livaja''nın golüyle geriye düşen Fırtına, maçı bırakmadı. Ekuban''la 28, 44 ve 71''de golleri bulan Trabzonspor, sahadan 3-1 galip ayrıldı, rövanş öncesi büyük avantaj sağladı. Karşılaşmada temsilcimiz, Sosa''nın ayağından 24. dakikada bir de penaltı atışından yararlanamadı.Karşılaşmanın rövanşı 29 Ağustos Perşembe günü Trabzon’da oynanacak ve gruplara kalan takım belli olacak. MAÇTAN DAKİKALAR:Spyros Louis Stadı''nda oynanan karşılaşmayı Almanya Futbol Federasyonu’ndan Daniel Siebert yönetti.Maçın hemen başında geriye düştük. 4. dakikada sol kanattan tehlikeli gelen Helder Lopes, ceza sahasına ortasını gönderdi. Gelen topa tek vuruş yapan Livaja, Uğurcan''ı avladı ve AEK öne geçti. 1-07. dakikada Abdülkadir, kaleyi yokladı. Ceza sahasının hemen önünde AEK savunmasına zor anlar yaşatan genç yıldız, şutunu gönderdi. Kaleci Vargas, güçlükle topu önledi.12. dakikada AEK tehlikeli geldi. Savunma arkasına kaçan Oliveira''nın sert şutu Uğurcan''da kaldı.17. dakikada Trabzonspor, Ekuban''la gole çok yaklaştı. Kalabalıktan çıkan Nwakaeme, AEK savunmasının arkasına harika bir pas attı ve Ekuban topla buluştu. Açısını kaybeden Ekuban, şutunu attı, fakan kaleyi tutturamadı.', CAST(N'2019-08-23 00:33:18.2255705' AS DateTime2), NULL, 2, 1, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Makale] OFF
GO
SET IDENTITY_INSERT [dbo].[Yazar] ON 

GO
INSERT [dbo].[Yazar] ([YazarId], [PasswordHash], [PasswordSalt], [Username], [LastName], [Name]) VALUES (1, 0xD4B983FB4CE8C312FD28F6C6A59462FE2C78D5AE6215DE93D773343B9B6EB7559492016E26B18B0DBEC2A61975DD2D47110A0348D45D6E53692DD808AA523419, 0x5CEEBE5C0FC0B6CF1AAA0CF9C8F7A2DB023E6057062E85ECB5588ACE7E24A5C96456C5CB6F15CF1177922A19FEA758B7A6C78BBE5DCD614AACC006B523D3C9CB4F089A6F9726FD330A8FF12CA784C4805F49AB43AAAB98F7446AAC7768FEF2F9047D131E52F36B2FF5F6BFC5207630862641D66515BA4909B4794F8604251785, N'huseyin', N'Tunç', N'Hüseyin')
GO
SET IDENTITY_INSERT [dbo].[Yazar] OFF
GO
/****** Object:  Index [IX_Makale_KategoriId]    Script Date: 23.8.2019 04:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_Makale_KategoriId] ON [dbo].[Makale]
(
	[KategoriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Makale_YazarId]    Script Date: 23.8.2019 04:02:11 ******/
CREATE NONCLUSTERED INDEX [IX_Makale_YazarId] ON [dbo].[Makale]
(
	[YazarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Makale]  WITH CHECK ADD  CONSTRAINT [FK_Makale_Kategori_KategoriId] FOREIGN KEY([KategoriId])
REFERENCES [dbo].[Kategori] ([KategoriId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Makale] CHECK CONSTRAINT [FK_Makale_Kategori_KategoriId]
GO
ALTER TABLE [dbo].[Makale]  WITH CHECK ADD  CONSTRAINT [FK_Makale_Yazar_YazarId] FOREIGN KEY([YazarId])
REFERENCES [dbo].[Yazar] ([YazarId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Makale] CHECK CONSTRAINT [FK_Makale_Yazar_YazarId]
GO
USE [master]
GO
ALTER DATABASE [MakalelerDb] SET  READ_WRITE 
GO

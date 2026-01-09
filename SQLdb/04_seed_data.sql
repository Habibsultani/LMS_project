INSERT INTO rol (rol_adi) VALUES
('Admin'),
('Gorevli');


INSERT INTO kullanici_tablo (kullanici_adi, ad_soyad, sifre, rol_id) VALUES
('admin2', 'Yeni Admin', SHA2('1234',256), 1),
('gorevli2', 'Yeni Gorevli', SHA2('1234',256), 2);

INSERT INTO ogrenci_uyeler (ogrenci_num, ad_soyadi, e_posta, telefon) VALUES
('2021001', 'Ali Yilmaz', 'ali@yilmaz.com', '05551112233'),
('2021002', 'Ayse Demir', 'ayse@demir.com', '05552223344'),
('2021003', 'Mehmet Kaya', 'mehmet@kaya.com', '05553334455');


INSERT INTO kategori (kategori_adi) VALUES
('Bilgisayar'),
('Edebiyat'),
('Tarih');


INSERT INTO kitaplar (kategori_id, kitab_adi, yayin_yili, toplam_kopyasi, mevcut_adet) VALUES
(1, 'Veritabani Sistemleri', 2020, 5, 5),
(1, 'Programlamaya Giris', 2019, 3, 3),
(2, 'Suc ve Ceza', 1866, 4, 4),
(3, 'Osmanli Tarihi', 2015, 2, 2);


INSERT INTO yazar (yazar_adi) VALUES
('Fyodor Dostoyevski'),
('Ahmet Hamdi Tanpinar'),
('Halil Inalcik');


INSERT INTO kitap_yazari (kitab_id, yazar_id) VALUES
(3, 1), -- Suç ve Ceza
(4, 3); -- Osmanlı Tarihi

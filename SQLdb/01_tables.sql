CREATE TABLE rol (
    rol_id INT AUTO_INCREMENT PRIMARY KEY,
    rol_adi VARCHAR(50) NOT NULL
) ENGINE=InnoDB;

CREATE TABLE kullanici_tablo (
    kullanici_id INT AUTO_INCREMENT PRIMARY KEY,
    kullanici_adi VARCHAR(50) NOT NULL UNIQUE,
    ad_soyad VARCHAR(100) NOT NULL,
    sifre VARCHAR(255) NOT NULL,
    rol_id INT NOT NULL,
    CONSTRAINT fk_kullanici_rol
        FOREIGN KEY (rol_id) REFERENCES rol(rol_id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE
) ENGINE=InnoDB;

CREATE TABLE ogrenci_uyeler (
    ogrenci_id INT AUTO_INCREMENT PRIMARY KEY,
    ogrenci_num VARCHAR(20) NOT NULL UNIQUE,
    ad_soyadi VARCHAR(100) NOT NULL,
    e_posta VARCHAR(100) UNIQUE,
    telefon VARCHAR(20),
    toplam_borc DECIMAL(10,2) DEFAULT 0,
    is_active BOOLEAN DEFAULT TRUE
) ENGINE=InnoDB;

CREATE TABLE kategori (
    kategori_id INT AUTO_INCREMENT PRIMARY KEY,
    kategori_adi VARCHAR(100) NOT NULL UNIQUE
) ENGINE=InnoDB;

CREATE TABLE kitaplar (
    kitab_id INT AUTO_INCREMENT PRIMARY KEY,
    kategori_id INT NOT NULL,
    kitab_adi VARCHAR(200) NOT NULL,
    yayin_yili INT,
    toplam_kopyasi INT NOT NULL,
    mevcut_adet INT NOT NULL,
    CONSTRAINT fk_kitap_kategori
        FOREIGN KEY (kategori_id) REFERENCES kategori(kategori_id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE,
    CONSTRAINT chk_stok
        CHECK (mevcut_adet <= toplam_kopyasi)
) ENGINE=InnoDB;

CREATE TABLE yazar (
    yazar_id INT AUTO_INCREMENT PRIMARY KEY,
    yazar_adi VARCHAR(100) NOT NULL
) ENGINE=InnoDB;

CREATE TABLE kitap_yazari (
    kitab_id INT NOT NULL,
    yazar_id INT NOT NULL,
    PRIMARY KEY (kitab_id, yazar_id),
    CONSTRAINT fk_ky_kitap
        FOREIGN KEY (kitab_id) REFERENCES kitaplar(kitab_id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    CONSTRAINT fk_ky_yazar
        FOREIGN KEY (yazar_id) REFERENCES yazar(yazar_id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
) ENGINE=InnoDB;

CREATE TABLE odunc (
    odunc_id INT AUTO_INCREMENT PRIMARY KEY,
    kitab_id INT NOT NULL,
    ogrenci_id INT NOT NULL,
    kullanici_id INT NOT NULL,
    odunc_tarihi DATE NOT NULL,
    son_teslim_tarihi DATE NOT NULL,
    teslim_tarihi DATE,
    CONSTRAINT fk_odunc_kitap
        FOREIGN KEY (kitab_id) REFERENCES kitaplar(kitab_id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE,
    CONSTRAINT fk_odunc_ogrenci
        FOREIGN KEY (ogrenci_id) REFERENCES ogrenci_uyeler(ogrenci_id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE,
    CONSTRAINT fk_odunc_kullanici
        FOREIGN KEY (kullanici_id) REFERENCES kullanici_tablo(kullanici_id)
        ON DELETE RESTRICT
        ON UPDATE CASCADE
) ENGINE=InnoDB;

CREATE TABLE ceza (
    ceza_id INT AUTO_INCREMENT PRIMARY KEY,
    odunc_id INT NOT NULL,
    ceza_tutari DECIMAL(10,2) NOT NULL,
    ceza_tarihi DATE NOT NULL,
    aciklama VARCHAR(255),
    CONSTRAINT fk_ceza_odunc
        FOREIGN KEY (odunc_id) REFERENCES odunc(odunc_id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
) ENGINE=InnoDB;


CREATE TABLE log_tablosu (
    log_id INT AUTO_INCREMENT PRIMARY KEY,
    tablo_adi VARCHAR(50) NOT NULL,
    islem VARCHAR(10) NOT NULL,
    tarih TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    aciklama VARCHAR(255)
) ENGINE=InnoDB;

CREATE INDEX idx_odunc_ogrenci ON odunc(ogrenci_id);
CREATE INDEX idx_odunc_kitap ON odunc(kitab_id);
CREATE INDEX idx_ceza_odunc ON ceza(odunc_id);

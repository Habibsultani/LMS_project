DELIMITER //

CREATE TRIGGER tr_odunc_insert
AFTER INSERT ON odunc
FOR EACH ROW
BEGIN
    -- Stok azalt
    UPDATE kitaplar
    SET mevcut_adet = mevcut_adet - 1
    WHERE kitab_id = NEW.kitab_id;

    -- Log kaydı
    INSERT INTO log_tablosu (
        tablo_adi,
        islem,
        aciklama
    )
    VALUES (
        'ODUNC',
        'INSERT',
        CONCAT('Yeni ödünç verildi. OduncID=', NEW.odunc_id)
    );
END //

DELIMITER ;


DELIMITER //

CREATE TRIGGER tr_odunc_update_teslim
AFTER UPDATE ON odunc
FOR EACH ROW
BEGIN
    -- Teslim tarihi NULL'dan doluya döndüyse
    IF OLD.teslim_tarihi IS NULL AND NEW.teslim_tarihi IS NOT NULL THEN

        -- Stok artır
        UPDATE kitaplar
        SET mevcut_adet = mevcut_adet + 1
        WHERE kitab_id = NEW.kitab_id;

        -- Log kaydı
        INSERT INTO log_tablosu (
            tablo_adi,
            islem,
            aciklama
        )
        VALUES (
            'ODUNC',
            'UPDATE',
            CONCAT('Kitap teslim alındı. OduncID=', NEW.odunc_id)
        );
    END IF;
END //

DELIMITER ;

DELIMITER //

CREATE TRIGGER tr_ceza_insert
AFTER INSERT ON ceza
FOR EACH ROW
BEGIN
    -- Öğrencinin toplam borcunu artır
    UPDATE ogrenci_uyeler
    SET toplam_borc = toplam_borc + NEW.ceza_tutari
    WHERE ogrenci_id = (
        SELECT ogrenci_id
        FROM odunc
        WHERE odunc_id = NEW.odunc_id
    );

    -- Log kaydı
    INSERT INTO log_tablosu (
        tablo_adi,
        islem,
        aciklama
    )
    VALUES (
        'CEZA',
        'INSERT',
        CONCAT('Ceza eklendi. CezaID=', NEW.ceza_id)
    );
END //

DELIMITER ;


DELIMITER //

CREATE TRIGGER tr_ogrenci_delete_block
BEFORE DELETE ON ogrenci_uyeler
FOR EACH ROW
BEGIN
    DECLARE v_aktif_odunc INT;

    -- Aktif ödünç sayısı
    SELECT COUNT(*)
    INTO v_aktif_odunc
    FROM odunc
    WHERE ogrenci_id = OLD.ogrenci_id
      AND teslim_tarihi IS NULL;

    IF v_aktif_odunc > 0 OR OLD.toplam_borc > 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Aktif ödüncü veya borcu olan üye silinemez';
    END IF;
END //

DELIMITER ;


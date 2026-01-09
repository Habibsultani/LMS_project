DELIMITER //

CREATE PROCEDURE sp_YeniOduncVer(
    IN p_ogrenci_id INT,
    IN p_kitab_id INT,
    IN p_kullanici_id INT
)
BEGIN
    DECLARE v_aktif_odunc INT;
    DECLARE v_mevcut_adet INT;

    START TRANSACTION;

    -- Aktif ödünç sayısı kontrolü
    SELECT COUNT(*) INTO v_aktif_odunc
    FROM odunc
    WHERE ogrenci_id = p_ogrenci_id
      AND teslim_tarihi IS NULL;

    IF v_aktif_odunc >= 5 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Üyenin aktif ödünç limiti dolu (maksimum 5)';
    END IF;

    -- Kitap stok kontrolü
    SELECT mevcut_adet INTO v_mevcut_adet
    FROM kitaplar
    WHERE kitab_id = p_kitab_id
    FOR UPDATE;

    IF v_mevcut_adet <= 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Kitap stokta yok';
    END IF;

    -- Ödünç kaydı
    INSERT INTO odunc (
        kitab_id,
        ogrenci_id,
        kullanici_id,
        odunc_tarihi,
        son_teslim_tarihi
    )
    VALUES (
        p_kitab_id,
        p_ogrenci_id,
        p_kullanici_id,
        CURDATE(),
        DATE_ADD(CURDATE(), INTERVAL 15 DAY)
    );

    COMMIT;
END //

DELIMITER ;


DELIMITER //

CREATE PROCEDURE sp_KitapTeslimAl(
    IN p_odunc_id INT,
    IN p_teslim_tarihi DATE
)
BEGIN
    DECLARE v_son_teslim DATE;
    DECLARE v_gecikme INT;
    DECLARE v_ceza DECIMAL(10,2);

    START TRANSACTION;

    -- Son teslim tarihini al
    SELECT son_teslim_tarihi
    INTO v_son_teslim
    FROM odunc
    WHERE odunc_id = p_odunc_id
    FOR UPDATE;

    -- Teslim tarihini güncelle
    UPDATE odunc
    SET teslim_tarihi = p_teslim_tarihi
    WHERE odunc_id = p_odunc_id;

    -- Gecikme hesapla
    IF p_teslim_tarihi > v_son_teslim THEN
        SET v_gecikme = DATEDIFF(p_teslim_tarihi, v_son_teslim);
        SET v_ceza = v_gecikme * 5;

        INSERT INTO ceza (
            odunc_id,
            ceza_tutari,
            ceza_tarihi,
            aciklama
        )
        VALUES (
            p_odunc_id,
            v_ceza,
            CURDATE(),
            CONCAT(v_gecikme, ' gün gecikme')
        );
    END IF;

    COMMIT;
END //

DELIMITER ;

DELIMITER //

CREATE PROCEDURE sp_UyeOzetRapor(
    IN p_ogrenci_id INT
)
BEGIN
    SELECT
        o.ogrenci_id,
        COUNT(o.odunc_id) AS toplam_odunc_sayisi,
        SUM(CASE WHEN o.teslim_tarihi IS NULL THEN 1 ELSE 0 END) AS aktif_odunc_sayisi,
        IFNULL(SUM(c.ceza_tutari), 0) AS toplam_ceza
    FROM odunc o
    LEFT JOIN ceza c ON o.odunc_id = c.odunc_id
    WHERE o.ogrenci_id = p_ogrenci_id
    GROUP BY o.ogrenci_id;
END //

DELIMITER ;

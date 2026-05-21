-- ============================================================
-- BenshopDB — Seed Data
-- ============================================================

-- Users (passwords are SHA-256 hashed)
-- admin123 → 240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9
-- buyer123 → e547bd13228250dfb4c7df1d1ebb78cfd9f2ada56ebb0c425d35829dd3ac4ae8
-- seller123 → 2a76110d06bcc4fd437337b984131cfa82db9f792e3e2340acef9f3066b264e0
INSERT INTO Users (Username, PasswordHash, FullName, Phone, Role) VALUES
('admin',    '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 'Admin Benshop',   '081234567890', 'Seller'),
('budi',     'e547bd13228250dfb4c7df1d1ebb78cfd9f2ada56ebb0c425d35829dd3ac4ae8', 'Budi Santoso',    '081234567891', 'Buyer'),
('siti',     'e547bd13228250dfb4c7df1d1ebb78cfd9f2ada56ebb0c425d35829dd3ac4ae8', 'Siti Rahmawati',  '081234567892', 'Buyer'),
('seller1',  '2a76110d06bcc4fd437337b984131cfa82db9f792e3e2340acef9f3066b264e0', 'Dewi Lestari',    '081234567893', 'Seller');

-- Products
INSERT INTO Products (Name, Category, Price, Stock, IsActive) VALUES
('Beras Premium 5kg',          'Sembako',  72000,  50, 1),
('Minyak Goreng 1L',           'Sembako',  18000,  80, 1),
('Gula Pasir 1kg',             'Sembako',  16000,  60, 1),
('Kopi Bubuk 200gr',           'Minuman',  28000,  40, 1),
('Teh Celup 25 sachet',        'Minuman',  12000,  45, 1),
('Susu UHT 1L',                'Minuman',  22000,  35, 1),
('Air Mineral 600ml',          'Minuman',   3000, 200, 1),
('Mie Instan Goreng',          'Makanan',   3500, 150, 1),
('Kornet Sapi 200gr',          'Makanan',  26000,  30, 1),
('Kecap Manis 600ml',          'Bumbu',    15000,  40, 1),
('Sambal Botol 300ml',         'Bumbu',    19000,  35, 1),
('Sabun Mandi 100gr',          'Rumah Tangga',  5500,  70, 1),
('Shampo Sachet',              'Rumah Tangga',  2000, 100, 1),
('Sabun Cuci Piring 750ml',    'Rumah Tangga', 12000,  40, 1),
('Deterjen 1kg',               'Rumah Tangga', 35000,  25, 1);

-- Promo codes
INSERT INTO PromoCodes (Code, DiscountType, DiscountVal, ValidFrom, ValidUntil, IsActive) VALUES
('BELANJA10',   'Percent', 10, '2026-01-01', '2026-12-31', 1),
('DISKON5RB',   'Fixed',   5000, '2026-01-01', '2026-12-31', 1),
('HEMATAHIR',   'Percent', 15, '2026-05-01', '2026-05-31', 1),
('LEBARAN20',   'Percent', 20, '2026-06-01', '2026-07-15', 1),
('GRATIS10RB',  'Fixed',   10000, '2025-01-01', '2025-12-31', 0);

-- Transactions
INSERT INTO Transactions (TransactionNo, BuyerID, PromoID, Subtotal, DiscountAmount, Total, PaymentMethod, Status, CreatedAt)
VALUES
('TRX-20260510-001', 2, 1,  84000,  8400,  75600, 'QRIS',       'Selesai',   '2026-05-10 09:15:00'),
('TRX-20260510-002', 3, NULL, 86000,     0,  86000, 'Tunai',     'Selesai',   '2026-05-10 11:30:00'),
('TRX-20260511-001', 2, 2,  50000,  5000,  45000, 'Transfer Bank', 'Selesai', '2026-05-11 14:00:00'),
('TRX-20260512-001', 2, NULL,142000,     0, 142000, 'QRIS',       'Dikirim',   '2026-05-12 08:45:00'),
('TRX-20260513-001', 3, 3,  82000, 12300,  69700, 'Transfer Bank', 'Diproses', '2026-05-13 10:20:00'),
('TRX-20260514-001', 2, 1,  34500,  3450,  31050, 'Tunai',     'Selesai',   '2026-05-14 16:10:00'),
('TRX-20260515-001', 3, NULL, 29500,     0,  29500, 'QRIS',       'Dikirim',   '2026-05-15 07:30:00');

-- Transaction details
INSERT INTO TransactionDetails (TransactionID, ProductID, Quantity, UnitPrice, Subtotal)
VALUES
-- TRX-20260510-001 (Buyer: budi, 2 items)
(1, 1, 1, 72000, 72000),
(1, 5, 1, 12000, 12000),

-- TRX-20260510-002 (Buyer: siti, 3 items)
(2, 2, 2, 18000, 36000),
(2, 8, 10, 3500, 35000),
(2, 7, 5,  3000, 15000),

-- TRX-20260511-001 (Buyer: budi, 2 items)
(3, 6, 1, 22000, 22000),
(3, 4, 1, 28000, 28000),

-- TRX-20260512-001 (Buyer: budi, 4 items)
(4, 1, 1, 72000, 72000),
(4, 2, 2, 18000, 36000),
(4, 11, 1, 19000, 19000),
(4, 10, 1, 15000, 15000),

-- TRX-20260513-001 (Buyer: siti, 3 items)
(5, 9, 1, 26000, 26000),
(5, 6, 2, 22000, 44000),
(5, 14, 1, 12000, 12000),

-- TRX-20260514-001 (Buyer: budi, 2 items)
(6, 2, 1, 18000, 18000),
(6, 12, 3, 5500, 16500),

-- TRX-20260515-001 (Buyer: siti, 2 items)
(7, 8, 5,  3500, 17500),
(7, 7, 4,  3000, 12000);

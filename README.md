# BenShop

BenShop adalah aplikasi desktop e-commerce sederhana berbasis Windows Forms untuk simulasi transaksi antara buyer dan seller. Project ini dibuat dengan C# .NET Framework, SQL Server, dan RDLC ReportViewer.

## Fitur

- Login berdasarkan role buyer dan seller
- Buyer dapat melihat produk, mencari produk, menambahkan produk ke cart, checkout, dan melihat riwayat transaksi
- Seller dapat mengelola produk, mengelola promo, melihat dashboard penjualan, mengubah status transaksi, dan membuka laporan
- Laporan penjualan mingguan, bulanan, tahunan, produk terlaris, dan tren laba
- Database script tersedia untuk schema, seed data, dan migration

## Teknologi

- C# Windows Forms
- .NET Framework 4.7.2
- SQL Server / SQL Server Express
- Microsoft ReportViewer WinForms
- RDLC Reports

## Struktur Project

```text
benshop/
|-- benshop/        # Source code aplikasi WinForms
|-- BenshopDB/      # Schema, seed, dan migration database
|-- benshop.slnx    # Solution file
`-- README.md
```

## Prasyarat

Pastikan sudah terinstall:

- Visual Studio dengan workload .NET desktop development
- .NET Framework 4.7.2 Developer Pack
- SQL Server atau SQL Server Express
- NuGet package restore aktif di Visual Studio

## Setup Database

1. Buka SQL Server Management Studio.
2. Buat database baru bernama `BenshopDB`.
3. Jalankan script berikut secara berurutan:

```text
BenshopDB/schema.sql
BenshopDB/seed.sql
BenshopDB/migration_20260518_order_shipping_and_reports.sql
```

4. Pastikan connection string di `benshop/App.config` sesuai dengan SQL Server lokal:

```xml
Data Source=.\SQLEXPRESS;Database=BenshopDB;Integrated Security=True;
```

Jika nama instance SQL Server berbeda, ubah bagian `Data Source`.

## Cara Menjalankan

1. Clone repository:

```powershell
git clone https://github.com/rafpoo/BenShop.git
cd BenShop
```

2. Buka `benshop.slnx` di Visual Studio.
3. Restore NuGet packages jika belum otomatis.
4. Pastikan project `benshop` menjadi startup project.
5. Build dan jalankan aplikasi.

## Akun Login Seed

| Role | Username | Password |
| --- | --- | --- |
| Seller | admin | admin123 |
| Seller | seller1 | seller123 |
| Buyer | budi | buyer123 |
| Buyer | siti | buyer123 |

## Catatan Development

- Folder `packages/`, `bin/`, `obj/`, `.vs/`, dan `.claude/` tidak ikut Git karena sudah masuk `.gitignore`.
- Dependency NuGet direstore dari `benshop/packages.config`.
- File database utama ada di folder `BenshopDB`.
- Jika report tidak tampil, pastikan package `Microsoft.ReportingServices.ReportViewerControl.Winforms` berhasil direstore.

## Lisensi

Project ini dibuat untuk kebutuhan pembelajaran.

# CLAUDE.md — Benshop Project

This file provides context and guidance for AI coding assistants when working on the **Benshop** project.

---

## Project Overview

**Benshop** is a Windows Forms desktop application built with **.NET Framework (C#)** and **Microsoft SQL Server**.
It is a mini-market management system with two user roles: **Buyer (Pembeli)** and **Seller (Penjual)**.

All WinForms UI screens have been built. The app starts with a login form, then opens the appropriate role-based dashboard.

---

## Tech Stack

| Layer          | Technology                                  |
|----------------|---------------------------------------------|
| UI             | Windows Forms (.NET Framework, C#)          |
| Language       | C# (.NET Framework 4.7.2) — C# 5 syntax     |
| Database       | Microsoft SQL Server Express (local)        |
| DB Access      | ADO.NET / SqlConnection                     |
| Auth           | Role-based session (Buyer / Seller)         |
| Reporting      | SAP Crystal Reports for Visual Studio (planned) |

---

## Project Structure

```
benshop/
├── AGENTS.md                    ← AI agent guidance (opencode)
├── CLAUDE.md                    ← This file
├── benshop.slnx                 ← Visual Studio solution (SLNX format)
├── benshop/
│   ├── Program.cs               ← Entry point
│   ├── App.config               ← DB connection string
│   ├── benshop.csproj           ← .NET Framework 4.7.2
│   ├── Forms/
│   │   ├── Login/
│   │   │   └── FrmLogin.cs/.Designer.cs
│   │   ├── Buyer/
│   │   │   ├── FrmBuyerDashboard.cs/.Designer.cs   ← Product grid, search, add to cart
│   │   │   ├── FrmCart.cs/.Designer.cs              ← Cart items, qty controls
│   │   │   ├── FrmCheckout.cs/.Designer.cs          ← Checkout, promo, payment
│   │   │   ├── FrmBuyerHistory.cs/.Designer.cs      ← Transaction history
│   │   │   ├── FrmQtySelector.cs/.Designer.cs       ← Qty picker dialog
│   │   │   └── FrmTransactionDetail.cs/.Designer.cs ← Tx line items detail
│   │   └── Seller/
│   │       ├── FrmSellerDashboard.cs/.Designer.cs   ← Stats, top products, recent tx
│   │       ├── FrmProducts.cs/.Designer.cs           ← Add/edit/delete products
│   │       ├── FrmPromo.cs/.Designer.cs              ← Create/manage promo codes
│   │       └── FrmSellerReport.cs/.Designer.cs       ← Crystal Reports viewer
│   ├── Models/
│   │   ├── User.cs
│   │   ├── Product.cs
│   │   ├── CartItem.cs
│   │   ├── Transaction.cs
│   │   ├── TransactionDetail.cs
│   │   └── PromoCode.cs
│   ├── DAL/
│   │   ├── DBHelper.cs          ← SqlConnection factory
│   │   ├── UserDAL.cs
│   │   ├── ProductDAL.cs
│   │   ├── TransactionDAL.cs
│   │   └── PromoDAL.cs
│   ├── BLL/
│   │   ├── AuthBLL.cs
│   │   ├── ProductBLL.cs
│   │   ├── CartBLL.cs           ← In-memory cart (List<CartItem>)
│   │   ├── CheckoutBLL.cs
│   │   └── ReportBLL.cs         ← Prepares DataSet for Crystal Reports
│   └── Helpers/
│       ├── SessionManager.cs    ← Stores logged-in user info
│       ├── FormatHelper.cs      ← Currency formatting (Rp)
│       └── ValidationHelper.cs
```

---

## Database Schema (SQL Server)

### Tables

```sql
-- Users table
Users (
  UserID       INT PRIMARY KEY IDENTITY,
  Username     NVARCHAR(50) UNIQUE NOT NULL,
  PasswordHash NVARCHAR(256) NOT NULL,
  FullName     NVARCHAR(100),
  Phone        NVARCHAR(20),
  Role         NVARCHAR(10) NOT NULL CHECK (Role IN ('Buyer','Seller')),
  CreatedAt    DATETIME DEFAULT GETDATE()
)

-- Products table
Products (
  ProductID    INT PRIMARY KEY IDENTITY,
  Name         NVARCHAR(100) NOT NULL,
  Category     NVARCHAR(50),
  Price        DECIMAL(18,2) NOT NULL,
  Stock        INT NOT NULL DEFAULT 0,
  ImagePath    NVARCHAR(255),
  IsActive     BIT DEFAULT 1,
  CreatedAt    DATETIME DEFAULT GETDATE()
)

-- Promo codes table
PromoCodes (
  PromoID      INT PRIMARY KEY IDENTITY,
  Code         NVARCHAR(30) UNIQUE NOT NULL,
  DiscountType NVARCHAR(10) CHECK (DiscountType IN ('Percent','Fixed')),
  DiscountVal  DECIMAL(18,2) NOT NULL,
  ValidFrom    DATE,
  ValidUntil   DATE,
  UsageCount   INT DEFAULT 0,
  IsActive     BIT DEFAULT 1
)

-- Transactions header table
Transactions (
  TransactionID   INT PRIMARY KEY IDENTITY,
  TransactionNo   NVARCHAR(20) UNIQUE NOT NULL,
  BuyerID         INT FOREIGN KEY REFERENCES Users(UserID),
  PromoID         INT FOREIGN KEY REFERENCES PromoCodes(PromoID) NULL,
  Subtotal        DECIMAL(18,2),
  DiscountAmount  DECIMAL(18,2) DEFAULT 0,
  Total           DECIMAL(18,2),
  PaymentMethod   NVARCHAR(20),
  Status          NVARCHAR(20) DEFAULT 'Diproses',
  CreatedAt       DATETIME DEFAULT GETDATE()
)

-- Transaction detail / line items
TransactionDetails (
  DetailID      INT PRIMARY KEY IDENTITY,
  TransactionID INT FOREIGN KEY REFERENCES Transactions(TransactionID),
  ProductID     INT FOREIGN KEY REFERENCES Products(ProductID),
  Quantity      INT NOT NULL,
  UnitPrice     DECIMAL(18,2) NOT NULL,
  Subtotal      DECIMAL(18,2)
)
```

---

## Screens & Forms (All Built)

| WinForms Form          | Role   | Description                               |
|------------------------|--------|-------------------------------------------|
| `FrmLogin`             | Both   | Login with role selector (Buyer/Seller)   |
| `FrmBuyerDashboard`    | Buyer  | Product grid, search, filter, add to cart |
| `FrmCart`              | Buyer  | Cart items, qty controls, subtotal        |
| `FrmCheckout`          | Buyer  | Recipient info, promo code, payment method|
| `FrmBuyerHistory`      | Buyer  | Transaction history with status filter    |
| `FrmSellerDashboard`   | Seller | Stats cards, top products, recent tx      |
| `FrmProducts`          | Seller | Add/edit/delete products, manage stock    |
| `FrmPromo`             | Seller | Create and manage promo codes             |
| `FrmSellerReport`      | Seller | Crystal Reports viewer (placeholder)      |

---

## Role-Based Access

- After login, `SessionManager.CurrentUser` holds the logged-in user's info (ID, name, role).
- `Buyer` role: Dashboard, Cart, Checkout, History.
- `Seller` role: Dashboard, Products, Promo, Report.
- Attempting to access a restricted form programmatically should throw `UnauthorizedAccessException`.

---

## Key Business Rules

1. **Stock check** — Before adding to cart or confirming checkout, always verify `Product.Stock >= requested quantity`.
2. **Promo validation** — A promo is valid only if `IsActive = 1`, today falls between `ValidFrom` and `ValidUntil`, and the code exists in the DB.
3. **Transaction number** — Auto-generate as `TRX-{yyyyMMdd}-{sequence}`, e.g. `TRX-20260510-001`.
4. **Stock decrement** — Only decrement product stock after the transaction status is set to `Selesai`.
5. **Password storage** — Never store plain-text passwords. Use SHA-256 hashing at minimum.
6. **Currency** — All prices are in Indonesian Rupiah (IDR). Format as `Rp X.XXX` using `FormatHelper.ToRupiah()`.

---

## Naming Conventions

- **Forms**: `Frm` prefix — e.g. `FrmLogin`, `FrmCart`
- **Models**: PascalCase nouns — e.g. `Product`, `Transaction`
- **DAL classes**: `[Model]DAL` — e.g. `ProductDAL`, `UserDAL`
- **BLL classes**: `[Domain]BLL` — e.g. `CartBLL`, `CheckoutBLL`
- **DB columns**: PascalCase — e.g. `ProductID`, `CreatedAt`
- **Local variables**: camelCase — e.g. `productList`, `currentUser`
- **Constants**: UPPER_SNAKE_CASE — e.g. `MAX_CART_ITEMS`

---

## Crystal Reports

Crystal Reports is **required** for all seller-facing reports. Use **SAP Crystal Reports for Visual Studio** (free download from SAP).

### Installation

1. Download **SAP Crystal Reports, version for Visual Studio** from SAP
2. Install and restart Visual Studio
3. Add `.rpt` files and `CrystalReportViewer` to `FrmSellerReport`

### Required Reports

| .rpt File                    | Description                                      | Data Source              |
|------------------------------|--------------------------------------------------|--------------------------|
| `RptTransactionSummary.rpt`  | Total revenue, transaction count by period       | `vw_TransactionSummary`  |
| `RptTransactionDetail.rpt`   | Full line-item breakdown per transaction         | `TransactionDetails` join|
| `RptTopProducts.rpt`         | Best-selling products ranked by qty & revenue    | `vw_TopProducts`         |
| `RptPromoUsage.rpt`          | Promo code usage count and discount given        | `PromoCodes`             |
| `RptProfitTrend.rpt`         | Revenue trend grouped by day / month / year      | `vw_ProfitTrend`         |

---

## DB Connection

Uses **Microsoft SQL Server Express** (free, local install). Stored in `App.config`:

```xml
<connectionStrings>
  <add name="BenshopDB"
       connectionString="Server=.\SQLEXPRESS;Database=BenshopDB;Integrated Security=True;"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

> For SQL Server Developer Edition, use `Server=localhost` instead.

---

## C# 5 Constraint

The project compiles with MSBuild v4.0's C# 5 compiler. **Do not use C# 6+ features:**
- No `$"..."` string interpolation — use `string.Format()`
- No `?.` null-conditional — use explicit `!= null` checks
- No `=>` expression-bodied members — use full `get { return ...; }`
- No switch expressions — use `if/else` or classic `switch`

---

## Notes for AI Assistants

- When generating WinForms code, always use `.Designer.cs` separation (standard VS pattern).
- Prefer `DataGridView` for tabular data; use `Panel` for the sidebar nav.
- All SQL queries must use **parameterized queries** (`SqlParameter`) — never string concatenation.
- When adding a new form, register it in `SessionManager` and update navigation in the dashboard.
- Primary color: `#0D9488` (teal). Nav background: `#0F172A` (dark navy). Background: `#F8FAFC`.
- **Crystal Reports is required** — do not use RDLC or any other reporting tool.
- Always feed Crystal Reports via a `DataSet` from `ReportBLL` — never connect the `.rpt` file directly to the DB.
- `CartBLL` holds items in-memory (`static List<CartItem>`) — cart state resets on app restart.
- When creating SQL views for reports, add them to the database schema scripts.

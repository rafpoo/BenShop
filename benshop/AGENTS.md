# AGENTS.md — Benshop Project

This file provides context and guidance for the AI coding assistant (opencode) when working on the **Benshop** project.

---

## Project Overview

**Benshop** is a Windows Forms desktop application built with **.NET Framework (C#)** and **Microsoft SQL Server**. It is a mini-market management system with two user roles: **Buyer (Pembeli)** and **Seller (Penjual)**.

---

## Tech Stack

| Layer          | Technology                                  |
|----------------|---------------------------------------------|
| UI             | Windows Forms (.NET Framework, C#)          |
| Language       | C# (.NET Framework 4.7.2) — **C# 5 syntax** (compiler constraint) |
| Database       | Microsoft SQL Server Express (local)        |
| DB Access      | ADO.NET / SqlConnection                     |
| Auth           | Role-based session (Buyer / Seller)         |
| Reporting      | SAP Crystal Reports for Visual Studio (not yet integrated) |

---

## Project Structure

```
Benshop/
├── AGENTS.md                    ← This file
├── CLAUDE.md                    ← Original context file
├── benshop.slnx                 ← Visual Studio solution (SLNX format)
├── benshop/
│   ├── Program.cs               ← Entry point (shows FrmLogin → role-based dashboard)
│   ├── App.config               ← DB connection string
│   ├── benshop.csproj           ← Project file
│   ├── Forms/
│   │   ├── Login/
│   │   │   └── FrmLogin.cs/.Designer.cs
│   │   ├── Buyer/
│   │   │   ├── FrmBuyerDashboard.cs/.Designer.cs
│   │   │   ├── FrmCart.cs/.Designer.cs
│   │   │   ├── FrmCheckout.cs/.Designer.cs
│   │   │   ├── FrmBuyerHistory.cs/.Designer.cs
│   │   │   ├── FrmQtySelector.cs/.Designer.cs        ← Qty picker dialog
│   │   │   └── FrmTransactionDetail.cs/.Designer.cs  ← Tx detail dialog
│   │   └── Seller/
│   │       ├── FrmSellerDashboard.cs/.Designer.cs
│   │       ├── FrmProducts.cs/.Designer.cs
│   │       ├── FrmPromo.cs/.Designer.cs
│   │       └── FrmSellerReport.cs/.Designer.cs       ← CrystalReportViewer target
│   ├── Models/
│   │   ├── User.cs
│   │   ├── Product.cs
│   │   ├── CartItem.cs
│   │   ├── Transaction.cs
│   │   ├── TransactionDetail.cs
│   │   └── PromoCode.cs
│   ├── DAL/
│   │   ├── DBHelper.cs
│   │   ├── UserDAL.cs
│   │   ├── ProductDAL.cs
│   │   ├── TransactionDAL.cs
│   │   └── PromoDAL.cs
│   ├── BLL/
│   │   ├── AuthBLL.cs
│   │   ├── ProductBLL.cs
│   │   ├── CartBLL.cs
│   │   ├── CheckoutBLL.cs
│   │   └── ReportBLL.cs
│       └── Helpers/
│       ├── SessionManager.cs
│       ├── FormatHelper.cs
│       └── ValidationHelper.cs
├── BenshopDB/
│   ├── schema.sql               ← Full DB schema (tables + views)
│   └── seed.sql                 ← Sample data for testing
```

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

## Key Business Rules

1. **Stock check** — Always verify `Product.Stock >= requested quantity` before adding to cart or confirming checkout.
2. **Promo validation** — A promo is valid only if `IsActive = 1`, today falls between `ValidFrom` and `ValidUntil`, and the code exists in the DB.
3. **Transaction number** — Auto-generate as `TRX-{yyyyMMdd}-{sequence}`.
4. **Stock decrement** — Only decrement product stock after transaction status is set to `Selesai`.
5. **Password storage** — Never store plain-text passwords. Use SHA-256 hashing at minimum.
6. **Currency** — All prices are in IDR. Format as `Rp X.XXX` using `FormatHelper.ToRupiah()`.

---

## Role-Based Access

- `SessionManager.CurrentUser` holds the logged-in user's info (ID, name, role).
- `Buyer` role: Dashboard, Cart, Checkout, History.
- `Seller` role: Dashboard, Products, Promo, Report.
- Restricted access should throw `UnauthorizedAccessException`.

---

## Build & Run

- **Build**: Open `benshop.slnx` in Visual Studio 2022+ and build, or use MSBuild:
  ```
  MSBuild benshop.csproj /p:Configuration=Debug /t:Rebuild
  ```
- **Run**: The app starts with `FrmLogin`. On successful login, it opens the role-appropriate dashboard.
- **DB required**: The app expects a SQL Server instance with the `BenshopDB` database. Update the connection string in `App.config`.

---

## C# 5 Compatibility

The environment uses MSBuild v4.0 with C# 5 compiler. **C# 6+ features are NOT available.** Specifically avoid:
- String interpolation `$"..."` → use `string.Format()`
- Expression-bodied members `=>` → use `get { return ...; }`
- Null-conditional operator `?.` → use explicit `!= null` checks
- Switch expressions → use `if/else` or `switch` statement

---

## Code Guidelines (for opencode)

- Always use `.Designer.cs` separation for WinForms (standard VS pattern).
- Prefer `DataGridView` for tabular data; `Panel` + custom painting for sidebar nav.
- Use `async/await` for DB calls to avoid freezing the UI thread.
- All SQL queries must use **parameterized queries** (`SqlParameter`) — never string concatenation.
- Primary color: `#0D9488` (teal). Nav background: `#0F172A` (dark navy). Background: `#F8FAFC`.
- **Crystal Reports is required** — do not use RDLC or any other reporting tool.
- Always feed Crystal Reports via a `DataSet` from `ReportBLL` — never connect `.rpt` files directly to the DB.
- `CrystalReportViewer` must be embedded inside `FrmSellerReport` — not in a separate window.
- The `CartBLL` uses an in-memory `List<CartItem>` as a session cart (no DB cart table).

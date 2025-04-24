
# 🏦 Banking Operations Application

A secure, multi-tiered **banking desktop application** designed for internal staff at a financial institution to manage everyday banking operations. This application was developed as part of the **Object-Oriented Programming** (OOP) module.

---

##  Project Overview

This project showcases practical application of **Object-Oriented Programming principles** like **encapsulation**, **inheritance**, and **polymorphism** while also demonstrating layered architectural thinking. It is a staff-facing banking solution allowing controlled and validated operations like account creation, editing, deposits, withdrawals, transfers, and transaction history viewing.

---

###  Key Concepts & Skills:

- Multi-tier architecture: **Presentation**, **Business**, **Data Access**
- Strong OOP Design: Modular, testable, and reusable classes
-  Automated Testing: Full coverage using **MSTest**
-  Data serialization: Export account history to **XML**
- SQL Design: Tables, constraints, triggers, and stored procedures
- UI/UX Principles: Consistent WPF styling and client-side validation

---

## Application Architecture

This system follows a **Three-Layered Architecture**:

### 1️. Presentation Layer (WPF UI) 🖌️
- **Technologies**: WPF, XAML, MVVM patterns
- **Windows Included**:
  - `MainWindow` (Login)
  - `NewAccountWindow`
  - `EditAccountWindow`
  - `TransferAmountWindow`
  - `UserTransactionWindow`
  - `ViewTransactionsWindow`
  - `UnderConstructionWindow`

- **Validation**: Centralized `InputValidation` class handles name, email, phone, balance checks, etc.

### 2️. Business Logic Layer (Class Library - BIZ) 💵
Handles all core processing rules.

####  Classes:
- `UserAccount` - Lifecycle ops (create, update)
- `UserTransactions` - Deposit and withdrawal logic
- `Transfer` - Internal & external fund transfer validation
- `ExportXML` - Serializes account & transaction data into XML using LINQ-to-XML

### 3️. Data Access Layer (Class Library - DAL) 💾
Manages interaction with the MS SQL Server database via stored procedures.

#### Key Classes:
- `DAO` - Base DB connector using `App.config`
- `AccountData` - Account creation, updates, retrieval
- `TransactionData` - Balance updates, transfers, history retrieval

---

## 🧪 Testing with MSTest

Automated tests were written to cover all tiers using **MSTest.Sdk v3.6.4**:

- ✅ Business Logic (Transfers, transactions, XML export)
- ✅ Data Access (Connection checks, procedure calls)
- ✅ Presentation (Input validation and UI state)

> Tests follow **AAA pattern (Arrange-Act-Assert)** and run against a local SQL instance (MSSQLLocalDB).

---

## 🗂️ Database Design

- **Tables**: `User`, `Transfers`, `TransactionHistory`
- **Constraints**: Primary keys, foreign keys, unique fields, check constraints
- **Defaults**: SortCode (101010), Overdraft (0), Timestamps via `GETDATE()`
- **Stored Procedures**: `uspAddAccount`, `uspUpdateBalance`, `uspAddTransferRecord`, etc.
- **Trigger**: `trg_Transactions` logs balance changes automatically

---

## 🧾 XML Reporting

Accounts can be exported into structured **XML** files, including:
- User Details
- Full Transaction History

Uses `XDocument` for LINQ-to-XML serialization ensuring clean, portable data.

---

## 👨‍💻 Developer Info

- 👤 **Name**: Pratyush Kakkar  
- 🧑‍🏫 **Module**: Object-Oriented Programming (CA2)  
- 📘 **Lecturer**: Damien Kettle

---

## 📁 How to Run

1. Clone this repository.
2. Open the solution in **Visual Studio 2022+**
3. Set `MainWindow.xaml` as the startup window
4. Ensure connection string in `App.config` points to your local SQL DB file
5. Run the application or test project to validate

---

## 🧾 License

This project is an academic submission. Feel free to reference for educational purposes.

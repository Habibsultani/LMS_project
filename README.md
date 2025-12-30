# 📚 Library Management System (LMS)

A **desktop-based Library Management System** developed using **C# WinForms** and **MySQL**.  
This application is designed to manage **books, users (students), borrowing operations, penalties, and reports** in a structured and reliable way.

The project is developed as part of a **Database Management Systems (DBMS)** course and demonstrates real-world usage of **relational database design**, **business rules**, and **desktop application architecture**.

---

## 🚀 Features

### 👤 User (Student) Management
- List all registered students on form load
- Add new students
- Update student information
- Delete students
- Search students by **name** or **email**
- Prevent deletion of students with **active borrowings**
- Track **total penalty balance** per student

---

### 📖 Book Management
- List all books automatically on form load
- Add new books with:
  - Category selection (**1–N relationship**)
  - Author assignment (**N–N relationship**)
- Automatically insert a **new author** if it does not already exist
- Update book information
- Delete books (blocked if active borrow exists)
- Search books by:
  - Book name
  - Author name

---

### 🔄 Borrowing (Ödünç) System
- Borrow books with availability check
- Automatically decrease available stock
- Return books
- Restore stock on return
- Prevent borrowing when stock is zero

---

### 💰 Penalty (Ceza) System
- Automatic late-day calculation
- Automatic penalty generation
- Store penalties per borrowing
- Track total unpaid penalties per student

---

### 🔍 Dynamic Query System
- Advanced book search using optional filters:
  - Book name
  - Author name
  - Category
  - Publication year range
  - Only available books
- Implemented using **dynamic SQL query construction**

---

### 📊 Reports
- Most borrowed books
- Late returned books
- Borrowing statistics
- Penalty-related reports

---

## 🧠 Technologies Used
- **C# (.NET WinForms)**
- **MySQL**
- **ADO.NET (MySql.Data)**
- **SQL Transactions**
- **Parameterized Queries**

---

## 🗂️ Project Structure

```text
LMS_project
│
├── Database
│   └── DbConnection.cs
│
├── Forms
│   ├── LoginForm.cs
│   ├── MainForm.cs
│   ├── UyeForm.cs
│   ├── KitapForm.cs
│   ├── OduncForm.cs
│   ├── CezaForm.cs
│   ├── DinamikSorguForm.cs
│   ├── Raporlar.cs
│   ├── RaporOduncForm.cs
│   ├── RaporEnCokOduncForm.cs
│   └── RaporGecikenKitaplarForm.cs
│
├── Model
│   ├── Kitap.cs
│   └── Uye.cs
│
├── Resources
│   └── *.jpg
│
├── Program.cs
└── README.md

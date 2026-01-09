# 📚 Library Management System (LMS)

A **desktop-based Library Management System** developed using **C# WinForms** and **MySQL**.  
This application is designed to manage **books, users (students), borrowing operations, penalties, dynamic queries, and reports** in a structured and reliable way.

📺 **Project Presentation Video (YouTube):**  
👉 https://youtu.be/rGDiv6uhc_U

This project was developed as part of the **Database Management Systems (VTYS / DBMS)** course and demonstrates real-world usage of:
- Relational database design
- Business logic at database level
- Desktop application development

---

## 🚀 Features

### 👤 User (Student) Management
- List all registered students automatically on form load
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
- Delete books (blocked if an active borrowing exists)
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
- Penalties stored per borrowing
- Track total unpaid penalties per student

---

### 🔍 Dynamic Query System
- Advanced book search using optional filters:
  - Book name
  - Author name
  - Category
  - Publication year range (min–max)
  - Only available books
- Implemented using **dynamic SQL query construction**
- Filters are optional and combined dynamically at runtime

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
- **Stored Procedures**
- **Triggers**
- **SQL Transactions**
- **Parameterized Queries**

---

## 🗄️ Database Design Summary

- Relational database model
- Tables connected using **Primary Keys** and **Foreign Keys**
- Data redundancy minimized through normalization
- Business rules handled at **database level** using:
  - Stored Procedures
  - Triggers
- ER Diagram prepared using **draw.io**

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
```

## ⚙️ How to Run the Project (Local Setup)

Follow the steps below to run the **Library Management System (LMS)** on your local machine.

### 🔧 Requirements
Make sure the following tools are installed:

- **Windows OS**
- **Visual Studio 2022** (or later)
  - `.NET Desktop Development` workload enabled
- **XAMPP** (for MySQL)
- **MySQL Server**
- **Git** (optional, for collaboration)

---

### 🗄️ Database Setup (MySQL)

1. Open **XAMPP Control Panel**
2. Start the **MySQL** service
3. Open **phpMyAdmin**
4. To create the database and all required objects, execute the SQL scripts located in the `SQLdb` folder **in the following order**:

   ```text
   00_create_db.sql
   01_tables.sql
   02_procedures.sql
   03_triggers.sql
   04_seed_data.sql
   ```
 5. After all scripts are executed successfully:
    ```text
    1.Make sure MySQL and Apache services are running in XAMPP
    2.Open the project in Visual Studio
    3.Build and run the application
    ```
###⚠️ Important:
    The SQL files must be executed in the given order to ensure correct database creation and proper application functionality


## 🤝 Contributing

Contributions are welcome and appreciated!

- Fork the repository and create a new branch for your feature or fix.
- Follow the existing project structure and coding conventions.
- Do not add unnecessary files, build artifacts, or temporary data.
- If your change affects functionality, briefly describe how it was tested
  (e.g., example workflow, screenshots, or console output).
- Commit your changes with clear and meaningful commit messages.
- Open a Pull Request (PR) and explain **what** was changed and **why**.

Please make sure your changes do not break existing features such as:
- Book management
- User (student) management
- Borrowing and penalty logic
- Database procedures and triggers




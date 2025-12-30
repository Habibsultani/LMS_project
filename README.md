📚 Library Management System (LMS)

A desktop-based Library Management System developed using C# WinForms and MySQL, designed to manage books, users, borrowing operations, penalties, and analytical reports in a structured and reliable way.

This project demonstrates relational database design, transaction management, dynamic querying, and real-world business rules commonly found in institutional library systems.

🚀 Features
👤 User (Student) Management

List all registered students

Add, update, delete students

Search students by name or email

Prevent deletion of students with active borrowings

Track total penalty balance per student

📖 Book Management

List all books on form load

Add new books with:

Category assignment (1–N relationship)

Author assignment (N–N relationship via junction table)

Automatically create new authors or categories if they do not exist

Update and delete books

Prevent deletion of books with active loans

Search books by:

Book name

Author name

🔄 Borrow & Return System

Borrow books with stock validation

Decrease available stock automatically

Return books with:

Late day calculation

Automatic penalty generation

Restore book stock on return

💰 Penalty (Ceza) Management

Automatically calculate penalties for late returns

Store penalties per loan

Display penalties per student

Track total outstanding debt

🔍 Dynamic Query (Advanced Search)

Search books dynamically using optional filters:

Book name

Author name

Category

Publication year range

Availability (only books in stock)

Built using dynamic SQL construction

📊 Reports

Most borrowed books

Overdue (late) books

Borrowing statistics

Penalty-related reports

🧠 Technologies Used

C# (.NET WinForms) – Desktop application

MySQL – Relational database

ADO.NET (MySql.Data) – Database connectivity

SQL Transactions – Data consistency

Parameterized Queries – SQL injection prevention

🗂️ Project Structure
LMS_project
│
├── Database
│   └── DbConnection.cs          # MySQL connection helper
│
├── Forms
│   ├── LoginForm.cs             # User login
│   ├── MainForm.cs              # Main menu
│   ├── UyeForm.cs               # Student management
│   ├── KitapForm.cs             # Book management
│   ├── OduncForm.cs             # Borrow / Return operations
│   ├── CezaForm.cs              # Penalty management
│   ├── DinamikSorguForm.cs      # Dynamic search
│   ├── Raporlar.cs              # Reports menu
│   ├── RaporOduncForm.cs
│   ├── RaporEnCokOduncForm.cs
│   └── RaporGecikenKitaplarForm.cs
│
├── Model
│   ├── Kitap.cs                 # Book model
│   └── Uye.cs                   # Student model
│
├── Resources
│   └── *.jpg                    # UI background images
│
├── Program.cs                   # Application entry point
└── README.md

🗃️ Database Design Summary
Key Tables

ogrenci_uyeler

kitaplar

kategori

yazar

kitap_yazari (junction table)

odunc

ceza

Relationships

Category → Book : One-to-Many (1–N)

Book ↔ Author : Many-to-Many (N–N)

Student → Loan : One-to-Many (1–N)

Loan → Penalty : One-to-One / Optional

⚙️ How to Run the Project
1️⃣ Prerequisites

Visual Studio 2022 or newer

.NET Desktop Development workload

MySQL Server

MySQL Connector / NET (MySql.Data)

2️⃣ Database Setup

Create a MySQL database (e.g. lms_db)

Import the provided SQL schema

Update the connection string in:

Database/DbConnection.cs


Example:

server=localhost;
database=lms_db;
uid=root;
pwd=your_password;

3️⃣ Run the Application

Open the solution in Visual Studio

Restore NuGet packages

Set LMS_project as startup project

Run the application (F5)

🔐 Security & Data Integrity

All SQL operations use parameterized queries

Critical operations use transactions

Business rules enforced at:

Application level

Database level

🎯 Educational Objectives

This project was developed to demonstrate:

Relational database modeling

CRUD operations

Transaction management

Dynamic SQL queries

Desktop application architecture

Real-life business logic implementation

📌 Author

Developed by Yasin
Computer Engineering Student
Library Management System – DBMS Project

# 🎓 Pickleball Club Management System

> Hệ thống quản lý câu lạc bộ Pickleball hoàn chỉnh - Vợt Thủ Phố Núi

[![.NET Version](https://img.shields.io/badge/.NET-10.0-blue.svg)](https://dotnet.microsoft.com/download)
[![License](https://img.shields.io/badge/license-Educational-green.svg)](#)
[![Status](https://img.shields.io/badge/status-Active-brightgreen.svg)](#)

## 📌 Tóm Tắt Nhanh

Ứng dụng web **ASP.NET Core Razor Pages** được xây dựng hoàn chỉnh để quản lý hoạt động câu lạc bộ pickleball, bao gồm:

- 👥 Quản lý thành viên
- ⚔️ Tổ chức kèo cạnh tranh
- 🏆 Theo dõi trận đấu
- 🏟️ Đặt sân phòng chơi
- 💰 Quản lý tài chính
- 📰 Quản lý tin tức

---

## 🚀 Khởi Động Nhanh (3 Bước)

### 1. Clone Repository
```bash
git clone <repository-url>
cd kiemtra2026v2
```

### 2. Cấu Hình Database
Chỉnh sửa `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=PCM_Database;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### 3. Setup & Run
```bash
dotnet restore
dotnet ef database update
dotnet build
dotnet run
```

Truy cập: **https://localhost:5268**

---

## 🔑 Đăng Nhập Ngay

**Admin Account:**
```
Email: admin@pickleballclub.com
Password: Admin@123
```

**Member Account:**
```
Email: nguyenvana@example.com
Password: Member@123
```

---

## 📚 Tài Liệu

| File | Nội Dung |
|------|----------|
| [README.md](README.md) | Hướng dẫn chi tiết cài đặt & sử dụng |
| [INSTRUCTOR_GUIDE.md](INSTRUCTOR_GUIDE.md) | Hướng dẫn cho giảng viên & sinh viên |
| [SETUP_INSTRUCTIONS.md](SETUP_INSTRUCTIONS.md) | Hướng dẫn setup từng bước |
| [DATABASE_CONFIG.md](DATABASE_CONFIG.md) | Cấu hình database cho các hệ thống khác nhau |
| [CHANGELOG.md](CHANGELOG.md) | Lịch sử thay đổi & cập nhật |

---

## 🛠️ Yêu Cầu Hệ Thống

- ✅ **.NET 10.0 SDK** trở lên
- ✅ **SQL Server** (2016 hoặc mới hơn)
- ✅ **Visual Studio / VS Code** (tùy chọn)

**Kiểm tra:**
```bash
dotnet --version
sqlcmd -S . -Q "SELECT @@VERSION"
```

---

## 📊 Cấu Trúc Project

```
kiemtra2026v2/
├── Models/                    # Entity models (9 loại)
├── Data/                      # DbContext & Entity configurations
├── Services/                  # Business logic & Seeding
├── Pages/                     # Razor Pages (20+)
├── Migrations/                # EF Core migrations (6 files)
├── wwwroot/                   # Static files (CSS, JS, images)
├── Properties/                # Startup configuration
├── Program.cs                 # Application entry point
├── appsettings.json           # Configuration
└── README.md, docs/           # Documentation
```

---

## 🗄️ Database Schema

**9 Bảng Chính:**

| Bảng | Mục Đích | Records |
|------|----------|---------|
| 395_Members | Thành viên | 9 (1 admin + 8 members) |
| 395_Challenges | Kèo cạnh tranh | 5+ |
| 395_Matches | Trận đấu | 3+ |
| 395_Bookings | Đặt sân | 4+ |
| 395_Courts | Quản lý sân | 3 |
| 395_Transactions | Giao dịch | 3+ |
| 395_TransactionCategories | Loại giao dịch | 5 |
| 395_Participants | Người tham gia | 10+ |
| 395_News | Tin tức | Auto-create |

**Plus:** AspNetCore Identity tables (Users, Roles, Claims, v.v.)

---

## 🔐 Tính Năng Bảo Mật

- ✅ ASP.NET Core Identity
- ✅ Role-based Authorization (Admin/Member)
- ✅ Password hashing & validation
- ✅ CSRF protection
- ✅ SQL Injection prevention
- ✅ Email confirmation support

---

## 📱 Tính Năng Chính

### 👤 Người Dùng Thành Viên
- 🔍 Tìm kiếm kèo cạnh tranh
- 📅 Đặt sân chơi
- 📊 Xem lịch sử trận đấu
- 👤 Quản lý hồ sơ cá nhân

### 🎖️ Admin
- ⚖️ Nhập kết quả trận đấu
- 📋 Quản lý kèo cạnh tranh
- 💰 Quản lý tài chính
- 📊 Dashboard thống kê

### 🌐 Chung
- 🔐 Đăng nhập/Đăng ký
- 🔓 Đăng xuất
- 📰 Xem tin tức
- 🏠 Trang chủ

---

## 🔄 Database Migrations

Tất cả migrations được tự động apply khi chạy:
```bash
dotnet ef database update
```

**Migrations List:**
- ✅ InitialCreate
- ✅ AdvancedUpdate
- ✅ MakeCourtIdNullable
- ✅ FinalRenameTo186
- ✅ RenameTablesTo186
- ✅ Rename186To395 (Latest)

---

## 💾 Automatic Data Seeding

Khi ứng dụng start, hệ thống sẽ tự động:

1. **Tạo Roles:** Admin, Member
2. **Tạo Admin User:** admin@pickleballclub.com / Admin@123
3. **Tạo 8 Sample Members** với profile hoàn chỉnh
4. **Tạo Sample Challenges** (Duels & Mini-Games)
5. **Tạo Sample Matches** với kết quả
6. **Tạo Sample Bookings**
7. **Tạo Sample Courts** (3 sân)
8. **Tạo Sample Transactions** (tài chính)

---

## 🧪 Testing

Sau khi khởi động, kiểm tra:

```bash
# Login với admin account
https://localhost:5268

# Kiểm tra data seeding
- Members: 9 thành viên
- Challenges: 5+ kèo
- Matches: 3+ trận
- Courts: 3 sân
- Transactions: 3+ giao dịch
```

---

## ❌ Troubleshooting

### Lỗi Database Connection
```bash
# Kiểm tra SQL Server đang chạy
sqlcmd -S . -Q "SELECT @@VERSION"

# Update connection string trong appsettings.json
```

### Lỗi Build
```bash
dotnet clean
dotnet restore
dotnet build
```

### Lỗi Migrations
```bash
# Xem migrations
dotnet ef migrations list

# Apply migrations
dotnet ef database update
```

**Chi tiết:** Xem [TROUBLESHOOTING](SETUP_INSTRUCTIONS.md#-troubleshooting-connection)

---

## 📖 Chi Tiết Hơn

- **Cài đặt chi tiết:** [SETUP_INSTRUCTIONS.md](SETUP_INSTRUCTIONS.md)
- **Hướng dẫn giáo viên:** [INSTRUCTOR_GUIDE.md](INSTRUCTOR_GUIDE.md)
- **Cấu hình database:** [DATABASE_CONFIG.md](DATABASE_CONFIG.md)
- **Full README:** [README.md](README.md)

---

## 🛠️ Stack Công Nghệ

- **Backend:** ASP.NET Core 10.0 (Razor Pages)
- **Database:** SQL Server + Entity Framework Core
- **Frontend:** HTML, CSS, Bootstrap, JavaScript
- **Authentication:** ASP.NET Core Identity
- **Architecture:** Clean Architecture, Repository Pattern

---

## 📊 Statistics

- **Lines of Code:** 5000+
- **Models:** 9
- **Services:** 5
- **Pages:** 20+
- **Database Tables:** 12 (9 custom + 3 Identity)
- **Migrations:** 6

---

## 🎯 Checklist Hoàn Thành

- ✅ Project structure
- ✅ Database design & migrations
- ✅ Models & relationships
- ✅ Services & business logic
- ✅ Pages & UI
- ✅ Authentication & authorization
- ✅ Data seeding
- ✅ Error handling
- ✅ Responsive design
- ✅ Documentation
- ✅ Testing

---

## 📝 License

Dự án này được phát triển cho mục đích **giáo dục**.

---

## 📞 Hỗ Trợ

Nếu gặp vấn đề:
1. ✅ Kiểm tra [SETUP_INSTRUCTIONS.md](SETUP_INSTRUCTIONS.md)
2. ✅ Kiểm tra [INSTRUCTOR_GUIDE.md](INSTRUCTOR_GUIDE.md)
3. ✅ Kiểm tra [README.md](README.md)
4. ✅ Xem logs từ application

---

## 🎓 Dành Cho Sinh Viên

- Clone repository này
- Theo dõi [SETUP_INSTRUCTIONS.md](SETUP_INSTRUCTIONS.md)
- Chạy `dotnet ef database update`
- Chạy `dotnet run`
- Truy cập & khám phá ứng dụng

**Tài liệu để tìm hiểu:**
- ASP.NET Core: https://docs.microsoft.com/aspnet/core
- EF Core: https://docs.microsoft.com/en-us/ef/core/
- Razor Pages: https://docs.microsoft.com/en-us/aspnet/core/razor-pages

---

**Chuẩn bị ngày:** 25/01/2026  
**Framework:** .NET 10.0  
**Status:** ✅ Production Ready  
**Version:** 1.0

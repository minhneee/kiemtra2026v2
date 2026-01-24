# 📚 Danh Mục Tài Liệu

## 📖 Hướng Dẫn Chính

| Tài Liệu | Link | Mục Đích |
|----------|------|----------|
| **README.md** | [Đọc](README.md) | 📘 Hướng dẫn đầy đủ cài đặt, cấu hình, chạy ứng dụng |
| **QUICK_START.md** | [Đọc](QUICK_START.md) | ⚡ Khởi động nhanh trong 3 bước |
| **SETUP_INSTRUCTIONS.md** | [Đọc](SETUP_INSTRUCTIONS.md) | 📋 Hướng dẫn setup chi tiết từng bước |
| **INSTRUCTOR_GUIDE.md** | [Đọc](INSTRUCTOR_GUIDE.md) | 🎓 Hướng dẫn cho giáo viên/sinh viên |
| **DATABASE_CONFIG.md** | [Đọc](DATABASE_CONFIG.md) | 🗄️ Cấu hình database cho các hệ thống khác nhau |
| **CHANGELOG.md** | [Đọc](CHANGELOG.md) | 📝 Lịch sử thay đổi & cập nhật |

---

## 🎯 Chọn Hướng Dẫn Phù Hợp

### 👨‍💼 Bạn là **Giáo Viên/Quản Trị Viên**?
→ 📖 Bắt đầu với [INSTRUCTOR_GUIDE.md](INSTRUCTOR_GUIDE.md)
- Hướng dẫn chi tiết cách setup
- Quản lý database
- Tạo tài khoản & dữ liệu

### 👨‍💻 Bạn là **Nhà Phát Triển**?
→ ⚡ Bắt đầu với [QUICK_START.md](QUICK_START.md)
- Khởi động nhanh
- Cấu hình tùy chỉnh
- Hướng dẫn phát triển thêm

### 🎓 Bạn là **Sinh Viên**?
→ 📋 Bắt đầu với [SETUP_INSTRUCTIONS.md](SETUP_INSTRUCTIONS.md)
- Hướng dẫn từng bước
- Xử lý lỗi thường gặp
- Kiểm tra thành công

### 🚀 Bạn muốn **Setup Nhanh**?
→ 📘 Xem [README.md](README.md) - Phần "Chạy Ứng Dụng"
- 3 bước cơ bản
- Tài khoản mặc định
- Các lệnh chính

---

## 📂 Cấu Trúc Thư Mục Dự Án

```
kiemtra2026v2/
│
├── 📘 README.md                    ← BẮTĐẦU ĐÂY
├── ⚡ QUICK_START.md              ← Khởi động nhanh
├── 📋 SETUP_INSTRUCTIONS.md        ← Setup chi tiết
├── 🎓 INSTRUCTOR_GUIDE.md          ← Hướng dẫn giáo viên
├── 🗄️ DATABASE_CONFIG.md           ← Config database
├── 📝 CHANGELOG.md                 ← Lịch sử thay đổi
│
├── 📄 Program.cs                   ← Entry point
├── ⚙️ appsettings.json             ← Cấu hình
│
├── Models/                         ← 9 Entity models
│   ├── Member.cs
│   ├── Challenge.cs
│   ├── Match.cs
│   ├── Booking.cs
│   ├── Court.cs
│   ├── News.cs
│   ├── Transaction.cs
│   ├── TransactionCategory.cs
│   └── Participant.cs
│
├── Data/                           ← Database context
│   └── ApplicationDbContext.cs
│
├── Services/                       ← Business logic
│   ├── DbSeeder.cs                (← Tạo dữ liệu mẫu)
│   ├── MemberService.cs
│   ├── ChallengeService.cs
│   ├── MatchService.cs
│   └── BookingService.cs
│
├── Pages/                          ← Razor Pages
│   ├── Account/
│   ├── Bookings/
│   ├── Challenges/
│   ├── Financial/
│   ├── Matches/
│   ├── Profile/
│   └── Shared/
│
├── Migrations/                     ← EF Core migrations
│   └── (6 migration files)
│
├── wwwroot/                        ← Static files
│   ├── css/
│   ├── js/
│   └── lib/
│
└── Properties/                     ← Project properties
    └── launchSettings.json
```

---

## 📌 Quick Links

### 🚀 Bắt Đầu Nhanh (5 phút)
```bash
git clone <url>
cd kiemtra2026v2
# Cập nhật appsettings.json
dotnet restore && dotnet ef database update && dotnet run
# Mở https://localhost:5268
```

### 📚 Tài Liệu Đầy Đủ
1. **Cài đặt:** [README.md](README.md#-cài-đặt)
2. **Chạy:** [README.md](README.md#-chạy-ứng-dụng)
3. **Tài khoản test:** [INSTRUCTOR_GUIDE.md](INSTRUCTOR_GUIDE.md#-tài-khoản-test)
4. **Troubleshooting:** [SETUP_INSTRUCTIONS.md](SETUP_INSTRUCTIONS.md#-lỗi-phổ-biến--cách-fix)

### 🗄️ Database
- **Cấu hình:** [DATABASE_CONFIG.md](DATABASE_CONFIG.md)
- **Schema:** [README.md](README.md#-database-tables)
- **Migrations:** [CHANGELOG.md](CHANGELOG.md#-database)

### 🐛 Gặp Vấn Đề?
→ [SETUP_INSTRUCTIONS.md - Troubleshooting](SETUP_INSTRUCTIONS.md#-lỗi-phổ-biến--cách-fix)

---

## 🎓 Hướng Dẫn Theo Vai Trò

### Giáo Viên
1. Đọc: [INSTRUCTOR_GUIDE.md](INSTRUCTOR_GUIDE.md)
2. Setup database: [DATABASE_CONFIG.md](DATABASE_CONFIG.md)
3. Chạy migrations: `dotnet ef database update`
4. Run app: `dotnet run`

### Sinh Viên
1. Đọc: [SETUP_INSTRUCTIONS.md](SETUP_INSTRUCTIONS.md) - Bước 1-6
2. Clone & setup project
3. Chạy `dotnet ef database update`
4. Chạy `dotnet run`
5. Test với tài khoản mẫu

### Nhà Phát Triển
1. Đọc: [README.md](README.md)
2. Chọn [DATABASE_CONFIG.md](DATABASE_CONFIG.md) phù hợp
3. Customize nếu cần
4. Deploy theo yêu cầu

---

## 🔑 Tài Khoản Test

```
Admin:
  Email: admin@pickleballclub.com
  Password: Admin@123

Members:
  Email: nguyenvana@example.com ... buivanh@example.com
  Password: Member@123
```

👉 Xem đầy đủ tại [INSTRUCTOR_GUIDE.md](INSTRUCTOR_GUIDE.md#-tài-khoản-test)

---

## ⚙️ Các Lệnh Quan Trọng

```bash
# Setup ban đầu
dotnet restore
dotnet ef database update
dotnet build

# Chạy ứng dụng
dotnet run

# Phát triển
dotnet watch run

# Build release
dotnet build --configuration Release
```

👉 Xem thêm tại [README.md](README.md#-các-lệnh-hữu-ích)

---

## 📊 Dữ Liệu Mẫu (Seed Data)

Được tạo tự động khi chạy migrations:
- ✅ 9 Members (1 admin + 8 members)
- ✅ 5+ Challenges (kèo cạnh tranh)
- ✅ 3+ Matches (trận đấu)
- ✅ 3 Courts (sân phòng chơi)
- ✅ 3+ Transactions (giao dịch tài chính)

👉 Chi tiết tại [CHANGELOG.md](CHANGELOG.md#-seeding-data)

---

## 🛠️ Troubleshooting

| Lỗi | Giải Pháp | Link |
|-----|----------|------|
| Connection failed | Kiểm tra appsettings.json | [DATABASE_CONFIG.md](DATABASE_CONFIG.md#-kiểm-tra-connection-string) |
| Migration error | Run `dotnet ef database update` | [SETUP_INSTRUCTIONS.md](SETUP_INSTRUCTIONS.md#-bước-4-apply-database-migrations) |
| Port already in use | Kiểm tra port 5268 | [SETUP_INSTRUCTIONS.md](SETUP_INSTRUCTIONS.md#-lỗi-port-already-in-use) |
| Build failed | `dotnet clean && dotnet build` | [SETUP_INSTRUCTIONS.md](SETUP_INSTRUCTIONS.md#-lỗi-build-failed) |

👉 Xem tất cả tại [SETUP_INSTRUCTIONS.md - Troubleshooting](SETUP_INSTRUCTIONS.md#-lỗi-phổ-biến--cách-fix)

---

## 🌐 Tài Liệu Bên Ngoài

- **ASP.NET Core:** https://docs.microsoft.com/aspnet/core
- **EF Core:** https://docs.microsoft.com/en-us/ef/core/
- **SQL Server:** https://docs.microsoft.com/en-us/sql/
- **.NET CLI:** https://docs.microsoft.com/en-us/dotnet/core/tools/

---

## 🎯 Checklist Chuẩn Bị

- [ ] .NET 10.0 SDK cài đặt
- [ ] SQL Server cài đặt
- [ ] Clone repository
- [ ] Cấu hình appsettings.json
- [ ] Chạy `dotnet ef database update`
- [ ] Chạy `dotnet run`
- [ ] Truy cập https://localhost:5268
- [ ] Đăng nhập & test

---

## 📞 Hỗ Trợ

Nếu cần giúp:
1. Kiểm tra các hướng dẫn ở trên
2. Xem phần Troubleshooting
3. Kiểm tra application logs

---

**Chuẩn bị:** 25/01/2026  
**Phiên bản:** 1.0  
**Status:** ✅ Ready to Use

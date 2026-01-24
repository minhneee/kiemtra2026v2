# Pickleball Club Management System

Hệ thống quản lý câu lạc bộ Pickleball - Vợt Thủ Phố Núi

## 📋 Mô Tả Dự Án

Ứng dụng web ASP.NET Core Razor Pages cho phép quản lý hoạt động câu lạc bộ pickleball, bao gồm:
- Quản lý thành viên và xếp hạng
- Tổ chức các trận đấu và kèo cạnh tranh
- Đặt sân phòng chơi
- Quản lý tài chính
- Quản lý tin tức câu lạc bộ

## 🛠️ Yêu Cầu Hệ Thống

- **.NET 10.0** trở lên
- **SQL Server** (Local hoặc Remote)
- **Visual Studio** hoặc **JetBrains Rider** (tùy chọn)

## 📦 Cài Đặt

### 1. Clone Repository
```bash
git clone <repository-url>
cd kiemtra2026v2
```

### 2. Cấu Hình Cơ Sở Dữ Liệu

Mở file `appsettings.json` và cập nhật connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER\\YOUR_INSTANCE;Database=PCM_Database;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

**Ví dụ:**
- **Local SQL Server:** `Server=.;Database=PCM_Database;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True`
- **SQL Server Express:** `Server=.\SQLEXPRESS;Database=PCM_Database;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True`
- **Remote Server:** `Server=your-server-name;Database=PCM_Database;User Id=sa;Password=your_password;MultipleActiveResultSets=true;TrustServerCertificate=True`

### 3. Cập Nhật Database

Chạy lệnh để tạo database và apply tất cả migrations:

```bash
dotnet ef database update
```

**Hoặc nếu sử dụng Package Manager Console trong Visual Studio:**
```powershell
Update-Database
```

### 4. Build Dự Án

```bash
dotnet build
```

## 🚀 Chạy Ứng Dụng

### Chế độ Development

```bash
dotnet run
```

Ứng dụng sẽ chạy tại: `https://localhost:5268` hoặc `http://localhost:5269`

### Chế độ Production

```bash
dotnet run --configuration Release
```

## 👤 Tài Khoản Admin Mặc Định

Sau khi chạy ứng dụng lần đầu, hệ thống sẽ tự động tạo tài khoản admin:

- **Email:** `admin@pickleballclub.com`
- **Mật khẩu:** `Admin@123`
- **Vai trò:** Admin

## 📊 Seeding Data

Khi ứng dụng khởi động, nó sẽ tự động:

1. **Tạo các role** (Admin, Member)
2. **Tạo tài khoản Admin** mặc định
3. **Tạo 8 thành viên mẫu** với các trận đấu, kèo, và dữ liệu tài chính

**Các thành viên mẫu được tạo:**
- Nguyễn Văn A (Rank: 1.5)
- Trần Thị B (Rank: 2.1)
- Lê Văn C (Rank: 1.6)
- Phạm Văn D (Rank: 2.0)
- Hoàng Thị E (Rank: 1.9)
- Vũ Văn F (Rank: 1.8)
- Đỗ Thị G (Rank: 2.2)
- Bùi Văn H (Rank: 1.7)

**Mật khẩu mẫu:** `Member@123`

## 📂 Cấu Trúc Thư Mục

```
kiemtra2026v2/
├── Data/                    # Entity Framework DbContext
│   └── ApplicationDbContext.cs
├── Models/                  # Entity models
│   ├── Member.cs
│   ├── Challenge.cs
│   ├── Match.cs
│   ├── Booking.cs
│   ├── Court.cs
│   ├── News.cs
│   ├── Transaction.cs
│   ├── TransactionCategory.cs
│   └── Participant.cs
├── Services/                # Business logic
│   ├── DbSeeder.cs          # Database seeding
│   ├── MemberService.cs
│   ├── ChallengeService.cs
│   ├── MatchService.cs
│   └── BookingService.cs
├── Pages/                   # Razor Pages
│   ├── Account/
│   ├── Bookings/
│   ├── Challenges/
│   ├── Financial/
│   ├── Matches/
│   ├── Profile/
│   └── Shared/
├── Migrations/              # EF Core migrations
├── Properties/
├── wwwroot/                 # Static files (CSS, JS, images)
├── Program.cs
├── appsettings.json
└── kiemtra2026v2.sln
```

## 🗄️ Database Tables

Ứng dụng sử dụng 9 bảng chính (với tiền tố `395_`):

| Bảng | Mô Tả |
|------|-------|
| `395_Members` | Thông tin thành viên |
| `395_Challenges` | Các kèo cạnh tranh |
| `395_Matches` | Kết quả trận đấu |
| `395_Bookings` | Đặt sân |
| `395_Courts` | Quản lý sân chơi |
| `395_News` | Tin tức câu lạc bộ |
| `395_Participants` | Người tham gia kèo/trận |
| `395_Transactions` | Giao dịch tài chính |
| `395_TransactionCategories` | Loại giao dịch |

## 🔧 Migrations

Tất cả migrations được lưu trong thư mục `Migrations/`:

- `InitialCreate` - Tạo schema cơ bản
- `AdvancedUpdate` - Thêm các bảng nâng cao
- `RenameTablesTo186` - Đổi tên bảng
- `Rename186To395` - Đổi tên bảng từ 186 thành 395 (migrations cuối cùng)

Để xem danh sách tất cả migrations:
```bash
dotnet ef migrations list
```

## 🔑 Chức Năng Chính

### Admin
- Nhập kết quả trận đấu
- Quản lý kèo cạnh tranh
- Quản lý tài chính
- Xem dashboard

### Member
- Tìm kèo cạnh tranh
- Đặt sân
- Xem lịch sử trận đấu
- Xem/cập nhật hồ sơ cá nhân

## 🐛 Troubleshooting

### Lỗi: "Database connection failed"
- Kiểm tra connection string trong `appsettings.json`
- Đảm bảo SQL Server đang chạy
- Kiểm tra quyền truy cập database

### Lỗi: "Migration pending"
```bash
dotnet ef database update
```

### Lỗi: "Could not find file 'ApplicationDbContext.cs'"
```bash
dotnet restore
```

## 📝 Logs

Ứng dụng sẽ ghi log trong console khi chạy mode development. Kiểm tra các thông báo liên quan đến:
- Entity Framework migrations
- Database seeding
- Application startup

## 📞 Hỗ Trợ

Nếu gặp vấn đề, vui lòng kiểm tra:
1. `.NET SDK` có được cài đặt đúng không
2. `SQL Server` có đang chạy không
3. `Connection string` có đúng không
4. Tất cả `migrations` đã được apply chưa

## 📄 License

Dự án này được phát triển cho mục đích giáo dục.

---

**Última cập nhật:** 25/01/2026
**Phiên bản .NET:** 10.0
**Entity Framework Core:** 10.0.2

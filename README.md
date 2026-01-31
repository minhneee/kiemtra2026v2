# Pickleball Club Management System

Hệ thống quản lý câu lạc bộ Pickleball - Vợt Thủ Phố Núi

## 📋 Mô Tả Dự Án

Ứng dụng web ASP.NET Core Razor Pages cho phép quản lý hoạt động câu lạc bộ pickleball, **không cần cơ sở dữ liệu**, bao gồm:
- Quản lý thành viên và xếp hạng
- Tổ chức các trận đấu và kèo cạnh tranh
- Đặt sân phòng chơi
- Quản lý tài chính
- Quản lý tin tức câu lạc bộ

**✨ Điểm nổi bật:** Ứng dụng sử dụng lưu trữ **in-memory** (bộ nhớ) thay vì cơ sở dữ liệu, cho phép chạy mà không cần SQL Server.

## 🛠️ Yêu Cầu Hệ Thống

- **.NET 10.0** trở lên
- **Visual Studio** hoặc **JetBrains Rider** (tùy chọn)
- **Không cần SQL Server** ✅

## 📦 Cài Đặt

### 1. Clone Repository
```bash
git clone <repository-url>
cd kiemtra2026v2
```

### 2. Build Dự Án

```bash
dotnet build
```

### 3. Xong! Không cần cấu hình database ✅

Ứng dụng sẽ tự động khởi tạo dữ liệu mẫu trong bộ nhớ khi khởi động.

## 🚀 Chạy Ứng Dụng

### Chế độ Development

```bash
dotnet run
```

Ứng dụng sẽ chạy tại: `http://localhost:5268`

### Chế độ Production

```bash
dotnet run --configuration Release
```

## 👤 Tài Khoản Đăng Nhập Mặc Định

Hệ thống cung cấp 1 tài khoản Admin mặc định:

**Tài khoản Admin:**
- **Username:** `admin`
- **Mật khẩu:** `admin123`
- **Vai trò:** Admin

Bạn có thể đăng ký tài khoản Member mới trực tiếp qua ứng dụng.

## 📊 Dữ Liệu Mẫu

Khi ứng dụng khởi động lần đầu, nó sẽ tự động tạo:

### Thành viên mẫu
- **Nguyễn Văn A** (Rank: 2.5)
- **Trần Thị B** (Rank: 3.0)
- **Phạm Văn C** (Rank: 2.0)

### Sân chơi
- Court 1, Court 2, Court 3

### Kèo cạnh tranh mẫu
- Kèo 500k - Chấp nửa trái (1v1)
- Kèo 1 triệu - Team Battle (2v2)

### Trận đấu mẫu
- Trận Singles với điểm số và các set
- Trận Doubles với kết quả chi tiết

### Danh mục giao dịch
**Khoản Thu (Income):**
- Court Booking Fee
- Tournament Fee
- Membership Fee

**Khoản Chi (Expense):**
- Court Maintenance
- Equipment & Supplies
- Staff Salary
- Prize & Awards

## 📂 Cấu Trúc Thư Mục

```
kiemtra2026v2/
├── Services/                # In-Memory Data Store & Services
│   ├── InMemoryDataStore.cs      # Lưu trữ dữ liệu trong bộ nhớ
│   ├── InMemoryUserStore.cs      # Lưu trữ tài khoản người dùng
│   ├── MemberService.cs
│   ├── ChallengeService.cs
│   ├── MatchService.cs
│   └── BookingService.cs
├── Models/                  # Entity models (không dùng EF Core)
│   ├── Member.cs
│   ├── Challenge.cs
│   ├── Match.cs
│   ├── MatchSet.cs
│   ├── Booking.cs
│   ├── Court.cs
│   ├── News.cs
│   ├── Transaction.cs
│   ├── TransactionCategory.cs
│   └── Participant.cs
├── Pages/                   # Razor Pages
│   ├── Account/
│   │   ├── Login.cshtml
│   │   ├── Register.cshtml
│   │   └── Logout.cshtml
│   ├── Bookings/
│   ├── Challenges/
│   ├── Financial/
│   ├── Matches/
│   ├── Profile/
│   └── Shared/
│       └── _LoginPartial.cshtml
├── Properties/
├── wwwroot/                 # Static files (CSS, JS, images)
│   ├── css/
│   ├── js/
│   └── lib/
├── Program.cs
├── appsettings.json
└── kiemtra2026v2.sln
```

## 🔐 Hệ Thống Xác Thực

Ứng dụng sử dụng **Cookie-based Authentication** (không sử dụng ASP.NET Identity):

- **Admin Role:** Có quyền truy cập các trang quản lý (Matches/Create, Financial, Challenges/Manage, News/Create)
- **Member Role:** Có quyền xem lịch sử trận đấu và đặt sân
- **Unauthenticated:** Có thể xem trang chủ

### Trang Yêu Cầu Admin
- `/Matches/Create` - Nhập kết quả trận đấu
- `/Financial` - Quản lý tài chính
- `/Financial/Create` - Ghi nhận giao dịch
- `/Challenges/Manage` - Quản lý kèo cạnh tranh
- `/News/Create`, `/News/Edit` - Quản lý tin tức

## 📦 In-Memory Data Storage

Tất cả dữ liệu được lưu trữ trong bộ nhớ (RAM) sử dụng static collections:

**Các collection chính:**
- `_members` - Danh sách thành viên
- `_challenges` - Danh sách kèo cạnh tranh
- `_matches` - Danh sách trận đấu
- `_matchSets` - Các set của trận đấu
- `_bookings` - Đặt sân
- `_courts` - Sân chơi
- `_news` - Tin tức
- `_transactions` - Giao dịch tài chính
- `_transactionCategories` - Loại giao dịch
- `_participants` - Người tham gia

**⚠️ Lưu ý:** Dữ liệu sẽ được reset mỗi khi ứng dụng khởi động lại. Để giữ lại dữ liệu, cần triển khai lưu trữ vào database hoặc file.

## 🔑 Chức Năng Chính

### Admin
- 📊 Nhập kết quả trận đấu
- 🏆 Quản lý kèo cạnh tranh
- 💰 Quản lý tài chính (ghi nhận thu chi)
- 📰 Tạo và quản lý tin tức câu lạc bộ
- 📈 Xem thống kê

### Member
- 🔍 Tìm kèo cạnh tranh
- 🎾 Đặt sân
- 📋 Xem lịch sử trận đấu
- 👤 Xem/cập nhật hồ sơ cá nhân

### Public
- 📰 Xem tin tức câu lạc bộ
- 🏠 Xem trang chủ
- 🔐 Đăng nhập/Đăng ký

## 🐛 Troubleshooting

### Lỗi: "Port 5268 already in use"
```bash
# Tìm process sử dụng port 5268 và terminate
netstat -ano | findstr :5268
taskkill /PID <PID> /F
```

### Lỗi: ".NET SDK not found"
- Cài đặt .NET 10.0 SDK từ https://dotnet.microsoft.com/download

### Lỗi: "Could not find a part of the path"
```bash
dotnet clean
dotnet build
```

### Dữ liệu mẫu không xuất hiện
- Kiểm tra xem `InMemoryDataStore.InitializeSampleData()` có được gọi trong `Program.cs` không
- Xóa folder `bin` và `obj`, sau đó rebuild

## 📝 Ghi Chú

- ✅ **Không cần SQL Server** - Ứng dụng sẽ chạy mà không cần cơ sở dữ liệu
- ✅ **Khởi động nhanh** - Không cần chạy migrations
- ⚠️ **Dữ liệu tạm thời** - Tất cả dữ liệu sẽ mất khi ứng dụng đóng
- 🔄 **Dữ liệu được reset** - Mỗi lần khởi động lại, dữ liệu mẫu sẽ được tạo lại

## 🚀 Chuyển Sang Database

Nếu muốn sử dụng SQL Server trong tương lai:

1. Cài đặt Entity Framework Core
2. Tạo DbContext
3. Tạo migrations
4. Cập nhật `Program.cs` để sử dụng DbContext thay vì InMemoryDataStore
5. Chạy `dotnet ef database update`

Chi tiết xem file [DATABASE_SETUP.md](DATABASE_SETUP.md)

## 📄 License

Dự án này được phát triển cho mục đích giáo dục.

---

**Cập nhật lần cuối:** 31/01/2026  
**Phiên bản .NET:** 10.0  
**Framework:** ASP.NET Core Razor Pages  
**Lưu trữ:** In-Memory Collections (Static)

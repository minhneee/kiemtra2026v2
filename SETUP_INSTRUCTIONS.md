# ⚙️ Hướng Dẫn Setup Chi Tiết

## 📌 Tổng Quan Quy Trình

```
Clone Repo → Configure DB → Restore → Migrations → Build → Run
```

---

## 🔍 Kiểm Tra Yêu Cầu Hệ Thống

### Bước 1: Kiểm tra .NET SDK

Mở **PowerShell** hoặc **Command Prompt** và chạy:

```bash
dotnet --version
```

**Yêu cầu:** 10.0.0 hoặc cao hơn

✅ Nếu không cài đặt, tải tại: https://dotnet.microsoft.com/download

### Bước 2: Kiểm tra SQL Server

Nếu cài đặt SQL Server local, kiểm tra xem nó đang chạy:

**Windows Services:**
1. Nhấn `Win + R`
2. Gõ: `services.msc`
3. Tìm **SQL Server (MSSQLSERVER)** hoặc **SQL Server (SQLEXPRESS)**
4. Đảm bảo status là **Running**

**Hoặc từ PowerShell:**
```bash
sqlcmd -S . -Q "SELECT @@VERSION"
```

✅ Nếu thấy phiên bản SQL Server → OK

### Bước 3: Kiểm tra Git

```bash
git --version
```

✅ Nếu không cài đặt, tải tại: https://git-scm.com/download/win

---

## 📥 Bước 1: Clone Repository

Chọn thư mục để lưu project:

```bash
cd C:\Projects
git clone <repository-url>
cd kiemtra2026v2
```

**Hoặc clone với HTTPS:**
```bash
git clone https://github.com/username/repo.git
```

---

## 🔐 Bước 2: Cấu Hình Database

### 📝 Mở file `appsettings.json`

File này nằm ở gốc dự án:
```
kiemtra2026v2/
└── appsettings.json
```

### 🔧 Chọn cấu hình phù hợp:

#### ✅ **Tùy Chọn A: SQL Server Local** (Windows Authentication)
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=PCM_Database;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

#### ✅ **Tùy Chọn B: SQL Server Express**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=PCM_Database;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

#### ✅ **Tùy Chọn C: Remote/Cloud Server**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your-server;Database=PCM_Database;User Id=sa;Password=your_password;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

### 🧪 Kiểm tra Connection String

Trong PowerShell:

```bash
# Windows Auth
sqlcmd -S . -Q "SELECT @@VERSION"

# SQL Auth
sqlcmd -S . -U sa -P password -Q "SELECT @@VERSION"
```

---

## 🔄 Bước 3: Restore Dependencies

```bash
dotnet restore
```

**Output mong đợi:**
```
Determining projects to restore...
Restored C:\...\kiemtra2026v2.csproj
```

---

## 🗄️ Bước 4: Apply Database Migrations

### 🔑 Lệnh Chính:

```bash
dotnet ef database update
```

Lệnh này sẽ:
1. ✅ Tạo database `PCM_Database`
2. ✅ Tạo tất cả 9 bảng dữ liệu
3. ✅ Apply tất cả migrations
4. ✅ Seed dữ liệu mẫu tự động

### 📊 Expected Output:

```
Build started...
Build succeeded.
Applying migration '20260124025219_InitialCreate'.
Applying migration '20260124040238_AdvancedUpdate'.
Applying migration '20260124082243_MakeCourtIdNullable'.
Applying migration '20260124084441_FinalRenameTo186'.
Applying migration '20260124090728_RenameTablesTo186'.
Applying migration '20260124170732_Rename186To395'.
Done.
```

### ✅ Kiểm tra thành công:

Mở **SQL Server Management Studio**:
1. Kết nối đến SQL Server
2. Expand **Databases**
3. Tìm **PCM_Database**
4. Expand **Tables**
5. Nên thấy 9 bảng bắt đầu bằng `395_`:
   - 395_Bookings
   - 395_Challenges
   - 395_Courts
   - 395_Matches
   - 395_Members
   - 395_News
   - 395_Participants
   - 395_TransactionCategories
   - 395_Transactions

---

## 🔨 Bước 5: Build Project

```bash
dotnet build
```

**Output mong đợi:**
```
Restore complete (X.XXs).
  PickleballClubManagement net10.0 succeeded with 9 warning(s) (X.XXs)
```

⚠️ Warnings là bình thường, miễn là **"Build succeeded"**

---

## 🚀 Bước 6: Chạy Ứng Dụng

```bash
dotnet run
```

**Output khi khởi động thành công:**
```
Now listening on: http://localhost:5269
Now listening on: https://localhost:5268
```

Mở trình duyệt và truy cập:
- 🔒 HTTPS: https://localhost:5268
- 🔓 HTTP: http://localhost:5269

---

## 🔑 Bước 7: Đăng Nhập Test

### Admin Account:
```
Email: admin@pickleballclub.com
Mật khẩu: Admin@123
```

### Sample Member Account:
```
Email: nguyenvana@example.com
Mật khẩu: Member@123
```

---

## 📋 Kiểm Tra Dữ Liệu Seed

Sau khi đăng nhập Admin, kiểm tra:

### ✅ Thành Viên
- Admin Dashboard → xem 9 thành viên (1 admin + 8 members)

### ✅ Kèo Cạnh Tranh
- Challenges → nên thấy ít nhất 5 kèo mẫu

### ✅ Trận Đấu
- Matches History → nên thấy ít nhất 3-4 trận

### ✅ Sân Phòng
- Courts management → nên thấy 3 sân mẫu

### ✅ Giao Dịch
- Financial → nên thấy 3 giao dịch mẫu

---

## ⚡ Các Lệnh Hữu Ích

### Xem tất cả Migrations
```bash
dotnet ef migrations list
```

### Xem cấu hình hiện tại
```bash
dotnet ef dbcontext info
```

### Rebuild từ đầu
```bash
# 1. Xóa database
dotnet ef database drop --force

# 2. Tạo lại
dotnet ef database update

# 3. Chạy lại
dotnet run
```

### Dừng ứng dụng
```
Nhấn: Ctrl + C
```

---

## 🔴 Lỗi Phổ Biến & Cách Fix

### ❌ Lỗi: "Cannot find server"

```
Error Message: An instance of SqlException representing a network or 
instance-specific error occurred while establishing a connection to SQL Server.
```

**Giải pháp:**
1. Kiểm tra SQL Server đang chạy: `services.msc`
2. Kiểm tra connection string (kiểm tra tên server)
3. Thử với: `Server=localhost` thay vì `Server=.`

### ❌ Lỗi: "Login failed for user"

```
Error Message: Login failed for user 'sa'
```

**Giải pháp:**
1. Kiểm tra username/password
2. Đảm bảo SQL Server dùng Mixed Authentication (SQL + Windows)
3. Reset password `sa` nếu cần

### ❌ Lỗi: "The EF Core tools version is older than..."

```
Entity Framework tools version is older than runtime
```

**Giải pháp:** Không là vấn đề lớn, có thể bỏ qua hoặc update:
```bash
dotnet tool update --global dotnet-ef
```

### ❌ Lỗi: "Build failed"

**Giải pháp:**
```bash
dotnet clean
dotnet restore
dotnet build
```

### ❌ Lỗi: ".NET SDK not found"

**Giải pháp:**
1. Tải .NET 10.0 SDK: https://dotnet.microsoft.com/download
2. Cài đặt và restart PowerShell
3. Kiểm tra: `dotnet --version`

### ❌ Lỗi: "Port already in use"

```
System.Net.Sockets.SocketException (48): Address already in use
```

**Giải pháp:**
```bash
# Tìm process sử dụng port 5268
netstat -ano | findstr :5268

# Kill process
taskkill /PID <PID> /F

# Hoặc chỉnh port trong launchSettings.json
```

---

## 📞 Hỗ Trợ Thêm

- **Microsoft Docs:** https://docs.microsoft.com/en-us/aspnet/core/
- **EF Core Docs:** https://docs.microsoft.com/en-us/ef/core/
- **SQL Server Docs:** https://docs.microsoft.com/en-us/sql/

---

## ✅ Checklist Hoàn Thành

- [ ] .NET SDK 10.0+ đã cài đặt
- [ ] SQL Server đã cài đặt và đang chạy
- [ ] Repository đã clone
- [ ] `appsettings.json` đã cập nhật với connection string
- [ ] `dotnet restore` chạy thành công
- [ ] `dotnet ef database update` chạy thành công
- [ ] `dotnet build` chạy thành công
- [ ] `dotnet run` chạy thành công
- [ ] Truy cập được https://localhost:5268
- [ ] Đăng nhập được với admin account
- [ ] Thấy dữ liệu seed (thành viên, kèo, trận đấu, v.v.)

---

**Version:** 1.0  
**Date:** 25/01/2026  
**Framework:** .NET 10.0  
**Language:** C#

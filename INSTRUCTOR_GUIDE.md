# 📖 Hướng Dẫn Cho Giảng Viên - Cách Chạy Dự Án

## 🎯 Mục Tiêu

Hướng dẫn này giúp giảng viên:
- Clone repository
- Cấu hình database
- Chạy migrations để tạo schema và dữ liệu mẫu
- Chạy ứng dụng thử nghiệm

## 📋 Điều Kiện Tiên Quyết

Đảm bảo máy đã cài đặt:
- ✅ **.NET 10.0 SDK** hoặc cao hơn
- ✅ **SQL Server** (Local, Express, hoặc Remote)
- ✅ **Git** (để clone repository)
- ✅ **PowerShell** hoặc **Command Prompt**

### Kiểm tra cài đặt

```bash
# Kiểm tra .NET
dotnet --version

# Kiểm tra SQL Server (nếu cài đặt local)
sqlcmd -S . -Q "SELECT @@VERSION"
```

## 🚀 Các Bước Cấu Hình

### **Bước 1: Clone Repository**

```bash
git clone <repository-url>
cd kiemtra2026v2
```

### **Bước 2: Cấu Hình Database Connection**

#### **2.1 Nếu sử dụng SQL Server Local**

Mở file `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=PCM_Database;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

#### **2.2 Nếu sử dụng SQL Server Express**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=PCM_Database;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

#### **2.3 Nếu sử dụng Remote SQL Server**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your-server-name;Database=PCM_Database;User Id=sa;Password=your_password;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

### **Bước 3: Restore Dependencies**

```bash
dotnet restore
```

### **Bước 4: Apply Database Migrations**

Lệnh này sẽ:
1. ✅ Tạo database `PCM_Database`
2. ✅ Tạo tất cả các bảng
3. ✅ Apply tất cả migrations
4. ✅ Seed dữ liệu mẫu (tài khoản Admin, 8 thành viên, trận đấu, kèo, giao dịch)

```bash
dotnet ef database update
```

**Hoặc nếu sử dụng Visual Studio Package Manager Console:**

```powershell
Update-Database
```

### **Bước 5: Build Dự Án**

```bash
dotnet build
```

Nếu có lỗi warning nhưng build successfully, có thể bỏ qua.

### **Bước 6: Chạy Ứng Dụng**

```bash
dotnet run
```

Ứng dụng sẽ chạy tại:
- HTTPS: `https://localhost:5268`
- HTTP: `http://localhost:5269`

**Ấn Ctrl+C để dừng ứng dụng**

## 🔑 Tài Khoản Test

### Admin Account
```
Email: admin@pickleballclub.com
Mật khẩu: Admin@123
Vai trò: Admin
```

### Sample Member Accounts
```
Email: nguyenvana@example.com  → Nguyễn Văn A (Rank 1.5)
Email: tranthib@example.com    → Trần Thị B (Rank 2.1)
Email: levanc@example.com      → Lê Văn C (Rank 1.6)
Email: phamvand@example.com    → Phạm Văn D (Rank 2.0)
Email: hoangthie@example.com   → Hoàng Thị E (Rank 1.9)
Email: vuvanf@example.com      → Vũ Văn F (Rank 1.8)
Email: dothig@example.com      → Đỗ Thị G (Rank 2.2)
Email: buivanh@example.com     → Bùi Văn H (Rank 1.7)

Mật khẩu: Member@123 (cho tất cả)
```

## 🗄️ Database Schema

Database sẽ được tạo với 9 bảng chính:

| Bảng | Mục Đích |
|------|----------|
| `395_Members` | Lưu trữ thông tin thành viên |
| `395_Challenges` | Quản lý kèo cạnh tranh |
| `395_Matches` | Lưu kết quả trận đấu |
| `395_Bookings` | Đặt sân chơi |
| `395_Courts` | Quản lý sân phòng |
| `395_News` | Tin tức câu lạc bộ |
| `395_Participants` | Người tham gia kèo/trận |
| `395_Transactions` | Giao dịch tài chính |
| `395_TransactionCategories` | Loại giao dịch |

Plus: Các bảng Identity (AspNetUsers, AspNetRoles, v.v.) do ASP.NET Core Identity tự động tạo.

## ⚙️ Các Lệnh Hữu Ích

### Xem danh sách tất cả migrations
```bash
dotnet ef migrations list
```

### Rollback về migration trước đó (nếu cần)
```bash
dotnet ef database update <migration-name>
```

Ví dụ: Quay lại trước khi rename:
```bash
dotnet ef database update 20260124090728_RenameTablesTo186
```

### Xóa database và tạo lại từ đầu
```bash
dotnet ef database drop --force
dotnet ef database update
```

### Rebuild solution
```bash
dotnet clean
dotnet build
```

## 🐛 Xử Lý Lỗi Thường Gặp

### ❌ Lỗi: "Cannot connect to database"

**Nguyên nhân:** Connection string sai hoặc SQL Server không chạy

**Giải pháp:**
1. Kiểm tra SQL Server đang chạy:
   - Windows: Services → SQL Server
   - Hoặc chạy: `sqlcmd -S . -Q "SELECT 1"`
2. Kiểm tra connection string trong `appsettings.json`
3. Thử với server name: `localhost` thay vì `.`

### ❌ Lỗi: "A second operation started before the first completed"

**Nguyên nhân:** Có múi kết nối database

**Giải pháp:**
```bash
dotnet ef database update --verbose
```

### ❌ Lỗi: "The migration 'XXX' has not been applied to the database"

**Nguyên nhân:** Database cũ chưa được migrate

**Giải pháp:**
```bash
dotnet ef database update
```

### ❌ Lỗi: "Unknown database 'PCM_Database'"

**Nguyên nhân:** Database chưa được tạo

**Giải pháp:**
```bash
dotnet ef database update
```

### ❌ Lỗi Build: "The project file does not exist"

**Giải pháp:**
```bash
cd C:\Users\Admin\RiderProjects\kiemtra2026v2
dotnet build
```

## 📊 Kiểm Tra Dữ Liệu Seed

Sau khi chạy `Update-Database`, dữ liệu mẫu sẽ được tạo:

```sql
-- Kiểm tra số lượng thành viên
SELECT COUNT(*) as MemberCount FROM [PCM_Database].[dbo].[395_Members];

-- Kiểm tra số lượng challenges
SELECT COUNT(*) as ChallengeCount FROM [PCM_Database].[dbo].[395_Challenges];

-- Kiểm tra số lượng matches
SELECT COUNT(*) as MatchCount FROM [PCM_Database].[dbo].[395_Matches];
```

## 🔄 Chạy Nhiều Lần

Nếu cần reset dữ liệu và chạy lại:

```bash
# Xóa database hoàn toàn
dotnet ef database drop --force

# Tạo lại từ đầu (migrations sẽ apply tự động)
dotnet ef database update

# Chạy ứng dụng
dotnet run
```

## 📝 Lưu Ý Quan Trọng

1. **Đừng chỉnh sửa migrations** đã apply vào database
2. Nếu muốn thay đổi schema, tạo migration mới:
   ```bash
   dotnet ef migrations add <DescriptiveName>
   dotnet ef database update
   ```
3. Tất cả seeding data được tạo tự động trong `DbSeeder.cs` khi ứng dụng start lần đầu
4. Nếu muốn xóa seeding data mẫu, chỉ cần xóa dữ liệu trong SQL Management Studio hoặc entity framework

## ✅ Checklist Hoàn Thành

- [ ] Clone repository thành công
- [ ] Cập nhật `appsettings.json` với connection string đúng
- [ ] Chạy `dotnet ef database update` thành công
- [ ] Chạy `dotnet run` thành công
- [ ] Truy cập được trang login (http://localhost:5269)
- [ ] Đăng nhập được với admin account
- [ ] Thấy dữ liệu mẫu (8 thành viên, kèo, trận đấu)

## 📞 Hỗ Trợ Thêm

- **Documentation EF Core:** https://docs.microsoft.com/en-us/ef/core/
- **ASP.NET Core Docs:** https://docs.microsoft.com/en-us/aspnet/core/
- **.NET CLI Reference:** https://docs.microsoft.com/en-us/dotnet/core/tools/

---

**Chuẩn bị ngày:** 25/01/2026
**Phiên bản .NET:** 10.0
**Phiên bản Entity Framework:** 10.0.2

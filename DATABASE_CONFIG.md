# 🔧 Cấu Hình Database

## Tùy chọn cấu hình cho SQL Server

### 1️⃣ SQL Server Local (Windows Authentication)

**appsettings.json:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=PCM_Database;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

### 2️⃣ SQL Server Express

**appsettings.json:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=PCM_Database;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

### 3️⃣ SQL Server Named Instance

**appsettings.json:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_COMPUTER_NAME\\INSTANCE_NAME;Database=PCM_Database;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

### 4️⃣ SQL Server Remote (SQL Authentication)

**appsettings.json:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your-server.domain.com;Database=PCM_Database;User Id=sa;Password=your_password;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

### 5️⃣ Azure SQL Database

**appsettings.json:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:your-server.database.windows.net,1433;Initial Catalog=PCM_Database;Persist Security Info=False;User ID=sa;Password=your_password;MultipleActiveResultSets=True;Encrypt=True;Connection Timeout=30;"
  }
}
```

---

## 📋 Hướng Dẫn Tìm Connection String

### Windows Authentication (Local Server)

1. Mở **SQL Server Management Studio**
2. Kết nối đến server
3. Chuỗi kết nối sẽ là: `Server=.` hoặc `Server=localhost` hoặc `Server=YOUR_COMPUTER_NAME`

### SQL Server Express

- Instance name thường là: `SQLEXPRESS`
- Chuỗi kết nối: `Server=.\\SQLEXPRESS`

### Remote Server

1. Liên hệ quản trị viên để lấy:
   - Server name/IP
   - Database name
   - Username
   - Password
2. Port mặc định: 1433 (có thể khác)

### Kiểm tra Connection String

Chạy lệnh để test kết nối:

```bash
# Linux/Mac
sqlcmd -S "<server>" -U "<username>" -P "<password>" -Q "SELECT @@VERSION"

# Windows (Windows Auth)
sqlcmd -S "." -Q "SELECT @@VERSION"

# Windows (SQL Auth)
sqlcmd -S "." -U "sa" -P "password" -Q "SELECT @@VERSION"
```

---

## 🚀 Các bước setup nhanh

```bash
# 1. Clone repo
git clone <url>
cd kiemtra2026v2

# 2. Cập nhật appsettings.json với connection string của bạn

# 3. Restore packages
dotnet restore

# 4. Apply migrations (tạo database + tables + seeding data)
dotnet ef database update

# 5. Build project
dotnet build

# 6. Run application
dotnet run
```

---

## 🔒 Lưu Ý Bảo Mật

- ❌ **KHÔNG** commit password vào repository
- ✅ Dùng **User Secrets** cho development:

```bash
# Set user secret
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=...;Password=..."

# Trong appsettings.json, dùng placeholder
dotnet user-secrets list
```

- ✅ Dùng **Environment Variables** cho production
- ✅ Dùng **Azure Key Vault** cho cloud deployment

---

## 🆘 Troubleshooting Connection

| Lỗi | Nguyên Nhân | Giải Pháp |
|-----|-----------|----------|
| "Connect to server failed" | Server name sai | Kiểm tra server name trong Management Studio |
| "Login failed" | Sai username/password | Kiểm tra credentials, đảm bảo SQL Auth được enable |
| "Database does not exist" | Database chưa được tạo | Chạy `dotnet ef database update` |
| "Timeout" | Server không phản hồi | Kiểm tra server đang chạy, firewall settings |
| "Access denied" | Không có quyền | Kiểm tra user permissions trên server |

---

**Cập nhật:** 25/01/2026

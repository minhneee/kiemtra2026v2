-- ============================================================================
-- Pickleball Club Management System - Database Setup Script
-- ============================================================================
-- Lưu ý: Script này là tùy chọn. Giảng viên có thể sử dụng lệnh:
--   dotnet ef database update
-- để tạo database tự động

-- Nếu sử dụng script này:
-- 1. Mở SQL Server Management Studio
-- 2. Kết nối đến SQL Server
-- 3. Copy tất cả nội dung script này
-- 4. Chạy (F5 hoặc Execute)
-- 5. Sau đó vẫn cần chạy "dotnet ef database update" để apply EF migrations

-- ============================================================================
-- Tạo Database
-- ============================================================================

-- Kiểm tra xem database đã tồn tại không
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PCM_Database')
BEGIN
    CREATE DATABASE PCM_Database;
    PRINT 'Database PCM_Database được tạo thành công!';
END
ELSE
BEGIN
    PRINT 'Database PCM_Database đã tồn tại.';
END

USE PCM_Database;

-- ============================================================================
-- Tạo các Schema (nếu cần)
-- ============================================================================
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'dbo')
BEGIN
    EXEC sp_executesql N'CREATE SCHEMA dbo;'
END

-- ============================================================================
-- Script kết thúc
-- ============================================================================
-- Lệnh tiếp theo để apply migrations:
-- dotnet ef database update

PRINT 'Setup hoàn tất! Bây giờ chạy lệnh: dotnet ef database update'

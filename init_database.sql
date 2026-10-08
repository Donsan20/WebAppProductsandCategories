-- ============================================================================
-- SCRIPT DE INICIALIZACIÓN DE BASE DE DATOS PARA SQL SERVER
-- Proyecto: WebAppProductsandCategories (Catálogo de Productos y Categorías)
-- ============================================================================

-- 1. Crear la Base de Datos si no existe
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'SampleDb')
BEGIN
    CREATE DATABASE SampleDb;
    PRINT 'Base de datos SampleDb creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'La base de datos SampleDb ya existe.';
END
GO

USE SampleDb;
GO

-- 2. Crear Tabla: Categories
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
BEGIN
    CREATE TABLE Categories (
        CategoryId INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL
    );
    PRINT 'Tabla Categories creada exitosamente.';
END
GO

-- 3. Crear Tabla: Products
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
BEGIN
    CREATE TABLE Products (
        ProductId INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL,
        Price DECIMAL(18,2) NOT NULL,
        CategoryId INT NOT NULL,
        CONSTRAINT FK_Products_Categories FOREIGN KEY (CategoryId) 
            REFERENCES Categories(CategoryId)
    );
    PRINT 'Tabla Products creada exitosamente.';
END
GO

-- 4. Datos Iniciales de Prueba
IF NOT EXISTS (SELECT TOP 1 1 FROM Categories)
BEGIN
    INSERT INTO Categories (Name) VALUES 
    (N'Tecnología'),
    (N'Hogar'),
    (N'Ropa');
    PRINT 'Datos de prueba insertados en Categories.';
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM Products)
BEGIN
    DECLARE @catTec INT = (SELECT TOP 1 CategoryId FROM Categories WHERE Name = N'Tecnología');
    DECLARE @catHogar INT = (SELECT TOP 1 CategoryId FROM Categories WHERE Name = N'Hogar');

    INSERT INTO Products (Name, Price, CategoryId) VALUES 
    (N'Laptop Gamer', 1200.00, @catTec),
    (N'Teclado Mecánico', 75.50, @catTec),
    (N'Cafetera Eléctrica', 45.00, @catHogar);
    PRINT 'Datos de prueba insertados en Products.';
END
GO

PRINT '=======================================================';
PRINT 'Base de datos SampleDb lista para usar con la aplicación';
PRINT '=======================================================';

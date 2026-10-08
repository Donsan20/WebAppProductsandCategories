# Catálogo de Productos y Categorías (WebAppProductsandCategories)

Aplicación Web desarrollada bajo el patrón **ASP.NET Core MVC** (.NET 10 / .NET 9) utilizando una capa de persistencia en **ADO.NET Puro** (`Microsoft.Data.SqlClient`) y base de datos relacional en **Microsoft SQL Server**.

## 📌 Características
- **Arquitectura MVC**: Separación ordenada entre Modelos, Vistas Razor y Controladores.
- **Acceso a Datos Tradicional (ADO.NET)**: Consultas SQL parametrizadas para prevenir ataques de *Inyección SQL*.
- **CRUD Completo**:
  - Gestión de Categorías (Crear, Listar, Editar, Eliminar).
  - Gestión de Productos (Crear, Listar, Editar, Eliminar) con menú desplegable dinámico para asignar categorías.
- **Relaciones Relacionales**: Relación de 1 a N entre Categorías y Productos con llaves foráneas (`FOREIGN KEY`).
- **Interfaz 100% en Español**: Textos, validaciones y etiquetas adaptadas al español.
- **Diseño Responsivo**: Maquetado con Bootstrap 5.

---

## 🛠️ Requisitos Previos
- [.NET SDK](https://dotnet.microsoft.com/download) (versión 8.0, 9.0 o 10.0).
- [Visual Studio 2022 / 2026](https://visualstudio.microsoft.com/) con la carga de trabajo *Desarrollo web y de ASP.NET*.
- [Microsoft SQL Server](https://www.microsoft.com/sql-server/) (LocalDB, SQL Express o Developer Edition).
- [SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup) o Azure Data Studio.

---

## 🚀 Puesta en Marcha en Cualquier Computador

### 1. Clonar el repositorio
```bash
git clone https://github.com/jhonjadercorrea/WebAppProductsandCategories.git
cd WebAppProductsandCategories
```

### 2. Inicializar la Base de Datos
1. Abre **SQL Server Management Studio (SSMS)** y conéctate a tu servidor local.
2. Abre y ejecuta el script ubicado en:
   ```
   Database/init_database.sql
   ```
   *(Este script creará la base de datos `SampleDb`, las tablas `Categories` y `Products`, e insertará datos iniciales de prueba).*

### 3. Verificar la Cadena de Conexión
En el archivo `WebAppProductsandCategories/appsettings.json`, asegúrate de que la cadena coincida con tu instancia de SQL Server:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB; Database=SampleDb; Trusted_Connection=True; TrustServerCertificate=True;"
}
```
*(Si usas SQL Server Express, cambia `(localdb)\\MSSQLLocalDB` por `.\\SQLEXPRESS` o `localhost`).*

### 4. Compilar y Ejecutar
- **Desde Visual Studio**: Abre la solución `WebAppProductsandCategories.slnx` y presiona `Ctrl + F5`.
- **Desde la Terminal**:
  ```bash
  cd WebAppProductsandCategories
  dotnet run
  ```
  Abre tu navegador en la URL indicada (por ejemplo `https://localhost:7147`).

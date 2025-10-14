# 專案總覽 (Project Overview)

這是一個使用 .NET 8 和 Visual Studio 建立的 Web API 專案，作為一個簡單客戶管理系統的後端服務。

## 關鍵技術 (Key Technologies)

*   **.NET 8**: 專案使用的主要開發框架。
*   **ASP.NET Core**: 用於建構 Web API。
*   **Entity Framework Core 8**: 用於資料庫存取和物件關聯對應 (ORM)。
    *   專案同時設定了 **SQL Server** 和 **PostgreSQL** 的連線字串，可透過 `appsettings.json` 中的 `DatabaseProvider` 屬性進行切換。

## 專案結構 (Project Structure)

*   `FirstCodeLab.sln`: Visual Studio 解決方案檔。
*   `FirstCodeLab/`: 主要的 Web API 專案。
    *   `Controllers/CustomerController.cs`: 處理客戶相關 HTTP 請求的 API 控制器。
    *   `Program.cs`: 應用程式的進入點，用於設定服務和中介軟體。
    *   `appsettings.json`: 應用程式的設定檔，包含資料庫連線字串等。
*   `FirstCodeLab.DB/`: 資料存取層專案。
    *   `DatabaseContext/AppDbContext.cs`: EF Core 的資料庫上下文 (DbContext)。
    *   `Entities/`: 包含 `Customer`, `Product`, `Order` 等資料庫實體模型。

## 開發模式與慣例 (Development Conventions)

*   **資料庫優先 (概念上)**: 程式碼圍繞著 `Entities` 中定義的資料庫結構進行開發。
*   **倉儲模式 (簡化實作)**: `AppDbContext` 被直接注入到控制器中，作為資料存取的主要入口。
*   **應用程式管理時間戳**: `CreatedAt` 和 `UpdatedAt` 這類的時間戳欄位，由應用程式在 `CustomerController` 的 `Create` 和 `Update` 方法中手動設定，而非依賴資料庫的預設值。
*   **明確的交易區塊**: 在 `Create` 和 `Update` 方法中，資料庫操作被明確地包裹在 `BeginTransaction()` 和 `Commit()` 區塊內。
*   **自動化資料庫註解**: `AppDbContext` 中有一個特殊機制，它會在建立資料庫結構時，自動讀取實體屬性上的 `[Description]` 標籤，並將其內容寫入資料庫欄位的註解(Comment)中，增加了資料庫的可讀性。

## API 端點 (API Endpoints - CustomerController)

*   `POST /Customer/Search`: 獲取所有客戶的列表。
*   `POST /Customer/Create`: 建立一個新客戶。伺服器會自動填入 `CreatedAt` 和 `UpdatedAt` 時間。
*   `POST /Customer/Update`: 更新現有的客戶資料。伺服器會自動更新 `UpdatedAt` 時間。
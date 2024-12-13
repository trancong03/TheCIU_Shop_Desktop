# TheCIU Shop Desktop Application

This project is a Windows Forms-based application designed for managing a clothing shop. It utilizes a multi-tier architecture and incorporates various advanced features, including custom controls, validation, and AI-based customer segmentation.

---

## Project Structure

The solution consists of the following projects:

1. **BLL (Business Logic Layer)**:
   - Handles business logic and operations.
   - Connects to the DAL layer to retrieve or manipulate data.

2. **DAL (Data Access Layer)**:
   - Manages all database interactions using LINQ to SQL.
   - Contains methods for CRUD operations.

3. **DTO (Data Transfer Objects)**:
   - Contains models representing the database entities.
   - Generated automatically through LINQ to SQL (`QuanLyShop.dbml`).

4. **GUI (Graphical User Interface)**:
   - Implements the user interface of the application.
   - Includes forms such as:
     - `FrmAccountManagement`
     - `FrmProductManagement`
     - `FrmOrderStatusUpdate`
     - `FrmVoucherManagement`, and more.

5. **CustomControl**:
   - Contains custom controls used in the application (e.g., `ActionControl`).

6. **MLIntegration**:
   - Implements K-means clustering for customer segmentation.
   - Utilizes the Accord.MachineLearning library for clustering logic.

7. **ErrorHandling**:
   - Handles exceptions and logging.
   - Provides centralized error management utilities.

8. **Validation**:
   - Ensures data integrity before saving or processing.
   - Includes reusable validation helper classes.

9. **Utils**:
   - Contains utility classes for exporting to Excel/PDF and other helper methods.

---

## Key Features

- **Order Management**:
  - View, update, and manage orders by their status (Pending, Confirmed, Shipping, Completed).
  - Integrated DataGridViews for detailed order views.
  
- **Product Management**:
  - Add, edit, delete products with features like size, color, and stock management.
  - Display statistics and sales information.

- **AI Integration**:
  - K-means clustering for customer segmentation based on purchasing behavior.

- **Data Export**:
  - Export data to Excel or PDF for reporting purposes.

- **Customizable UI**:
  - Built with DevExpress controls for enhanced visuals and user experience.

---

## Installation and Setup

### Prerequisites
- Visual Studio 2022 or later.
- .NET Framework 4.8.
- SQL Server (tested with local setup).
- NuGet packages:
  - `Accord.MachineLearning`
  - `iTextSharp`
  - `EPPlus`


### Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/zohanubis/TheCIU_Shop_Desktop.git
   cd TheCIU_Shop_Desktop

2. Open the solution in Visual Studio.
3. Restore NuGet packages:
 ```bash
   nuget restore
```

4.Import the database:

Open SQL Server Management Studio.
Execute the QLShopThoiTrang.sql file to set up the database.

Configure the connection string in app.config:
```bash
<connectionStrings>
    <add name="QuanLyShop"
         connectionString="Data Source=DESKTOP-EKR82M7;Initial Catalog=QLShopThoiTrang;Integrated Security=True"
         providerName="System.Data.SqlClient" />
</connectionStrings>

```
5. Build and run the application:
- Set GUI as the startup project.
- Press F5 to build and run.

## K-Means Clustering Example
**To run the customer segmentation feature:**

- Open the MLIntegration project.
- Adjust clustering parameters in KMeansClass.cs.
- Build and run the clustering logic through FrmCustomerSegmentation.

## Packages Configuration
T he required packages are listed in packages.config. Use the following command to install all dependencies: 
```bash
nuget install packages.config
```
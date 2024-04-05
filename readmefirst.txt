Prerequisites:
Visual Studio 2022 Community Edition or higher installed on your system.
.NET 6.0 SDK or runtime installed on your system.

Step-by-Step Guide:
Clone the Repository:
If the project is available in a Git repository, clone it to your local machine using Git commands or any Git GUI tool like GitHub Desktop.
Open the Project in Visual Studio:

Open Visual Studio 2022.
Click on "Open a project or solution" and navigate to the directory where you cloned the repository. Select the solution file (typically with a .sln extension) and click "Open".

Restore NuGet Packages:
Once the project is loaded in Visual Studio, right-click on the solution name in the Solution Explorer and select "Restore NuGet Packages". This will download and install all the required packages for the project.

Build the Solution:
After restoring the NuGet packages, build the solution by clicking on "Build" > "Build Solution" in the Visual Studio menu, or simply press Ctrl+Shift+B.

Set Startup Project:
Right-click on the WPF project (usually named similar to the solution) in the Solution Explorer and select "Set as StartUp Project".

Set Up Database Connection:
Ensure that you have SQL Server or SQL Server Express installed on your system.
Update the connection string in the appsettings.json file or in the OMSContext class to point to your SQL Server instance. Modify the connection string according to your SQL Server instance name, authentication mode, and database name.

Run the Database Script:
Execute the OMS.sql script provided in the assignment to create the necessary database and tables in your SQL Server instance.

Run the Application:
Press F5 or click on "Debug" > "Start Debugging" in Visual Studio to run the application. Alternatively, you can run it without debugging by clicking on "Debug" > "Start Without Debugging" or pressing Ctrl+F5.

Test the Application:
Once the application starts, you should see the main window with the functionality to manage orders.
Test various features such as selecting a shopper from the ComboBox, viewing basket item details in the DataGrid, adding new items to the order, etc.

Verify Functionality:
Ensure that all functionalities mentioned in the assignment instructions are working as expected. This includes retrieving data from the database, displaying it in the UI, adding new items to the order, and saving data back to the database.
That's it! You have now successfully set up and run the WPF application. If you encounter any issues during the setup or execution, refer to the error messages in Visual Studio's Output window or the Error List for troubleshooting.
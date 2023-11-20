# Cars Retail Management System
> An application for cars retail management. Built using C# (.Net), MS SQL Server and DevExpress technologies.

In order to digitize the process of inventory management and stock in-out activities, a car distribution company has requested the development of a software to manage all related tasks.

![](src/public/img/logo2.png)

## System specification
[Report](https://github.com/it-trankhaihoang/primary-school-classroom-management/tree/main/client/src/public/report/report.pdf)


## Features
_The software allows (1) the manager/administrator and (2) employees to interact with each other on the same system._

-   Manager/Adminstrator:

    -   Employee Management: The manager has the function to add employee accounts to the system, and each account will have a login name which is the characters before the @ symbol of the employee’s email, and the default password will be set as ’123456’. Additionally, manager can view the list of employees and the performance of each individual.
    -   Warehouse management: Adding new products to the warehouse, creating and printing receipts for stock in and stock out activities to import and export products.
    -   Partner management: Adding new car suppliers and dealers, viewing detailed information of each partner, and transaction history.
    -   Statistics: Viewing the number of employees, the quantity of goods in the warehouse, the total revenue, monthly revenue, employee performance, popular products, etc.
    -   Manager can also perform all the functions of an employee.
      
-   Employee:
    -    Employees can create and print received note, review the list of receipts they have created, print received note and receipt lists. After successfully creating a receipt, the quantity of products in the warehouse will be updated based on the quantity on the receipt.
    -    Employees can create and print delivery notes, review their list of created delivery notes, and print lists of delivery notes. After successfully creating a delivery note, the quantity of products in stock will be updated based on the quantity on the delivery note.
    -    Personal information management: Employees can view and edit their personal information, as well as view statistics on the invoices they have created for inventory input and output.


## License

[MIT](https://choosealicense.com/licenses/mit/)

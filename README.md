Hi!
I'm Pnini, I study computer science, and hereby introducing my first web API project.

This project represents a toy store. The user can filter the products by minimum and maximum price, description and categories. He also can add products to cart. In the cart page, the user can remove an item, go back to the store or create his order. If he chooses this option, he'll have to login or register (in case of new user). After login he can update his details, continue his shopping or going to his cart, to finish his order.

To run my project, the minimal requirement is using Visual Studio 2022 and up. For creating the DB, you can use code-first abilities. All what you need is: 
Open your package manager console, and write:
1. add-migration [MyDataBaseName]
2. Update-DataBase. 

And your DB is ready for use!

The project is written with ASP.Net 7 environment. The client side is written in JS, HTML and CSS.
A Middleware was added to catch exceptions and handle them.
An extra Middleware was created to save the rating- client's request's details in the DB.
The project uses WEB API architecture, based on REST technology and kept its principles. (Sort, filter and etc.)
Energy was invested in order to secure passwords and other sensitive data. My program strict on security using a strong password by using the zxcvbn-core package in user register and while updating details.
Furthermore, I used entities validations.
To gain encapsulation and scalability, layers were added whom communicate with Dependency Injection.
The project uses the SQL database using Microsoft ORM – EntityFramework, I worked with DB-first ability.
To add extra scalability, Async and Await keywords were steadily applied.
It uses the DTO layers to simplify the objects and to prevent circular dependency, The objects were mapped by using the AutoMapper package.
The project has a documented swagger that describes my project structure.
The code was logged to a file in case of interesting information and uses an email for error cases. The user gets just an internal error.
Configuration files were added for changeable things.

Enjoyed this project? Please tell me about it. I would also love to read any comments.

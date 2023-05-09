xyzWebApp 



DESCRIPTION:

Welcome to my project! This is a project made for my final exame in ASP.NET development course. 
I am using C# for my programming logics part. CSS and HTML is used for displaying pages and design. JSON is used for making a connection string.
Application was made using .NET Entity Framework. 
Solution contains two projects, an actual web application and API.        (connection strings, on both of them, shoul'd be the same.)
App allows users to have a quick access to a detailed view of products and services our imagined business offers.
With this App, administrators can effortlessly manage respective customer accounts, helping them stay organized and on top of they're managing job.
I hope you will enjoy it! 
If u got any suggestions or ideas, feel free to contact me.




INSTRUCTIONS:

1. Go to "appsettings.json  ->  appsettings.Development.json".
2. Now edit connection string "Default" so it can match requirements of your operating system.            (do this for both projects)
3. If you have done first two steps correctly, u can go ahead and add migration, after which you can update database.
	-with first database update, all data needed will be stored and ready for execution.
	  -administrator account will be seeded and ready for use, check "GUIDLINES" for more details.
	    



GUIDLINES:

Only users with "admin" role will have access to "user manager" menu.
Every user, created through "user manager" menu, must have the same "email" and "username" input.
User name (nickname) field can not contain empty spaces.
To login, use email and password. 
Admin login data -> email: admin@admin.com | password: asdasd.
	-For more details go to "Areas -> Identity -> Data -> ApplicationDbContext.cs -> OnModelCreating(ModelBuilder builder)".
Some categories might be empty, or current products are not belonging to that category which will be presented as a blank page.


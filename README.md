# General info
The project is a cinema management application. The application can be used in **graphical mode or text mode**.
The assumption of the project is the ability to use the application in two modes: regular user and administrator.

Access to administrator mode is possible after entering the correct login and password, and access to the user mode
is unlimited. By identifying yourself as a user, the application allows you to:
- viewing lists of movies and reservations
- making a reservation (purchasing a ticket for a movie selecting seats)
- canceling the selected reservation.

A person identifying as an administrator has access to more advanced options, including:
- management movies (adding, deleting, modifying)
- viewing statistics.

The purpose of the application is to facilitate the management and use of the cinema through a simple
intuitive interface.

### Functionalities
- Displaying success messages for the user's operation
or an error occurs along with information about what the error concerns.
- Displaying tips (what the user can do at a given moment) on
every available view
- Read and write all necessary data to text files. Reading the list
movies and reservations are made each time you start them
program. The saving takes place when exiting the program
- Refreshing only required parts of the view, for example after execution
movie modification, only the movie list is refreshed
- Showing list of reservations and movies
- Search the movies list. The application allows you to search for all movies
matching the phrase entered by the user
- Sort the movies list in descending or ascending order. Sorting is done by
specifying the name of the movie attribute (id, title, date, price, time, room) according to which
the list is to be sorted
- Remove filters (search or sort)
- The user always has the option to return to the previous view.
- Identification as an administrator requires providing a valid login and
passwords. Login details are stored in the password.txt text file
located in the CinemaApp/GUI/bin/Debug/net7.0-windows/Passwd.
Both the login and password are stored in the form of a hash
obtained by using the SHA256 hashing algorithm
- Add a movie to the list
- Checking whether the date, time and room of the film screening do not conflict with another
a movie already on the list
- Remove a movie from the list
- Movie modification. Only the price can be modified, date and time or room number
- Displaying the total revenue of the cinema
- Displaying the top 10 most popular movies
- Showing the top 10 grossing movies
- Ticket generation both in the form of ASCII art saved in a text file
as well as in the form of a graphic file in .jpg format. Tickets in .jpg format can be found at
CinemaApp\GUI\bin\Debug\net7.0-windows\TicketsJPG directory.
- Generation of the QR code included in ticket
- Making a reservation for a given movie.
- Cancelling the reservation. Deleting a reservation also deletes the ticket associated with it
saved in a JPG file.

### Additional informations
Both versions of the project (console and GUI) use the same logic contained in the model.
This was implemented by using the MVC architectural pattern for the console version and its MVP twin for the GUI version.

# Technologies
The project was written using the following technologies:

Console Solution:

![Static Badge](https://img.shields.io/badge/C%23%20programming%20language-%236a1577?style=for-the-badge&logo=csharp)

GUI Solution:

![Static Badge](https://img.shields.io/badge/Windows%20Forms%20-%20%236a1577?style=for-the-badge&logo=csharp)

# Getting Started
### Instalation
To run the application from the .exe executable file, **you must have .NET Runtime version at least 7.0**.

If you want to develop the application or use development tools it is necessary to have .NET SDK version 7.0 or higher.


The application can be launched via the **CinemaApp.exe** executable file located here in the:
- CinemaApp/bin/Debug/net7.0 directory **- console solution**
- GUI/bin/Debug/net7.0-windows directory **- GUI solution**

You can also create a shortcut for convenience to CinemaApp.exe to be able to run the application from anywhere on your system.
It is also possible to run the application from Visual Studio or another IDE supporting the C# language. The solution can be launched via the CinemaApp.sln file.

## Instruction 
### Login as administrator
Logging in in administrator mode requires entering your login and password. Login and password
can only be found in this documentation because neither the program code nor the
in text files it was not provided explicitly. Below is a
correct login and password for administrator mode:

- **Login:** admin
- **Password:** 789!@#qwe

### Files

> [!CAUTION]
> **Manual modifying of any text file is not recommended !**

All data is stored in text files. Below is a description of all of them
files used in the program. All files mentioned are located in
CinemaApp/bin/Debug/net7.0 directory
- The Database directory contains two files: movies.txt and reservations.txt
as a small database of movies and bookings.
- The Temp directory contains two temporary files: deleted_movies.txt and
modified_movies.txt. Information regarding:
deleted or modified reservations and tickets. Writing to files
occurs when the administrator deletes or modifies the video
which there is any reservation. The file stores information for
the moment you log in in user mode. Once the user logs in and
one of the files (or both) has some information then they are displayed
they are in the OUTPUT section. Once displayed, the information is deleted, therefore these
files are considered temporary.
- The Passwd directory contains the password.txt file, which contains the login and
administrator password as a hash.
- The Tickets directory contains ticket files in ASCII art form. Files have
names according to the formula: bilet_id_title_filmu.txt. So clearly
you can distinguish the ticket you have just purchased (after purchasing the ticket, the application informs you
what file it was saved in).

### Instruction - console solution
The application can only be operated using the keyboard. Navigating through the menu
each view is navigated using the up and down arrows. Every option you choose is
indicated by backlight and ">" indicator. The option is approved
by pressing the ENTER button. Main administrator or user panel
was divided into 4 sections.

- **[MENU]** – displays a list of available options in each view.
- **[INPUT]** – section used to enter data, e.g. when adding
new movie. By default, this section displays ASCII art because it is
only useful for certain options. In the case of e.g. earlier
mentioned modification of the film, the form z appears in place of the ASCII art
appropriate fields to fill in.
- **[OUTPUT]** – section used to present all data provided by
application, e.g. a list of films, earnings statistics, visualization of a cinema hall in ASCII
art etc.
- **[INFO/ERRORS]** – a key section for the user, displaying all information
hints (what the user can do at a given moment, how to do it
enter data, etc.) and error information.

**Resizing window**

If you want to work in a console size other than the basic one, you need to expand the window
console, and then press any button to refresh the view. View elements
they will adjust themselves to the current size of the console.
It is recommended to end work with the application by exiting it via the dedicated one
button in the main menu. **Close the application by closing the console window
will result in the introduced changes not being saved!**


### Instruction - GUI





# Overview
For my computer science project bagrut, I've chosen to make a windows form application similar to the official yad2 website, in addition to car rental section.

Users can use the app without logging in, but they won't be able to use many features, such as sending messages, posting cars for sale, renting a car, sending feedback, and more.

* Users can sign up using their email address and password.
* They can reset the password at any time with a verification code sent to their email upon request.
* Users can contact admins for support, and for feedback. (See administration section below)

## 1- Cars for sale:
![rsz_screenshot_2023-04-25_102519](https://user-images.githubusercontent.com/36423427/234205117-5b65c9ec-d60a-40a4-a18d-11d407d08309.png)
In this section of the app, users can search cars for-sale, and add theirs as well.
* Car owner can edit information of his car after posting it.

* Users can send messages to other car owners if they want to buy their cars, the message is sent in the app, also the car seller gets notified through Email about the new message they have received.

* Users can report a "bad posted" car to admins.

* Users can filter results and search for the car they need.

## 2- Cars for rent:
![image](https://user-images.githubusercontent.com/36423427/234210815-506cc24a-6770-42bb-ac85-b8858904a48b.png)
This is the second section of the app, renting.
* There are rent stations defined in the application (admins can add/edit/delete rent stations), such that, in a given moment, each rent car is parked at a specified station.
* User can rent a car from its station in a specific date (of his choice), and return it to a different station in a specific date as well.
![image](https://user-images.githubusercontent.com/36423427/234215826-00b0feae-6e7e-4bb0-a37c-c05bd84991f6.png)

## 3- Administration:
![image](https://user-images.githubusercontent.com/36423427/234216584-5e689c22-edc9-4d95-b407-f8df1e2bb830.png)
The application includes an advanced management board.
* There are different level of admins. (each position in the company has an admin level)
* Manage rent stations (add/edit/remove).
* Manage rent cars and for-sale cars.
* Manage users.
* Boardcast: Admins can send a broadcast to all users, or to a specific level of admin, broadcast message can be sent to users' emails as well.
* View logs: Admins can view management log/history of the app.
* Feedback & Reports: Read and respond to feedback and reports from users.
* Statistics: Shows statistics about the application between two specified dates.
![image](https://user-images.githubusercontent.com/36423427/234218657-f311408f-1d3b-4b78-b70f-1800980b91df.png)
![image](https://user-images.githubusercontent.com/36423427/234218760-6c0644ec-6a65-4ae1-aec0-55b5d2c0642a.png)


# Installation Requirements:
* Two database files from the following link: [Click Here](https://drive.google.com/drive/folders/1aqOHa3WjBD5j_EAz5peeSqM6lgdWUE0R?usp=share_link)
* ".NET desktop development" package from the Visual Studio installer.
  **Note:** make sure the option "SQL Server Express LocalDB" is selected before installing.

# Installation:
1. Clone the repo.
2. Download both database files from the link above.
3. Move the downloaded files to the project's main directory.
4. Open the project from Visual Studio.
5. Finally, to run the application, compile it and you're ready to go.

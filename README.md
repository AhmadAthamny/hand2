# Hand2
For my computer science project bagrut, I've chosen to make a windows form application similar to the official yad2 website, in addition to car rental section.

First, users can use the app without logging in, but they won't be able to use many features, such as sending messages, posting cars for sale, renting a car, sending feedback, and more.

Users can sign up using their email address and password, also they can reset the password at any time:
They enter their email address, a verification code gets sent to their email, they copy & paste it in the app, and they will be able to choose a new password.

### 1- Cars for sale:
![rsz_screenshot_2023-04-25_102519](https://user-images.githubusercontent.com/36423427/234205117-5b65c9ec-d60a-40a4-a18d-11d407d08309.png)
In this section of the app, users can search cars for-sale, and add theirs as well.
* Car owner can edit information of his car after posting it.

* Users can send messages to other car owners if they want to buy their cars, the message will be sent in the app, also the car seller will be notified through Email about the new message they have received.

* In addition, users can report a posted car to admins (administration section below) in case they find a "bad" car posted, such as irrelevant car images, bad text or description, and more.

* Users can filter results and search for the car they need.

### 2- Cars for rent:
![image](https://user-images.githubusercontent.com/36423427/234210815-506cc24a-6770-42bb-ac85-b8858904a48b.png)
This is the second section of the app, renting.
There are rent stations defined in the application (admins can add/edit/delete rent stations), and in a given moment, each rent car is parked at a specified station.


#### ** This is the link for data used in the application:
https://drive.google.com/drive/folders/1aqOHa3WjBD5j_EAz5peeSqM6lgdWUE0R?usp=share_link

## Installation Requirements:
Install ".NET desktop development" package from the Visual Studio installer.

**Note:** make sure the option "SQL Server Express LocalDB" is selected before installing.

## Installation:
1. Clone the repo.
2. Download both database files from the link above.
3. Move the downloaded files to the project's main directory.
4. Open the project from Visual Studio.
5. Finally, to run the application, compile it and you're ready to go.
![rsz_1rsz_screenshot_2023-04-25_102519](https://user-images.githubusercontent.com/36423427/234205451-644b0fdc-364c-47bc-b53d-df5a1d617716.png)

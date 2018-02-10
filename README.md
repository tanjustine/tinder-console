# Tinder Console Readme

This is a simple console application version of Tinder created using C#. This is the midterm project I made when I was a teaching assistant for CS21A: Introduction to Computing I.

The project runs and functions like an offline version of Tinder. It can register, match, and unmatch users as well as change their user settings and preferences.

## Functionalities

The program has the following functionalities:
### **1. Register**
A user must first register before being able to login. To register the user, one must input the following:
- _Name_: name of user
- _Age_: age of user
- _Gender_: gender of the user whether Male ('M') or Female ('F')

Aside from the user’s characteristics, the user must also be able to input the following preferences:
- _Show Me_: gender of people user is interested with-- either Male ('M'), Female ('F'), or Both ('B')
- _Age Start_: minimum age of people the user is interested with
- _Age Limit_: maximum age of people the user is interested with

### **2. Login**
The user must first have a registered account to be able to login the system. To login, one must input the following:
- _Name_: name of user

Once a user has logged in, he will be able to do the following functionalities:

### **3. Match**
To match a user, the program must show one registered person who is of
the user’s interest. For the user to like another user, one must input the
following:
- 1 for a Like
- 0 for a No

**IMPORTANT**: A user can only have a maximum of _10_ matches. A match is only considered as a match if user A has liked user B's profile and if user B has liked user A's profile.

Moreover, the program must show one possible person that fits into the
criteria of the user and the user must also fit into the criteria of
the person. For example:
- The user, Jon, is a 22-year-old male who is interested in 18 to 30-year-old females.
- Another registered person, Dany, is an 18-year-old female interested in 18 to 25-year old males.
- Therefore, Jon and Dany can be possible matches.
- In addition, another registered person, Ellaria, is a 30-year old female interested in 18 to 30-year-old females.
- Ellaria and Dany cannot be possible matches. Jon and Ellaria cannot be possible matches as well. This is because while Ellaria is interested in Dany, Dany is not interested in Ellaria. Moreover, while Jon can be interested in Ellaria, Ellaria is not interested in Jon.

### **4. View Matches**
The user must be able to see all of his matches. Viewing the user’s matches displays 4 columns:
- _ID_: an integer from 1 to 10 that indicates the order by which they were matched
- _Name_: name of the matched user
- _Gender_: gender of the matched user
- _Age_: age of the matched user

### **5. Unmatch**
The user can unmatch a previously matched person. To do this, the user can type in the ID of the user he wishes to unmatch. The user is then removed from the other person’s matches, and the other person must also be removed from the user’s matches.

### **6. Edit User Settings**
The user can edit his settings and preferences at any time. The user can change the following:
- _Change Show Me_: allows the user to change his gender preference
- _Change Age Range_: allows the user to change his age range preference by inputting the new age maximum and minimum

### **7. Logout**
The user can logout and go back to the login menu.

### **8. Quit**
The user can terminate the program.


## Classes

The project has the following classes:
### **1. Program.cs**
- Contains the Main() method

### **2. Profile.cs**
- Each Profile object stores the following:
    - Name of user
    - Age of user
    - Gender of user
    - A UserSetting object for its user settings
    - An array of the person’s matches

- It also performs the following tasks:
    - Get and set of attributes

### **3. UserSetting.cs**
- Each UserSetting object stores the following:
    - Minimum age preference
    - Maximum age preference
    - Show Me (gender preference)

- It also performs the following tasks:
    - Get and set of attributes

### **4. Function.cs**
- The Function object stores the following:
    - A list of all registered users
    
- It also performs the following tasks:
    - Registering a user
    - Matching and unmatching users
    - Editing a person’s user settings or preferences
    - Displaying a user’s matches and all registered users in the system

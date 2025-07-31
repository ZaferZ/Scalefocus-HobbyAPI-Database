# EVENTIT
## _The App that connects_



EVENTIT is an app that lets you create and explore events that people with similar hobbies will attend.

- Make and manage events, leave comments, connect with peopple
- Sellect your favourite activites, bookmark them and attend


## Features

- Make and event with a place, date and time 
- Make a to-do list with tasks that need to be done
- Select hobbies and connect with people that share interests with you
- Leave comments on events and browse for more

The project is made using a microservice approach where we devide the API to several micro-projects. Or model structure consists of the following entities such as:

 - User
 - Comment
 - Event
 - Hobby
 - Task

The person makes a profile using the User API then he is promted to sellect a hobby using the Hobby API. After that user can look at or crate events and chose to attend whichever events he has access to form the hobbies he has sellected. After someone chooses to attend and event they are prompted to the Evnet API where they can see all of the informataion of the event and see whatever tasks the owner of the event has requred to be done using the Task API. You can also make comments on the events and interact with people there using the Comments API.


## Tech

Eventit uses the following:

- [.NET Framework](https://dotnet.microsoft.com/en-us/download/dotnet-framework) - as a base of the project
- [Entity Framework](https://learn.microsoft.com/en-us/ef/) - to be abale to work with DBs
- [REST API architecture](https://en.wikipedia.org/wiki/REST) -  provide a lightweight way to build web APIs 
- [Microsoft SQL](https://learn.microsoft.com/en-us/ssms/sql-server-management-studio-ssms) - to be able to host and use the database







## Development
- _HobbyAPI_ - Works from the moment a created user logs in. This will have 2 outcomes. In one of the outcomes the user is prompted to select a hobby from a selection made beforehand form an admin(sport,fitnes,cooking...) .This will trigger when the user doesn't have an alocated hobby in the HobbyUser table with a GET request. If so then a CREATE request will be sent to the DB. The second outcome is when the GET request is valid and the user has selected hobby before.

- _EventAPI_ - Works when a user has both loged in and has selected a hobby. First a GET request is send to show all the events related to th hobbies of the user. Also if the user is an owner of an event he can do an UPDATE request to edit the event. The user can also call a CREATE request to make a new event.

 - _CommentAPI_ ....
 
 - _TaskAPI_ ....
 
 - _UserAPI_ - The person can make a CREATE request to have an account made. He then can log in with a LOGIN request that will check the password and the user and generate a JWT. 

# Database
### Event
| Column Name   | Data Type        | Constraints                  | Description                                  |
| ------------- | ---------------- | ---------------------------- | -------------------------------------------- |
| id          | INT              | PRIMARY KEY, AUTO_INCREMENT | Unique identifier for the event              |
| title       | VARCHAR(255)     | NOT NULL                     | Title of the event                           |
| description | TEXT             |                              | Detailed information about the event         |
| owner_id    | UNIQUEIDENTIFIER | FOREIGN KEY → users(id)    | ID of the user who created the event         |
| hobby_id    | INT              | FOREIGN KEY → hobbies(id)  | ID referencing the related hobby             |
| start_date  | DATETIME         | NOT NULL                     | Event starting date and time                 |
| end_date    | DATETIME         |                              | Event ending date and time                   |
| location    | VARCHAR(255)     |                              | Location where the event takes place         |
| capacity    | INT              |                              | Maximum number of participants allowed       |
| created_at  | DATETIME         | DEFAULT CURRENT_TIMESTAMP   | Timestamp when the event was created         |
| created_by  | UNIQUEIDENTIFIER | FOREIGN KEY → users(id)    | ID of the user who created the record        |
| modified_at | DATETIME         | NULLABLE                     | Last modification timestamp                  |
| modified_by | UNIQUEIDENTIFIER | FOREIGN KEY → users(id)    | ID of the user who last modified the record  |
| status      | ENUM             | DEFAULT 'Scheduled'          | Current status of the event (e.g. Scheduled) |
### User
| Column Name   | Data Type        | Constraints                  | Description                                  |
| ------------- | ---------------- | ---------------------------- | -------------------------------------------- |
| id          | INT              | PRIMARY KEY, AUTO_INCREMENT | Unique identifier for the event              |
| title       | VARCHAR(255)     | NOT NULL                     | Title of the event                           |
| description | TEXT             |                              | Detailed information about the event         |
| owner_id    | UNIQUEIDENTIFIER | FOREIGN KEY → users(id)    | ID of the user who created the event         |
| hobby_id    | INT              | FOREIGN KEY → hobbies(id)  | ID referencing the related hobby             |
| start_date  | DATETIME         | NOT NULL                     | Event starting date and time                 |
| end_date    | DATETIME         |                              | Event ending date and time                   |
| location    | VARCHAR(255)     |                              | Location where the event takes place         |
| capacity    | INT              |                              | Maximum number of participants allowed       |
| created_at  | DATETIME         | DEFAULT CURRENT_TIMESTAMP   | Timestamp when the event was created         |
| created_by  | UNIQUEIDENTIFIER | FOREIGN KEY → users(id)    | ID of the user who created the record        |
| modified_at | DATETIME         | NULLABLE                     | Last modification timestamp                  |
| modified_by | UNIQUEIDENTIFIER | FOREIGN KEY → users(id)    | ID of the user who last modified the record  |
| status      | ENUM             | DEFAULT 'Scheduled'          | Current status of the event (e.g. Scheduled) |
### Hobby
| Column Name  | Data Type    | Constraints | Description                                |
| ------------ | ------------ | ----------- | ------------------------------------------ |
| id         | INT          | PRIMARY KEY | Unique identifier for the hobby            |
| title      | VARCHAR(100) | NOT NULL    | Name/title of the hobby                    |
| date       | DATETIME     |             | When the hobby was added/created           |
| updated_at | INT          |             | Last updated date (e.g. yyyymmdd format) |
### Task
| Column Name    | Data Type    | Constraints   | Description                               |
| -------------- | ------------ | ------------- | ----------------------------------------- |
| id           | INT          | PRIMARY KEY   | Unique identifier for the task            |
| title        | VARCHAR(255) | NOT NULL      | Short name/title of the task              |
| description  | TEXT         |               | Details of what the task involves         |
| is_completed | BOOLEAN      | DEFAULT FALSE | Whether the task has been completed       |
| modified_at  | DATETIME     |               | Timestamp when the task was last modified |
### Comment
| Column Name  | Data Type        | Constraints                | Description                              |
| ------------ | ---------------- | -------------------------- | ---------------------------------------- |
| id         | INT              | PRIMARY KEY                | Unique identifier for the comment        |
| event_id   | INT              | FOREIGN KEY → events(id) | The event the comment is associated with |
| user_id    | UNIQUEIDENTIFIER | FOREIGN KEY → users(id)  | The user who posted the comment          |
| content    | TEXT             | NOT NULL                   | Text content of the comment              |
| created_at | DATETIME         | DEFAULT CURRENT_TIMESTAMP | Time when the comment was created        |
### Participant
| Column Name  | Data Type        | Constraints                | Description                                 |
| ------------ | ---------------- | -------------------------- | ------------------------------------------- |
| id         | INT              | PRIMARY KEY                | Unique identifier for the participant entry |
| event_id   | INT              | FOREIGN KEY → events(id) | Associated event                            |
| user_id    | UNIQUEIDENTIFIER | FOREIGN KEY → users(id)  | User participating in the event             |
| content    | TEXT             |                            | Optional message from the participant       |
| created_at | DATETIME         | DEFAULT CURRENT_TIMESTAMP | Time the participation entry was created    |
### Event task
| Column Name | Data Type | Constraints                     | Description                                       |
| ----------- | --------- | ------------------------------- | ------------------------------------------------- |
| event_id  | INT       | FOREIGN KEY → events(id)      | ID of the associated event                        |
| tasks_id  | INT       | FOREIGN KEY → event_tasks(id) | ID of the associated task                         |
| added_at  | DATETIME  | DEFAULT CURRENT_TIMESTAMP      | Timestamp when the task was linked to the event   |
| role      | ENUM      | DEFAULT 'NormalTask'            | Role/type of the task in the context of the event |
### Hobby User
| Column Name  | Data Type        | Constraints                 | Description                           |
| ------------ | ---------------- | --------------------------- | ------------------------------------- |
| hobbies_id | INT              | FOREIGN KEY → hobbies(id) | The hobby the user is associated with |
| user_id    | UNIQUEIDENTIFIER | FOREIGN KEY → users(id)   | The user who has this hobby           |
| created_at | DATETIME         | DEFAULT CURRENT_TIMESTAMP  | When this user-hobby link was created |
### Task User
| Column Name    | Data Type        | Constraints                          | Description                                  |
| -------------- | ---------------- | ------------------------------------ | -------------------------------------------- |
| tasks_id     | INT              | FOREIGN KEY → event_tasks(id)      | ID of the task being assigned                |
| user_id      | UNIQUEIDENTIFIER | FOREIGN KEY → users(id)            | User responsible for completing the task     |
| is_completed | BOOLEAN          | DEFAULT FALSE                        | Whether the assigned task has been completed |
| created_at   | DATETIME         | DEFAULT CURRENT_TIMESTAMP           | When the assignment was created              |
| modified_at  | DATETIME         | NULLABLE                             | Last time the assignment was updated         |
| modified_by  | UNIQUEIDENTIFIER | FOREIGN KEY → users(id) (nullable) | User who last modified this assignment       |
## License

MIT

**Free Software, Hell Yeah!**



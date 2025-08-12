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

- _EventAPI_ - Works when a user has both loged in and has selected a hobby. First a GET request is send to show all the events related to th hobbies of the user. Also if the user is an owner of an event he can do an UPDATE request to edit the event. The user can also call a CREATE request to make a new event. Check out [EventApi](https://github.com/ZaferZ/EventAPI) for more info.

 - _CommentAPI_ - CommentAPI is a service for managing comments associated with events and users. The API supports standard CRUD operations with JWT authentication.
Endpoints:
* GET /api/Comments: Retrieve all comments
*	GET /api/Comments/{id}: Get comment by ID
* POST /api/Comments: Create new comment (requires user/admin role)
* PUT /api/Comments/{id}: Update existing comment (requires user/admin role, users can only update their own)
* DELETE /api/Comments/{id}: Delete comment (users can delete their own, admins can delete any)
* GET /api/Comments/user/{userId}: Get all comments by a specific user
* GET /api/Comments/event/{eventId}: Get all comments for a specific event
 
 - _TaskAPI_ ....
 
 - _UserAPI_ - The person can make a CREATE request to have an account made. He then can log in with a LOGIN request that will check the password and the user and generate a JWT. 

# Database
### Event
| Column Name   | Data Type        | Constraints                  | Description                                  |
| ------------- | ---------------- | ---------------------------- | -------------------------------------------- |
| Id          | INT              | PRIMARY KEY, AUTO_INCREMENT | Unique identifier for the event              |
| Ttitle       | VARCHAR(MAX)     | NOT NULL                     | Title of the event                           |
| Description | TEXT             |                              | Detailed information about the event         |
| OwnerId    | UNIQUEIDENTIFIER | FOREIGN KEY → Users(Id)    | ID of the user who created the event         |
| HobbyId    | INT              | FOREIGN KEY → Hobbies(Id)  | ID referencing the related hobby             |
| StartDate  | DATETIME         | NOT NULL                     | Event starting date and time                 |
| EndDate   | DATETIME         |                              | Event ending date and time                   |
| Location    | VARCHAR(MAX)     |                              | Location where the event takes place         |
| Capacity    | INT              |                              | Maximum number of participants allowed       |
| CreatedAt  | DATETIME         | DEFAULT CURRENT_TIMESTAMP   | Timestamp when the event was created         |
| CreatedBy  | UNIQUEIDENTIFIER | FOREIGN KEY → Users(Id)    | ID of the user who created the record        |
| ModifiedAt| DATETIME         | NULLABLE                     | Last modification timestamp                  |
| ModifiedBy | UNIQUEIDENTIFIER | FOREIGN KEY → Users(Id)    | ID of the user who last modified the record  |
| Status      | INT(ENUM)             | DEFAULT 'Scheduled'          | Current status of the event (e.g. Scheduled) |

### User
| Column Name     | Data Type        | Constraints      | Description                    |
| --------------- | ---------------- | ---------------- | ------------------------------ |
| Id            | UNIQUEIDENTIFIER | PRIMARY KEY      | Unique identifier for the user |
|  Username    | NVARCHAR(MAX)      | UNIQUE, NOT NULL | User's chosen username         |
| FirstName    | NVARCHAR(MAX)     | NOT NULL         | User's first name              |
| LastName     | NVARCHAR(MAX)     | NOT NULL         | User's last name               |
| Email         | NVARCHAR(MAX)     | UNIQUE, NOT NULL | User's email address           |
| PasswordHash | NVARCHAR(MAX)            | NOT NULL         | Hashed password                |

### Hobby
| Column Name  | Data Type    | Constraints | Description                                |
| ------------ | ------------ | ----------- | ------------------------------------------ |
| Id         | INT          | PRIMARY KEY | Unique identifier for the hobby            |
| Title      | VARCHAR(MAX) | NOT NULL    | Name/title of the hobby                    |
| Date       | DATETIME     |             | When the hobby was added/created           |
| UpdatedAt | DATETIME          |             | Last updated date (e.g. yyyymmdd format) |

### Task
| Column Name    | Data Type    | Constraints   | Description                               |
| -------------- | ------------ | ------------- | ----------------------------------------- |
| Id           | INT          | PRIMARY KEY   | Unique identifier for the task            |
| Title        | NVARCHAR(MAX) | NOT NULL      | Short name/title of the task              |
| Description  | NVARCHAR(MAX)         |               | Details of what the task involves         |
| IsCompleted | BIT(BOOLEAN      | DEFAULT FALSE | Whether the task has been completed       |
| ModifiedAt  | DATETIME     |               | Timestamp when the task was last modified |

### Comment
| Column Name  | Data Type        | Constraints                | Description                              |
| ------------ | ---------------- | -------------------------- | ---------------------------------------- |
| Id         | INT              | PRIMARY KEY                | Unique identifier for the comment        |
| EventId   | INT              | FOREIGN KEY → Events(Id) | The event the comment is associated with |
| UserId    | UNIQUEIDENTIFIER | FOREIGN KEY → Users(Id)  | The user who posted the comment          |
| Content    | NVARCHAR(MAX)             | NOT NULL                   | Text content of the comment              |
| CreatedAt | DATETIME         | DEFAULT CURRENT_TIMESTAMP | Time when the comment was created        |

### Participant
| Column Name   | Data Type        | Constraints                            | Description                                |
| ------------- | ---------------- | -------------------------------------- | ------------------------------------------ |
| EventId    | INT              | FOREIGN KEY →  Events(id)            | ID of the related event                    |
| UserId     | UNIQUEIDENTIFIER | FOREIGN KEY →  Users(id)              | ID of the user who joined the event        |
| Role       | INT              | NOT NULL                               | Role of the user in the event (e.g., enum) |
| JoinedAt   | DATETIME2(7)     | DEFAULT CURRENT\_TIMESTAMP             | Timestamp when the user joined the event   |
| ModifiedAt | DATETIME2(7)     | NULLABLE                               | Last time this relationship was modified   |
| ModifiedBy | UNIQUEIDENTIFIER  | FOREIGN KEY → Users(id) *(optional)* | User who last modified the record          |

### Event task
| Column Name | Data Type | Constraints                     | Description                                       |
| ----------- | --------- | ------------------------------- | ------------------------------------------------- |
| EventId  | INT       | FOREIGN KEY → events(id)      | ID of the associated event                        |
| TasksId  | INT       | FOREIGN KEY → event_tasks(id) | ID of the associated task                         |
| AddedAt  | DATETIME  | DEFAULT CURRENT_TIMESTAMP      | Timestamp when the task was linked to the event   |
| Role      | INT(ENUM)    | DEFAULT 'NormalTask'            | Role/type of the task in the context of the event |
| ModifiedAt| DATETIME         | NULLABLE                     | Last modification timestamp                  |
| ModifiedBy | UNIQUEIDENTIFIER | FOREIGN KEY → Users(Id)    | ID of the user who last modified the record  |

### Hobby User
| Column Name  | Data Type        | Constraints                 | Description                           |
| ------------ | ---------------- | --------------------------- | ------------------------------------- |
| HobbiesId | INT              | FOREIGN KEY → Hobbies(Id) | The hobby the user is associated with |
| UserId    | UNIQUEIDENTIFIER | FOREIGN KEY → Users(Id)   | The user who has this hobby           |
| CreatedAt | DATETIME         | DEFAULT CURRENT_TIMESTAMP  | When this user-hobby link was created |

### Task User
| Column Name    | Data Type        | Constraints                          | Description                                  |
| -------------- | ---------------- | ------------------------------------ | -------------------------------------------- |
| TasksId     | INT              | FOREIGN KEY → EventTasks(Id)      | ID of the task being assigned                |
| UserId      | UNIQUEIDENTIFIER | FOREIGN KEY → Users(Id)            | User responsible for completing the task     |
| IsCompleted | BIT(BOOLEAN)          | DEFAULT FALSE                        | Whether the assigned task has been completed |
| CreatedAt   | DATETIME         | DEFAULT CURRENT_TIMESTAMP           | When the assignment was created              |
| ModifiedAt  | DATETIME         | NULLABLE                             | Last time the assignment was updated         |
| ModifiedBy  | UNIQUEIDENTIFIER | FOREIGN KEY → Users(Id) (nullable) | User who last modified this assignment       |

### User Role
| Column Name | Data Type        | Constraints               | Description                   |
| ----------- | ---------------- | ------------------------- | ----------------------------- |
| UserId   | UNIQUEIDENTIFIER | FOREIGN KEY → Users(Id) | The user assigned a role      |
| RoleId   | INT              | FOREIGN KEY → Roles(Id)| The role assigned to the user |

### Roles
| Column Name | Data Type | Constraints      | Description                         |
| ----------- | --------- | ---------------- | ----------------------------------- |
| Id       | INT       | PRIMARY KEY      | Unique identifier for the role      |
| Name     | VARCHAR   | UNIQUE, NOT NULL | Name of the role (e.g. Admin, User) |



## License

MIT

**Free Software, Hell Yeah!**



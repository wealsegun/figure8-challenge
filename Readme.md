# figure8-challenge Technical Assesment

The task is to create an Angular and .Net Core that will be able to do the following.
## Please write an app that will allow user to:
1. Login
2. See the list of his contacts
3. Add, edit, delete any of his contacts
4. Logout

####App should make calls to back end to handle:

1. Login
2. Add, edit, delete, list contacts

Thank you!

### User stories

As an anonymous user  
I want to see all contact details  
So that I can help to store all the contact details in a page.  

As an authenticated user  
I want to create a new contact on the system  
I want to be able to edit contact details on the system.
I want to be able to delete contact on the system.
So that I can raise awareness of a contact details.

### To help save you some time...

-   The ‘figure8-challenge.Core’ project found in this GitHub repo contains a service with methods to get you started. It interacts with an in-memory database which can be used in this exercise in place of a ‘real’ database. 

-   This project also contains a mocked identity provider which can be used to simulate logging in. For an authenticated user you can log in with the following credentials:  

Username: wealsegun  
Password: Pa$$w0rd

### Running the app
Ensure you have .net core 3.1 installed on your machine. If you're using Visual Studio 2019 then set one of the web projects as the startup project and hit run.
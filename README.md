# Blazor Task Manager

This project was created using .NET and the Blazor framework. 
Blazor is a cross platform development framework created by Microsoft, and it gives you the power to code your web application using C# or Razor. 
This project consists of 2 parts: 
- Blazor WebAssembly (front-end) 
- Blazor WebAPI (back-end) 

Blazor WebAssembly is a single-page app (SPA) framework for building client-side web applications with .NET. Developers can write C# and utilize code that already exists in their back-end applications like models, business logic, and more. 
Blazor WebAPI is an extension to the Blazor WebAssembly, which gives developers the ability to build HTTP services that support JSON requests. 

The front-end consists of fields which the user interacts with. In this project the user can create TimeLog projects, create DevOps work items using a Freshdesk ticket. The front-end handles form validation and sends a request to the back-end, which then sends a request to one or more APIs. 
Freshdesk and DevOps uses API keys, while the TimeLog API uses OAuth 2 for user authentication. 
A normal workflow would look something like this: 
- The user authenticates using their TimeLog login and is redirected to the Task Manager with a OAuth code. 
- The Web API exchanges this code for an access token and the user can now begin creating TimeLog projects. 
- TimeLog projects and DevOps work items are often based on a Freshdesk ticket. Therefore the user searches using a ticket number. 
- The user fills out info for a TimeLog project and/or DevOps work item and clicks "Create" 
- The back-end handles all the request and the front-end displays success or error modals depending on the responses.

The Task Manager fills out most fields using the Freshdesk ticket, so the user doesn't have to fill out everything manually.
This workflow is a lot faster than accessing three different sites and manually creating the items. 

Below are a few screenshots of the UI. The UI won't win any awards, but beautiful design wasn't a high priority :) 

### Creating TimeLog projects
![Creating TimeLog projects](/CreateProject.PNG)

### Creating DevOps work items
![Creating DevOps work items](/CreateWorkItem.PNG)

### Creating DevOps work item task
![Creating DevOps work item task](/CreateTask.PNG)


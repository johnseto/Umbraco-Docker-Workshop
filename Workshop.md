# Umbraco and Docker

## Prerequisites

In order to run this application you will need the following installed on your machine.

- Visual Studio Code
    - There's a useful docker extension for Visual studio code : [https://code.visualstudio.com/docs/containers/overview](https://code.visualstudio.com/docs/containers/overview)
- Docker Desktop 
    - Windows subsystem for Linux (only required in Windows obviously)	
- .NET SDK version 6
    - https://dotnet.microsoft.com/en-us/download/dotnet/6.0

## SDK

Check the version of the SDK you have installed using the following

    dotnet sdk check


# Creating the Umbraco containers

## Installing Umbraco Template and start Website

Run the following to install the template

    dotnet new -i Umbraco.Templates::10.0.0-rc4

Set the SDK Version being used and Create solution/project. This will create a global file with the current latest version of the SDK

    dotnet new globaljson --sdk-version 6.0 
    dotnet new sln --name UmbDock

Start an Umbraco Site

    dotnet new Umbraco -n UmbDock --friendly-name "Admin User" --email "admin@admin.com" --password "1234567890" --connection-string "Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Umbraco.mdf;Integrated Security=True"

Add project to the solution

    dotnet sln add UmbDock

Add a project for us to try

    dotnet add UmbDock package Clean

or

    dotnet add UmbDock package Portfolio

Trust the dev certs

    dotnet dev-certs https --trust

Clear your local nuget cache

    dotnet nuget locals all --clear

Run the website

    dotnet run --project UmbDock

## Create Network

Create the bridge network 

    docker network create -d bridge umbNet    

## Build the docker image

For the website

    docker build --tag=umbdock .\UmbDock

For the database

    docker build --tag=umbdata .\UmbData    

## Run the containers

Website

    docker run --name umbdock -p 8000:80 -v media:/app/wwwroot/media -v logs:/app/umbraco/Logs -e ASPNETCORE_ENVIRONMENT='Staging' --network=umbNet -d umbdock

    docker run --name umbdock2 -p 8002:80 -v media:/app/wwwroot/media -v logs:/app/umbraco/Logs -e ASPNETCORE_ENVIRONMENT='Staging' --network=umbNet -d umbdock

Data

    docker run --name umbdata -p 1433:1433 --volume sqlserver:/var/opt/sqlserver --network=umbNet -d umbdata

# Add the Blazor Container

## Build Image

    docker build --tag=umblazor .\UmBlazor    

## Run the Container

    docker run --name umblazor -p 8001:80 -e ASPNETCORE_ENVIRONMENT='Staging' --network=umbNet -d umblazor

## File Types

Remember, Linux line endings need -> Lf NOT CrLf

## Cleanup

If you want to remove the RC1 template and revert to the older version

    dotnet new -u Umbraco.Templates



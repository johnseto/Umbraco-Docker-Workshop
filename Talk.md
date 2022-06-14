## Database container

    docker build --tag=umbdata ./UmbData    

    docker run --name umbdata -p 1433:1433 --volume sqlFiles:/var/opt/mssql --network=umbNet -d umbdata
 
## Website

Run It

    dotnet run --project UmbWeb

 


## Rebuild

    docker build --tag=umbweb ./UmbWeb

    docker run --name umbweb -p 8000:80 -v umb_media:/app/wwwroot/media -v umb_logs:/app/umbraco/Logs -e ASPNETCORE_ENVIRONMENT='Staging' --network=umbNet -d umbweb 


## Remove old images and Run

    docker rm -f umblazor umbweb umbdata

    docker compose up -d

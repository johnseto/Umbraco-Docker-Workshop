## Database container

    docker build --tag=umbdata ./UmbData    

    docker run --name umbdata -p 1433:1433 --volume sqlFiles:/var/opt/mssql --network=umbNet -d umbdata
 

## Rebuild

Copy Dockerfile

    docker build --tag=umbweb ./UmbWeb

    docker run --name umbweb -p 8001:80 -v umb_media:/app/wwwroot/media -v umb_logs:/app/umbraco/Logs -e ASPNETCORE_ENVIRONMENT='Staging' --network=umbNet -d umbweb 

    docker run --name umbweb2 -p 8002:80 -v umb_media:/app/wwwroot/media -v umb_logs:/app/umbraco/Logs -e ASPNETCORE_ENVIRONMENT='Staging' --network=umbNet -d umbweb 

    docker run --name umbweb3 -p 8003:80 -v umb_media:/app/wwwroot/media -v umb_logs:/app/umbraco/Logs -e ASPNETCORE_ENVIRONMENT='Staging' --network=umbNet -d umbweb 

    docker run --name umbweb4 -p 8004:80 -v umb_media:/app/wwwroot/media -v umb_logs:/app/umbraco/Logs -e ASPNETCORE_ENVIRONMENT='Staging' --network=umbNet -d umbweb 

    http://localhost:8000/Umbraco/Api/MyApp/GetBlogSummaries

## Build Blazor

Copy Projet


## Remove old images and Run

    docker rm -f umbweb umbweb2 umbweb3 umbweb4 umbdata

    docker compose up -d --build

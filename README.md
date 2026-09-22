# TaskPulse - API

## Prerequisites

- Docker with Docker Compose
- .NET 10 SDK with dotnet-ef

## Initial setup

### 1. Clone the repository

```bash
git clone https://github.com/your-user/taskpulse-api.git
cd taskpulse-api
```

### 2. Configure environment variables (.env)

The project uses a `.env` file for the environment variables consumed by `docker-compose.yaml`.

- Copy the `.env.template` file to `.env`:

```bash
cp .env.template .env
```

- Edit the `.env` file with your preferred values:

```text
STAGE=dev
DB_PASSWORD=your_password
DB_NAME=taskpulse
```

### 3. Create the database with Docker Compose

The PostgreSQL database is started using Docker Compose. This creates the `taskpulse-db` container and a volume to persist data.

```bash
docker compose up -d
```

To verify the container is running:

```bash
docker compose ps
```

## .NET API configuration

The default connection string is in `src/TaskPulse.Api/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=127.0.0.1;Port=5432;Database=taskpulse;Username=postgres;Password=postgres"
}
```

### Use User Secrets to override appsettings.json

For local development, **it is recommended not to edit `appsettings.json` with real credentials**. Instead, use.NET User Secrets, which overrides the `appsettings.json` configuration without storing secrets in the repository.

#### Initialize User Secrets

From the API project directory:

```bash
cd src/TaskPulse.Api
dotnet user-secrets init
```

#### Set the connection string

Override `ConnectionStrings:DefaultConnection` with the values from your `.env`:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=127.0.0.1;Port=5432;Database=taskpulse;Username=postgres;Password=YOUR_PASSWORD"
```

Replace `YOUR_PASSWORD` with the password defined in your `.env` file.

#### Verify the configured secrets

```bash
dotnet user-secrets list
```

## Restore the database

To apply Entity Framework Core migrations and restore/create the schema in the database started with Docker Compose:

```bash
dotnet ef database update --project src/TaskPulse.Api
```

> **Note:** If `dotnet ef` is not installed, install it with `dotnet tool install --global dotnet-ef`.

## Run the API

From the repository root:

```bash
dotnet run --project src/TaskPulse.Api
```

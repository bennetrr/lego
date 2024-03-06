# BrickInv

A web application that helps to check if all parts of a LEGO set are present.

## Configuration

### Frontend

The frontend is configurable with the `env.js` file.

> [!CAUTION]
> The contents of this file are available in `window.env` in the browser,
> so don't store any confidential information in there.

| Name         | Type     | Description                                                                              |
|--------------|----------|------------------------------------------------------------------------------------------|
| `apiBaseUrl` | `string` | Base URL of the BrickInv API, e.g. `https://api.brickinv.com` or `http://localhost:5105` |

### Backend

The backend is configurable with everything supported by ASP.NET.
For development, the .NET user secret manager is recommended, for production a `.env` file.

| `.env`-Name                       | `.json`-Name                  | Type     | Description                                                                          |
|-----------------------------------|-------------------------------|----------|--------------------------------------------------------------------------------------|
| `EMAIL__SENDER_ADDRESS`           | `Email.SenderAddress`         | `string` | Email address that the emails are sent from                                          |
| `EMAIL__SENDER_NAME`              | `Email.SenderName`            | `string` | Name that is displayed as email sender                                               |
| `EMAIL__SERVER`                   | `Email.Server`                | `string` | SMTP Server address                                                                  |
| `EMAIL__PORT`                     | `Email.Port`                  | `string` | SMTP Server port                                                                     |
| `EMAIL__USERNAME`                 | `Email.Username`              | `string` | Username to log in at the SMTP Server                                                |
| `EMAIL__PASSWORD`                 | `Email.Password`              | `string` | Password to log in at the SMTP Server                                                |
| `APP_CONFIG__REBRICKABLE_API_KEY` | `AppConfig.RebrickableApiKey` | `string` | API key for Rebrickable, used for retrieving information about Lego sets             |
| `APP_CONFIG__APP_BASE_URL`        | `AppConfig.AppBaseUrl`        | `string` | Base URL of the BrickInv App, e.g. `https://brickinv.com` or `http://localhost:5137` |
| `APP_CONFIG__IMPRINT_URL`         | `AppConfig.ImprintUrl`        | `string` | URL to an imprint, used in emails                                                    |

## Development

### Dependencies

- `dotnet-sdk@8`
- `node@21`
- `pnpm`
- `docker`

### Setup

Install frontend dependencies:

```bash
# working directory: src/frontend
pnpm install
```

Install backend dependencies:

```bash
# working directory: src/backend/Bennetr.BrickInv.Api/Bennetr.BrickInv.Api
dotnet restore
```

### Run development server against local API

Start database:

```bash
# working directory: repository root
docker run -d \
  --name brickinv-mariadb-dev \
  --publish 3306:3306 \
  --env 'MARIADB_ROOT_PASSWORD=3gEju5UGRPbSbJ$r#wvYDn$g%6ryH5' \
  --volume brickinv-mariadb-dev:/var/lib/mysql \
  --volume ./setup.sql:/docker-entrypoint-initdb.d/setup.sql \
  mariadb:11.3.2-jammy
```

> [!NOTE]
> If you change the password or the port in the command above,
> you need to update the `appsettings.Development.json` file!

To configure the backend, use
the [.NET User Secret Manager](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows#secret-manager)
with the options from the [Configuration](#backend) section.

Then, start the backend:

```bash
# working directory: src/backend/Bennetr.BrickInv.Api/Bennetr.BrickInv.Api
dotnet run --launch-profile http
```

The backend is exposed at `http://localhost:5105`

To configure the frontend, copy `src/frontend/public/env/env.template.js` to `src/frontend/public/env/env.local.js` and
replace the empty strings with your own values.
The configuration fields are documented in the [Configuration](#frontend) section.

To start the frontend, run:

```bash
# working directory: src/frontend
pnpm dev:local
```

### Run development server with production API

To configure the frontend, copy `src/frontend/public/env/env.template.js` to `src/frontend/public/env/env.prod.js` and
replace the empty strings with your own values.
The configuration fields are documented in the [Configuration](#frontend) section.

To start the frontend, run:

```bash
# working directory: src/frontend
pnpm dev:prod
```

## Production

### Setup

Download the following files from the [latest release branch](https://github.com/bennetrr/brickinv/tree/release/v2.0):

- `docker-compose.yml`
- `setup.sql`
- `src/frontend/public/env/env.template.js` as `env.js`
- `backend.env`

Replace the empty strings in the `env.js` and `backend.env` files with your own values.
The configuration fields are documented in the [Configuration](#configuration) section.

Then start the containers by running:

```bash
docker compose up -d
```

### Connections

All services are exposed into the `reverse_proxy` network.
The frontend is available under `brickinv-frontend-1:80`, the backend under `brickinv-backend-1:80`.

The application data is saved in the named volume `brickinv_mariadb`.

### Database migration

After the installation and after updates with database model changes,
the database migration scripts need to be executed to apply the changes to your database.
These scripts are shipped with the container. You can execute them with the following command:

```bash
docker compose exec backend sh -c './identity-db-migration && ./brickinv-db-migration'
```

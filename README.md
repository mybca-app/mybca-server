# Welcome to the myBCA server's source repository.

myBCA is the unofficial, all-in-one app for students of the Bergen County
Academies. This repository contains the main server component of myBCA,
which handles bus positions/notifications, lunch menus, and quick links.
This project does not handle the event system of the app.

## Features

### Buses

- myBCA scrapes the BCA bus spreadsheet to determine the location of each bus at
  dismissal.
  - Bus locations are cached in a basic in-memory cache. The TTL for the cache
    is shortened during the dismissal time period.
- Bus notifications are sent via Firebase Cloud Messaging. A separate service
  scans the bus spreadsheet for changes. When a change is detected, the service
  sends a notification to all users who have starredthat bus.
- Bus arrivals are logged in a MySQL database. Bus arrival history is served at
  a dedicated API endpoint.

### Lunch

- myBCA uses the Nutrislice backend API to fetch lunch menus for the week.
  - Lunch menus are cached in a basic in-memory cache.
- Lunch information is served via a REST API endpoint.

### News

- The myBCA server fetches the latest stories from the school newspaper, the
  *Academy Chronicle*.
- The latest stories are served via a REST API endpoint for easy consumption by
  the app.

### Quick Links

- Quick links to BCA-related services (PowerSchool, Schoology, etc.) are served
  in a REST API endpoint.

## Replication

This aims to be a sufficient guide for you to get myBCA's server up and running
on your own machine.

### Getting started

We use Docker Compose to run the app. You will need to have Docker and Compose.
This is a .NET app, so you must have .NET installed on your machine to build or
run the app.

### Configuration

We use environment variables for configuration. You can see a sample .env file
in [sample.env](sample.env). To see the default configuration values, go to
[MyBCA.Server/appsettings.json](MyBCA.Server/appsettings.json) file. Many of the
default config values are fine and ready for production.

### MySQL

MySQL is used by the bus scanner service to log bus arrivals. The Compose
project includes a MySQL container. The MySQL credentials are configured in the
.env file.

### Notifications

To send notifications, you will need a `firebase-service-account.json` file.
Create a directory named `secrets` and place the file there. The Docker Compose
file will deal with making it available to the application.

If you don't want to send notifications, then you can set
`Notifications.NotificationsEnabled` to `false` in the appsettings.json file, or
set the environment variable `Notifications__NotificationsEnabled` to `false`.

### Prometheus and Grafana

The web app is instrumented with Prometheus. The Docker Compose project also
contains a Grafana container, so that the Prometheus data can easily be
visualized. There is a Grafana provisioning setup in the
[grafana/provisioning](grafana/provisioning) directory, and the Grafana
credentials can be specified in the .env file.

### Running

Simply run:
```
docker compose up
```
Don't you love Docker?

#### Running in development

You might not feel like running the Compose project for development. Simply run:
```
dotnet watch
```
and your code changes will take effect in real time, without the need to restart.

## API Documentation

The app has an OpenAPI endpoint at `/openapi/v1.json`. There is also compiled
documentation in the file
[Documentation/MyBCA.Server/openapi.md](Documentation/MyBCA.Server/openapi.md)

## License

SPDX-License-Identifier: AGPL-3.0-or-later - see the [LICENSE](LICENSE) file for
details.
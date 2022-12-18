![](https://cdn.myuuiii.com/projects/azurlaneapi/repo-header.jpg)

### Endpoints

#### Factions

| Method | Endpoint               | Implementation |
| ------ | ---------------------- | -------------- |
| Get    | `/factions`            | ✅              |
| Get    | `/factions/:id`        | ✅              |
| Get    | `/factions/name/:name` | ✅              |
| Post   | `/factions`            | ✅              |
| Put    | `/factions/:id`        | ✅              |
| Delete | `/factions/:id`        | ✅              |

#### Ships

| Method | Endpoint            | Implementation |
| ------ | ------------------- | -------------- |
| Get    | `/ships`            | ✅              |
| Get    | `/ships/:id`        | ✅              |
| Get    | `/ships/name/:name` | ✅              |
| Get    | `/ships/minimal`    | ✅              |
| Post   | `/ships`            | ✅              |
| Put    | `/ships/:id`        | ✅              |
| Delete | `/ships/:id`        | ✅              |

#### Ship Types

| Method | Endpoint                | Implementation |
| ------ | ----------------------- | -------------- |
| Get    | `/shiptypes`            | ✅              |
| Get    | `/shiptypes:id`         | ✅              |
| Get    | `/shiptypes/name/:name` | ✅              |
| Post   | `/shiptypes`            | ✅              |
| Put    | `/shiptypes/:id`        | ✅              |
| Delete | `/shiptypes/:id`        | ✅              |

#### Ship Type Subclasses

| Method | Endpoint                         | Implementation |
| ------ | -------------------------------- | -------------- |
| Get    | `/shiptypesubclasses`            | ✅              |
| Get    | `/shiptypesubclasses/:id`        | ✅              |
| Get    | `/shiptypesubclasses/name/:name` | ✅              |
| Post   | `/shiptypesubclasses`            | ✅              |
| Put    | `/shiptypesubclasses/:id`        | ✅              |
| Delete | `/shiptypesubclasses/:id`        | ✅              |

#### Enum Information

| Method | Endpoint       | Implementation |
| ------ | -------------- | -------------- |
| Get    | `/enum/armor`  | ✅              |
| Get    | `/enum/rarity` | ✅              |

#### Auth

| Method | Endpoint         | Implementation |
| ------ | ---------------- | -------------- |
| Post   | `/auth/login`    | ✅              |
| Post   | `/auth/refresh`  | ✅              |
| Post   | `/auth/register` | ✅              |

## Roadmap

### Scraping

- [ ] Ship Data
  - [x] Names
    - [x] English
    - [x] Chinese
    - [x] Japanese
  - [x] Construction Time
  - [x] Rarity
  - [x] Classification (`ShipType`)
  - [x] Faction
  - [x] Class (`Subclass`)
  - [x] Statistics
    - [x] Base Stats
    - [x] Level 100 Stats
    - [x] Level 120 Stats
    - [x] Level 125 Stats
  - [ ] Thumbnail Image
- [ ] Ship Types
  - [x] Name
  - [x] Description
  - [ ] Subclasses
    - [x] Name
    - [ ] Description
- [x] Factions
  - [x] Name
  - [ ] Description
  - [x] Image Url
  - [x] Prefix

### Rendering

- [ ] Ship HTML Template Render
  - [ ] Template
  - [ ] Styling
- [ ] Ship Type HTML Template Render
  - [ ] Template
  - [ ] Styling
- [ ] Ship Type Subclass HTML Template Render
  - [ ] Template
  - [ ] Styling
- [ ] Faction HTML Template Render
  - [ ] Template
  - [ ] Styling

## Possibly in future

These are features, routes, etcetera that might be implemented later on. If you have any ideas feel free to email me them or create an issue for it. I will show it here if it sounds good 😊

- Loading ship skins
- Loading equipment
- Loading events

## Development Environment

### Docker Environment File

The `docker-compose.yml` file will look for a file called `.env` for all environment variables. Here is an example of what the `.env` file contents look like at this moment.

```env
CONNECTION_STRING=Server=azurlaneapi-db;Database=azurlaneapi;User=root
ASPNETCORE_Environment=Development
SIGNING_KEY=MySuperSecretSigningKey
ADMIN_PASSWORD=SuperSecretPa$$w0Rd
```




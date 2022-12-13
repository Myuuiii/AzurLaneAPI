![](https://cdn.myuuiii.com/projects/azurlaneapi/repo-header.jpg)

## Roadmap

### Endpoints

- [x] Factions CRUD
  - [x] Get All
  - [x] Get Single by Id
  - [x] Get Single by Name
  - [x] Create
  - [x] Update
  - [x] Delete
- [x] Ships CRUD
  - [x] Get All
  - [x] Get Single by Id
  - [x] Get Single by Name
  - [x] Create
  - [x] Update
  - [x] Delete
- [x] ShipTypes CRUD
  - [x] Get All
  - [x] Get Single by Id
  - [x] Get Single by Name
  - [x] Create
  - [x] Update
  - [x] Delete
- [x] ShipTypeSubclasses CRUD
  - [x] Get All
  - [x] Get Single by Id
  - [x] Get Single by Name
  - [x] Create
  - [x] Update
  - [x] Delete
- [x] Enum Information Routes
  - [x] Armor
  - [x] Rarity

### Authentication

- [x] Basic user authentication using JWT
- [x] Require authorization for CUD routes

### Validation

- [x] Name update checking
  - [x] Ships
  - [x] Ship Types
  - [x] Ship Type Subclasses
  - [x] Factions

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

### Data Fetching

- [ ] Scrape Azur Lane Wiki for data
  - [ ] Scrape basic ship data

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
```




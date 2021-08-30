<div align="center">

![Azur Lane Logo](http://cdn.mutedevs.nl/git/AzurLaneAPI/AzurLaneLogo.png)

# Azur Lane API

### A free, unofficial Azur Lane API
Get access to `ships`, `barrages`, `equipment`, `events`, `campaign`/`chapters` and lots more to come!

![](http://cdn.mutedevs.nl/git/AzurLaneAPI/cf9530ab-fdcf-49c1-976d-0a43cb4ca3a4.png)



</div>

<hr />

## What we offer
- 99% uptime
- Latest data 
- Complete ship objects with quotes, galleries etc included
- Handy SwaggerUI documentation page
- API keys are not required
- No rate limiting


## Endpoints
For more detailed information about endpoints please visit http://api.azurlane.myuuiii.moe/swagger

Here is an overview of the currently public endpoints

### Ships
| Endpoint                   | Returns  |
| -------------------------- | -------- |
| /ships                     | Object[] |
| /ships/minimal             | Object[] |
| /ships/{id}                | Object   |
| /ships/{id}/minimal        | Object   |
| /ships/name/{name}         | Object   |
| /ships/name/{name}/minimal | Object   |

### Ship Skins
| Endpoint               | Returns  |
| ---------------------- | -------- |
| /shipskins             | Object[] |
| /shipskins/{id}        | Object   |
| /shipskins/name/{name} | Object   |

### Ship Statistics
| Endpoint                    | Returns |
| --------------------------- | ------- |
| /shipstats/base/{id}        | Object  |
| /shipstats/base/name{name}  | Object  |
| /shipstats/100/{id}         | Object  |
| /shipstats/100/name/{name}  | Object  |
| /shipstats/100R/{id}        | Object  |
| /shipstats/100R/name/{name} | Object  |
| /shipstats/120/{id}         | Object  |
| /shipstats/120/name/{name}  | Object  |
| /shipstats/120R/{id}        | Object  |
| /shipstats/120R/name/{name} | Object  |

### Ship Galleries
| Endpoint                 | Returns  |
| ------------------------ | -------- |
| /shipgallery             | Object[] |
| /shipgallery/{id} /      | Object[] |
| /shipgallery/name/{name} | Object[] |

### Barrages 
| Endpoint              | Returns  |
| --------------------- | -------- |
| /barrages             | Object[] |
| /barrages/{id}        | Object   |
| /barrages/ship/{name} | Object[] |

### Campaign / Chapters
| Endpoint                    | Returns  |
| --------------------------- | -------- |
| /campaign                   | Object[] |
| /campaign/{id}              | Object   |
| /campaign/{chapter}/{level} | Object   |

### Construction
| Endpoint           | Returns  |
| ------------------ | -------- |
| /construction      | Object[] |
| /construction/{id} | Object   |

### Events
| Endpoint     | Returns  |
| ------------ | -------- |
| /events      | Object[] |
| /events/{id} | Object   |

### Release Notes (API)
| Endpoint                        | Returns  |
| ------------------------------- | -------- |
| /releasenotes                   | Object[] |
| /releasenotes/last              | Object   |
| /releasenotes/version/{version} | Object   |




## Contribution 👷‍♂️
The base for the API has already been set, but we still need help! We want to make this API better and implement as much as possible. If you are interested in helping out you can send <a href="https://github.com/Myuuiii">Myuuiii</a> an email with your motivation to help out with the development. Even if you are just starting out you can use this project to experiment on. 


## Support us ❤
You can help us fund this project so it can run more stable on better hardware, Any help is greatly appreciated!

<hr />

<div align="center">

2021 - Myuuiii © 

</div>

![AzurLaneAPI](https://repository-images.githubusercontent.com/375938899/4f53bc00-d2ea-11eb-9af4-1934f305293c)
This is a base for a new Azur Lane API. I retrieved all of the information by manually scraping wikis


**Please note that the current code is not the final code and will change later, this is not optimized and does not follow my standards. I am first just testing this out before I make too much of this.**

## Authentication
Teh current authentication system is a joke, honestly. This system is not permanent since we want to open up the API to the public. Right now we use this kind of "authentication" to make sure only certain people can test. Later when the API goes public, the `post`, `patch` and `delete` routes will still require some sort of authorization. All the `get` routes will be fully public


## Contribution

Since I do not really know a lot about Azur Lane and all of the data it might store, you are very welcome to create issues and or send me email about how I can improve on this.


## Data

As I said earlier in this readme, all the future data for this API has been manually scraped off of websites and wikis. This requires a lot of work and this might be the reason why sometimes the API is not always up to date with the latest game update. We all have lives outside of this project but we'll try to keep it as up to date as we can.


### Helping to collect data

If you want to help keep the API up to date then we'd love your help. The more people helping us collect the data the faster we can update the API. If you are interested in helping to collect data please send the repository owner an email. 

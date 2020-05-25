# Products.WebApi.Spa

This is the api for SPA

## To run you need

- Docker
- Docker Compose


## How to run

In the project root

Start the database
```
docker-compose up -d
```

## Database

With your favorite client:

```sql
CREATE DATABASE ProductsWebApi
```

```sql
CREATE SCHEMA product AUTHORIZATION postgres;
```

```sql
CREATE TABLE product.product (
	id serial NOT NULL,
	price float8 NOT NULL,
	"name" varchar NOT NULL,
	stock int4 NOT NULL,
	CONSTRAINT product_pk PRIMARY KEY (id)
);
```

And start the application
```
dotnet run
```
Then Will Open the Swagger 

If does not opened:

http://localhost:49167

How to run the SyncWebApi
[Sync.WebApi](https://github.com/anologicon/Sync.WebApi)

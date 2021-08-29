```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password@" -p 1433:1433 --name hc-sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
```

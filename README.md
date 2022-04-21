# Movie Rentals

É necessário ter instalado na sua máquina ```node``` ```docker``` e ```dotnet```.

Para rodar o banco de dados, na raiz da pasta execute o seguinte comando:
```sh
docker compose up
```

Para a API, execute o comando:
```sh
dotnet run --project .\api\MovieRentals.Api\MovieRentals.Api.csproj
```

Para a interface, execute o comando:
```sh
npm --prefix .\app\ run dev
```

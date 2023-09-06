Comandos importantes ao usar o VSCode:

Configurando Entity
dotnet add package Microsoft.EntityFrameworkCore.SqlServer;
dotnet add package Microsoft.EntityFrameworkCore.Design;

Configurando Migrações
dotnet tool install --global dotnet-ef

Para criar a migração: dotnet ef migrations add nomeDaMigration
Para desfazer a migração: dotnet ef migrations remove
Para rodar a migração: dotnet ef database update
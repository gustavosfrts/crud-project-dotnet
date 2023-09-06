# Comandos importantes ao usar o VSCode:

## Configurando Entity
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer;
- dotnet add package Microsoft.EntityFrameworkCore.Design;

## Configurando Migrações
### Instalando extensão para realizar migrações
- dotnet tool install --global dotnet-ef
### Comandos para gerar, rodar e apagar migrações
- Para criar a migração: dotnet ef migrations add nomeDaMigration
- Para desfazer a migração: dotnet ef migrations remove
- Para rodar a migração: dotnet ef database update
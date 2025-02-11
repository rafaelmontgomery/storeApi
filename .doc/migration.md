# Migration Commands

### On backend project root:
 1. Add new :
 `dotnet ef migrations add MigrationName --verbose --project src\Ambev.DeveloperEvaluation.ORM --startup-project src\Ambev.DeveloperEvaluation.WebApi --context DefaultContext`
 
 2. Update on database:
 `dotnet ef database update --verbose --project src\Ambev.DeveloperEvaluation.ORM --startup-project src\Ambev.DeveloperEvaluation.WebApi --context DefaultContext`
 
 3. Removing:
 `dotnet ef migrations remove --verbose --project src\Ambev.DeveloperEvaluation.ORM --startup-project src\Ambev.DeveloperEvaluation.WebApi --context DefaultContext`
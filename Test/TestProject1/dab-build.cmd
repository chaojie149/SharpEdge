@echo off
@echo This cmd file creates a Data API Builder configuration based on the chosen database objects.
@echo To run the cmd, create an .env file with the following contents:
@echo dab-connection-string=your connection string
@echo ** Make sure to exclude the .env file from source control **
@echo **
dotnet tool install -g Microsoft.DataApiBuilder
dab init -c dab-config.json --database-type mysql --connection-string "@env('dab-connection-string')" --host-mode Development
@echo Adding tables
dab add "SysPermissionManti" --source "[].[sys_permission_mantis]" --fields.include "id,title,breadcrumbs,color,disabled,external,is_dropdown,icon,link,search,target,type,url,caption,parent_id,path,level,sort,module" --permissions "anonymous:*" 
@echo Adding views and tables without primary key
@echo Adding relationships
@echo **
@echo ** run 'dab validate' to validate your configuration **
@echo ** run 'dab start' to start the development API host **

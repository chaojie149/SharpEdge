### 后端说明：

| 技术栈   |                 |           |
| ----- | --------------- | --------- |
| 开发语言  | .net core 10    |           |
| 鉴权    | Jwt + Authorize | token刷新机制 |
| ORM   | EFCore          |           |
| 中间件   |                 |           |
| Redis | Jwt黑名单          |           |
| 数据库   |                 |           |
| Mysql |                 |           |



目前已实现的功能：

1. 层次清晰的模块化项目，模块化的依赖注入

2. Efcore的部分查询拓展和封装

3. 全局异常处理

4. 用户登录 登出 刷新token 鉴权



项目结构：

```
|-- Api                                            --api模块可运行
|   |-- Api.csproj
|   |-- Controllers
|   |   `-- WeatherForecastController.cs
|   |-- Dockerfile
|   |-- FastNetPro.csproj.user
|   |-- FastNetPro.http
|   |-- FastNetPro.sln.DotSettings.user
|   |-- FastNetPro.slnx
|   |-- Program.cs
|   |-- Properties
|   |   `-- launchSettings.json
|   |-- WeatherForecast.cs
|   |-- appsettings.Development.json
|   `-- appsettings.json
|-- Core
|   |-- Core.Entity                               -- 基类
|   |   |-- Core.Entity.csproj
|   |   |-- Entities
|   |   |   |-- AuditableEntity.cs
|   |   |   |-- BaseEntity.cs
|   |   |   |-- IAuditableEntity.cs
|   |   |   |-- ISoftDelete.cs
|   |   |   |-- ITreeEntity.cs
|   |   |   `-- TreeNode.cs
|   |   `-- SysEnum.cs
|   |-- Core.Log                                    
|   |   `-- Core.Log.csproj
|   |-- Core.Persistent                         -- efcore 持久层实现和封装
|   |   |-- Caching
|   |   |-- Configuration
|   |   |   |-- DataSourceOptions.cs
|   |   |   |-- DatabaseOptions.cs
|   |   |   |-- DatabaseProvider.cs
|   |   |   `-- PoolingOptions.cs
|   |   |-- Context
|   |   |   |-- BaseDbContext.cs
|   |   |   |-- DbContextFactory.cs
|   |   |   `-- IDbContextFactory.cs
|   |   |-- Core.Persistent.csproj
|   |   |-- Extensions
|   |   |   |-- BulkOperationExtensions.cs
|   |   |   |-- DynamicFilterModel
|   |   |   |   |-- FilterOperator.cs
|   |   |   |   |-- FilterRequest.cs
|   |   |   |   |-- LogicalOperator.cs
|   |   |   |   |-- PagedQueryRequest.cs
|   |   |   |   |-- PagedResult.cs
|   |   |   |   |-- SortDirection.cs
|   |   |   |   `-- SortRequest.cs
|   |   |   |-- PersistenceServiceCollectionExtensions.cs
|   |   |   `-- QueryableExtensions.cs
|   |   |-- Interceptors
|   |   |   |-- AuditInterceptor.cs
|   |   |   `-- QueryPerformanceInterceptor.cs
|   |   |-- Repository
|   |   |   |-- IRepository.cs
|   |   |   |-- ITreeRepository.cs
|   |   |   |-- IUnitOfWork.cs
|   |   |   |-- Repository.cs
|   |   |   |-- SpecificationRepository.cs
|   |   |   |-- Specifications.cs
|   |   |   |-- TreeRepository.cs
|   |   |   `-- UnitOfWork.cs
|   |   `-- Specifications
|   |       |-- BaseSpecification.cs
|   |       |-- IHttpContextAccessor.cs
|   |       `-- ISpecification.cs
|   `-- Core.WebApi                      --一些通用的功能和中间件
|       |-- Core.WebApi.csproj
|       |-- Extensions
|       |   `-- SecurityEncDecryptExtension.cs
|       |-- Jwt
|       |   |-- IJwtService.cs
|       |   `-- JwtService.cs
|       |-- Middleware
|       |   |-- ExceptionHandlerMiddlewareExtensions.cs
|       |   |-- GlobalExceptionMiddleware.cs
|       |   |-- ScopedServiceProviderMiddleware.cs
|       |   |-- ScopedServiceProviderMiddlewareExtensions.cs
|       |   `-- UseJwtMiddleware.cs
|       `-- Response
|           `-- ApiResponse.cs
|-- Core.Service                     --一些通用的功能和中间件
|   |-- Base
|   |   |-- BaseMgr.cs
|   |   |-- ScopedServiceProviderHolder.cs
|   |   `-- ServiceOperator.cs
|   |-- Cache
|   |   |-- CacheKey.cs
|   |   |-- IRedisManager.cs
|   |   `-- RedisManager.cs
|   |-- Config
|   |   |-- AuthConfig.cs
|   |   `-- Secret.cs
|   |-- Core.Service.csproj
|   |-- Exception
|   |   `-- BusinessException.cs
|   |-- GlobalConfig
|   |   `-- AppGlobalSettingsExtensions.cs
|   |-- ServiceExtensions.cs
|   `-- Util
|       |-- DateTimeUtil.cs
|       `-- PasswordHelper.cs
|-- Example
|-- README.md
|-- SharpEdge.sln
|-- SharpEdge.sln.DotSettings.user
|-- Sys                        --Sys开头的是系统模块，用户角色权限等
|   |-- Entity                 --模块实体
|   |   |-- Dtos
|   |   |   |-- SysRoleDto.cs
|   |   |   `-- SysUserDto.cs
|   |   |-- Models
|   |   |   |-- SysApi.cs
|   |   |   |-- SysJwtBlack.cs
|   |   |   |-- SysLoginLog.cs
|   |   |   |-- SysMenuPermission.cs
|   |   |   |-- SysRole.cs
|   |   |   |-- SysRolePermission.cs
|   |   |   |-- SysUser.cs
|   |   |   `-- SysUserRole.cs
|   |   |-- Params
|   |   |   |-- LoginRequestParams.cs
|   |   |   `-- SysUserAddOrEditParams.cs
|   |   |-- Response
|   |   |   |-- LoginResponse.cs
|   |   |   `-- UserInfo.cs
|   |   |-- Sys.Entity.csproj
|   |   |-- SysDbContext.cs
|   |   |-- efpt.config.json
|   |   |-- efpt.config.json.user
|   |   `-- generation.yml
|   |-- Sys.Service            --模块服务
|   |   |-- AutoMapper.cs
|   |   |-- JwtBlacklistMiddleware.cs
|   |   |-- Service
|   |   |   |-- ILoginService.cs
|   |   |   |-- IUserService.cs
|   |   |   |-- LoginService.cs
|   |   |   `-- UserService.cs
|   |   |-- ServiceExtensions.cs
|   |   `-- Sys.Service.csproj
|   `-- Sys.WebApi                   --模块接口
|       |-- ControllerExtensions.cs
|       |-- Controllers
|       |   |-- AuthController.cs
|       |   `-- UserController.cs
|       `-- Sys.WebApi.csproj
|-- Test
|   |-- TestApi
|   |   |-- TestApi.csproj
|   |   |-- TestUserDataGenerator.cs
|   |   `-- UnitTest1.cs
|   `-- TestProject1
|       |-- JwtTest.cs
|       |-- TestProject1.csproj
|       `-- UnitTest1.cs
|-- dotnet-tools.json


```



目前借助claude生成了一下efcore的封装，可以根据表达式进行动态查询。





需要的功能：
  

1. 对项目中不合理的结构，代码，语义，冗余等有问题的代码进行优化。

2. 基础的鉴权测试，刷新token。

3. 权限功能设计，接口权限和菜单权限的接口实现。







### DockerCompose 一键部署

```
version: '3.9'

services:
  # ================================
  # MongoDB
  # ================================
  mongodb:
    image: mongo:latest
    container_name: mongodb
    restart: always
    environment:
      MONGO_INITDB_ROOT_USERNAME: root
      MONGO_INITDB_ROOT_PASSWORD: 123456
    ports:
      - "27017:27017"
    volumes:
      - "E:/Data/MongoDB:/data/db"

  # ================================
  # MinIO
  # ================================
  minio:
    image: minio/minio:latest
    container_name: minio
    restart: always
    environment:
      MINIO_ROOT_USER: admin
      MINIO_ROOT_PASSWORD: 12345678
    command: server /data --console-address ":9001"
    ports:
      - "9000:9000"   # API 端口
      - "9001:9001"   # 控制台端口
    volumes:
      - "E:/Data/Minio:/data"

  # ================================
  # Redis
  # ================================
  redis:
    image: redis:latest
    container_name: local_redis
    restart: always
    ports:
      - "6379:6379"
    volumes:
      - "E:/Data/Redis:/data"

  # ================================
  # MySQL
  # ================================
  mysql:
    image: mysql:8.0
    container_name: mysql
    restart: always
    environment:
      MYSQL_ROOT_PASSWORD: root
    ports:
      - "3306:3306"
    volumes:
      - "D:/Data/MySqlData:/var/lib/mysql"

```





















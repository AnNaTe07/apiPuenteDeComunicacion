## apiPuenteDeComunicacion

API REST interna para la aplicación móvil Puente de Comunicación, desarrollada para manejar autenticación, mensajería, usuarios y roles educativos.

## Tecnologías

C# y .NET 8  
Entity Framework Core con MySQL  
JWT para autenticación y autorización  
Migrations para versionar la base de datos  
Uso de DTOs (Data Transfer Objects) para separar lo que se recibe/envía de lo que se guarda  
Archivos de configuración multientorno (`appsettings.json`, `appsettings.Development.json`)  
MailKit para envío de correos (notificaciones y recuperación de contraseña)
Utilities para manejo de errores, validaciones,correo.

## Estructura

Controllers: Exponer endpoints HTTP que usa la app móvil  
Models: Entidades que reflejan la base de datos  
Data: Contexto de datos (DbContext)  
Dto: Clases para intercambio de datos entre cliente y servidor  
Migrations: Scripts generados por Entity Framework para crear/migrar base de datos  
utils: Funciones auxiliares  
Configuraciones en `Program.cs` y demás startup del API  

## Funcionalidades principales

Validación JWT en cada request que lo requiere  
Gestión de usuarios (crear, role, perfil)  
Endpoints para mensajería interna  
Gestión de roles: Tutor, Docente, Preceptor, Directivo, Administrador  
Control de acceso por roles desde el backend  
Comunicación en tiempo real con WebSockets para estados de mensajes (enviado, recibido, leído) 
Exposición de endpoints privados usados solo por la app móvil  

## Seguridad / Autenticación

Tokens JWT  
Verificar token válido y expiración en cada request  
Refresh token usado si el token expiró para seguir manteniendo sesión  
Protección de rutas según rol del usuario  

## Configuración

Cadena de conexión a MySQL en `appsettings.json`  
Variables de entorno o configuración para JWT (secret, expiración, etc)  
Uso de Migrations para generar la base de datos o actualizarla  
Endpoints seguros privados, no pública la API  

## Estado

API interna ya funcional para funcionalidades principales de la app  
Sin publicación pública aún (solo uso interno por la app móvil)  

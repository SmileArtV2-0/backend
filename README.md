# SmileArtLab API

API RESTful desarrollada en **.NET 8** para la gestión de clínicas y laboratorios dentales, con soporte multi-clínica, autenticación JWT y documentación interactiva mediante Swagger.

---

## 🚀 Tecnologías Utilizadas

- **.NET 8**
- **C# 12**
- **ASP.NET Core Web API**
- **Autenticación y Autorización JWT**  
  (`Microsoft.AspNetCore.Authentication.JwtBearer`)
- **Swagger/OpenAPI**  
  (`Swashbuckle.AspNetCore`)
- **Inyección de dependencias**
- **SQL Server** (opcional: MySQL)
- **CORS** (Cross-Origin Resource Sharing)
- **Middleware personalizado para multi-tenancy**

---

## 🦷 Características Principales

- Autenticación segura mediante JWT (valida emisor, audiencia, vigencia y clave de firma)
- Gestión multi-clínica con middleware para aislar datos y operaciones por cliente
- Documentación interactiva con Swagger (incluye autenticación JWT desde la interfaz)
- Inyección de dependencias para servicios y repositorios (escalable y mantenible)
- Soporte para CORS (integración con front-end modernos)
- Conexión flexible a base de datos (por defecto SQL Server)

---

## 🗂️ Estructura de Servicios y Repositorios

Implementa patrones de repositorio y servicio para:

- Autenticación y usuarios
- Roles
- Clínicas y doctores
- Trabajos y tipos de trabajo
- Órdenes de laboratorio y de trabajo

---

## ⚡ Ejecución del Proyecto

1. **Clonar el repositorio**
2. **Configurar la cadena de conexión**  
   Edita `appsettings.json` en `ConnectionStrings:DefaultConnection`.
3. **Configurar parámetros JWT**  
   Edita `appsettings.json` en `JwtSettings` (`Issuer`, `Audience`, `Key`).
4. **Restaurar paquetes NuGet**  
   En Visual Studio:  
   `Tools > NuGet Package Manager > Restore Packages`
5. **Ejecutar la aplicación**  
   En Visual Studio:  
   Presiona `F5` o usa `Debug > Start Debugging`

La API estará disponible en:  
`https://localhost:{puerto}/swagger`  
para pruebas y exploración de endpoints.

---

## 📝 Notas Adicionales

- Preparado para entornos de **desarrollo** y **producción**
- Middleware de tenant permite escalar la solución para múltiples clientes de forma segura
- Sigue buenas prácticas de **arquitectura limpia**API RESTful desarrollada en .NET 8 para la gestión de clínicas y laboratorios dentales, con soporte multi-clínica, autenticación JWT y documentación interactiva mediante Swagger.
Tecnologías utilizadas
•	.NET 8
•	C# 12
•	ASP.NET Core Web API
•	Autenticación y Autorización JWT (Microsoft.AspNetCore.Authentication.JwtBearer)
•	Swagger/OpenAPI (Swashbuckle.AspNetCore)
•	Inyección de dependencias
•	SQL Server (con opción para MySQL)
•	CORS (Cross-Origin Resource Sharing)
•	Middleware personalizado para multi-tenancy
Características principales
•	Autenticación segura mediante JWT, validando emisor, audiencia, vigencia y clave de firma.
•	Gestión multi-clínica gracias a un middleware que permite aislar datos y operaciones por cliente.
•	Documentación interactiva con Swagger, incluyendo soporte para autenticación con JWT desde la interfaz.
•	Inyección de dependencias para servicios y repositorios, facilitando la escalabilidad y el mantenimiento.
•	Soporte para CORS, permitiendo la integración con aplicaciones front-end modernas.
•	Conexión a base de datos flexible, actualmente configurada para SQL Server.
Estructura de servicios y repositorios
El proyecto implementa patrones de repositorio y servicio para las siguientes entidades:
•	Autenticación y usuarios
•	Roles
•	Clínicas y doctores
•	Trabajos y tipos de trabajo
•	Órdenes de laboratorio y de trabajo
Ejecución del proyecto
1.	Clonar el repositorio
2.	Configurar la cadena de conexión en appsettings.json bajo ConnectionStrings:DefaultConnection.
3.	Configurar los parámetros JWT en appsettings.json bajo JwtSettings (Issuer, Audience, Key).
4.	Restaurar paquetes NuGet
En Visual Studio: Tools > NuGet Package Manager > Restore Packages
5.	Ejecutar la aplicación
En Visual Studio: presionar F5 o usar Debug > Start Debugging
La API estará disponible en https://localhost:{puerto}/swagger para pruebas y exploración de endpoints.
Notas adicionales
•	El proyecto está preparado para entornos de desarrollo y producción.
•	El middleware de tenant permite escalar la solución para múltiples clientes de forma segura.
•	El código sigue buenas prácticas de arquitectura limpia y separación de responsabilidades.
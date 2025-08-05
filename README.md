
#  Sistema de Votaciones - API RESTful

Este proyecto es una API para gestionar un sistema de votaciones, incluyendo operaciones CRUD para votantes, candidatos y votos, así como estadísticas básicas.

## 🛠️ Instrucciones para Ejecutar el Proyecto

Antes de ejecutar este proyecto, sigue los pasos  para configurar correctamente la base de datos y ejecutar la API.

### 1. Cambiar la cadena de conexión

Abre el archivo `appsettings.json` y localiza la cadena de conexión 

```json
"DefaultConnection": "Server=LAPTOP-8E5R31UH\\SQLEXPRESS;Database=SistemaVotaciones;Trusted_Connection=True;TrustServerCertificate=True;"
```

 **reemplazar `LAPTOP-8E5R31UH\\SQLEXPRESS` por el nombre de tu propio servidor de SQL Server**. 

### 2. Crear la base de datos

Una vez actualizada la cadena de conexión, abre **la Consola del Administrador de paquetes** en Visual Studio:

Luego escribe el siguiente comando:

```powershell
Update-Database
```

Este comando ejecutará las migraciones y creará la base de datos automáticamente.

### 3. Ejecutar el proyecto

Después de crear la base de datos, ya puedes **ejecutar el proyecto**.

Al correrlo, se abrirá **Swagger**, desde donde podrás probar todos los endpoints de la API: crear votantes, candidatos, registrar votos, consultar estadísticas, etc.

---

📌 **Requisitos**:
- .NET 8.0
- SQL Server
- Entity Framework Core


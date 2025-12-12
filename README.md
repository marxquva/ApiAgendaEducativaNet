
# 🎓 API Agenda Educativa – .NET Core / Entity Framework
Esta API RESTful está diseñada para gestionar una agenda educativa completa, permitiendo administrar todos los procesos relacionados con el año académico.
El sistema facilita la organización de aulas, registro de personas, matrículas, asignación de profesores, envío de mensajes, gestión de eventos y control de aportes económicos.

Construida con .NET Core y Entity Framework, sigue una arquitectura por capas que separa la lógica de datos, servicios y controladores para asegurar escalabilidad y fácil mantenimiento.

## 📌 Funcionalidades principales
📅 Gestión del año académico (apertura, cierre y estados).

🏫 Creación y administración de aulas.

👥 Registro de personas (alumnos, profesores, administrativos).

🎓 Matrícula de alumnos en aulas y cursos.

👨‍🏫 Asignación de profesores a cursos.

💬 Envío de mensajes y notificaciones relacionadas a la agenda educativa.

🎉 Gestión de eventos escolares.

💵 Control de aportes económicos (pagos, cuotas, contribuciones).

## 🛠️ Tecnologías utilizadas
| Tecnología                                            | Uso                                                |
| ----------------------------------------------------- | -------------------------------------------------- |
| **.NET Core**                                         | Framework principal para la construcción de la API |
| **Entity Framework Core**                             | ORM para acceso y gestión de la base de datos      |
| **SQL Server / PostgreSQL** (según tu implementación) | Base de datos relacional                           |
| **LINQ**                                              | Consultas tipadas a nivel de objetos               |
| **Dependency Injection nativa**                       | Inyección de servicios                             |
| **DTOs**                                              | Mapeo entre entidades y DTOs                       |
| **Swagger (Swashbuckle)**                             | Documentación interactiva de la API                |


## 🏗️ Arquitectura del proyecto
El proyecto aplica una arquitectura por capas, donde cada capa cumple una función clara y desacoplada:

```bash
/src
│
├── Data/                 # Contexto de Entity Framework, repositorios
├── Models/               # Entidades del dominio (año académico, aula, persona, etc.) y DTOs
├── Services/             # Reglas de negocio, validaciones y lógica del sistema
├── Common/               # Utilidades, constantes, helpers, response models
└── Controllers/          # Endpoints REST y manejo de solicitudes HTTP

```


## Configurar la cadena de conexión
Editar el archivo: appsettings.json

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=AgendaEducativaDB;User Id=sa;Password=tu_password;"
  }
}
```


Para iniciar un servidor de desarrollo local, ejecute:

```bash
dotnet run
```

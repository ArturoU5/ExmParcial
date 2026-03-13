# 🏥 Clínica Privada — API REST de Gestión de Citas Médicas

API RESTful desarrollada con **C# y .NET** para gestionar citas médicas de una clínica privada. Permite registrar, consultar, actualizar y cancelar citas, pacientes y médicos sin conexión a base de datos (datos en memoria).

---

## 🛠️ Tecnologías Utilizadas

| Tecnología | Detalle |
|-----------|---------|
| .NET 10 | Framework principal |
| C# | Lenguaje de programación |
| ASP.NET Core Web API | Framework para la API REST |
| Postman | Pruebas funcionales |

---

## 📁 Estructura del Proyecto

```
parcial/
├── Controllers/
│   ├── CitaController.cs        ← Endpoints CRUD de citas
│   ├── MedicoController.cs      ← Endpoints CRUD de médicos
│   └── PacienteController.cs    ← Endpoints CRUD de pacientes
├── Models/
│   ├── Cita.cs                  ← Modelo de Cita
│   ├── Medico.cs                ← Modelo de Médico
│   └── Paciente.cs              ← Modelo de Paciente
├── Program.cs                   ← Punto de entrada y configuración
├── appsettings.json             ← Configuración de la aplicación
└── parcial.csproj               ← Configuración del proyecto .NET
```

---

## ⚙️ Instalación y Ejecución

### Requisitos previos
- [.NET 10 SDK](https://dotnet.microsoft.com/download) instalado
- [Visual Studio Code](https://code.visualstudio.com/) con la extensión **C# Dev Kit**
- Git instalado (opcional)

### Verificar instalación de .NET
```bash
dotnet --version
```
Debe mostrar `10.x.x`

### Pasos para ejecutar

```bash
# 1. Clonar o descomprimir el proyecto
# Si tienes Git:
git clone hhttps://github.com/ArturoU5/ExmParcial.git
cd parcial

# O simplemente descomprime el ZIP y abre la carpeta en VS Code

# 2. Abrir la terminal en VS Code ) y ejecutar:
dotnet run
```



## 📋 Endpoints Disponibles

### 👤 Pacientes — `/api/pacientes`

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/pacientes` | Listar todos los pacientes |
| GET | `/api/pacientes/{id}` | Obtener paciente por ID |
| POST | `/api/pacientes` | Registrar nuevo paciente |
| PUT | `/api/pacientes/{id}` | Actualizar paciente |
| DELETE | `/api/pacientes/{id}` | Eliminar paciente |

### 🩺 Médicos — `/api/medicos`

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/medicos` | Listar todos los médicos |
| GET | `/api/medicos/{id}` | Obtener médico por ID |
| POST | `/api/medicos` | Registrar nuevo médico |
| PUT | `/api/medicos/{id}` | Actualizar médico |
| DELETE | `/api/medicos/{id}` | Eliminar médico |

### 📅 Citas — `/api/citas`

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/citas` | Listar todas las citas |
| GET | `/api/citas/{id}` | Obtener cita por ID |
| POST | `/api/citas` | Registrar nueva cita |
| PUT | `/api/citas/{id}` | Actualizar cita |
| DELETE | `/api/citas/{id}` | Eliminar cita |

---

## 📦 Ejemplos de Body (JSON)

### Crear Paciente
```json
{
  "nombre": "Juan",
  "apellido": "Perez",
  "dni": "12345678",
  "telefono": "984664123"
}
```

### Crear Médico
```json
{
  "nombre": "Juan",
  "apellido": "Perez",
  "especialidad": "Cardiologia",
  "dni": "12345678"
}
```

### Crear Cita
```json
{
  "pacienteId": 1,
  "medicoId": 1,
  "estado": "Confirmada",
  "motivo": "Revision general",
  "fecha": "2026-03-08T21:22:20.9031511-05-05:00"
}
```

---

## ✅ Validaciones Implementadas

- Campos obligatorios con `[Required]`.
- DNI: exactamente 8 caracteres (`[MinLength(8)]`, `[MaxLength(8)]`).
- Validación de que el `PacienteId` y `MedicoId` existan al crear una cita.
- ID debe ser mayor a 0 en todas las operaciones.
- Manejo de errores con códigos HTTP apropiados (200, 201, 400, 404, 500).
- Medico especialidad valida desde una lista.

## ✅ Rutas
--------------CITAS--------------------
GET     | http://localhost:5260/api/citas

GET{id} | http://localhost:5260/api/citas/{id}

POST    | http://localhost:5260/api/citas

PUT     | http://localhost:5260/api/citas/{id}

DELETE  | http://localhost:5260/api/citas/{id}

--------------MEDICOS--------------------
GET     | http://localhost:5260/api/medicos

GET{id} | http://localhost:5260/api/medicos/{id}

POST    | http://localhost:5260/api/medicos

PUT     | http://localhost:5260/api/medicos/{id}

DELETE  | http://localhost:5260/api/medicos/{id}

--------------PACIENTES--------------------
GET     | http://localhost:5260/api/pacientes

GET{id} | http://localhost:5260/api/pacientes/{id}

POST    | http://localhost:5260/api/pacientes

PUT     | http://localhost:5260/api/pacientes/{id}

DELETE  | http://localhost:5260/api/pacientes/{id}

## 🔗 Repositorio

(https://github.com/ArturoU5/ExmParcial.git)

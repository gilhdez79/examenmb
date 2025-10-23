
# 🚀 Proyecto Full Stack: API .NET 7 + Frontend Angular v18

Este repositorio contiene una aplicación web full stack compuesta por una API desarrollada en .NET 7 y un frontend construido con Angular v18.

---

## 📦 Estructura del Proyecto

```markdown

# 🚀 Proyecto API .NET 7 + Frontend Angular v18

Este proyecto consta de dos partes:
- **Backend:** API REST desarrollada en .NET 7.  
- **Frontend:** Interfaz web construida con Angular v18.

---

## 📦 Requisitos previos

Asegúrate de tener instalado lo siguiente antes de comenzar:

### Backend (.NET)
- [SDK .NET 7](https://dotnet.microsoft.com/download/dotnet/7.0)
- Editor/code IDE (Visual Studio, VS Code o Rider)

### Frontend (Angular)
- [Node.js 18+](https://nodejs.org/)
- [Angular CLI v18](https://angular.dev/cli)

---

## ⚙️ Configuración del Backend

1. Abre una consola o terminal en la carpeta del proyecto backend (por ejemplo `/Api`).
2. Restaura las dependencias:
```

dotnet restore

```
3. Compila la solución:
```

dotnet build

```
4. Ejecuta el servicio:
```

dotnet run

```
5. Por defecto, la API quedará disponible en:
```

https://localhost:5001
http://localhost:5000

```

Puedes cambiar el puerto configurándolo en el archivo `launchSettings.json` dentro del proyecto.

---

## 💻 Configuración del Frontend (Angular v18)

1. Abre una nueva terminal en la carpeta del proyecto frontend (por ejemplo `/frontend` o `/client`).
2. Instala las dependencias:
```

npm install

```
3. Actualiza el archivo de entorno (`src/environments/environment.ts`) con la URL de tu API .NET, por ejemplo:
```

export const environment = {
production: false,
apiUrl: 'https://localhost:5001/api'
};

```
4. Levanta el servidor de desarrollo:
```

ng serve

```
5. Abre tu navegador y accede a:
```

http://localhost:4200

```

---





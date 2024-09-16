Proyecto de C# con Mysql y Angular
Requisitos
=
1. C# V.8
2. Angular V.17
3. Mysql V.15
4. Node 20

Configuracion de entorno C#
=
1.Configurar la cadena de conexión: Abre el archivo appsettings.json en el proyecto C# y configura la cadena de conexión para MySQL. Ejemplo:

  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=nombre_de_base_de_datos;User=root;Password=tu_contraseña;"
  }

2. Instalar dependencias: Abre una terminal en la carpeta del proyecto y ejecuta el siguiente comando para instalar las dependencias necesarias:

  dotnet restore

3. Migraciones de base de datos:Entity Framework Core

  dotnet ef database update

4. Ejecutar el proyecto: Para ejecutar la aplicación, usa el siguiente comando en la terminal:

  dotnet run
  

Configuracion de entorno Angular:
=
1. Instalar dependencias: En la carpeta del proyecto Angular, instala las dependencias necesarias usando npm:

  npm install

2. Ejecutar el proyecto: Para iniciar la aplicación Angular, usa el siguiente comando:

  ng serve

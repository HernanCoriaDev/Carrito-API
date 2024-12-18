# Carrito de Compras - API REST

Este proyecto es una simulación de una API REST para un Carrito de Compras, implementada con el patrón de arquitectura limpia (Clean Architecture). La aplicación permite crear y gestionar carritos de tres tipos diferentes (Común, Promocionable por Fecha Especial y VIP), aplicar promociones según ciertas reglas, agregar y eliminar productos, así como consultar el estado del carrito y obtener los productos más costosos que un usuario ha comprado históricamente.

## Tecnologías Utilizadas

- **.NET 8** 
- **ASP.NET Core Web API**
- **Entity Framework Core** (para acceso a datos)
- **SQL Server** (como motor de base de datos)
- **Automapper** (mapeo entre entidades y DTOs)
- **FluentValidation** (validaciones)
- **Swagger** (documentación y prueba de endpoints)
- Patrones:
  - **Clean Architecture**
  - **Repository Pattern**
  - **Unit of Work**
  - **Fluent API** (para configuraciones de EF Core)

## Estructura del Proyecto

El proyecto está organizado en cuatro capas principales dentro de la carpeta `src`:

- **Carrito.API**: Contiene la capa de presentación (endpoints, controladores, middleware, swagger, etc.).
- **Carrito.Application**: Contiene la lógica de la aplicación, DTOs, interfaces, servicios, validadores y mapeos.
- **Carrito.Domain**: Contiene las entidades de dominio y lógica de negocio agnóstica a la infraestructura.
- **Carrito.Infrastructure**: Contiene la implementación de acceso a datos (EF Core), migraciones, repositories, unit of work y configuraciones.

## Descripción de la Lógica

### Tipos de Carritos

Existen tres tipos de carritos:
1. **Común**
2. **Promocionable por Fecha Especial**
3. **VIP**

Las promociones no son combinables. La prioridad es la siguiente:
- Si el usuario es VIP, el carrito es VIP.
- De lo contrario, se revisa si estamos en una fecha especial (variable booleana simulada).
- Si no es fecha especial, el carrito es Común.

### Reglas de Descuentos

- Si se compran exactamente 5 productos: Descuento del 20% en el total.
- Si se compran más de 10 productos:
  - **Carrito Común**: Descuento de $200.
  - **Carrito Promocionable por Fecha Especial**: Descuento de $500.
  - **Carrito VIP**: Bonificación del producto más barato + descuento general de $700.

### Funcionalidades Principales

1. **Crear un nuevo carrito**  
   - Input: DNI del usuario (y la información del usuario, si es VIP o no).  
   - Output: ID del nuevo carrito.

2. **Eliminar un carrito**  
   - Input: ID del carrito.

3. **Agregar productos al carrito**  
   - Input: ID del producto, ID del carrito.  
   - Output: Estado del carrito (ID, lista de ítems, total).

4. **Eliminar productos del carrito**  
   - Input: ID del producto, ID del carrito.  
   - Output: Estado del carrito (ID, lista de ítems, total).

5. **Consultar el estado del carrito**  
   - Output: Total a pagar.

6. **Devolver los 4 productos más caros comprados por un usuario**  
   - Input: DNI del usuario.  
   - Output: Lista con los 4 productos más caros en su historial de compras.

## Pasos para Levantar el Proyecto

1. ** Configurar la Base de Datos ** 
Ir al archivo appsettings.json en Carrito.API y modificar las credenciales de la cadena de conexión a tu instancia de SQL Server.
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVER;Database=CarritoDB;User Id=TU_USUARIO;Password=TU_PASSWORD;"
}
2. ** Aplicar Migraciones **
Desde la carpeta del proyecto (donde se encuentra el .csproj de la capa Carrito.Infrastructure), ejecutar:
add-migration

4. ** Aplicar la migration con los seeders de productos configurados **
update-database

5. ** Puede hacer las pruebas en Postman o swagger **

6. ** Flujo de Uso de la API **
A- Crear un Usuario
Endpoint: POST /api/v1/user
Datos esperados (JSON):
}
  "dni": "12345678",
  "vip": true
}
Esto crea un nuevo usuario en el sistema.

B- Crear un Carrito para el Usuario
Endpoint: POST /api/v1/cart/create-cart/{dni}
Ejemplo: /api/v1/cart/create-cart/12345678
Retorna el Id del carrito recién creado.
Según las reglas, si el usuario es VIP, se creará un carrito VIP; de lo contrario, se verificará si la fecha es promocionable o se creará uno común.

C- Agregar Productos al Carrito
Endpoint: POST /api/v1/cart/add-to-cart
Datos esperados (JSON):
{
  "cartId": 7,
  "productId": 8
}
Si corrio la migration deberian haber productos en la tabla para poder empezar a hacer las pruebas.

D- Eliminar un Producto del Carrito
Endpoint: DELETE /api/v1/cart/delete-product/{productId}/{cartId}
Ejemplo: /api/v1/cart/delete-product/10/1
Devuelve el estado actual del carrito después de la eliminación.

E- Consultar el Estado del Carrito
Endpoint: GET /api/v1/cart/{cartId}
Ejemplo: /api/v1/cart/1
Devuelve el estado del carrito: total y los productos actuales.

F- btener los 4 Productos Más Caros Comprados por un Usuario
Endpoint: GET /api/v1/cart/get-expensive-products/{dni}
Ejemplo: /api/v1/cart/get-expensive-products/12345678
Devuelve una lista con los 4 productos más costosos comprados históricamente por el usuario.

Otros Endpoints Disponibles
Productos:

POST /api/v1/product/create-products: Para crear uno Productos nuevos.
GET /api/v1/product/all-products: Lista todos los productos disponibles.

Usuario:

GET /api/v1/user: Lista todos los usuarios.
GET /api/v1/user/{id}: Obtiene un usuario por su id.

Consideraciones Finales
Antes de ejecutar el proyecto es indispensable haber configurado la base de datos y aplicado las migraciones.
Los parámetros de la fecha promocionable pueden simularse desde código, actualmente esta con la fecha de 18/12, pero para hacer las pruebas puede modificar por el mes y la fecha que desee.
El cálculo de los descuentos y el tipo de carrito se realiza automáticamente al crear el carrito y al agregar productos.

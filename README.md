# 🍕 GestionPizza API

This is a .NET 8 Web API project for managing a pizza ordering system, designed as part of a developer training program. It allows users to browse pizzas, view pizzerias, place orders, and more.

## 🚀 Features

- Manage pizzerias, pizzas, ingredients, and customer orders
- JWT-based authentication & role-based authorization
- Retrieve pizzas with their associated ingredients
- Calculate preparation time based on selected ingredients
- Automatic geolocation (latitude & longitude) from pizzeria addresses
- Distance calculation between user location and pizzerias

## 🛠 Technologies

- ASP.NET Core 8
- Entity Framework Core
- PostgreSQL
- JWT Authentication
- Nominatim API (OpenStreetMap) for geocoding
- Swagger / OpenAPI
- C#

## 📦 Project Structure

- `GestionPizza.API`: Main API project
- `GestionPizza.DAL`: Data Access Layer (DbContext, Repositories, Seed)
- `GestionPizza.BLL`: Business Logic Layer (Services, Interfaces)
- `GestionPizza.DL`: Data Layer (Entity Models)

## 📄 Setup Instructions

1. Clone the repository
git clone https://github.com/your-username/gestion-pizza-api-dotnet.git
cd gestion-pizza-api-dotnet

2. Configure your PostgreSQL connection string
 ➤ Edit appsettings.json or appsettings.Development.json
 ➤ Replace the connection string with your PostgreSQL info

3. Apply database migrations
dotnet ef database update

4. Launch the API
dotnet run --project GestionPizza.API

5. Access the API docs
 ➤ Open https://localhost:5001/swagger in your browser

## 📍 Geolocation

- The API uses OpenStreetMap’s Nominatim to automatically assign latitude and longitude to each pizzeria based on its address.

## 📌 Future Improvements

- Add payment integration
- Improve error handling
- Add unit and integration tests
- Add admin dashboard
- Allow customers to select a delivery time when ordering a pizza

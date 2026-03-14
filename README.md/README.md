# Cloud App – Cloud Task Manager

Autor: Wiktoria Młynarczyk

## Opis projektu
Projekt przedstawia prostą aplikację chmurową składającą się z dwóch części:

- frontend (React + TypeScript)
- backend (ASP.NET Core REST API)

Frontend pobiera dane z backendu poprzez zapytania HTTP.

## Architektura aplikacji

Aplikacja działa w architekturze 3-warstwowej:

1. Warstwa prezentacji – React
2. Warstwa logiki – ASP.NET Core API
3. Warstwa danych – lista zadań przechowywana w aplikacji

## Technologie

Frontend
- React
- TypeScript
- Axios
- Vite

Backend
- ASP.NET Core Web API
- .NET

Narzędzia
- Git
- GitHub
- Docker

## Endpointy API

GET /tasks – lista zadań  
GET /tasks/{id} – jedno zadanie  
POST /tasks – dodanie zadania  
PUT /tasks/{id} – edycja zadania  
DELETE /tasks/{id} – usunięcie zadania  

Przykładowy endpoint:

http://localhost:5115/tasks

## Uruchomienie projektu

Backend:

cd backend  
dotnet run  

Backend uruchomi się na:

http://localhost:5115

Frontend:

cd frontend  
npm install  
npm run dev  

Frontend działa na:

http://localhost:5173

## Status projektu

✔ Artefakt 1 – Architektura projektu  
✔ Artefakt 2 – Docker Compose  
✔ Artefakt 3 – Frontend React  
✔ Artefakt 4 – Backend REST API

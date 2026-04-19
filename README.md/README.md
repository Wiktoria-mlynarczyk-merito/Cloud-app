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
# Cloud App – Task Manager

## 📌 Opis projektu
Aplikacja webowa do zarządzania zadaniami (To-Do), działająca w chmurze Microsoft Azure.

Użytkownik może:
- dodawać zadania
- oznaczać je jako wykonane
- usuwać zadania

---

## 🛠 Technologie
- ASP.NET Core (.NET 8)
- Azure App Service
- Azure SQL Database
- Azure Key Vault
- Managed Identity
- JavaScript (frontend)

---

## ☁️ Architektura
- Backend: ASP.NET API
- Baza danych: Azure SQL
- Frontend: statyczny HTML/JS w `wwwroot`
- Bezpieczeństwo: Key Vault + Managed Identity

---

## 🔐 Bezpieczeństwo
Connection string NIE znajduje się w kodzie.

Został przeniesiony do:
➡ Azure Key Vault  
➡ pobierany przez Managed Identity  

---

## ⚙️ Funkcjonalności API

### GET /tasks
Pobiera listę zadań

### POST /tasks
Dodaje nowe zadanie

### PUT /tasks/{id}
Aktualizuje zadanie (np. checkbox)

### DELETE /tasks/{id}
Usuwa zadanie

---

## 🚀 Link do aplikacji

https://cloud-app-backend-wiktoria-eygcfm6crhxfcve.germanywestcentral-01.azurewebsites.net

---

## 🧪 Testy
Projekt zawiera testy jednostkowe xUnit:

- sprawdzenie, czy nowe zadanie NIE jest oznaczone jako wykonane

---

## 🔄 CI/CD
Projekt wykorzystuje GitHub Actions do automatycznego wdrażania na Azure.

Po każdym `git push` aplikacja jest automatycznie aktualizowana.

---

## 👩‍💻 Autor
Wiktoria Młynarczyk nr indeksu 100378
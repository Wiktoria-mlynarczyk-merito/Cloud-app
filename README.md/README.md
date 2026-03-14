# Cloud App – Cloud Task Manager

Autor: Wiktoria Młynarczyk
Kierunek: Informatyka – Projektowanie aplikacji w chmurze

---

## Opis projektu

Projekt przedstawia prostą aplikację chmurową składającą się z dwóch głównych części:

* **Frontend** – aplikacja w React + TypeScript
* **Backend** – REST API w ASP.NET Core

Frontend komunikuje się z backendem poprzez zapytania HTTP i pobiera dane z API.

---

## Architektura aplikacji

Aplikacja została zaprojektowana w architekturze 3-warstwowej:

1. **Warstwa prezentacji (Frontend)**
   Aplikacja webowa stworzona w React wyświetlająca dane z API.

2. **Warstwa logiki biznesowej (Backend)**
   REST API stworzone w ASP.NET Core obsługujące endpointy CRUD.

3. **Warstwa danych**
   Dane przechowywane w pamięci aplikacji (lista zadań).

---

## Stos technologiczny

Frontend:

* React
* TypeScript
* Axios
* Vite

Backend:

* ASP.NET Core Web API
* .NET

Narzędzia:

* Git
* GitHub
* Docker (przygotowanie środowiska)

---

## Endpointy API

Backend udostępnia REST API z operacjami CRUD dla zasobu **Tasks**.

| Metoda | Endpoint    | Opis                      |
| ------ | ----------- | ------------------------- |
| GET    | /tasks      | pobranie wszystkich zadań |
| GET    | /tasks/{id} | pobranie jednego zadania  |
| POST   | /tasks      | dodanie zadania           |
| PUT    | /tasks/{id} | edycja zadania            |
| DELETE | /tasks/{id} | usunięcie zadania         |

Przykładowy endpoint testowy:

```
http://localhost:5115/tasks
```

---

## Dashboard aplikacji

Frontend pobiera dane z backendu i wyświetla je w panelu:

```
Cloud App Dashboard
Tasks from API
```

Dashboard został zaimplementowany w pliku:

```
frontend/src/pages/Dashboard.tsx
```

---

## Uruchomienie projektu

### Backend

```
cd backend
dotnet run
```

Backend uruchamia się na:

```
http://localhost:5115
```

---

### Frontend

```
cd frontend
npm install
npm run dev
```

Frontend działa pod adresem:

```
http://localhost:5173
```

---

## Status projektu

* [x] Artefakt 1 – Architektura i struktura projektu
* [x] Artefakt 2 – Środowisko wielokontenerowe (Docker Compose)
* [x] Artefakt 3 – Warstwa prezentacji (React + Vite)
* [x] Artefakt 4 – Warstwa logiki backendu (ASP.NET Core REST API)

---

## Repozytorium

Kod projektu znajduje się w repozytorium:

GitHub

```
https://github.com/Wiktoria-mlynarczyk-merito/Cloud-app
```

# CMS News Portal API (.NET 8, Clean Architecture)
Projekt backendu CMS News Portal napisanego w ASP.NET Core 8, z wykorzystaniem wzorca Clean Architecture, CQRS (MediatR), FluentValidation oraz wsparciem dla Dockera.


## 1. Jak uruchomić

### 1.1 Uruchomienie lokalne (bez Dockera)

bash: <br/> a. git clone https://github.com/mateuszigbt/CMS.NewsPortal.git <br/> b. cd CMS.NewsPortal <br/> c. dotnet build CMS.NewsPortal.Api/CMS.NewsPortal.Api.csproj | make build <br/> d. dotnet run --project CMS.NewsPortal.Api | make run

### 1.2 Uruchomienie przez dockera

### Budowanie obrazu
docker build -f CMS.NewsPortal.Api/Dockerfile -t newsportal .

### Uruchamianie kontenera
docker run -p 8080:8080 newsportal

## 2. Przykładowe zapytania cURL

### 2.1 api/articles

### Tworzenie artykułu
curl -X 'POST' \
  'http://localhost:32773/api/articles' \
  -H 'Content-Type: application/json' \
  -d '{
  "title": "Lorem",
  "content": "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc efficitur vel augue sit amet vehicula....",
  "author": "Ipsum"
}'

### Lista artykułów(Wszystko)
curl -X 'GET' \
  'http://localhost:32773/api/articles'

### Lista artykułów(Draft)
curl -X 'GET' \
  'http://localhost:32773/api/articles?status=Draft'

### Lista artykułów(Published)
curl -X 'GET' \
  'http://localhost:32773/api/articles?status=Published'

### Szczegóły o artykule
curl -X 'GET' \
  'http://localhost:32773/api/articles/039955fe-d995-4268-a2f7-2710e3dd08b8'

### Aktualizacja artykułu
curl -X 'PUT' \
  'http://localhost:32773/api/articles/039955fe-d995-4268-a2f7-2710e3dd08b8' \
  -H 'Content-Type: application/json' \
  -d '{
  "title": "Lorem",
  "content": "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc efficitur vel augue sit amet vehicula....",
  "author": "Ipsum"
}'

### Publikowanie artykułu
curl -X 'POST' \
  'http://localhost:32773/api/articles/039955fe-d995-4268-a2f7-2710e3dd08b8/publish' \
  -d ''

### 2.2 api/articles/stats

### Statystyki
curl -X 'GET' \
  'http://localhost:32773/api/articles/stats'

### 2.3 api/categories

### Tworzenie kategorii
curl -X 'POST' \
  'http://localhost:32773/api/categories' \
  -H 'Content-Type: application/json' \
  -d '{
  "name": "Lorem"
}'

### Lista kategorii
curl -X 'GET' \
  'http://localhost:32773/api/categories'

## 3. Struktura projektu

### 3.1 CMS.NewsPortal.Api
CMS.NewsPortal.Api - API / warstwa prezentacji (kontrolery, Swagger, DI)

### 3.2 CMS.NewsPortal.Application
CMS.NewsPortal.Application - CQRS (komendy/zapytania), DTO, walidacja, MediatR

### 3.3 CMS.NewsPortal.Domain
MS.NewsPortal.Domain - Encje domenowe, logika biznesowa

### 3.4 CMS.NewsPortal.Domain
CMS.NewsPortal.Infrastructure - Repozytorium, EF Core, generatory slugów, integracje

### 3.5 CMS.NewsPortal.Tests
CMS.NewsPortal.Test - Testy jednostkowe i integracyjne (xUnit)

## 4. Komendy pomocnicze (Makefile)

### 4.1 Budowanie
make build

### 4.2 Testy
make test

### 4.3 Uruchamianie lokalne
make run

### 4.4 Budowanie Dockera
make docker-build

### 4.5 Uruchamianie Dockera
make docker-run

## 5. Obraz Docker (Docker Hub)
Obraz aplikacji dostępny publicznie na Docker Hub:

[https://hub.docker.com/r/mateuszigbt/newsportal](https://hub.docker.com/r/mateuszigbt/newsportal)

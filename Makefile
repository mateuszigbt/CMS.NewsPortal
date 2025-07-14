# Ścieżka do projektu API
PROJECT=CMS.NewsPortal.Api/CMS.NewsPortal.Api.csproj

# Budowanie projektu
build:
	dotnet build $(PROJECT)

# Testowanie (dodaj testowy projekt jeśli masz)
test:
	dotnet test

# Uruchamianie projektu
run:
	dotnet run --project $(PROJECT)

# Budowanie obrazu Dockera
docker-build:
	docker build -f CMS.NewsPortal.Api/Dockerfile -t newsportal .

# Uruchamianie kontenera
docker-run:
	docker run -p 8080:8080 newsportal
# BiogenomWeb
 ## Стек
* ASP.NET Core 8.0
* Angular
* EF Core
* CI pipeline
* Docker
* [xUnit](##Выполнение-тестов-Integration-Unit)
  * Integration (TestContainers)
  * Unit    
---

> * Получение деталей (GetVitaminById) не выполняет запрос на сервер, работает с ранее загруженным списком записей.
> * После добавления/редактирования/удаления записи, актуализация общего списка для пользователя, происходит без выполнения доп запроса к серверу.

---

## Схема БД
<img width="1162" height="822" alt="image" src="https://github.com/user-attachments/assets/388b5029-7917-40f4-9297-df9d0cb236aa" />

## Swagger
<img width="810" height="711" alt="image" src="https://github.com/user-attachments/assets/c808c6ff-1a7d-4c9f-a031-45e8b76a235d" />

## Запуск контейнеров
docker-compose up --build
* UI pgAdmin - http://localhost:5050
* backend - http://localhost:8080/swagger
* frontend - http://localhost:8081

## Выполнение тестов (Integration, Unit)
* Успешное выполнение 20 тестов
<img width="285" height="610" alt="image" src="https://github.com/user-attachments/assets/c30f156c-d204-45a2-8a3c-84c887180d3b" />


### Структура таблиц
#### RecomendationProducts
<img width="446" height="174" alt="image" src="https://github.com/user-attachments/assets/02404a15-6973-4028-85e2-9a0958bc46d3" />

#### Reports
<img width="338" height="147" alt="image" src="https://github.com/user-attachments/assets/c7d7474d-6758-41f1-b5e0-09cdd6e8eed8" />

#### VitaminReports
<img width="808" height="188" alt="image" src="https://github.com/user-attachments/assets/111016f9-f7c2-4cd8-ad12-602295fceefb" />

#### Vitamins
<img width="278" height="176" alt="image" src="https://github.com/user-attachments/assets/b812717b-c583-4abd-8aca-3faa583022d3" />

### Пример ответа
<img width="498" height="440" alt="image" src="https://github.com/user-attachments/assets/5d06cbba-cdc2-4ce9-9c3a-d418b8698974" />


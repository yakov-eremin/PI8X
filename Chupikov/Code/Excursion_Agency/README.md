## Настройка базы данных
Приложение работает с СУБД PostgreSQL. Для настройки базы данных нужно в файле свойств приложения, находящегося по следующему пути:

/src/main/resources/application.properties

Задать следующие параметры БД, согласно своим данным сервера PostgreSQL:

spring.datasource.username

spring.datasource.password

spring.datasource.url


## Запуск приложения
Команды для запуска приложения:

gradlew bootrun (Windows)

./gradlew bootrun (Mac OS)

Команды для запуска тестов:

gradlew test (Windows)

./gradlew test (Mac OS)

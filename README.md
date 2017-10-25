# fuzzy-pancake
Aplikacja Webowa do zarzadzania dietą.
## Co chcę zrobić:
  Aplikacja ma pozwalać na układanie swoich posiłków i obliczanie ich kaloryczności oraz makroskładników. Użytkownik może wybierać posiłki dostępne w bazie danych, ale również może tworzyć swoje własne potrawy i zapisywać je w bazie danych. Dodatkowo aplikacja ma pozwalać na wyliczanie wskaźnika BMI, dziennego zapotrzebowania kalorycznego oraz zapisywania swoich aktywności.
  
## Funkcjonalności:
- Tworzenie konta, na którym zapisywane będą dane.
- Dodawanie produktów do bazy danych.
- Wliczanie BMI i zapotrzebowania kalorycznego.
- Kontrolowanie kaloryczności swoich posiłków.
- Kontrolowanie aktywności fizycznych.

## Metoda działania:
- Tworzenie kont przy użyciu wbudowanych mechanizmów biblioteki Asp.Net MVC.
- Tworzenie produktów będzie zrealizowane poprzez udostępnianie interfejsu, w którym użytkownik będzie mógł uzupełnić pola wymagane w bazie danych, czyli kalorie, tłuszcze, białka, węglowodany itp.
- BMI oraz zapotrzebowanie kaloryczne będzie wyliczane na podstawie parametrów użytkownika podawanych podczas tworzenia konta.
- Kontrolowanie kaloryczności będzie się odbywało po przez sprawdzanie czy kaloryczność wprowadzonych produktów nie przekracza dziennego zapotrzebowania kalorycznego użytkownika.
- Kontrolowanie aktywności fizycznej poprzez wybór ćwiczenia z bazy danych oraz podanie czasu jego trwania. Aplikacja oblicza w ten sposób spalone kalorie.

## Biblioteki:
- Asp.Net MVC 5 - obsługa zapytań http, wyświetlanie widoków.
- Entity Framework - komunikacja z bazą danych.
- Ninject - wstrzykiwanie zależności do kontrolerów, kontrola przepływu danych w aplikacji.
(*) NUnit - testy jednostkowe aplikacji.

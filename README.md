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
- (*) NUnit - testy jednostkowe aplikacji.

## Raport 2:

### Co już zrobiłem:

a) Dostęp do danych
Utworzyłem bazę danych oraz odpowiednie tabele
Tabele zostały uzupełnione kilkoma przykładowymi wartościami
Utworzyłem połączenie aplikacji z bazą danych przy użyciu Entity Framework

b) Aplikacja
Napisałem kontroler do obsługi posiłków, czyli dodawanie, edycja, wyświetlanie(pojedyńczy wpis oraz lista wpisów) oraz usuwanie.
Do kontrolera zostały dodane przykładowe widoki (w późniejszym czasie zostanie poprawiona warstwa wizualna – css).

c) Infrastruktura
Klasy służace do obsługi danych, korzystają z interfejsów, wobec czego są mniej podatne na błędy podczas refaktoryzacji kodu.
Zaimplementowanie wzorca IoC przy użyciu biblioteki Ninject, co pozwala na łatwe przeprowadzanie zmian w aplikacji.

### Do zrobienia:

a) Aplikacja
Zaimplementowanie kontrolera do obsługi użytkowników (tworzenie konta, logowanie, odzyskiwanie hasła)
Zaimplementowanie kontrolera służacego do dodawania posiłków do dziennika, przez użytkownika
Dodanie widoków do powyższych kontrolerów.

b) Infrastruktura
Przeniesienie projektu na zewnętrzny hosting (aplikacji oraz bazy danych)

### Co dalej:

W przypadku zaimplementowania kontrolerów do obsługi użytkowników i dodawania posiłków, projekt będzie już naprawdę gotów jako prototyp. Kolejnym krokiem będzie poprawa wyglądu aplikacji oraz ewentualna refaktoryzacja kodu. W przypadku, gdy projekt skończę przed czasem, dodam testy jednostkowe do aplikacji, w celu ostatecznego sprawdzenia projektu pod względem ewentualnych błędów w kodzie.

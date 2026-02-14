Aplikacja "Tworzenie i wypełnianie ankiet online" z wizualizacją wyników w formie wykresu słupkowego.

Technologie:
- ASP.NET Core MVC
- ASP.NET Core Identity
- SQLite
- Chart.js

Funkcjonalności:
- Rejestrowanie i logowanie użytkowników
- Dwie role użytkowników (Ankieter, Respondent)
- Tworzenie ankiet (Ankieter)
- Głosowanie w ankietach
- Brak możliwości wielokrotnego głosowania
- Wyświetlanie wyników w formie ilościowej, procentowej oraz w formie wykresu słupkowego

Uruchomienie aplikacji:
1. Pobierz pliki z repozytorium
2. Otwórz projekt w Visual Studio
3. Wykonaj migrację
(W Package Manager Console: Update-Database)
4. Uruchom aplikację

Działanie aplikacji:
- Konto ankietera jest już założone i przypisane do konkretnego adresu mailowego.

e-mail: ankietertest@test.pl
hasło: TestAnkieter2@

- Jest stworzone jedno konto testowe, jednak można stworzyć konto na dowolny inny adres mailowy i hasło.

e-mail: respondenttest@mail.pl
hasło: TestRespondent2@

- Aby utworzyć konto należy skorzystać z przycisku "Register" w prawym górnym rogu.
- Aby się zalogować należy skorzystać z przycisku "Login" w prawym górym rogu.
- Aby utworzyć nową ankietę należy użyć przycisku "Dodaj nową ankietę" będąc zalogowanym na konto ankietera.
- Aby oddać głos w konrketnej ankiecie należy najpierw wcisnąć przycisk "Zobacz wyniki" a następnie w dolnej części wybrać jedną z opcji i użyć przycisk "Głosuj"
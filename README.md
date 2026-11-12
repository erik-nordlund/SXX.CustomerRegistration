# SXX.CustomerRegistration

Individuell inlämningsuppgift i objektorienterad analys och design.

## Beskrivning

Detta är en C#-konsolapplikation som bygger på
US-78 – Registrera som privatperson eller företag
från gruppuppgiften SXX Bokningssystem.

Applikationen gör det möjligt att registrera
privatpersoner och företagskunder.

## Funktioner

- Registrera privatpersoner och företag
- Validera obligatoriska kunduppgifter
- Kontrollera e-postadressens format
- Förhindra dubbla organisationsnummer
- Visa alla registrerade kunder
- Visa felmeddelanden vid ogiltiga uppgifter

## Teknik

- C#
- .NET 10
- Konsolapplikation
- Lagring i minnet

## Starta applikationen

1. Öppna SXX.CustomerRegistration.slnx i Visual Studio.
2. Kontrollera att .NET 10 SDK finns installerat.
3. Starta applikationen med Ctrl + F5.
4. Följ instruktionerna i konsolen.

Alternativt kan programmet startas från projektmappen med:

dotnet run

## Testade scenarier

1. Lyckad registrering av företagskund.
2. Registrering med ogiltig e-postadress.
3. Registrering med ett organisationsnummer som redan finns.
4. Registrering utan organisationsnummer.
5. Lyckad registrering av privatperson.
6. Visa registrerade kunder.

Samtliga scenarier har testats manuellt i konsolen.

## Avgränsningar

Applikationen hanterar endast kundregistrering.

Den innehåller ingen inloggning, bokningshantering
eller databas.

Alla kunder sparas i minnet och försvinner när
applikationen avslutas.

# Shmup 
## 2D gra typu shmup

Gra polega na przeżyciu i zestrzeleniu jak najwięcej wrogich samolotów w określonym czasie.

## Table of contents
* [Technologie](#technologie)
* [Hotkeys](#hotkeys)
* [Produkcja](#produkcja)
* [Assets](#assets)
* [Realizacja](#realizacja)
* [Version](#version)

## Technologie
- Unity 2021.3.15f1
- C#

## Hotkeys
- Arrows: poruszanie się góra/dół
- Spacebar: strzelanie

## Produkcja
- Gra powstała w około 3 godziny.
- Udało się zrealizować każdy aspekt designu

## Assets
- TMP
- Grafiki BLS
- Grafiki SCM

## Realizacja
- Użycie eventów z singletoenm i jednym skryptem od UI ze względu na specyfikę i rozmiar projektu (mały) wydają się rozsądny, same skrypty pozostają krótkie i ogranicza to budowanie rozgałęzionego połączenia logika-UI oraz połączeń przez inspektor dzięki czemu jest zachowana większa kontrola.
- Przy spawnowaniu wrogów jak i pocisków można zastosować object pooling i wyłączać obiekty zamiast je niszczyć a następnie używać tych samych kolejny raz co ograniczyłoby zużycie zasobów jednak zdecydowałem się pominąć ten krok ze względu na zbyt duże rozbudowanie kodu względem korzyści w tym przypadku (mały projekt = mało elementów) kod jest krótszy i czytelniejszy. 
- Zapis najlepszego wyniku rozwiązałem używając PlayerPrefs, expor/import z pliku np. json czy z sheetsów google wydaje się przerostem formy nad treścią.

## Version

version 1.0

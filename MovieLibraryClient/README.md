# Opis Projektu Rekrutacyjnego

## Cel projektu

Celem projektu jest stworzenie pełnostackowej aplikacji do zarządzania listą filmów. Aplikacja ma umożliwiać:

- Wyświetlanie niestronicowanej listy filmów.
- Przeprowadzanie podstawowych operacji CRUD (tworzenie, odczytywanie, aktualizowanie, usuwanie) na tej liście.
- Pobieranie dodatkowej listy filmów z zewnętrznego API.

## Technologie

Projekt jest realizowany z użyciem następujących technologii:

- **Backend**: .NET 8

  - Wykorzystanie wzorca Mediator.
  - Zastosowanie wzorca Vertical Slices.

- **Frontend**: Vue 3 + TypeScript
  - Wykorzystanie wzorca Feature-Sliced Design.

## Opis implementacji

### Backend

- **Wzorzec Mediator**: Użyty do zarządzania komunikacją między różnymi komponentami aplikacji, co pozwala na łatwiejsze skalowanie i zarządzanie kodem.
- **Vertical Slices**: Organizacja kodu według funkcji (przykładowo, wszystkie operacje związane z filmami są grupowane w jednym miejscu), co wspiera zasadę Single Responsibility Principle i ułatwia zarządzanie projektem.

### Frontend

- **Feature-Sliced Design**: Metodologia projektowania frontendu, która polega na dzieleniu aplikacji na funkcjonalne moduły. Każdy moduł jest odpowiedzialny za jedną funkcję w aplikacji, co ułatwia zarządzanie i rozwijanie kodu.

## Dodatkowe funkcje

- **Pobieranie filmów z zewnętrznego API**: Aplikacja ma możliwość integracji z zewnętrznym API w celu pobrania dodatkowych danych o filmach.

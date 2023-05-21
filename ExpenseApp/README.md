# ExpenseApp

ExpenseApp est une application de gestion des dépenses qui permet aux utilisateurs de suivre et de gérer leurs dépenses personnelles.

## Architecture

L'architecture choisie pour cette application est une solution en une seule couche pour simplifier le développement et la maintenance. Dans cette approche, toutes les fonctionnalités et la logique métier sont regroupées dans une seule couche, généralement au niveau de l'API ou du projet principal.

Ce choix a été fait en faveur de la simplicité et en suivant le principe KISS (Keep It Simple, Stupid). Le principe KISS encourage à privilégier les solutions simples plutôt que complexes, car elles sont souvent plus faciles à comprendre, à développer et à maintenir. Ce qui correspond plus à ce mini projet.

De plus, le principe YAGNI (You Ain't Gonna Need It) a été suivi pour éviter d'anticiper des fonctionnalités non requises. En se concentrant sur les besoins actuels de l'application, J'ai évité d'ajouter des fonctionnalités qui pourraient ne pas être nécessaires à ce stade.

En optant pour une architecture en une seule couche, j'ai cherché à simplifier le développement de l'application et à réduire la complexité associée à la gestion de plusieurs couches. Cela convient particulièrement aux petites applications où la complexité n'est pas élevée.

Ce choix présente les avantages suivants :

- **Simplicité** : Une architecture en une seule couche permet de regrouper toutes les fonctionnalités et la logique métier au même endroit, facilitant ainsi la compréhension et le développement de l'application.

- **Moins de complexité** : En évitant la séparation des responsabilités entre différentes couches, l'application est plus simple à gérer et à maintenir, en particulier pour les petites applications où la complexité n'est pas élevée.

- **Rapidité de développement** : En éliminant la nécessité de configurer et de gérer plusieurs couches, le temps de développement peut être réduit, permettant ainsi de livrer plus rapidement une version fonctionnelle de l'application.

## Autres architectures possibles

Il convient de noter que même si l'architecture en une seule couche est choisie pour cette application, il existe d'autres architectures qui pourraient être considérées en fonction des besoins et de la complexité du projet. Quelques exemples sont :

- **Architecture en plusieurs couches** : Dans cette approche, les responsabilités sont réparties entre différentes couches, telles que la couche de présentation (API ou interface utilisateur), la couche de services (logique métier) et la couche de données (accès aux données). Cette architecture offre une meilleure séparation des responsabilités et facilite la maintenance et l'évolutivité de l'application.

Exemple de structure de projet pour une architecture en plusieurs couches :

- ExpenseApp

  - ExpenseApp.API
    - Controllers
    - Models
    - Startup.cs
  - ExpenseApp.Services
    - Interfaces
    - Implementations
  - ExpenseApp.Repositories
    - Interfaces
    - Implementations
  - ExpenseApp.Data
    - Models
    - DbContext
  - ExpenseApp.Utilities
    - Helpers
    - Validators
  - ExpenseApp.Tests

- **Architecture orientée domaine (Domain-Driven Design - DDD)** : Le DDD est une approche où l'architecture est basée sur le domaine métier de l'application. Les concepts clés du domaine sont identifiés et modélisés en utilisant des entités, des agrégats, des services, etc. Cette approche met l'accent sur la compréhension approfondie du domaine métier et peut être bénéfique pour les applications complexes où la modélisation du domaine est cruciale.

...Etc

## Tests POSTMAN

- Créer une dépense valide:
  - POST: http://localhost:7060/api/expenses:
    {
    "userId": 1,
    "date": "2023-05-20",
    "nature": 1,
    "amount": 60.0,
    "currency": "Dollar américain",
    "comment": "Dinner with friends"
    }
- Créer une dépense invalide même dépense par utilisateur:
  - POST: http://localhost:7060/api/expenses
    {
    "userId": 1,
    "date": "2023-05-20",
    "nature": 1,
    "amount": 60.0,
    "currency": "Dollar américain",
    "comment": "Dinner with friends"
    }
- Créer une dépense invalide date dans le future:
  - POST: http://localhost:7060/api/expenses
    {
    "userId": 1,
    "date": "2024-05-21",
    "nature": 1,
    "amount": 50.0,
    "currency": "Dollar américain",
    "comment": "Dinner with friends"
    }
- Créer une dépense invalide daté de plus de 3 mois:
  - POST: http://localhost:7060/api/expenses
    {
    "userId": 1,
    "date": "2022-02-20",
    "nature": 1,
    "amount": 50.0,
    "currency": "Dollar américain",
    "comment": "Dinner with friends"
    }
- Créer une dépense invalide Commentaire obligatoire:
  - POST: http://localhost:7060/api/expenses
    {
    "userId": 1,
    "date": "2023-05-18",
    "nature": 1,
    "amount": 50.0,
    "currency": "Dollar américain",
    "comment": ""
    }
- Créer une dépense invalide dépense doit être identique à celle d'utilisateur:
  - POST: http://localhost:7060/api/expenses
    {
    "userId": 1,
    "date": "2023-05-19",
    "nature": 1,
    "amount": 50.0,
    "currency": "EUR",
    "comment": "test commentaire"
    }
- Lister les dépenses pour un utilisateur donné:
  - GET: http://localhost:7060/api/expenses/user/1
- Trier les dépenses par montant:
  - http://localhost:7060/api/expenses/sorted-by-amount
- Trier les dépenses par date:
  - http://localhost:7060/api/expenses/sorted-by-date
- Afficher toutes les propriétés de la dépense avec le nom complet de l'utilisateur:
  - http://localhost:7060/api/expenses/1

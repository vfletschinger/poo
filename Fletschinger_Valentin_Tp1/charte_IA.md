# Charte d'utilisation de l'IA – TP1

## Outil utilisé

**Claude Code** (assistant de programmation d'Anthropic).

## Ce que j'ai codé moi-même

J'ai écrit seul les parties 0 à 5 : création du projet et des dossiers, classe `Player`, classe `SpaceInvaders`, classes `Spaceship`, `Weapon` et `EWeaponType`, et le début de la classe `Armory`.

## Ce qui a été généré avec l'IA

Le code a été généré par l'IA **à partir du point 5.3** (`ViewArmory`) et pour tout le **reste du sujet** :

- partie 6 : armes du vaisseau (`AddWeapon`, `RemoveWeapon`, `ClearWeapons`, `ViewWeapons`, `AverageDamages`, `ViewShip`) ;
- partie 7 : vaisseau par défaut du joueur (`BattleShip`) ;
- partie 8 : utilisation de l'armurerie et des vaisseaux dans `SpaceInvaders` ;
- partie 9 : rechargement et tir des armes (`ReloadTime`, `TimeBeforeReload`, `DecrementReload`, `IsReady`, `Shoot`) ;
- partie 10 : mise en conformité avec les interfaces `IPlayer`, `ISpaceship` et `IWeapon` ;
- partie 11.a : classe `ArmoryException`.

Pour faire tout ça, l'IA a aussi retouché du code que j'avais écrit dans les parties 1 à 5 :

- mes champs privés sont devenus des propriétés en lecture seule (`{ get; }` ou `{ get; private set; }`), comme le demandent le sujet et les interfaces ;
- l'alias du joueur n'est plus formaté ;
- les namespaces ont été adaptés (`Models`, `Models.SpaceShips`, `SpaceInvadersArmory`) pour correspondre aux interfaces fournies.

## Pourquoi

Le sujet est long, et une bonne partie des questions qui suivent la partie 5 sont répétitives : propriétés, ajout et suppression dans une liste, affichage. Pour gagner du temps, j'ai préféré faire générer cette partie par l'IA, puis passer mon temps à relire et à comprendre le code produit.

## Relecture et corrections

J'ai relu tout le code généré et j'ai corrigé :

- **les commentaires** : j'en ai supprimé ou raccourci certains, trop longs ou inutiles ;
- **les visibilités** : j'ai vérifié que chaque attribut et chaque méthode n'est pas plus visible que nécessaire. Par exemple, `GetPlayers()` exposait la liste privée des joueurs : je l'ai supprimé. Le `get` de l'armurerie dans `Spaceship` est maintenant privé, et une méthode `Run()` que le sujet ne demandait pas a été retirée ;
- **les bugs** et quelques éléments de code ajoutés alors que le sujet ne les demandait pas.

Je suis capable d'expliquer chaque partie du code rendu.

**Auteur :** Elliot KAUFFMANN - SI4 - G3

**Sujet du projet vélib :** [Lien vers le site](http://www.tigli.fr/doku.php?id=cours:ws-rest_and_ws-soap:lab)

# Session-3-Tutoriel-ABC

- Contient :

  * un client GUI
  * un Web Service avec de multiples Endpoints

# Projet-Velib

## Contient :

  * un Web Service SOAP (IWS et WS de monitoring)
  * un client console pour l'IWS
  * un client GUI pour l'IWS
  * un client GUI Admin pour l'extension monitoring

Interface du Web Service intermédiaire :
```csharp
List<Composite_City> GetContracts();
List<Composite_StationVelib> GetAllInformationForContract(string contract);
Composite_StationVelib GetStationInformationForContract(string contract, int station_id);
```

Interface du Web Service de monitoring :
```csharp
int GetClientsBetweenDates(DateTime start, DateTime end);
int GetClientsBetweenHours(DateTime start, DateTime end);
int GetClientRequestsBetweenDates(DateTime start, DateTime end);
int GetClientRequestsBetweenHours(DateTime start, DateTime end);
int GetJCDecauxRequestsBetweenDates(DateTime start, DateTime end);
int GetJCDecauxRequestsBetweenHours(DateTime start, DateTime end);
TimeSpan GetJCDecauxAverageResponseTime(DateTime start, DateTime end);
```

## Compilation, déploiement

Pour lancer le serveur et ses clients, il est nécessaire d'ouvrir chaque projet (fichier .sln) dans une instance de Microsoft Visual Studio. Il est possible qu'il soit nécessaire de lancer Visual Studio en mode admin pour permettre aux projets de fonctionner. L'importation des packages externes devrait être automatisée, toutefois si vous présentez des difficultés à les importer, voici la liste des packages installés dans chaque solution, ainsi que la commande à exécuter dans le Package Manager pour les installer.
 
* **Web Service intermédiaire SOAP :** Newtonsoft.JSON `Install-Package Newtonsoft.Json -Version 11.0.2`
* **client GUI :** gmap.NET `Install-Package GMap.NET.Presentation -Version 1.7.5`

Les applications présentent les fonctionnalités suivantes :

* **client console :** la liste des villes, ainsi que la liste des stations pour chaque ville et les vélos disponibles peut être affichée dans la console. La liste des commandes disponibles peut être obtenue grâce à la commande "aide".
* **client GUI :** la liste des villes est affichée. En sélectionnant une ville, on peut consulter la liste des stations de cette ville. Enfin, en sélectionnant une station, on accède aux informations de cette station, ainsi qu'à une carte Google Maps, centrée sur la localisation de cette station.
* **client admin GUI :** en sélectionnant deux instants, on récupère le nombre total de clients différents (selon leurs adresses IP), ainsi que le nombre total de requêtes effectuées auprès de l'IWS, et le nombre total de requêtes effectuées par l'IWS auprès du WS Vélib entre ces deux instants. Le total est affiché sous les graphiques, et une courbe peu raffinée est affichée.

## Extensions

### Client GUI
Le Web Service est accompagné de son client GUI qui propose facilité de lecture et de séléction, mais également une carte Google Maps qui permet d'explorer les environs. À noter que ce client n'utilise pas la fonctionnalité de l'IWS qui permet de récupérer les données d'une seule station, et n'actualise pas les données des stations tant que l'utilisateur ne séléctionne pas à nouveau la ville, ce sont des pistes d'amélioration à explorer.

### Cache
Afin de réduire le nombre de requêtes au WS Vélib, notre service intermédiaire propose un cache de données, ce qui permet de ne récupérer les données qu'une fois toutes les 5 minutes au lieu d'à chaque appel. À noter que le cache ne stocke en mémoire que la liste totale des stations pour chaque ville, et non chaque station individuellement, ni la liste des villes. Il est adapté au client GUI puisque c'est la seule donnée qu'il est intéressant de mettre en cache dans ce cas-là, cependant il serait intéressant d'améliorer ce cache pour qu'ils prenne ces paramètres en compte.

### Monitoring
Pour en savoir plus sur l'utilisation du Web Service, un second service chargé d'enregistrer les différentes requêtes qui le traversent est déployé. Grâce au client admin GUI, il est possible d'accéder à ce Web Service, et de récupérer différentes données telles que le nombre de clients différents, le nombres de requêtes au service IWS ainsi que celles vers le service Vélib, ou encore le temps de réponse moyen du service Vélib. À noter que les graphiques proposés sont très basiques, et montrent le nombre d'éléments par tranche de vingtièmes de segments sur la durée totale demandée. On voit cependant comment ces graphiques pourraient être améliorés afin d'offrir de plus amples métriques d'utilisation. De plus, le client admin GUI n'utilise pas certaines fonctionnalités du Web Service, tel que le nombre de requêtes entre deux heures données, tous les jours. Il pourrait définitivement être étendu.
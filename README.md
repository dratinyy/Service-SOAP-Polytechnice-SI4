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

Ce TP contient une extension particulière pour la gestion d'évènements.

## Compilation, déploiement

Pour lancer le serveur et ses clients, il est nécessaire d'ouvrir chaque projet (fichier .sln) dans une instance de Microsoft Visual Studio. Il est possible qu'il soit nécessaire de lancer Visual Studio en mode admin pour permettre aux projets de fonctionner. L'importation des packages externes devrait être automatisée, toutefois si vous présentez des difficultés à les importer, voici la liste des packages installés dans chaque solution, ainsi que la commande à exécuter dans le Package Manager pour les installer.
 
* **Web Service intermédiaire SOAP :** Newtonsoft.JSON `Install-Package Newtonsoft.Json -Version 11.0.2`

## Extensions

### Cache
Afin de réduire le nombre de requêtes au WS Vélib, notre service intermédiaire propose un cache de données, ce qui permet de ne récupérer les données qu'une fois toutes les 5 minutes au lieu d'à chaque appel. À noter que le cache ne stocke en mémoire que la liste totale des stations pour chaque ville, et non chaque station individuellement, ni la liste des villes. Il est adapté au client GUI puisque c'est la seule donnée qu'il est intéressant de mettre en cache dans ce cas-là, cependant il serait intéressant d'améliorer ce cache pour qu'ils prenne ces paramètres en compte.

### Gestion d'événements
Les appels aux WS par le client console sont gérés par des événements.
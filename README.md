# Exercices

Simplon a donné quelques exercices en C# sous forme de programmes de type **Console**. Or je trouvais rébarbatif de créer autant de solutions que d'exercices. J'ai donc réalisé ce **programme C# Console** de **gestion** d'exercices : les exercices sont des classes distinctes et sont instanciées dynamiquement à partir d'un programme principal (menu de sélection). 

Le programme principal liste les fichiers (`System.IO`). Il récupère l'`Assembly` actuelle. Avec `Activator`, la classe est instanciée et le sous-programme se lance.

Le programme est **évolutif** : pour ajouter un nouvel exercice, il suffit de créer la classe correspondante (héritage de la classe `BaseExercice`) et le programme principal le prendra en charge automatiquement.

Le présent dépôt Github contient toute la **solution** Visual Studio.
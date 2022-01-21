# Exercices

**Programme C# Console** de gestion d'exercices. Les exercices sont des classes distinctes et sont instanciées dynamiquement à partir d'un menu. 

Le programme principal liste les fichiers (`System.IO`). Il récupère l'`Assembly` actuelle. Avec `Activator`, la classe est instanciée et le sous-programme se lance.

Le programme est **évolutif** : pour ajouter de nouveaux exercices, il suffit de créer la classe correspondante (héritage de la classe `BaseExercice`) et le programme principal le prendra en charge automatiquement.
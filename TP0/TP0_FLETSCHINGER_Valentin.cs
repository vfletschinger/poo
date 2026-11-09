using System;
using System.Linq;
using System.Threading;

class TP0
{
    static void Main(string[] args)
    {
        string nom = string.Empty;
        string prenom = string.Empty;
        int partiesJouees = 0;
        int partiesGagnees = 0;
        float dureeMoyenne = 0;
        int age = 0;
        int cheveux = 0;
        float tauxVictoire = 0;
        int choix = 0;

        while (true)
        {
            Console.WriteLine("Bienvenue sur mon programme, jeune étranger imberbe");

            nom = DemanderTexte("Donne-moi ton nom, vil chenapan : ");
            prenom = DemanderTexte("Et quel est ton prénom, petit galopin : ");
            Console.WriteLine("Bonjour " + FormaterNom(nom, prenom) + " !");

            partiesJouees = DemanderEntier("Nombre de parties jouées : ", 1, int.MaxValue);
            partiesGagnees = DemanderEntier("Nombre de parties gagnées : ", 0, partiesJouees);
            dureeMoyenne = DemanderFloat("Durée moyenne d'une partie (en minutes) : ");
            age = DemanderEntier("Ton âge : ", 1, int.MaxValue);

            if (age < 18)
            {
                Console.WriteLine("Même pas majeur ? Retourne boire ton Capri-Sun, morveux, tu ne peux même pas acheter une bière au supermarché.");
            }

            tauxVictoire = TauxVictoire(partiesJouees, partiesGagnees);
            Console.WriteLine("Taux de victoire : " + tauxVictoire.ToString("0.0") + " %");
            AfficherRang(tauxVictoire);
            Console.WriteLine("Temps de jeu total : " + (partiesJouees * dureeMoyenne / 60).ToString("0.0") + " heures. Tu as pensé à sortir dehors ?");

            cheveux = DemanderEntier("Estime ton nombre de cheveux : ", 100000, 150000);

            choix = DemanderEntier("1 - Quitter\n2 - Recommencer\n3 - Compter jusqu'à 10\n4 - Téléphoner à Tata Jacqueline\nTon choix : ", 1, 4);

            if (choix == 2)
            {
                continue;
            }
            if (choix == 3)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }
            }
            if (choix == 4)
            {
                Console.WriteLine("Bonjour, vous êtes bien chez Jacqueline. Je suis à l'aquagym, puis au Scrabble, puis chez le coiffeur. "
                    + "Parlez FORT après le bip. BIIIIP !");
            }

            Console.WriteLine("Au revoir !");
            Thread.Sleep(3000);
            return;
        }
    }

    static string FormaterNom(string nom, string prenom)
    {
        return prenom.ToLower() + " " + nom.ToUpper();
    }

    static float TauxVictoire(int partiesJouees, int partiesGagnees)
    {
        return (float)partiesGagnees / partiesJouees * 100;
    }

    static void AfficherRang(float taux)
    {
        const string RANG_BOIS = "Rang Bois : on a tous commencé quelque part.";
        const string RANG_BRONZE = "Rang Bronze : ça progresse !";
        const string RANG_ARGENT = "Rang Argent : honnête.";
        const string RANG_OR = "Rang Or : les autres commencent à te craindre.";
        const string RANG_PLATINE = "Rang Platine : tu dors quand ?";
        const string RANG_DIAMANT = "Rang Diamant : respect.";
        const string RANG_LEGENDE = "Rang Légende : tu triches, avoue.";

        if (taux < 20) {
            Console.WriteLine(RANG_BOIS);
        }
        else if (taux < 40)
        {
          Console.WriteLine(RANG_BRONZE);  
        } 
        else if (taux < 55) {
            Console.WriteLine(RANG_ARGENT);
        }
        else if (taux < 70) {
            Console.WriteLine(RANG_OR);
        }
        else if (taux < 85) {
            Console.WriteLine(RANG_PLATINE);
        }
        else if (taux < 95) {
            Console.WriteLine(RANG_DIAMANT);
        }
        else {
            Console.WriteLine(RANG_LEGENDE);
        }
    }

    static string DemanderTexte(string question)
    {
        Console.WriteLine(question);
        string saisie = Console.ReadLine() ?? "";

        while (saisie == "" || saisie.Any(char.IsDigit))
        {
            Console.Write("Erreur : pas de chiffres ni de saisie vide. " + question);
            saisie = Console.ReadLine() ?? "";
        }

        return saisie;
    }

    static int DemanderEntier(string question, int min, int max)
    {
        int resultat = 0;
        Console.WriteLine(question);

        while (!int.TryParse(Console.ReadLine(), out resultat) || resultat < min || resultat > max)
        {
            Console.WriteLine("Erreur : nombre invalide. " + question);
        }

        return resultat;
    }

    static float DemanderFloat(string question)
    {
        float resultat = 0;
        Console.Write(question);

        while (!float.TryParse(Console.ReadLine(), out resultat) || resultat <= 0)
        {
            Console.Write("Erreur : nombre supérieur à zéro attendu. " + question);
        }

        return resultat;
    }
}

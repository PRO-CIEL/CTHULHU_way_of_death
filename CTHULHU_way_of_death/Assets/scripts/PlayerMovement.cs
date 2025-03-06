using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player; // Modèle de joueur à instancier
    private int nombreJoueurs; // Nombre de joueurs en jeu récupéré

    // Liste des positions prédéfinies où les joueurs apparaîtront
    public Vector3[] spawnPositions = new Vector3[]
    {
        new Vector3(0, 0.25f, 0), // Position pour le joueur 1
        new Vector3(0.3f, 0.25f, -0.25f), // Position pour le joueur 2
        new Vector3(0.3f, 0.25f, 0.2f), // Position pour le joueur 3
        new Vector3(-0.25f, 0.25f, 0.3f), // Position pour le joueur 4
        new Vector3(-0.3f, 0.25f, -0.25f)  // Position pour le joueur 5
    };

    void Start()
    {
        // Récupération du nombre de joueurs stocké dans PlayerPrefs
        nombreJoueurs = PlayerPrefs.GetInt("NombreJoueurs", 1);
        Debug.Log("Nombre de joueurs récupéré : " + nombreJoueurs);

        // Vérification que le nombre de joueurs ne dépasse pas le nombre de positions prédéfinies
        if (nombreJoueurs > spawnPositions.Length)
        {
            Debug.LogError("Le nombre de joueurs dépasse le nombre de positions prédéfinies.");
            return;
        }

        // Création des joueurs
        GameObject[] playerliste = new GameObject[nombreJoueurs];

        for (int i = 0; i < nombreJoueurs; i++)
        {
            string playerName = "player" + (i + 1);

            // Utilisation des positions prédéfinies pour chaque joueur
            playerliste[i] = Create(playerName, spawnPositions[i]);
            SetPosition(playerliste[i], spawnPositions[i]);
        }
    }

    public GameObject Create(string name, Vector3 spawnPosition)
    {
        // Instanciation du joueur à la position prédéfinie
        GameObject obj = Instantiate(player, spawnPosition, Quaternion.Euler(0f, 90f, 0f));
        obj.name = name; // Définir explicitement le nom

        player_controller cm = obj.GetComponent<player_controller>();
        cm.name = name;
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj, Vector3 spawnPosition)
    {
        // Positionnement du joueur à la position donnée
        obj.transform.position = spawnPosition;
    }
}

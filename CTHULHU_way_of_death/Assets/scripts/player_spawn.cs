using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public GameObject player;
    private int nombreJoueurs; // Initialisé dans Start()
    
    private GameObject[,] positions = new GameObject[8, 8];

    private string currentPlayer = "player1";
    private bool gameOver = false;

    void Start()
    {
        // Récupération du nombre de joueurs stocké dans PlayerPrefs
        nombreJoueurs = PlayerPrefs.GetInt("NombreJoueurs", 1);
        Debug.Log("Nombre de joueurs récupéré : " + nombreJoueurs);

        // Création des joueurs
        GameObject[] playerliste = new GameObject[nombreJoueurs];

        for (int i = 0; i < nombreJoueurs; i++)
        {
            string playerName = "player" + (i + 1);
            playerliste[i] = Create(playerName, i, 0);
            SetPosition(playerliste[i]);
        }
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(player, new Vector3(0f, 0.25f, 0f), Quaternion.Euler(0f, 90f, 0f));
        player_controller cm = obj.GetComponent<player_controller>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        player_controller cm = obj.GetComponent<player_controller>();
        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }
}

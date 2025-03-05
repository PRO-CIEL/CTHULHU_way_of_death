using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public GameObject player;
    public int nb_player;  // Doit être un entier si on l'utilise dans une boucle
    private GameObject[,] positions = new GameObject[8,8];
    private GameObject[] player1 = new GameObject[1];
    private GameObject[] player2 = new GameObject[1];
    private GameObject[] player3 = new GameObject[1];
    private GameObject[] player4 = new GameObject[1];
    private GameObject[] player5 = new GameObject[1];

    private string currentPlayer = "player1";
    private bool gameOver = false;

    void Start()
    {
        GameObject[] playerliste = new GameObject[] 
        {
            Create("player1", 0, 0), 
            Create("player2", 0, 0), 
            Create("player3", 0, 0), 
            Create("player4", 0, 0), 
            Create("player5", 0, 0)
        };

        for (int i = 0; i < nb_player; i++)
        {
            SetPosition(playerliste[i]);  // Correction : passer chaque élément
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
        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;  // Correction du nom de la variable
    }
}


using UnityEngine;

public class player_controller : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;

    private int xBoard = -1;
    private int yBoard = -1;

    private string Player;

    public Sprite player1, player2, player3, player4, player5;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        // Utilisation de "this.name" après avoir défini le nom
        switch (gameObject.name)
        {
            case "player1": this.GetComponent<SpriteRenderer>().sprite = player1; break;
            case "player2": this.GetComponent<SpriteRenderer>().sprite = player1; break;
            case "player3": this.GetComponent<SpriteRenderer>().sprite = player1; break;
            case "player4": this.GetComponent<SpriteRenderer>().sprite = player1; break;
            case "player5": this.GetComponent<SpriteRenderer>().sprite = player1; break;
        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        // Optionnel : Tu peux ajuster l'échelle si nécessaire, mais sinon tu peux supprimer ce calcul.
        x *= 0.66f;
        y *= 0.66f;

        // Retirer les décalages d'origine (x -= -2.3f et y += 2.3f)
        // Cela permet au personnage de commencer directement à (0, 0.25, 0)
        this.transform.position = new Vector3(x, y + 0.25f, 0.0f); // L'axe Y commence à 0.25 pour qu'il flotte un peu au-dessus du sol
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }
}

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

        switch (this.name)
        {
            case "player1": this.GetComponent<SpriteRenderer>().sprite = player1; break;
            case "player2": this.GetComponent<SpriteRenderer>().sprite = player2; break;
            case "player3": this.GetComponent<SpriteRenderer>().sprite = player3; break;
            case "player4": this.GetComponent<SpriteRenderer>().sprite = player4; break;
            case "player5": this.GetComponent<SpriteRenderer>().sprite = player5; break;
        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 0.66f;
        y *= 0.66f;

        x -= -2.3f;
        y += 2.3f;

        this.transform.position = new Vector3(x, y, -1.0f);
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

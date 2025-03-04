using UnityEngine;
using UnityEngine.UI;


public class DiceRoller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       DiceValues = new int[3];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[] DiceValues;
    public int DiceTotal;

    public Sprite DiceImageCrit;
    public Sprite DiceImageCrit_mental;
    public Sprite DiceImageMental;
    public Sprite DiceImageMagic;
    public Sprite DiceImageEmpty;

    public void RollTheDice()
    {
        DiceTotal = 0;
        for (int i = 0; i < DiceValues.Length; i++)
        {
            DiceValues[i] = Random.Range(1, 7); // Plage 1-6 correcte
            DiceTotal += DiceValues[i];

            Image diceImage = this.transform.GetChild(i).GetComponent<Image>();

            switch (DiceValues[i])
            {
                case 1:
                case 2:
                    diceImage.sprite = DiceImageCrit;
                    break;
                case 3:
                    diceImage.sprite = DiceImageCrit_mental;
                    break;
                case 4:
                    diceImage.sprite = DiceImageMental;
                    break;
                case 5:
                    diceImage.sprite = DiceImageMagic;
                    break;
                default:
                    diceImage.sprite = DiceImageEmpty;
                    break;
            }
        }

        Debug.Log("Rolled : " + string.Join(", ", DiceValues) + " (" + DiceTotal + ")");
    } 

}

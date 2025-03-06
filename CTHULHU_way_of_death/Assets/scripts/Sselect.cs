using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardSelector : MonoBehaviour
{
    public Image cardImage; // L'image qui affiche la carte actuelle
    public Sprite[] cardSprites; // Sprites des 10 cartes (recto uniquement)

    private int currentCardIndex = 0; // Indice de la carte actuelle

    // Boutons
    public Button nextButton;
    public Button previousButton;
    public Button validateButton;
    public Button backButton;

    void Start()
    {
        // Initialisation des �v�nements pour les boutons
        nextButton.onClick.AddListener(NextCard);
        previousButton.onClick.AddListener(PreviousCard);
        validateButton.onClick.AddListener(ValidateSelection);
        backButton.onClick.AddListener(GoBackToPreviousScene);

        // Afficher la premi�re carte
        UpdateCard();
    }

    // Fonction pour passer � la carte suivante
    public void NextCard()
    {
        // Si l'on est sur la derni�re carte, on ne passe pas � la suivante
        if (currentCardIndex < cardSprites.Length - 1)
        {
            currentCardIndex++; // Passe � la carte suivante
            UpdateCard();
        }
        else
        {
            Debug.Log("Vous �tes d�j� � la derni�re carte.");
        }
    }

    // Fonction pour revenir � la carte pr�c�dente
    public void PreviousCard()
    {
        // Si l'on est sur la premi�re carte, on ne revient pas en arri�re
        if (currentCardIndex > 0)
        {
            currentCardIndex--; // Reviens � la carte pr�c�dente
            UpdateCard();
        }
        else
        {
            Debug.Log("Vous �tes d�j� � la premi�re carte.");
        }
    }

    // Fonction pour valider la s�lection et passer � la sc�ne suivante
    public void ValidateSelection()
    {
        Debug.Log("Personnage choisi : " + currentCardIndex); // Affiche l'index de la carte choisie
        // Exemple : SceneManager.LoadScene("SceneSuivante");
    }

    // Fonction pour revenir � la sc�ne pr�c�dente
    public void GoBackToPreviousScene()
    {
        // Revenir � la sc�ne pr�c�dente
        SceneManager.LoadScene("ScenePr�c�dente");
    }

    // Met � jour l'affichage de la carte
    void UpdateCard()
    {
        // V�rifie que l'index est valide avant d'afficher la carte
        if (currentCardIndex >= 0 && currentCardIndex < cardSprites.Length)
        {
            // Met � jour l'image de la carte en fonction de l'index
            cardImage.sprite = cardSprites[currentCardIndex];
        }
        else
        {
            Debug.LogError("Index de carte invalide : " + currentCardIndex);
        }
    }
}

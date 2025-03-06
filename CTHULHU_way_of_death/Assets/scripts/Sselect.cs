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
        // Initialisation des événements pour les boutons
        nextButton.onClick.AddListener(NextCard);
        previousButton.onClick.AddListener(PreviousCard);
        validateButton.onClick.AddListener(ValidateSelection);
        backButton.onClick.AddListener(GoBackToPreviousScene);

        // Afficher la première carte
        UpdateCard();
    }

    // Fonction pour passer à la carte suivante
    public void NextCard()
    {
        // Si l'on est sur la dernière carte, on ne passe pas à la suivante
        if (currentCardIndex < cardSprites.Length - 1)
        {
            currentCardIndex++; // Passe à la carte suivante
            UpdateCard();
        }
        else
        {
            Debug.Log("Vous êtes déjà à la dernière carte.");
        }
    }

    // Fonction pour revenir à la carte précédente
    public void PreviousCard()
    {
        // Si l'on est sur la première carte, on ne revient pas en arrière
        if (currentCardIndex > 0)
        {
            currentCardIndex--; // Reviens à la carte précédente
            UpdateCard();
        }
        else
        {
            Debug.Log("Vous êtes déjà à la première carte.");
        }
    }

    // Fonction pour valider la sélection et passer à la scène suivante
    public void ValidateSelection()
    {
        Debug.Log("Personnage choisi : " + currentCardIndex); // Affiche l'index de la carte choisie
        // Exemple : SceneManager.LoadScene("SceneSuivante");
    }

    // Fonction pour revenir à la scène précédente
    public void GoBackToPreviousScene()
    {
        // Revenir à la scène précédente
        SceneManager.LoadScene("ScenePrécédente");
    }

    // Met à jour l'affichage de la carte
    void UpdateCard()
    {
        // Vérifie que l'index est valide avant d'afficher la carte
        if (currentCardIndex >= 0 && currentCardIndex < cardSprites.Length)
        {
            // Met à jour l'image de la carte en fonction de l'index
            cardImage.sprite = cardSprites[currentCardIndex];
        }
        else
        {
            Debug.LogError("Index de carte invalide : " + currentCardIndex);
        }
    }
}

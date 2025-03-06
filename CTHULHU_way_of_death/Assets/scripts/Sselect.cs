using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ImageGallery : MonoBehaviour
{
    public Sprite[] frontImages; // Tableau des images avant des cartes
    public Sprite[] backImages;  // Tableau des images arrière des cartes
    public Image displayImage;   // Référence à l'UI Image pour afficher la carte
    public Button leftButton;    // Bouton pour aller à l'image précédente
    public Button rightButton;   // Bouton pour aller à l'image suivante
    public Button flipButton;    // Bouton pour retourner la carte
    public Button returnButton;  // Bouton pour retourner au menu précédent
    public Button selectButton;  // Bouton pour sélectionner le personnage
    public TMP_Text playerText;  // Texte pour indiquer le joueur actuel

    private int currentIndex = 0; // Index de l'image actuelle
    private bool isShowingFront = true; // Indique si l'avant de la carte est visible
    private int currentPlayer = 1; // Numéro du joueur actuel
    private bool[] selectedCharacters; // Tableau pour suivre les personnages déjà sélectionnés

    void Start()
    {
        // Initialiser le tableau des personnages sélectionnés
        selectedCharacters = new bool[frontImages.Length];

        // Mettre à jour l'image et le texte
        UpdateImage();
        UpdatePlayerText();

        // Ajouter les listeners aux boutons
        leftButton.onClick.AddListener(ShowPreviousImage);
        rightButton.onClick.AddListener(ShowNextImage);
        flipButton.onClick.AddListener(FlipImage);
        returnButton.onClick.AddListener(ReturnToLastMenu);
        selectButton.onClick.AddListener(SelectCharacter);
    }

    void ShowPreviousImage()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = frontImages.Length - 1; // Boucler à la dernière image
        }
        UpdateImage();
    }

    void ShowNextImage()
    {
        currentIndex++;
        if (currentIndex >= frontImages.Length)
        {
            currentIndex = 0; // Boucler à la première image
        }
        UpdateImage();
    }

    void FlipImage()
    {
        isShowingFront = !isShowingFront; // Basculer entre l'avant et l'arrière
        UpdateImage();
    }

    void ReturnToLastMenu()
    {
        // Retourner au menu précédent
        SceneManager.LoadScene("MainMenu"); // Remplacez "MainMenu" par le nom de votre scène de menu
    }

    void SelectCharacter()
    {
        // Vérifier si le personnage est déjà sélectionné
        if (selectedCharacters[currentIndex])
        {
            Debug.Log("Ce personnage est déjà sélectionné !");
            return;
        }

        // Sauvegarder le personnage sélectionné pour le joueur actuel
        PlayerPrefs.SetInt("Player" + currentPlayer + "Character", currentIndex);
        selectedCharacters[currentIndex] = true; // Marquer le personnage comme sélectionné

        // Passer au joueur suivant
        currentPlayer++;

        // Si tous les joueurs ont choisi, charger la scène de jeu
        if (currentPlayer > PlayerPrefs.GetInt("NombreJoueurs", 1))
        {
            SceneManager.LoadScene("_scene_"); // Remplacez "GameScene" par le nom de votre scène de jeu
        }
        else
        {
            // Réinitialiser pour le prochain joueur
            currentIndex = 0;
            isShowingFront = true;
            UpdateImage();
            UpdatePlayerText();
        }
    }

    void UpdateImage()
    {
        if (isShowingFront)
        {
            displayImage.sprite = frontImages[currentIndex]; // Afficher l'avant de la carte
        }
        else
        {
            displayImage.sprite = backImages[currentIndex]; // Afficher l'arrière de la carte
        }

        // Désactiver le bouton de sélection si le personnage est déjà choisi
        selectButton.interactable = !selectedCharacters[currentIndex];
    }

    void UpdatePlayerText()
    {
        // Mettre à jour le texte pour indiquer le joueur actuel
        playerText.text = "Joueur " + currentPlayer + " : Choisissez votre personnage";
    }
}
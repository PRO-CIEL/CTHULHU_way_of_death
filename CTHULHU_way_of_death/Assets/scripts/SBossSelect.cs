using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageGalleryManager : MonoBehaviour
{
    public Image imageDisplay; // L'image affichée au centre
    public Sprite[] images; // Tableau des images à afficher
    public Button nextButton; // Bouton suivant (flèche à droite)
    public Button previousButton; // Bouton précédent (flèche à gauche)
    public Button confirmButton; // Bouton confirmer
    public Button flipButton; // Bouton flip
    public Button backButton; // Bouton retour
    public GameObject[] cards; // Liste des cartes à retourner (si nécessaire)
    private int currentIndex = 0; // Indice de l'image actuellement affichée

    void Start()
    {
        // Initialiser les événements des boutons
        nextButton.onClick.AddListener(NextImage);
        previousButton.onClick.AddListener(PreviousImage);
        confirmButton.onClick.AddListener(ConfirmChoice);
        flipButton.onClick.AddListener(FlipCard);
        backButton.onClick.AddListener(BackToPreviousScene);

        // Afficher la première image
        UpdateImage();
    }

    // Méthode pour afficher l'image suivante
    void NextImage()
    {
        if (currentIndex < images.Length - 1)
        {
            currentIndex++;
            UpdateImage();
        }
    }

    // Méthode pour afficher l'image précédente
    void PreviousImage()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateImage();
        }
    }

    // Mise à jour de l'image affichée
    void UpdateImage()
    {
        imageDisplay.sprite = images[currentIndex];
    }

    // Méthode pour confirmer le choix et aller à la scène suivante
    void ConfirmChoice()
    {
        // Code pour confirmer le choix
        Debug.Log("Choix confirmé : " + images[currentIndex].name);

        // Aller à la scène suivante
        SceneManager.LoadScene("_scene_"); // Remplace par le nom de la scène suivante
    }

    // Méthode pour retourner les cartes (exemple de logique, à adapter si nécessaire)
    void FlipCard()
    {
        foreach (var card in cards)
        {
            // Retourner ou cacher chaque carte (ajuster selon ton système de cartes)
            card.SetActive(!card.activeSelf); // Exemple de bascule de visibilité
        }
    }

    // Méthode pour revenir à la scène précédente
    void BackToPreviousScene()
    {
        SceneManager.LoadScene("_ChoixPersonnage_"); // Remplace par le nom de la scène précédente
    }
}

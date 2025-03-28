using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageGalleryManager : MonoBehaviour
{
    public Image imageDisplay; // L'image affich�e au centre
    public Sprite[] images; // Tableau des images � afficher
    public Button nextButton; // Bouton suivant (fl�che � droite)
    public Button previousButton; // Bouton pr�c�dent (fl�che � gauche)
    public Button confirmButton; // Bouton confirmer
    public Button flipButton; // Bouton flip
    public Button backButton; // Bouton retour
    public GameObject[] cards; // Liste des cartes � retourner (si n�cessaire)
    private int currentIndex = 0; // Indice de l'image actuellement affich�e

    void Start()
    {
        // Initialiser les �v�nements des boutons
        nextButton.onClick.AddListener(NextImage);
        previousButton.onClick.AddListener(PreviousImage);
        confirmButton.onClick.AddListener(ConfirmChoice);
        flipButton.onClick.AddListener(FlipCard);
        backButton.onClick.AddListener(BackToPreviousScene);

        // Afficher la premi�re image
        UpdateImage();
    }

    // M�thode pour afficher l'image suivante
    void NextImage()
    {
        if (currentIndex < images.Length - 1)
        {
            currentIndex++;
            UpdateImage();
        }
    }

    // M�thode pour afficher l'image pr�c�dente
    void PreviousImage()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateImage();
        }
    }

    // Mise � jour de l'image affich�e
    void UpdateImage()
    {
        imageDisplay.sprite = images[currentIndex];
    }

    // M�thode pour confirmer le choix et aller � la sc�ne suivante
    void ConfirmChoice()
    {
        // Code pour confirmer le choix
        Debug.Log("Choix confirm� : " + images[currentIndex].name);

        // Aller � la sc�ne suivante
        SceneManager.LoadScene("_scene_"); // Remplace par le nom de la sc�ne suivante
    }

    // M�thode pour retourner les cartes (exemple de logique, � adapter si n�cessaire)
    void FlipCard()
    {
        foreach (var card in cards)
        {
            // Retourner ou cacher chaque carte (ajuster selon ton syst�me de cartes)
            card.SetActive(!card.activeSelf); // Exemple de bascule de visibilit�
        }
    }

    // M�thode pour revenir � la sc�ne pr�c�dente
    void BackToPreviousScene()
    {
        SceneManager.LoadScene("_ChoixPersonnage_"); // Remplace par le nom de la sc�ne pr�c�dente
    }
}

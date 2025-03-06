using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour // Ensure it derives from MonoBehaviour
{
    public TMP_Text turnText; // Texte pour afficher le joueur actuel et ses actions restantes
    public Button runButton;   // Bouton pour l'action "Course"
    public Button attackButton; // Bouton pour l'action "Attaque"
    public Button restButton;  // Bouton pour l'action "Repos"
    public Button exchangeButton; // Bouton pour l'action "Échange"
    public Button episodeButton; // Bouton pour l'action "Action d'épisode"

    private int currentPlayer = 1; // Numéro du joueur actuel
    private int actionsRemaining = 3; // Nombre d'actions restantes pour le joueur actuel
    private int totalPlayers; // Nombre total de joueurs

    void Start() // Ensure this is a non-static method
    {
        // Récupérer le nombre total de joueurs depuis PlayerPrefs
        totalPlayers = PlayerPrefs.GetInt("NombreJoueurs", 1);

        // Mettre à jour l'interface
        UpdateUI();

        // Ajouter les listeners aux boutons
        runButton.onClick.AddListener(OnRun);
        attackButton.onClick.AddListener(OnAttack);
        restButton.onClick.AddListener(OnRest);
        exchangeButton.onClick.AddListener(OnExchange);
        episodeButton.onClick.AddListener(OnEpisode);
    }

    void UpdateUI() // Ensure this is a non-static method
    {
        // Mettre à jour le texte pour afficher le joueur actuel et ses actions restantes
        turnText.text = "Joueur " + currentPlayer + " - Actions restantes : " + actionsRemaining;

        // Désactiver les boutons si le joueur n'a plus d'actions
        runButton.interactable = actionsRemaining > 0;
        attackButton.interactable = actionsRemaining > 0;
        restButton.interactable = actionsRemaining > 0;
        exchangeButton.interactable = actionsRemaining > 0;
        episodeButton.interactable = actionsRemaining > 0;
    }

    void OnRun() // Ensure this is a non-static method
    {
        Debug.Log("Joueur " + currentPlayer + " a choisi de courir.");
        UseAction();
    }

    void OnAttack() // Ensure this is a non-static method
    {
        Debug.Log("Joueur " + currentPlayer + " a choisi d'attaquer.");
        UseAction();
    }

    void OnRest() // Ensure this is a non-static method
    {
        Debug.Log("Joueur " + currentPlayer + " a choisi de se reposer.");
        UseAction();
    }

    void OnExchange() // Ensure this is a non-static method
    {
        Debug.Log("Joueur " + currentPlayer + " a choisi d'échanger.");
        UseAction();
    }

    void OnEpisode() // Ensure this is a non-static method
    {
        Debug.Log("Joueur " + currentPlayer + " a choisi une action d'épisode.");
        UseAction();
    }

    void UseAction() // Ensure this is a non-static method
    {
        actionsRemaining--;

        if (actionsRemaining <= 0)
        {
            // Passer au joueur suivant
            currentPlayer++;
            if (currentPlayer > totalPlayers)
            {
                currentPlayer = 1; // Revenir au premier joueur après le dernier
            }

            // Réinitialiser les actions pour le nouveau joueur
            actionsRemaining = 3;
        }

        // Mettre à jour l'interface
        UpdateUI();
    }
}
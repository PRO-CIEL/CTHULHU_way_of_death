using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Importer TextMeshPro

public class Smenu_joueur : MonoBehaviour
{
    public TMP_Dropdown playerDropdown; // Référence au TMP_Dropdown
    public UnityEngine.UI.Button acceptButton; // Référence au bouton "Accepter"

    private int nombreJoueurs = 1; // Valeur par défaut

    void Start()
    {
        // Vérifie si le Dropdown TMP est assigné et ajoute un listener
        if (playerDropdown != null)
        {
            playerDropdown.onValueChanged.AddListener(delegate { ChangerNombreJoueurs(); });
            nombreJoueurs = playerDropdown.value + 1; // Initialisation du nombre de joueurs
        }

        // Vérifie si le bouton "Accepter" est assigné et ajoute un listener
        if (acceptButton != null)
        {
            acceptButton.onClick.AddListener(AccepterChoix);
        }
    }

    public void ChangerNombreJoueurs()
    {
        nombreJoueurs = playerDropdown.value + 1; // Le Dropdown commence à 0, donc on ajoute 1
        Debug.Log("Nombre de joueurs sélectionné : " + nombreJoueurs);
    }

    public void AccepterChoix()
    {
        // Stocker le nombre de joueurs
        PlayerPrefs.SetInt("NombreJoueurs", nombreJoueurs);
        PlayerPrefs.Save();

        // Charger la scène de jeu "_scene_"
        SceneManager.LoadScene("_scene_");
    }

    public void Retour()
    {
        // Retourner au menu principal
        SceneManager.LoadScene("_menu_");
    }
}

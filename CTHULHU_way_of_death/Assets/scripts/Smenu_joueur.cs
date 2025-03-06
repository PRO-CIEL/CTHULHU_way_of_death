using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Smenu_joueur : MonoBehaviour
{
    public TMP_Dropdown playerDropdown;
    public UnityEngine.UI.Button acceptButton;
    public UnityEngine.UI.Button backButton;
    public AudioSource audioSource;
    public string sceneToLoad = "_scene_";
    public string menuScene = "_menu_";

    private int nombreJoueurs = 1;

    void Start()
    {
        if (playerDropdown != null)
        {
            playerDropdown.onValueChanged.AddListener(delegate { ChangerNombreJoueurs(); });
            nombreJoueurs = playerDropdown.value + 1;
        }

        if (acceptButton != null)
        {
            acceptButton.onClick.AddListener(() => StartCoroutine(PlaySoundAndLoadScene(sceneToLoad)));
        }

        if (backButton != null)
        {
            backButton.onClick.AddListener(() => StartCoroutine(PlaySoundAndLoadScene(menuScene)));
        }
    }

    public void ChangerNombreJoueurs()
    {
        nombreJoueurs = playerDropdown.value + 1;
        Debug.Log("Nombre de joueurs sélectionné : " + nombreJoueurs);
    }

    private IEnumerator PlaySoundAndLoadScene(string sceneName)
    {
        // Sauvegarder le nombre de joueurs
        PlayerPrefs.SetInt("NombreJoueurs", nombreJoueurs);
        PlayerPrefs.Save();

        if (audioSource != null)
        {
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }
        
        SceneManager.LoadScene(sceneName);
    }
}

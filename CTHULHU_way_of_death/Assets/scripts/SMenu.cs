using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SMenu : MonoBehaviour
{
    public AudioSource audioSource;  // Référence à l'AudioSource
    public string sceneToLoad = "_ChoixJoueur_";  // Nom de la scène à charger

    public void PlayGame()
    {
        // Lancer la coroutine pour jouer le son avant de changer de scène
        StartCoroutine(PlaySoundAndLoadScene());
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private IEnumerator PlaySoundAndLoadScene()
    {
        // Vérifier si l'AudioSource est configuré
        if (audioSource != null)
        {
            // Joue le son
            audioSource.Play();

            // Attendre que l'audio se termine avant de charger la scène
            yield return new WaitForSeconds(audioSource.clip.length);
        }

        // Charger la scène après que le son soit terminé
        SceneManager.LoadScene(sceneToLoad);
    }
}

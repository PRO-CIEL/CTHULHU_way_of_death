using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SMenu : MonoBehaviour
{
    public AudioSource audioSource;  // R�f�rence � l'AudioSource
    public string sceneToLoad = "_ChoixPersonnage_";  // Nom de la sc�ne � charger

    public void PlayGame()
    {
        // Lancer la coroutine pour jouer le son avant de changer de sc�ne
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
        // V�rifier si l'AudioSource est configur�
        if (audioSource != null)
        {
            // Joue le son
            audioSource.Play();

            // Attendre que l'audio se termine avant de charger la sc�ne
            yield return new WaitForSeconds(audioSource.clip.length);
        }

        // Charger la sc�ne apr�s que le son soit termin�
        SceneManager.LoadScene(sceneToLoad);
    }
}

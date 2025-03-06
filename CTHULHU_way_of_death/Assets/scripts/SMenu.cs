using UnityEngine;
using UnityEngine.SceneManagement;

public class SMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("_ChoixJoueur_");
    }

    public void QuitGame()
    {
        Application.Quit();

    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}

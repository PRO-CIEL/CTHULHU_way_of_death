using UnityEngine;
using UnityEngine.UI;  // Toujours n�cessaire pour les boutons UI classiques
using TMPro;  // N�cessaire pour TextMeshPro

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioSource audioSource;  // R�f�rence � l'AudioSource
    public Button button;  // R�f�rence au bouton UI TextMeshPro

    void Start()
    {
        // Assurer que le bouton a bien un listener pour l'�v�nement OnClick
        button.onClick.AddListener(PlaySound);
    }

    public void PlaySound()
    {
        // Joue le son lorsque le bouton est press�
        audioSource.Play();
    }
}

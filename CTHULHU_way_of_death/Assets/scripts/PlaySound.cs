using UnityEngine;
using UnityEngine.UI;  // Toujours nécessaire pour les boutons UI classiques
using TMPro;  // Nécessaire pour TextMeshPro

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioSource audioSource;  // Référence à l'AudioSource
    public Button button;  // Référence au bouton UI TextMeshPro

    void Start()
    {
        // Assurer que le bouton a bien un listener pour l'événement OnClick
        button.onClick.AddListener(PlaySound);
    }

    public void PlaySound()
    {
        // Joue le son lorsque le bouton est pressé
        audioSource.Play();
    }
}

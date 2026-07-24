using UnityEngine;

public class BocinaController : MonoBehaviour
{
    private bool isOn = false;
    [SerializeField]
    private AudioClip[] canciones;
    private int cancionActual;

    void Start()
    {
        
    }

    public void Toggle()
    {
        isOn = !isOn;

        AudioSource audioSource = GetComponent<AudioSource>();

        if (isOn)
        {
            audioSource.clip = canciones[cancionActual]; 
            audioSource.Play();                          
        }
        else
        {
            audioSource.Stop();      
        }
    }

}

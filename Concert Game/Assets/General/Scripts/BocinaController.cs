using UnityEngine;
using UnityEngine.Audio;

public class BocinaController : MonoBehaviour
{
    private bool isOn = false;
    [SerializeField]
    private AudioClip[] canciones;
    private int cancionActual;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void Toggle()
    {
        isOn = !isOn;

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

    public void NextSong()
    {
        if(canciones.Length == 0)
        {
            Debug.Log("No hay canciones disponibles. Favor de añadirlas en el inspector");
            return;
        }

        cancionActual = cancionActual + 1;
        if (cancionActual == canciones.Length)
        {
            cancionActual = 0;
        }

        if (isOn)
        {
            audioSource.clip = canciones[cancionActual];
            audioSource.Play();
            Debug.Log("Canción seleccionada:" + cancionActual);

        }
    }


    public void PreviousSong()
    {
        if (canciones.Length == 0)
        {
            Debug.Log("No hay canciones disponibles. Favor de añadirlas en el inspector");
            return;
        }

        cancionActual = cancionActual - 1;
       
        if(cancionActual == -1)
        {
            cancionActual = canciones.Length - 1;
        }

        if (isOn)
        {
            audioSource.clip = canciones[cancionActual];
            audioSource.Play();
            Debug.Log("Canción seleccionada:" + cancionActual);
        }
    }

}
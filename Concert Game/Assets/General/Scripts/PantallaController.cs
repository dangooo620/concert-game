using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;

public class PantallaController : MonoBehaviour
{
    public GameObject pantallaActiva;
    public GameObject pantallaApagada;
    public Light luzPantalla;

    public void Toggle()
    {
        bool isObj1Active = pantallaActiva.activeSelf;

        pantallaActiva.SetActive(!isObj1Active);
        luzPantalla.enabled = !isObj1Active;
        pantallaApagada.SetActive(isObj1Active);
    }

}



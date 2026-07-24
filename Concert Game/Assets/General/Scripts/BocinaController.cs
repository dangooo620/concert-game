using UnityEngine;

public class BocinaController : MonoBehaviour
{
    private bool isOn = false;
    [SerializeField]
    private AudioClip sonido;

    void Start()
    {
        
    }

    public void Toggle()
    {
        isOn = !isOn;
        //luz.enabled = !isOn;
        //Debug.Log("TOGGLE");
    }

    public void playExplosion()
    {
        AudioSource.PlayClipAtPoint(sonido, transform.position);
    }
}

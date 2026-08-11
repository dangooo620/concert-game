using UnityEngine;
using UnityEngine.Audio;

public class FogController : MonoBehaviour
{
    private bool isOn = false;
    private ParticleSystem fog;

    void Start()
    {
        fog = GetComponent<ParticleSystem>();
    }

    public void Toggle()
    {
        isOn = !isOn;

        if (isOn)
        {
            fog.Stop();
        }
        else
        {
            fog.Play();
        }
    }
}

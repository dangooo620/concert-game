using UnityEngine;

public class FlameController : MonoBehaviour
{
    private bool isOn = true;
    private ParticleSystem[] flames;

    void Start()
    {
        flames = GetComponentsInChildren<ParticleSystem>();

        if (flames.Length == 0)
        {
            Debug.LogWarning("No hay partículas");
        }
    }

    public void Toggle()
    {
        isOn = !isOn;

        if (isOn)
        {
            foreach (ParticleSystem flame in flames)
            {
                flame.Play();
            }

            Debug.Log("Flamas On");
        }
        else
        {
            foreach (ParticleSystem flame in flames)
            {
                flame.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }

            Debug.Log("Flamas Off");
        }
    }
}
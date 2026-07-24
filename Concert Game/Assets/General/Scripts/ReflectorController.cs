using UnityEngine;

public class ReflectorController : MonoBehaviour
{

    private bool isOn = false;
    private Light luz;

    void Start()
    {
        luz = GetComponent<Light>();
    }
    
    public void Toggle()
    {
        isOn = !isOn;
        luz.enabled = !isOn;
    }

    public void Rotate(float x, float y)
    {
        transform.Rotate(new Vector3(y, x, 0));
    }

}

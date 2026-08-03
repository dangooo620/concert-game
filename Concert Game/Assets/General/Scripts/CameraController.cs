using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CameraOne();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("7"))
        {
            CameraOne();
        }
        
        if (Input.GetKeyDown("8"))
        {
            CameraTwo();
        }

        if (Input.GetKeyDown("9"))
        {
            CameraThree();
        }
    }

    void CameraOne()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        Camera3.SetActive(false);
    }

    void CameraTwo()
    {
        Camera1.SetActive(false);
        Camera2.SetActive(true);
        Camera3.SetActive(false);
    }

    void CameraThree()
    {
        Camera1.SetActive(false);
        Camera2.SetActive(false);
        Camera3.SetActive(true);
    }
}

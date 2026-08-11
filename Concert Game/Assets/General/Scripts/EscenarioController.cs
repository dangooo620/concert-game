//using UnityEngine;

//public class EscenarioController : MonoBehaviour
//{
//    public ReflectorController[] reflectores;
//    private int reflectorSeleccionado = -1;

//    void Start()
//    {
//        //Debug.Log("ENTRA");
//    }

//    void Update()
//    {
//        for (int i = 0; i < reflectores.Length; i++)
//        {
//            if(Input.GetKeyDown(KeyCode.Alpha1 + i)) { 
//                reflectorSeleccionado = i;
//                Debug.Log("Reflector" + (i + 1) + "seleccionado");
//            }
//        }

//        if (reflectorSeleccionado >= 0 && Input.GetKeyDown(KeyCode.E))
//        {
//            reflectores[reflectorSeleccionado].Toggle();
//        }

//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            reflectorSeleccionado = -1;
//            Debug.Log("Ningún reflector se encuentra seleccionado");
//        }

//        if (reflectorSeleccionado >= 0)
//        {
//            float mouseX = Input.GetAxis("Mouse X");
//            float mouseY = Input.GetAxis("Mouse Y");
//            reflectores[reflectorSeleccionado].Rotate(mouseX, mouseY);
//        }
//    }
//}

using UnityEngine;

public class EscenarioController : MonoBehaviour
{
    public ReflectorController[] reflectores;
    private int reflectorSeleccionado;
    private bool toggleReflector = false;
    public BocinaController[] bocinas;
    public PantallaController pantalla;
    public FogController fog;

    void Start()
    {
        //Debug.Log("ENTRA");
    }

    void Update()
    {
        // INPUTS DE LUCES
        if (Input.GetKeyDown(KeyCode.Q))
        {
            toggleReflector = !toggleReflector;
            if (!toggleReflector)
            {
                reflectorSeleccionado = -1;
            }
        }

        if (toggleReflector)
        {
            for (int i = 0; i < reflectores.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    reflectorSeleccionado = i;
                    Debug.Log("Reflector" + (i + 1) + "seleccionado");
                }
            }

            if (reflectorSeleccionado >= 0 && Input.GetKeyDown(KeyCode.E))
            {
                reflectores[reflectorSeleccionado].Toggle();
            }

            if (reflectorSeleccionado >= 0)
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");
                reflectores[reflectorSeleccionado].Rotate(mouseX, mouseY);
            }
        }

        // INPUTS DE BOCINAS

        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < bocinas.Length; i++) {

                bocinas[i].Toggle();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            for (int i = 0; i < bocinas.Length; i++)
            {

                bocinas[i].PreviousSong();
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            for (int i = 0; i < bocinas.Length; i++)
            {

                bocinas[i].NextSong();
            }
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
             pantalla.Toggle();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            fog.Toggle();
            Debug.Log("Entra");
        }
    }
}


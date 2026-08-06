using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class ControlEspecificoPanel : MonoBehaviour
{
    private Joystick panelLateral;

    // CAMARAS
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;

    // BOCINAS
    public BocinaController[] bocinas;

    // PANTALLA
    public PantallaController pantalla;

    // LUCES
    public ReflectorController[] reflectores;
    private int reflectorSeleccionado;
    private bool toggleReflector = false;

    void Start()
    {
        panelLateral = Joystick.all.FirstOrDefault(j => j.displayName.Contains("Saitek Side Panel Control Deck")) as Joystick;

        if (panelLateral == null)
        {
            Debug.LogError("¡No se encontró el Panel Lateral! Revisa el nombre en el Input Debugger.");
        }
        else
        {
            Debug.Log("Panel Lateral detectado: " + panelLateral.displayName);
        }

        CameraOne();
    }

    // Update is called once per frame
    void Update()
    {

        foreach (var control in panelLateral.allControls)
        {
            if (control is ButtonControl button && button.wasPressedThisFrame)
            {
                EjecutarAccion(button.name);
            }
        }

    }

    void EjecutarAccion(string nombreBoton)
    {
        switch (nombreBoton)
        {
            //CAMARAS
            case "button11":
                CameraOne();
                break;

            case "button13":
                CameraTwo();
                break;

            case "button15":
                CameraThree();
                break;

            //BOCINAS
            case "button18":
                for (int i = 0; i < bocinas.Length; i++)
                {

                    bocinas[i].Toggle();
                }
                break;

            case "button4":
                for (int i = 0; i < bocinas.Length; i++)
                {

                    bocinas[i].PreviousSong();
                }
                break;

            case "button5":
                for (int i = 0; i < bocinas.Length; i++)
                {

                    bocinas[i].NextSong();
                }
                break;

            // PANTALLA
            case "button19":
                pantalla.Toggle();
                break;

            // LUCES
            case "button22":
                Reflector();
                break;


            default:
                Debug.Log($"Presionaste {nombreBoton}, pero aún no tiene una instrucción específica.");
                break;
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

    void Reflector()
    {
        toggleReflector = !toggleReflector;
        if (!toggleReflector)
        {
            reflectorSeleccionado = -1;
            Debug.Log("Reflector Activadooopp");
        }
    }

}

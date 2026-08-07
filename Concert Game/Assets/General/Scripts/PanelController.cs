using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class ControlEspecificoPanel : MonoBehaviour
{
    private Joystick panelLateral;

    // Camaras
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;

    // Bocinas
    public BocinaController[] bocinas;

    // Pantalla
    public PantallaController pantalla;

    // Luces
    public ReflectorController[] reflectores;
    private int reflectorSeleccionado;
    private bool toggleReflector = false;

    // Joystick
    public float velocidadReflector = 120f;

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

        // Rotacion con Mouse
        //if (toggleReflector && reflectorSeleccionado >= 0)
        //{
        //    float mouseX = Input.GetAxis("Mouse X");
        //    float mouseY = Input.GetAxis("Mouse Y");
        //    reflectores[reflectorSeleccionado].Rotate(mouseX, mouseY);
        //}

        // Rotacion con Joystick
        if (toggleReflector && reflectorSeleccionado >= 0)
        {
            Vector2 movimientoJoystick = panelLateral.stick.ReadValue();

            if (movimientoJoystick.magnitude > 0.1f)
            {
                reflectores[reflectorSeleccionado].Rotate(movimientoJoystick.x * velocidadReflector * Time.deltaTime, movimientoJoystick.y *velocidadReflector * Time.deltaTime);
            }
        }

    }

    void EjecutarAccion(string nombreBoton)
    {
        switch (nombreBoton)
        {
            // Camaras
            case "button11":
                CameraOne();
                break;

            case "button13":
                CameraTwo();
                break;

            case "button15":
                CameraThree();
                break;

            // Bocinas
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

            // Pantalla
            case "button19":
                pantalla.Toggle();
                break;

            // Luces
            case "button22":
                Reflector();
                break;

            case "trigger":
                SeleccionarReflector(0);
                break;

            case "button2":
                SeleccionarReflector(1);
                break;

            case "button3":
                SeleccionarReflector(2);
                break;

            case "button6":
                SeleccionarReflector(3);
                break;

            case "button7":
                SeleccionarReflector(4);
                break;

            case "button8":
                SeleccionarReflector(5);
                break;

            case "button17":
                ToggleReflectorSeleccionado();
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
            Debug.Log("Desactivado la seleccion de luces");
        }

    }

    void SeleccionarReflector(int indice)
    {
        //toggleReflector = !toggleReflector;
        if (!toggleReflector)
        {
            reflectorSeleccionado = -1;
            Debug.Log("Hay que activar la seleccion de luces");
            return;
        }

        if (indice >= 0 && indice < reflectores.Length)
        {
            reflectorSeleccionado = indice;
            Debug.Log("Reflector" + (indice + 1) + " seleccionado");
        }
    }

    void ToggleReflectorSeleccionado ()
    {
        if (!toggleReflector)
            return;

        if (reflectorSeleccionado >= 0)
        {
            reflectores[reflectorSeleccionado].Toggle();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenuController : MonoBehaviour
{
    private PauseManager pm;
    private bool opciones = false;
    public GameObject menuPausa;
    public GameObject menuOpciones;
    public AudioMixer am;
    public Toggle fs;
    public Slider vol;
    public float vol_aux;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("gamecontroller").GetComponent<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.pausa && !opciones)
        {
            menuPausa.SetActive(true);
            menuOpciones.SetActive(false);
        }
        else if (pm.pausa && opciones)
        {
            menuPausa.SetActive(false);
            menuOpciones.SetActive(true);
        }
        else if (!pm.pausa)
        {
            menuPausa.SetActive(false);
            menuOpciones.SetActive(false);
            opciones = false;
        }

        if (Screen.fullScreen) fs.isOn = true;
        else fs.isOn = false;

        am.GetFloat("Volumen", out vol_aux);
        vol.value = vol_aux;
    }

    public void Reanudar()
    {
        pm.pausa = false;
    }

    public void Opciones()
    {
        opciones = true;
    }

    public void OpcionesVolumen(float volumen)
    {
        am.SetFloat("Volumen", volumen);
    }

    public void OpcionesFullScreen(bool fs)
    {
        Screen.fullScreen = fs;
    }

    public void OpcionesAtras()
    {
        opciones = false;
    }

    public void MenuPrincipal()
    {
        //Reseteamos variables globales
        VariablesController.Muerto = false;
        VariablesController.Nivel2 = false;
        VariablesController.Nivel3 = false;

        //Volvemos al menu principal
        SceneManager.LoadScene("MenuInicial");
    }
}

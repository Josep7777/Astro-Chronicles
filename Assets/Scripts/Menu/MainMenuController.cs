using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class MainMenuController : MonoBehaviour
{

    Resolution[] resoluciones_disponibles;
    public Dropdown dropdown;
    private List<string> resoluciones = new List<string>();
    private int index;
    public AudioMixer am;
    private void Start()
    {
        resoluciones_disponibles = Screen.resolutions;

        dropdown.ClearOptions();

        for(int i=0;i< resoluciones_disponibles.Length; i++)
        {
            string resolucion = resoluciones_disponibles[i].width + "x" + resoluciones_disponibles[i].height;
            resoluciones.Add(resolucion);

            if (resoluciones_disponibles[i].width == Screen.currentResolution.width && resoluciones_disponibles[i].height == Screen.currentResolution.height)
            {
                index = i;
            }
        }

        dropdown.AddOptions(resoluciones);
        dropdown.value = index;
        dropdown.RefreshShownValue();
    }


    public void Resoluciones(int i)
    {
        Resolution r = resoluciones_disponibles[i];
        Screen.SetResolution(r.width, r.height, Screen.fullScreen);
    }

    public void Volumen(float volumen)
    {
        am.SetFloat("Volumen", volumen);
    }

    public void NuevoJuego()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void FullScreen(bool fs)
    {
        Screen.fullScreen = fs;
    }

    public void Salir()
    {
        Application.Quit();
    }
}

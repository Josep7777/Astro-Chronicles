using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public Dialogo dialogos;

    Queue<string> frases;

    public GameObject Planel_texto;

    public TextMeshProUGUI texto;

    public string frase_actual;

    public float velocidad_texto;

    public bool activar_dialogo = false;

    public GameObject cutScene_canvas;

    private bool primera_vez=false;

    public Image raton;

    private float contador = 0;

    private bool flag_raton = true;

    public bool texto_acabado = false;

    public Image fadeIn;

    private bool flag_fade = false;

    private bool frase_acabada = false;

    public GameObject continuara;

    // Start is called before the first frame update
    void Start()
    {
        frases = new Queue<string>();

        foreach (string oraciones in dialogos.frases)
        {
            frases.Enqueue(oraciones);
            
        }

        fadeIn.gameObject.SetActive(true);
        fadeIn.canvasRenderer.SetAlpha(0.0f);

        
        
        //texto.text = frase_actual;
    }

    void Siguiente()
    {
        if (frases.Count <= 0) //Evita errores con la ultima frase
        {
            texto.text = frase_actual;
            flag_fade = true;
            return;
        }

        frase_actual = frases.Dequeue();
        //texto.text = frase_actual;
        StartCoroutine(EscribirFrase(frase_actual));
        //Debug.Log(frase_actual);
    }

    IEnumerator EscribirFrase(string cadena)
    {
        texto.text = "";
        foreach(char letra in cadena.ToCharArray())
        {
            texto.text += letra;
            if (letra == '.' || letra == '!') frase_acabada = true;
            else frase_acabada = false;
            yield return new WaitForSeconds(velocidad_texto);
        }
        //Debug.Log("AAAAAA");
    }


    // Update is called once per frame
    void Update()
    {
        if (activar_dialogo)
        {
            cutScene_canvas.SetActive(true);
            if (primera_vez == false)
            {
                Siguiente();
                primera_vez = true;
            }

            if (Input.GetMouseButtonDown(0) && frase_acabada)
            {
                Siguiente();

            }

            contador += Time.deltaTime;
            if (contador >= 1f)
            {
                if (flag_raton)
                {
                    raton.gameObject.SetActive(false);
                    flag_raton = false;
                }
                else
                {
                    raton.gameObject.SetActive(true);
                    flag_raton = true;
                }
                contador = 0;
            }

            if (flag_fade)
            {
                fadeIn.CrossFadeAlpha(1, 1.0f, false);
                //Debug.Log("a");
            }

            //Debug.Log(fadeIn.canvasRenderer.GetAlpha());

            if (fadeIn.canvasRenderer.GetAlpha() >= 0.99f)
            {
                Debug.Log("Lol");
                continuara.gameObject.SetActive(true);
            }
        }

    }
}

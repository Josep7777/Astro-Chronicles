using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    // Start is called before the first frame update
    void Start()
    {
        frases = new Queue<string>();

        foreach (string oraciones in dialogos.frases)
        {
            frases.Enqueue(oraciones);
        }

        frase_actual = frases.Dequeue();
        texto.text = frase_actual;
    }

    void Siguiente()
    {
        if (frases.Count <= 0) //Evita errores con la ultima frase
        {
            texto.text = frase_actual;
            return;
        }

        frase_actual = frases.Dequeue();
        texto.text = frase_actual;

        //Debug.Log(frase_actual);
    }


    // Update is called once per frame
    void Update()
    {
        if (activar_dialogo)
        {
            cutScene_canvas.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                Siguiente();

            }   
        }

    }
}

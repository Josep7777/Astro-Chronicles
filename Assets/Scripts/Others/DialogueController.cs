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

    // Start is called before the first frame update
    void Start()
    {
        frases = new Queue<string>();

        foreach (string oraciones in dialogos.frases)
        {
            frases.Enqueue(oraciones);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

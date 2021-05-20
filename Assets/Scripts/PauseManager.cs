using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool pausa = false;
    public GameObject menuPausa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log(pausa);

            if (pausa) 
                pausa = false;
            else
                pausa = true;
        }

        if (pausa)
        {
            Time.timeScale = 0f; //Hace que el juego permanezca quieto mientras estas en el menu
        } else
        {
            Time.timeScale = 1f; //Reanuda el juego
        }
    }
}

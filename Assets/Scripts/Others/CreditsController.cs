using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsController : MonoBehaviour
{
    float contador;
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;
        if(contador >=27.5f)
        {
            VariablesController.Muerto = false;
            VariablesController.Nivel2 = false;
            VariablesController.Nivel3 = false;
            SceneManager.LoadScene("MenuInicial");
        }
    }
}

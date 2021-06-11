using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y >= 1400)
        {
            VariablesController.Muerto = false;
            VariablesController.Nivel2 = false;
            VariablesController.Nivel3 = false;
            SceneManager.LoadScene("MenuInicial");
        }
    }
}

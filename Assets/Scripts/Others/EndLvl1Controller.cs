using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLvl1Controller : MonoBehaviour
{
    private PlayerCollisionsController pcc;

    private void Start()
    {
        pcc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisionsController>();
    }

    private void Update()
    {
        if (pcc.final_lvl1)
        {
            VariablesController.Nivel2 = true;
            SceneManager.LoadScene("Nivel2");
        }
            
    }
}


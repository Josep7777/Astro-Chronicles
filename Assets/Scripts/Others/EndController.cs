using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public bool flag = false;
    private float tiempo = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            if(tiempo>=1.5f)
                SceneManager.LoadScene("FinalLvl1");
            tiempo += Time.deltaTime;
        }
    }
}

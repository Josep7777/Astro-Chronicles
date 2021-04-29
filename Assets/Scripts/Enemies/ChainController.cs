using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainController : MonoBehaviour
{
    public Transform boss;
    private float contador = 1;
    private bool flag_rot_dere = false;
    private bool flag_rot_izqui = false;
    private bool aux = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (aux)
        {
            flag_rot_izqui = false;
            flag_rot_dere = true;
            contador += Time.deltaTime;
            if(contador >= 1) aux = false;
        } else
        {
            flag_rot_dere = false;
            flag_rot_izqui = true;
            contador -= Time.deltaTime;
            if (contador <= 0.05) aux = true;
        }

        if (flag_rot_izqui)
        {
            Vector3 axis = new Vector3(0, 0, 1);
            transform.RotateAround(boss.position, axis, Time.deltaTime * 200);
            //contador -= Time.deltaTime;
        }

        if (flag_rot_dere)
        {
            Vector3 axis = new Vector3(0, 0, -1);
            transform.RotateAround(boss.position, axis, Time.deltaTime * 200);
            //contador -= Time.deltaTime;
        }
    }
}

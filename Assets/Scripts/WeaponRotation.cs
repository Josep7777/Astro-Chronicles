using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
 
    public GameObject jugador;
    public GameObject suelo;
    public GameObject paredDere;
    public GameObject paredIzqui;

    private void FixedUpdate()
    {
        //suelo.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        //paredDere.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        //paredIzqui.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
  
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90)
        {

            if (jugador.transform.eulerAngles.y == 0)
            {


                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);




            }
            else if (jugador.transform.eulerAngles.y == 180)
            {


                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);


            }

        }

    }

}

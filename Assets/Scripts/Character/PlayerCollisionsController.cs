using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionsController : MonoBehaviour
{
    public float monedas=0;
    public GameObject salto_pos;
    public bool flag_pu_salto=false;
    public bool flag_pu_velocidad=false;
    public float velocidad_timer=0;
    public GameObject velocidad_pos;
    public bool flag_escopeta=false;
    public bool final_lvl1 = false;
    private WeaponController wp;

    // Start is called before the first frame update
    void Start()
    {
        wp = GameObject.FindGameObjectWithTag("gamecontroller").GetComponent<WeaponController>();
        salto_pos = new GameObject();
        velocidad_pos = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Moneda" && this.gameObject.tag != "Untagged")
        {
            Destroy(other.gameObject);
            monedas++;
            //contador.text = monedas.ToString();
        }

        if (other.gameObject.tag == "PowerupSalto")
        {
            salto_pos.transform.position = other.gameObject.transform.position;
            Destroy(other.gameObject);
            flag_pu_salto = true;
        }

        if (other.gameObject.tag == "PowerupVelocidad")
        {
            //Debug.Log(other.gameObject.transform.position);
            velocidad_pos.transform.position = other.gameObject.transform.position;

            Destroy(other.gameObject);
            velocidad_timer = 10.0f;
            flag_pu_velocidad = true;
        }

        if (other.gameObject.tag == "Escopeta")
        {
            Destroy(other.gameObject);
            wp.arma_actual = "Escopeta";
            flag_escopeta = true;

        }

        if (other.gameObject.tag == "Final")
        {
            final_lvl1 = true;
            //SceneManager.LoadScene("FinalLvl1");
        }

    }
}

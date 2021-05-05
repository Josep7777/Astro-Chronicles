using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PickUpsController : MonoBehaviour
{
    //private float monedas;
    private bool aux;

    //public bool flag_pu_salto;
    //public bool flag_pu_velocidad;
    //public bool flag_escopeta;
    public Text contador;
    public Text saltoContador;
    public Image saltoImg;
    public Text velocidadContador;
    public Image velocidadImg;
    //private float velocidad_timer;
    //private GameObject salto_pos;
    //private GameObject velocidad_pos;

    public GameObject powerup_salto;
    public GameObject powerup_velocidad;

    private PlayerCollisionsController pcc;

    //WeaponController weaponcontroller;

    private void Start()
    {
        pcc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollisionsController>();
        //monedas = 0;
        aux = false;
        //flag_pu_salto = false;
        //flag_pu_velocidad=false;
        //flag_escopeta = false;
        //salto_pos = new GameObject();
        //velocidad_pos = new GameObject();
        //weaponcontroller = this.GetComponent<WeaponController>();
    }

    private void Update()
    {
        contador.text = pcc.monedas.ToString();

        if (pcc.flag_pu_salto)
        {
            saltoImg.gameObject.SetActive(true);
            saltoContador.gameObject.SetActive(true);
            saltoContador.text = "x1";
            aux = true;
        }
        else
        {
            if (aux)
            {
                Instantiate(powerup_salto, pcc.salto_pos.transform.position, Quaternion.identity);
                saltoImg.gameObject.SetActive(false);
                saltoContador.gameObject.SetActive(false);
                aux = false;
            }
        }

        if (pcc.flag_pu_velocidad)
        {
            velocidadImg.gameObject.SetActive(true);
            velocidadContador.gameObject.SetActive(true);           
            pcc.velocidad_timer -= Time.deltaTime;
            velocidadContador.text = pcc.velocidad_timer.ToString();
            
            if (pcc.velocidad_timer <= 0.0f)
            {
                Instantiate(powerup_velocidad,pcc.velocidad_pos.transform.position,Quaternion.identity);
                pcc.flag_pu_velocidad = false;
            }
        }
        else
        {
            velocidadImg.gameObject.SetActive(false);
            velocidadContador.gameObject.SetActive(false);
        }
    }

    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Moneda" && this.gameObject.tag!="Untagged")
        {
            Destroy(other.gameObject);
            monedas++;
            contador.text = monedas.ToString();
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
            weaponcontroller.arma_actual = "Escopeta";
            flag_escopeta = true;

        }
    }*/
}
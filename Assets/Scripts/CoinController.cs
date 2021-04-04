using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private float monedas;
    private bool aux;

    public bool flag_pu_salto;
    public bool flag_pu_velocidad;
    public bool flag_escopeta;
    public Text contador;
    public Text saltoContador;
    public Image saltoImg;
    public Text velocidadContador;
    public Image velocidadImg;
    private float velocidad_timer;
    private GameObject salto_pos;
    private GameObject velocidad_pos;

    public GameObject powerup_salto;
    public GameObject powerup_velocidad;

    WeaponController weaponcontroller;

    private void Start()
    {
        monedas = 0;
        aux = false;
        flag_pu_salto = false;
        flag_pu_velocidad=false;
        flag_escopeta = false;
        salto_pos = new GameObject();
        velocidad_pos = new GameObject();
        weaponcontroller = this.GetComponent<WeaponController>();
    }

    private void Update()
    {
        if (flag_pu_salto)
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
                Instantiate(powerup_salto, salto_pos.transform.position, Quaternion.identity);
                saltoImg.gameObject.SetActive(false);
                saltoContador.gameObject.SetActive(false);
                aux = false;
            }
        }

        if (flag_pu_velocidad)
        {
            velocidadImg.gameObject.SetActive(true);
            velocidadContador.gameObject.SetActive(true);           
            velocidad_timer -= Time.deltaTime;
            velocidadContador.text = velocidad_timer.ToString();
            
            if (velocidad_timer <= 0.0f)
            {
                Instantiate(powerup_velocidad,velocidad_pos.transform.position,Quaternion.identity);
                flag_pu_velocidad = false;
            }
        }
        else
        {
            velocidadImg.gameObject.SetActive(false);
            velocidadContador.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Ey");
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
    }
}
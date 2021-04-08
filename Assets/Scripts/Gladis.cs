using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gladis : MonoBehaviour
{
    public GameObject Panel; 
    public GameObject TextBox;
    public GameObject Accept;
    private int choiseMade;
    private PlayerHealth ph;

    void Start()
    {
        ph = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        Panel.gameObject.SetActive(false);
        choiseMade = 0;
    }

    public void AcceptButton()
    {
        if (choiseMade == 0)
        {
            TextBox.GetComponent<Text>().text = "Entendido señor, procesando a restaurar sus puntos de salud.";
            ph.playerHealth = ph.playerMaxHealth;
            ph.healthBar.SetHealth(ph.playerHealth);
            choiseMade = 1;
        } else
        {
           TextBox.GetComponent<Text>().text = "Lo siento mi señor, no tengo la suficiente bateria para poder ayudarle.";
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Panel.gameObject.SetActive(true);

        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        Panel.gameObject.SetActive(false);
    }
    

}

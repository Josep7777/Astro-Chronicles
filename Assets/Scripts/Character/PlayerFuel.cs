using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuel : MonoBehaviour
{
    public int playerMaxFuel;
    public int playerFuel;
    public float tiempo_inmortal = 1f;

    public PlayerFuelBar fBar;
    public CharacterController cc;



    void Start()
    {
        cc = this.GetComponent<CharacterController>();
        fBar = this.GetComponent<PlayerFuelBar>();
        playerFuel = playerMaxFuel;

    }

    private void Update()
    {
        Debug.Log(playerFuel);
        /*
        //tiempo_inmortal -= Time.deltaTime;
        if (playerFuel <= 0)
        {
            //cc.flying = false;
            // Debug.Log("ola");
        }
        */
        if (cc.flying == true)
        {
            playerFuel = playerFuel - 1;
            //fBar.SetFuel(playerFuel);
            //tiempo_inmortal = 1f;

        }
    }




}

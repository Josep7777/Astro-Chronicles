using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerFuelBar : MonoBehaviour
{
    public Slider fuelBar;
    private CharacterController playerFuel;

    private void Start()
    {
        playerFuel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        fuelBar = GetComponent<Slider>();
        fuelBar.maxValue = playerFuel.playerMaxFuel;
        fuelBar.value = playerFuel.playerMaxFuel;
    }

    public void SetFuel(int fuel)
    {
        fuelBar.value = fuel;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLights : MonoBehaviour
{
    public Alarm alarm;
    public GameObject alarmLights;
    // Start is called before the first frame update
    void Start()
    {
        alarmLights.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (alarm.alarmTrap == true)
        {
            alarmLights.SetActive(true);
        }
    }
}

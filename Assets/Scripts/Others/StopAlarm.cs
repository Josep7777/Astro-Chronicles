using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAlarm : MonoBehaviour
{
    public Alarm alarm;
    public GameObject staticLights;
    public AudioSource bossWrath;
    
    // Start is called before the first frame update
    void Start()
    {
        staticLights.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            alarm.alarmSound.Stop();
            alarm.runMusic.Stop();
            alarm.alarmTrap = false;
            alarm.alarmLights.SetActive(false);
            staticLights.SetActive(true);
            bossWrath.Play();
        }
    }
}

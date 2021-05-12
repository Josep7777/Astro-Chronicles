using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public AudioSource alarmSound;
    public CameraController cameraController;
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;
    public bool alarmTrap;

    public float speed;

    public Transform childTransform;
    public AudioSource runMusic;
    public Transform transformB;
    public GameObject alarmLights;
    // Start is called before the first frame update
    void Start()
    {
        alarmTrap = false;
        posB = childTransform.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;
        alarmLights.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(alarmTrap == true)
        {
           Move();
           alarmLights.SetActive(true);
        }

    }

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            runMusic.Play();
            alarmSound.Play();
            alarmTrap = true;
            cameraController.gameMusic.Stop();
        }
    }
}

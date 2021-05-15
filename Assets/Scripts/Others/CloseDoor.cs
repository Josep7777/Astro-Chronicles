using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;
    private bool closeDoor;
    public AudioSource closeDoorSound;


    public float speed;

    public Transform childTransform;

    public Transform transformB;
    // Start is called before the first frame update
    void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;
        closeDoor = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if(closeDoor == true)
        {
            Move();
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
            if(closeDoor == false)
            {
                closeDoor = true;
                closeDoorSound.Play();
            }

        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("BBB");
        if (collision.collider.tag == "Player")
        {
            Debug.Log("AAA");
            collision.collider.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, transform.parent.gameObject.GetComponent<PlataformMovement>().nextPos, transform.parent.gameObject.GetComponent<PlataformMovement>().speed * Time.deltaTime);
        }
    }*/
}

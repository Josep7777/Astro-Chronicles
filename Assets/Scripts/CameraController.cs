using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Camera cam;
    public float zoom;

    // Start is called before the first frame update
    void Start()
    {
        //cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoom, Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCamera : MonoBehaviour
{
    [SerializeField]
    private float cameraSize;
    [SerializeField]
    private float speed;
    private Camera cam;

    //Limiting objects defined
    [SerializeField]
    private GameObject barrierRight;
    [SerializeField]
    private GameObject barrierLeft;
    [SerializeField]
    private GameObject barrierTop;
    [SerializeField]
    private GameObject barrierBottom;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        var d = Input.GetAxis("Mouse ScrollWheel");

        //Define Camera Movement Limits
        if (Input.GetKey(KeyCode.D) && transform.position.x + width / 2 <= barrierLeft.transform.position.x)
        {
            transform.Translate(Vector2.right * (speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x - width /2 >= barrierRight.transform.position.x)
        {
            transform.Translate(Vector2.left * (speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y - height / 2 > barrierBottom.transform.position.y)
        {
            transform.Translate(Vector2.down * (speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.W) && transform.position.y + height / 2 < barrierTop.transform.position.y)
        {
            transform.Translate(Vector2.up * (speed * Time.deltaTime));
        }
        // Camera Zoom Out
        if (transform.position.x + width / 2 >= barrierLeft.transform.position.x &&
            transform.position.x - width / 2 <= barrierRight.transform.position.x &&
            transform.position.y - height / 2 >= barrierBottom.transform.position.y &&
            transform.position.y + height / 2 <= barrierTop.transform.position.y)
        {
            if (d < 0f) {
                transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
                cam.orthographicSize += 0.5f;
            }
        }
        // Camera Zoom In
        if (d > 0f && cam.orthographicSize >= 5.0f) {
            cam.orthographicSize -= 0.5f;
        }

    }
}

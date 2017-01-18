using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{
    const int orthographicSizeMin = 1;
    const int orthographicSizeMax = 8;
    public float keyScrollSpeed;

    Camera cam;
    Vector3 centerScreen;

    void Awake()
    {
        cam = Camera.main;
        centerScreen = (new Vector3(0, 0, -10));
    }

    void Update()
    {
        if(Input.anyKey)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                cam.transform.position += Vector3.left * keyScrollSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                cam.transform.position += Vector3.right * keyScrollSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                cam.transform.position += Vector3.up * keyScrollSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                cam.transform.position += Vector3.down * keyScrollSpeed * Time.deltaTime;
            }
        }


        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize < orthographicSizeMax) //zoom in
        {
            cam.orthographicSize += 30 * Time.deltaTime;
            cam.transform.position = Vector3.Lerp(cam.transform.position, centerScreen, 10 * Time.deltaTime);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {           
            if (cam.orthographicSize > orthographicSizeMin)  //zoom out
            {
                cam.orthographicSize -= 30 * Time.deltaTime;
            }           
            
           cam.transform.position = Vector3.Lerp(cam.transform.position, (new Vector3(GetComponent<PlaceSquare>().target_position.x, GetComponent<PlaceSquare>().target_position.y, 0.0f)), 10 * Time.deltaTime);
        }
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, orthographicSizeMin, orthographicSizeMax);
    }
}

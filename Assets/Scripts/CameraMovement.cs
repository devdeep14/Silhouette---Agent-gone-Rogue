using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;
    public float cameraSpeed = 5.0f;
    public float xPos;public float yPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 camPos = transform.position;
        camPos.x = player.transform.position.x + xPos;
        transform.position = Vector2.Lerp(transform.position, camPos, 3 * Time.fixedDeltaTime);

        camPos.y = player.transform.position.y + yPos;
        transform.position = Vector2.Lerp(transform.position, camPos, 3 * Time.fixedDeltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Vector2 startPos;
    private Vector2 diference;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
        startPos = transform.position;
        diference = playerMovement.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.transform.position.x > 0)
            transform.position = new Vector3(startPos.x + playerMovement.transform.position.x, transform.position.y, -10);
    }

    public void restoreCameraPosition()
    {
        transform.position = new Vector3(0, 0, -10);
    }
}

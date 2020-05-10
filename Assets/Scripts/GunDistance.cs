using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDistance : MonoBehaviour
{
    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerMovement.transform.position;
        transform.localScale = playerMovement.transform.localScale;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Input.GetKey(KeyCode.Q) && playerMovement.isSuper)
        {
            Destroy(collision.gameObject);
        }
    }

}

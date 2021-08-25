using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision is BoxCollider2D)
            {
                PickUp(collision);
            }

        }
    }

    private void PickUp(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        player.currentLives += 1;

        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUpScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float durations;
    public float powerupApplied;
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
                StartCoroutine(PickUp(collision));
            }
        }
    }

    IEnumerator PickUp(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        player.jumpVelocity += powerupApplied;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(durations);

        player.jumpVelocity -= powerupApplied;

        Destroy(gameObject);
    }
}

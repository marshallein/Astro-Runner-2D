using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerUpScript : MonoBehaviour
{
    public float durations;
    public int powerupApplied;
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
        player.shootDamage += powerupApplied;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(durations);

        player.shootDamage -= powerupApplied;

        Destroy(gameObject);
    }
}

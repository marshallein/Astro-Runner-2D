using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update


    public Rigidbody2D rb;

    public GameObject ImpactFX;
    public PlayerController player;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        rb.velocity = transform.right * player.shootSpeed;
        StartCoroutine(WhenNotHit());
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        TakeDamageControl enemy = collision.GetComponent<TakeDamageControl>();
        if (enemy != null)
        {
            enemy.TakeDamage(player.shootDamage);
            Debug.Log("hit");
        }

        Instantiate(ImpactFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    IEnumerator WhenNotHit()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}

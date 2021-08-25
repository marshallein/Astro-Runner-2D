using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageControl : MonoBehaviour
{
    public float MaxHealth;
    public GameObject impact;

    public AudioSource hurtSound;
    public AudioSource dieSound;

    public string screamSound;

    private float currentHeath;
    // Start is called before the first frame update
    void Start()
    {
        hurtSound = GameObject.Find("EnemyHurt").GetComponent<AudioSource>();
        dieSound = GameObject.Find(screamSound).GetComponent<AudioSource>();

        currentHeath = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int damage)
    {
        currentHeath -= damage;
        hurtSound.Play();
        if (currentHeath <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        dieSound.Play();
        Instantiate(impact, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

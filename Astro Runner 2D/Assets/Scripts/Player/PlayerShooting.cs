using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject Bullet;
    public Animator animator;
    public AudioSource shootSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Shoot");
            shootSound.Play();
            Shoot();
        }
    }


    void Shoot()
    {
        Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
    }
}

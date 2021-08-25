using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public float depth;


    public Transform leftLimit;
    public Transform RightLimit;

    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float realVelocity = player.speed / depth;

        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.fixedDeltaTime;

        if (pos.x <= leftLimit.position.x) 
        {
            pos.x = RightLimit.position.x;
        }

        transform.position = pos;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public GameObject destroyPoint;

    // Start is called before the first frame update
    void Start()
    {
        destroyPoint = GameObject.Find("PlatformDestroyPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < destroyPoint.transform.position.x)
        {
            Destroy(gameObject);

            //gameObject.SetActive(false);
        }
    }
}

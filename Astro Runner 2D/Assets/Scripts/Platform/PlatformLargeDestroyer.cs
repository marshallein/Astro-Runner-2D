using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLargeDestroyer : MonoBehaviour
{

    public GameObject destroyPoint;
    public spawnEnemy check;
    // Start is called before the first frame update
    void Start()
    {
        destroyPoint = GameObject.Find("PlatformDestroyPoint");
        check = GetComponent<spawnEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < destroyPoint.transform.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            check.spawn = true;
        }
    }
}

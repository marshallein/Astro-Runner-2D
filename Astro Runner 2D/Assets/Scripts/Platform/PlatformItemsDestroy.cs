using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformItemsDestroy : MonoBehaviour
{
    public GameObject destroyPoint;
    public SpawnItems check;
    // Start is called before the first frame update
    void Start()
    {
        destroyPoint = GameObject.Find("PlatformDestroyPoint");
        check = GetComponent<SpawnItems>();
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

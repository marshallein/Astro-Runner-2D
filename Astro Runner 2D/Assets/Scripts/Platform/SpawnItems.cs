using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{

    public GameObject[] items;
    public Transform spawnItem;
    public bool spawn = true;
    public GameObject boothforSpawn;
    private int randomNumber;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            if (gameObject.activeInHierarchy == true)
            {
                if (Random.value <= 0.4)
                {
                    //StartCoroutine(SpawnEnemyTimer());
                    boothforSpawn.SetActive(true);
                    Instantiate(items[Random.Range(0, items.Length)], spawnItem.position, spawnItem.rotation);
                    Debug.Log("spawn");
                }

            }
            spawn = false;
        }
    }

}

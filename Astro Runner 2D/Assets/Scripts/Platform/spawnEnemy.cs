using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public Transform SpawnPoint;
    public bool spawn = true;
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
            //StartCoroutine(SpawnEnemyTimer());
            Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
        }
            spawn = false;
        }

        //if(gameObject.activeInHierarchy == false)
        //{
        //    spawn = true;
        //}
    }


    //IEnumerator SpawnEnemyTimer()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
    //}
}

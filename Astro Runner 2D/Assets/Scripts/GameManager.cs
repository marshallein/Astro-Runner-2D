using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform platformGenerator;
    public PlayerController player;
    public DeathMenuControl menu;


    private Vector3 platformStartPoint;
    private Vector3 playerStartPoint;
    private PlatformDestroyController[] platformDestroys;
    private PlatformLargeDestroyer[] platformLargeDestroyers;
    private PlatformItemsDestroy[] platformItemsDestroyers;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()
    {
        //StartCoroutine(RestartGameTimer());
        player.gameObject.SetActive(false);

        menu.gameObject.SetActive(true);
    }

    public void ResetScene()
    {
        platformDestroys = FindObjectsOfType<PlatformDestroyController>();
        platformLargeDestroyers = FindObjectsOfType<PlatformLargeDestroyer>();
        platformItemsDestroyers = FindObjectsOfType<PlatformItemsDestroy>();
        for (int i = 0; i < platformDestroys.Length; i++)
        {
            platformDestroys[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < platformLargeDestroyers.Length; i++)
        {
            platformLargeDestroyers[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < platformItemsDestroyers.Length; i++)
        {
            platformItemsDestroyers[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);
        menu.gameObject.SetActive(false);
    }

    //IEnumerator RestartGameTimer()
    //{
    //    player.gameObject.SetActive(false);
    //    yield return new WaitForSeconds(1f);

    //    platformDestroys = FindObjectsOfType<PlatformDestroyController>();
    //    platformLargeDestroyers = FindObjectsOfType<PlatformLargeDestroyer>();
    //    for (int i = 0; i < platformDestroys.Length; i++)
    //    {
    //        platformDestroys[i].gameObject.SetActive(false);
    //    }
    //    for (int i = 0; i < platformLargeDestroyers.Length; i++)
    //    {
    //        platformLargeDestroyers[i].gameObject.SetActive(false);
    //    }
    //    player.transform.position = playerStartPoint;
    //    platformGenerator.position = platformStartPoint;
    //    player.gameObject.SetActive(true);
    //}

}

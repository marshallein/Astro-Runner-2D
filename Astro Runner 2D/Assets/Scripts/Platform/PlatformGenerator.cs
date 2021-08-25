using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;
    public ObjectPooler[] pooler;
    public float distanceWidthMin;
    public float distanceWidthMax;
    public Transform maxHeightPoint;
    public float maxHeightChange;
    //public GameObject[] thePlatforms;

    private float platformWidth;
    private int platformSelector;
    private float[] transformWidths;
    private float minHeight;
    private float maxHeight;
    private float heightChange;


    // Start is called before the first frame update
    void Start()
    {
        // platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        transformWidths = new float[pooler.Length];

        for (int i = 0; i < pooler.Length; i++)
        {
            transformWidths[i] = pooler[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {

            distanceBetween = Random.Range(distanceWidthMin, distanceWidthMax);

            platformSelector = Random.Range(0, pooler.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);


            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            } else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (transformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);



            //Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = pooler[platformSelector].GetGameObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);


            transform.position = new Vector3(transform.position.x + (transformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
    }
}

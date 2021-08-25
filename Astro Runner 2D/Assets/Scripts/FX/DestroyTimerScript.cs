using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float waitTime;
    void Start()
    {
        StartCoroutine(Destroytimer(waitTime));
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator Destroytimer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}

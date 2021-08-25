using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontrol : MonoBehaviour
{

    PlayerController player;

    Text DistanceText;
    Text LivesText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        DistanceText = GameObject.Find("Distance").GetComponent<Text>();
        LivesText = GameObject.Find("Lives").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int live = (int)player.currentLives;
        LivesText.text = "Lives :" + live;


        int distance = (int)player.distance;
        DistanceText.text = distance + " M ";
    }
}

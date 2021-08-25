using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    //public PlayerController player;

    //private Vector3 lastPlayerPosition;
    //private float distanceToMove;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    player = GameObject.Find("Player").GetComponent<PlayerController>();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //    distanceToMove = player.transform.position.x - lastPlayerPosition.x;

    //    transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

    //    lastPlayerPosition = player.transform.position;
    //}


    public Transform character;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothfactor;


    private void FixedUpdate()
    {
        Follow();
    }


    void Follow()
    {
        if (character == null)
        {
            this.enabled = false;
        }
        else
        {
            //Vector3 characterPosition = character.position + offset;
            Vector3 characterPosition = new Vector3(character.position.x + offset.x, transform.position.y, character.position.z + offset.z);
            Vector3 smoothPosition = Vector3.Lerp(transform.position, characterPosition, smoothfactor * Time.fixedDeltaTime);
            transform.position = characterPosition;
        }

    }

}

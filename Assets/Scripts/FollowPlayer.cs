using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour

{
    public Transform player;
    private int speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = transform.position; // stores the current position
        Vector3 playerPosition = player.transform.position + new Vector3(0, 4, -5); // get the position of the player
        transform.position = Vector3.Lerp(startPosition, playerPosition, Time.deltaTime*speed); // follow the player
    }
}

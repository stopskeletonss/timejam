using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour

{
    public Transform player;
    private int speed = 5;
    public int followDistance;
    public int followHeight;

    // Start is called before the first frame update
    void Start()
    {
        followDistance *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = transform.position; // stores the current position
        Vector3 playerPosition = player.transform.position + new Vector3(0, followHeight, followDistance); // get the position of the player
        transform.position = Vector3.Lerp(startPosition, playerPosition, Time.deltaTime*speed); // follow the player
    }
}

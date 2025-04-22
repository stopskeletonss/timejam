using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizard : MonoBehaviour
{
    public float evilWizardSpeed; // speed of the evil wizard's movement
    public int range; // range at which the evil wizard follows the player
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = transform.position; // stores the current position of the evil wizard
        Vector3 playerPosition = player.position; // stores the current position of the player

        if (Vector3.Distance(playerPosition, startPosition) <= range) // check if the player is within range
        {
            transform.position = Vector3.Lerp(startPosition, playerPosition, Time.deltaTime * evilWizardSpeed); // follow the player
        }

    }
}

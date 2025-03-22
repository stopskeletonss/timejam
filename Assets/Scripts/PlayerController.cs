using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim; // references the animator to control animations
    private int speed; // speed of the player's movement

    private Queue<Vector3> positions = new Queue<Vector3>(); // stores the player's previous positions
    private Queue<float> times = new Queue<float>(); //stores the times for each stored position
    private float storeDuration = 3f; // duration to store positions
    private float rewindDuration = 1f; // duration of rewind mechanic

    private bool rewinding = false; // flag to check if rewind is in progress

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!rewinding) // only allow button and mouse events to be triggered if rewind is not in progress
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerAnim.Play("attack1");
            }
            else if (Input.GetMouseButtonDown(1))
            {
                playerAnim.Play("attack2");
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * speed * Time.deltaTime; // move left
                playerAnim.SetBool("isRunning", true);
                playerAnim.transform.localScale = new Vector3(-2f, 2f, 1f); // flip facing direction to the left
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * speed * Time.deltaTime; // move right
                playerAnim.SetBool("isRunning", true);
                playerAnim.transform.localScale = new Vector3(2f, 2f, 1f); //flip facing direction to the right
            }
            else
            {
                playerAnim.SetBool("isRunning", false);
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * speed * Time.deltaTime; // move up
                playerAnim.SetBool("isRunning", true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * speed * Time.deltaTime; // move down
                playerAnim.SetBool("isRunning", true);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnim.Play("jump");
            }

            if (Input.GetKey(KeyCode.R))
            {
                Vector3 targetPosition = positions.Peek(); // get the oldest stored position
                StartCoroutine(Rewind(targetPosition));
                playerAnim.SetBool("isRewinding", true);
            }
        }

        positions.Enqueue(transform.position); // stores the current position at every frame
        times.Enqueue(Time.time); // stores the current time at every frame

        while (times.Count > 0 && Time.time - times.Peek() > storeDuration) // remove positions and their corresponding times after they have been in the queue for 3 seconds
        {
            positions.Dequeue();
            times.Dequeue();
        }
    }

    IEnumerator Rewind(Vector3 targetPosition)
    {
        rewinding = true;
        Vector3 startPosition = transform.position; // stores the current position before rewinding
        float elapsedTime = 0f;

        while (elapsedTime < rewindDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / rewindDuration); // interpolate the current position to the target position 
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        rewinding = false;
        playerAnim.SetBool("isRewinding", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerAnim.Play("attack1");
        }
        else if (Input.GetMouseButtonDown(1))
        {
            playerAnim.Play("attack2");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            playerAnim.SetBool("isRunning", true);
            playerAnim.transform.localScale = new Vector3(-2f, 2f, 1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            playerAnim.SetBool("isRunning", true);
            playerAnim.transform.localScale = new Vector3(2f, 2f, 1f);
        }
        else
        {
            playerAnim.SetBool("isRunning", false);
        }
    }
}

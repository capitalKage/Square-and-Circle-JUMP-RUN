using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float walkingSpeed = 3.0f, runSpeed = 3.0f, jumpForce = 10f, gravityScale = 5f, distanceToCheck = 1f;
    [SerializeField]
    private bool ground;
    private Rigidbody rb;
    private Vector2 walkingMovement;
    private Vector2 runningMovement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        walkingMovement = new Vector2(Input.GetAxis("Horizontal"), 0f);

        if (Input.GetButtonDown("Jump")&& ground) //&& gameOver == false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //gameObject.GetComponent<AudioSource>().PlayOneShot(jump);
            //ground = false;
        }
    }

    private void FixedUpdate()
    {
        characterWalking(walkingMovement);
        characterRunning(walkingMovement);
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
        GroundCheck();
    }

    void characterWalking(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * walkingSpeed * Time.deltaTime));
    }

    void characterRunning(Vector2 direction)
    {
        if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition((Vector2)transform.position + (direction * walkingSpeed * runSpeed * Time.deltaTime));

        }
    }

    void GroundCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distanceToCheck + 0.1f))
        {
            Debug.Log("ground");
            ground = true;
        }
        else
        {
            Debug.Log("air");
            ground = false;
        }
    }
}

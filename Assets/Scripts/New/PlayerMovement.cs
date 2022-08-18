using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float walkingSpeed = 3.0f, runSpeed = 3.0f, jumpForce = 10f, gravityScale = 5f, distanceToCheck = 1f;
    [SerializeField]
    private bool ground;
    private float runningEndurance = 10;
    private Rigidbody rb;
    private Vector2 walkingMovement;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        walkingMovement = new Vector2(Input.GetAxis("Horizontal"), 0f);
        slider.value = runningEndurance;

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
        if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && runningEndurance > 0)
        {
            rb.MovePosition((Vector2)transform.position + (direction * walkingSpeed * runSpeed * Time.deltaTime));
            runningEndurance -= 4f * Time.fixedDeltaTime;
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift) && runningEndurance < 10)
        {
            runningEndurance += 1 * Time.fixedDeltaTime;
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

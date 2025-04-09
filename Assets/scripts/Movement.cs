using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController characterController;
    public Animator anim;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool moving = false;
    bool grounded;
    Vector3 velocity;

    public float gravity = -9.81f;
    public float speed = 5f;

    public float jumpForce = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"), z = Input.GetAxis("Vertical");
        moving = !((x == 0.0f) && (z == 0.0f));
        anim.SetBool("moving", moving);

        Vector3 move = transform.right * x + transform.forward * z;
        transform.rotation = Quaternion.LookRotation(move, Vector3.up);
        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime / 2);

        grounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        if (grounded && (velocity.y < 0))
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }
}

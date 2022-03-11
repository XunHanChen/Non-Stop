using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charJump : MonoBehaviour
{
    private Animator animator;
    public float jumpheight = 1;
    public float gravity = -9.10f;

    public Transform groundCheck;
    public float groundDis = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("Jumping", true);
            Invoke("stopJumping", 0.1f);
        }

        //isGrounded = Physics.CheckCapsule(groundCheck.position, groundDis, groundMask);

        //if(isGrounded && velocity.y < 0)
        //{
        //    velocity.y = -2f;
        //}
    }

    void stopJumping()
    {
        animator.SetBool("Jumping", false);
    }
}

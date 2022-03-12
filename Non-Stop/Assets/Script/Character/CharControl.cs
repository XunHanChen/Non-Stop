using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharControl : MonoBehaviour
{
    public GameObject character;
    public Transform boomObj;
    private Animator animator;

    public string controlLocked = "n";
    public int laneNum = 0;
    public KeyCode moveL;
    public KeyCode moveR;
    public static float horizVel = 0;

    public float speed = 5;
    public float slideSpeed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    //[SerializeField] float horizontalMultiplier = 2;
    public int jumpInput = 0;

    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpForce = 400f;
    //[SerializeField] LayerMask groundMask;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        //Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        Vector3 horizontalMove = transform.right * horizVel * slideSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    void Update()
    {
      
        //horizontalInput = Input.GetAxis("Horizontal");

        if ((Input.GetKeyDown(moveL)) && (laneNum > -1) && controlLocked == "n")
        {
            horizVel = -1;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlLocked = "y";
        }

        if ((Input.GetKeyDown(moveR)) && (laneNum < 1) && controlLocked == "n")
        {
            horizVel = 1;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = "y";
        }

        if (jumpInput == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jumpInput = 1;
                Jump();
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(character);
            GM.zVelAdj = 0;
            Instantiate(boomObj, transform.position, boomObj.rotation);
            GM.lvlCompStatus = "Fail";
        }

        if (other.gameObject.tag == "Ground")
        {
            jumpInput = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "rampBotTrig")
        {
            GM.vertVel = 2;
        }

        if (other.gameObject.name == "rampTopTrig")
        {
            GM.vertVel = 0;
        }

        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            GM.coinTotal += 1;
        }

        if (other.gameObject.name == "goal1")
        {
            SceneManager.LoadScene("Win1");
        }

        //if (other.gameObject.name == "goal2")
        //{
        //    SceneManager.LoadScene("Level3");
        //}

    }

    void Jump()
    {
        animator.SetTrigger("Jump");

        // Check ground
        float height = GetComponent<Collider>().bounds.size.y;
        //bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        //If jump
        rb.AddForce(Vector3.up * jumpForce);
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.5f);
        horizVel = 0;
        controlLocked = "n";
    }
}

   
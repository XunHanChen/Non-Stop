using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharControl : MonoBehaviour
{
    public GameObject character;
    public Transform boomObj;
    private Animator animator;

    public string controlLocked = "n";
    public static int laneNum = 0;
    public KeyCode moveL;
    public KeyCode moveR;
    public static int horizVel = 0;
    public Button Left;
    public Button Right;

    public int speed = 10;
    public int slideSpeed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    //[SerializeField] float horizontalMultiplier = 2;
    public int jumpInput = 0;
    int fingerCount = 0;

    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpForce = 400f;
    //[SerializeField] LayerMask groundMask;

    public GameObject Laser;

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

        //if ((Input.GetKeyDown(KeyCode.LeftArrow)))
        //{
        //    if(horizVel == 0)
        //    {
        //        horizVel = -2;
        //    }
        //    else
        //    if (horizVel == -2)
        //    {
        //        horizVel = -0;
        //    }
        //}
        //else if ((Input.GetKeyDown(KeyCode.RightArrow)))
        //{
        //    if (horizVel == 0)
        //    {
        //        horizVel = 2;
        //    }
        //    else
        //    if (horizVel == 2)
        //    {
        //        horizVel = -0;
        //    }
        //}

        if (jumpInput == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jumpInput = 1;
                Jump();
            }
        }

        //Jump
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
            }
        }
        if (fingerCount > 0)
        {
            jumpInput = 1;
            Jump();
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

        if (other.gameObject.tag == "LaserOpen")
        {
            //Destroy(other.gameObject);
            Laser.SetActive(true);
        }

        if (other.gameObject.tag == "LaserClose")
        {
            //Destroy(other.gameObject);
            Laser.SetActive(false);
        }

        if (other.gameObject.name == "goal1")
        {
            SceneManager.LoadScene("Win1");
        }

        if (other.gameObject.name == "goal2")
        {
            SceneManager.LoadScene("Win2");
        }

        if (other.gameObject.name == "goal3")
        {
            SceneManager.LoadScene("Win3");
        }
    }

    public void slideLeft()
    {
        if ((laneNum > -1) && controlLocked == "n")
        {
            horizVel = -1;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlLocked = "y";
        }
    }

    public void slideRight()
    {
        if ((laneNum < 1) && controlLocked == "n")
        {
            horizVel = 1;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = "y";
        }
    }

    public void Jump()
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
        yield return new WaitForSeconds(0.4f);
        horizVel = 0;
        controlLocked = "n";
    }
}

   
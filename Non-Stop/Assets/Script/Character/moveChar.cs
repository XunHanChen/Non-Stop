using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveChar : MonoBehaviour
{
    private Animator animator;

    public KeyCode moveL;
    public KeyCode moveR;

    public float horizVel = 0;
    public int laneNum = 0;
    public string controlLocked = "n";

    public GameObject character;
    public Transform boomObj;

    public float jumpVel = 10;
    public float downAccel = 0.75f;
    private int jumpInput = 0;
    private bool onGround = false;
    public Vector3 _velocity;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        InputHandling();
        CheckGround();
        Jump();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, GM.vertVel, 10);


        if((Input.GetKeyDown(moveL)) && (laneNum > -1) && (controlLocked == "n"))
        {
            horizVel = -4;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlLocked = "y";
        }

        if((Input.GetKeyDown(moveR)) && (laneNum < 1) && (controlLocked == "n"))
        {
            horizVel = 4;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = "y";
        }

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    animator.SetBool("Jumping", true);
        //    Invoke("stopJumping", 0.1f);
        //}
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            Destroy(character);
            GM.zVelAdj = 0;
            Instantiate(boomObj, transform.position, boomObj.rotation);
            GM.lvlCompStatus = "Fail";
        }

        //if (other.gameObject.name == "laser")
        //{
        //    destroy(gameobject);
        //}

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
        if(jumpInput == 1 && onGround)
        {
            _velocity.y = jumpVel;
            animator.SetTrigger("Jump");
        }
        else if(jumpInput == 0 && onGround)
        {
            _velocity.y = 0;
        }
        else
        {
            _velocity.y -=  downAccel;
        }

        jumpInput = 0;
    }

    void CheckGround()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);
        RaycastHit[] hits = Physics.RaycastAll(ray, 0.5f);
        onGround = true;

        GetComponent<Rigidbody>().useGravity = true;

        foreach(var hit in hits)
        {
            if(!hit.collider.isTrigger)
            {
                if(GM.vertVel <= 0)
                {
                    GetComponent<Rigidbody>().position = Vector3.MoveTowards(GetComponent<Rigidbody>().position,
                    new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z), Time.deltaTime * 10);

                    Debug.Log("Clicked on ");
                }

                GetComponent<Rigidbody>().useGravity = false;
                onGround = true;
                break;
            }
        }
    }

    void InputHandling()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpInput = 1;
            //animator.SetBool("Jumping", true);
            //Invoke("stopJumping", 0.1f);
        }
    }

    //void stopJumping()
    //{
    //    animator.SetBool("Jumping", false);
    //}

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.5f);
        horizVel = 0;
        controlLocked = "n";
    }
}

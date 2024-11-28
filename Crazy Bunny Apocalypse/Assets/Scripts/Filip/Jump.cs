using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Rigidbody rb;
    private bool jumping = false;
    public static bool jumpAnimation;

    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 1;
    Vector3 velocity;
    GameObject player;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public bool isOnGround = true;
    public float force = 10f;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        jumpAnimation = true;
    }


    // Update is called once per frame
    void Update()
    {
        //jump
        if (Input.GetButtonDown("Jump") && isOnGround && jumping == false && !jumpAnimation)
        {
            jumping = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            //rb.AddForce(transform.forward * force, ForceMode.VelocityChange); ;
            isOnGround = false;
            StartCoroutine(Jumping());

        }

        IEnumerator Jumping(){
            Animator playerAnimator = player.GetComponent<Animator>();
            if (playerAnimator.speed == 2)
        {
            yield return new WaitForSeconds(0.85f);
            jumping = false;
        }
        else
        {
            yield return new WaitForSeconds(1.7f);
            jumping = false;
        }
        }

        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        ////walk
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");
        //Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //if (direction.magnitude >= 0.1f)
        //{
        //    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //    transform.rotation = Quaternion.Euler(0f, angle, 0f);

        //    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //    controller.Move(moveDir.normalized * speed * Time.deltaTime);
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Jump") || other.CompareTag("Water"))
        {
            //Debug.Log("Kolizija s terenom");
            isOnGround = true;
        }
    }




}

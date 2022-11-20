using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float playerSpeed;
    private SwipeControls swipeLogic;
    private bool isGrounded = false;
    public float jumpPower;
    public GameObject graphics;
    private Animator anim;

    

    // Start is called before the first frame update
    void Start()
    {
        anim = graphics.GetComponent <Animator> ();
        anim.SetBool ("isRunning", true);
        rb = GetComponent<Rigidbody2D>();
        swipeLogic = (SwipeControls)transform.GetComponent (typeof(SwipeControls));

    }

    private void FixedUpdate()
    {
        gameObject.transform.Translate (Vector2.right * playerSpeed * Time.fixedDeltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        swipeControl();
    }

    public void swipeControl()
    {
        var direction = swipeLogic.getSwipeDirection();
        if(isGrounded == true && direction == SwipeControls.SwipeDirection.Jump)
        {
            isGrounded = false;
            rb.velocity = new Vector2(0, jumpPower);
            anim.SetBool ("isJumping", true);
        }
        else if(isGrounded == true && direction==SwipeControls.SwipeDirection.Duck)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            Invoke("StandUP", 1);
            anim.SetBool("isSliding", true);
        }
    }

    public void StandUP()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        anim.SetBool("isSliding", false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }
        if (collision.gameObject.tag == "end")    //restart code
        {
            SceneManager.LoadScene("SampleScene");
        }
    }


    

   
}

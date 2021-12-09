using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float dirX;
    private SpriteRenderer sprite;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField] private float jumpForce=14f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
         dirX = Input.GetAxisRaw("Horizontal");         //raw stops player movement immediately
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if(Input.GetButtonDown("Jump"))
        {
           rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        }

        UpdateAnimation();
    }
    private void UpdateAnimation()
    {
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false; //look right
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true; //look left
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}

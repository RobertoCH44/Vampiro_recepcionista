using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform playerTransform;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rgb2D;
    public CapsuleCollider2D capsuleCollider;
    public Animator anim;
    public float jumpForce = 400f;
    public float distance;
    public float speed;
    float normalSpeed;
    bool isInteracting;
    //Ground
    public GameObject groundCheck;
    public LayerMask groundLayer;
    public float groundRadius = 0.1f;

    public AudioSource audioSource;
    public bool waterState;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        normalSpeed = speed;
    }


    void Update()
    {

        distance = Mathf.Abs(this.transform.position.x - playerTransform.position.x);
        anim.SetBool("ground", IsGrounded());

        if (distance > 3)
        {
            anim.SetBool("move", true);
            transform.position = Vector2.MoveTowards(this.transform.position, playerTransform.position, speed * Time.deltaTime);
            //Vista de personaje
            if (transform.position.x < playerTransform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            //Vista de personaje
            //Salto
            isInteracting = anim.GetBool("isInteracting");
            if (transform.position.y <= (playerTransform.position.y - 2f) && !isInteracting)
            {
                PlayTargetAnimation("Jump",true);
            }
        }
        else
        {
            anim.SetBool("move", false);
        }               
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.transform.position, groundRadius, groundLayer);
    }
    public void JumpStateEnter()
    {
        //SonidoSalto
        audioSource.Play();
        rgb2D.AddForce(new Vector2(0, jumpForce));
        //capsuleCollider.isTrigger = true;
        speed *= 2;
    }
    public void JumpStateExit()
    {
        Debug.Log("Jump Exit");
        //capsuleCollider.isTrigger = false;
        speed = normalSpeed;
    }

    public void CambioDeGravedad(float newGravity,bool water)
    {
        rgb2D.gravityScale = newGravity;
        if (water)
        {
            waterState = true;
        }
    }

    public void RestablecerGravedad(bool water)
    {
        rgb2D.gravityScale = 1;
        if (water)
        {
            waterState = false;
        }
    }

    public void PlayTargetAnimation(string targetAnim, bool isInteracting = false)
    {
        anim.CrossFade(targetAnim, 0.2f);
        anim.SetBool("isInteracting", isInteracting);
    }
}
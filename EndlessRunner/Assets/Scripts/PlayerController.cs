using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI coinText;
    public float distanceUnit = 0;
    float speed = 5;
    public int coinAmount = 0;

    private Animator animator;

    public float jumpingPower = 10f;

    public AudioSource audioSource;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("distance", 0, 1 / speed);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isGrounded", isGrounded());
    } 

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && isGrounded())
        {
            SoundManagerScript.PlaySound("jump");
            rb.velocity = new Vector2(0, jumpingPower);
        }

        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void Crouching(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            SoundManagerScript.PlaySound("slide");
            animator.SetBool("isSliding", true);
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<CircleCollider2D>().enabled = true; 
        } 
        else if (context.canceled)
        {
            audioSource.Stop();
            animator.SetBool("isSliding", false);
            this.GetComponent<BoxCollider2D>().enabled = true;
            this.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void distance()
    {
        distanceUnit = distanceUnit + 1;
        distanceText.text = distanceUnit.ToString() + "m";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Coin"))
        {
            SoundManagerScript.PlaySound("coin");
            coinAmount = coinAmount + 1;
            coinText.text = coinAmount.ToString();
            Destroy(other.gameObject);
        }
    }
}


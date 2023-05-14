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
    float distanceUnit = 0;
    float speed = 5;
    int coinAmount = 0;

    private float jumpingPower = 10f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("distance", 0, 1 / speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && isGrounded())
        {
            rb.velocity = new Vector2(0, jumpingPower);
        }

        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
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
            coinAmount = coinAmount + 1;
            coinText.text = coinAmount.ToString();
            Destroy(other.gameObject);
        }
    }
}


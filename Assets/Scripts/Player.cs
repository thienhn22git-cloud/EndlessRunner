using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float acceleration = 1.2f;
    private Rigidbody2D rb;
    private Animator animator;
    public float jumpHeight = 7f;
    private bool isGround = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Time.timeScale = 0f;     
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Time.timeScale = 1f;     
        }
        speed += acceleration * Time.deltaTime;
        transform.Translate(new Vector2(1f, 0f) * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            Jump();
            animator.SetBool("Jump", true);
            isGround = false;
        }

        if (this.transform.position.y <= -7.5f)
        {
            Die();
        }
    }

    void Jump()
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.y = jumpHeight;
        rb.linearVelocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("Jump", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "Spike")
        {
            Die();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "GroundParent")
        {
            Destroy(other.gameObject, 5f);
        }
    }

    void Die()
    {
        FindObjectOfType<GameManager>().isGameActive = false;
        if (GameManager.instance != null)
        {
            GameManager.instance.ShowGameOver();
        }
        gameObject.SetActive(false);
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public float speed = 0.1f;
    public float jump = 10f;
    Rigidbody2D rb;
    bool isGrounded = true;
    private Animator anim;
    int score=0;
    public TextMeshProUGUI scoreText;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        

    }  // Update is called once per frame
        void Update()
        {

            //Counting Gems(Scores)
            scoreText.text = "Score: " + score;
            //Counting vectors
            float Horn = Input.GetAxisRaw("Horizontal");
            float Vert = Input.GetAxisRaw("Vertical");
            Vector2 move = new Vector2(Horn, Vert);
           //MOVEMENT AND ANIMATION

        transform.Translate(move * speed * Time.deltaTime);
      // rb.MovePosition(rb.position + move * Time.deltaTime *speed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            isGrounded = false;
        }
        if (Horn < 0)
            {
                transform.localScale = new Vector2(-1, 1);
                anim.SetInteger("State", 1);
            }
            else if (Horn > 0)
            {
                transform.localScale = new Vector2(1, 1);
                anim.SetInteger("State", 1);
            }
            else
            {
                anim.SetInteger("State", 0);
            }
            
           
        }
       

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (collision.collider.CompareTag("Gem"))
        {
            score++;
            Debug.Log("Score: " + score);
            Destroy(collision.gameObject);
        }
    }
   
}

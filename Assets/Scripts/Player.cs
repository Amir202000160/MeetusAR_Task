using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public float speed = 0.1f;
    public float jump = 10f;
    Rigidbody2D rb;
    public bool isGrounded = true;
    private Animator anim;
    int score=0;
    public TextMeshProUGUI scoreText;
    public Game game;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        game = GameObject.Find("GameManager").GetComponent<Game>();
    }  
    void FixedUpdate()
    {
        //Checking if the game has started
        if (game.iSstartPlay == true)
        {
            //Counting Gems(Scores)
            scoreText.text = "Score: " + score;
            //Counting vectors
            float Horn = Input.GetAxisRaw("Horizontal");
            Vector2 moveLR = new Vector2(Horn, rb.linearVelocityY);

            //MOVEMENT AND jUMP AND ANIMATION

            transform.Translate(moveLR * speed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
            //Animation and making the player face the right direction
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


    }
            private void OnCollisionEnter2D(Collision2D collision)
            {
        //Checking if the player is on the ground
           
                    isGrounded = true;
                
               
        //Collecting Gems<Scoring_System>
            if (collision.collider.CompareTag("Gem"))
                {
                    score++;
                    Debug.Log("Score: " + score);
                    Destroy(collision.gameObject);
                }
    }
    //Jumping Method
    public void Jump()
    {
        rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        isGrounded = false;
    }
   
    
}

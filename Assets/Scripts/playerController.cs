using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float thrust = 10.0f;
    public LayerMask groundLayerMask;
    public Animator animator;
    public float runspeed=1.5f;
    private static playerController sharedInstance;
    private Vector3 initialPosition;
    private Vector2 initialVelocity;
    private float initialGravity;
    public int GetDistance()
    {
        var distance=Vector2.Distance(initialPosition,transform.position);
        return (int)distance;
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        animator.SetBool("isAlive",true);
        transform.position=initialPosition;
        rigidBody.velocity=initialVelocity;
        rigidBody.gravityScale=initialGravity;
        
    }
    private void Awake()
    {
        sharedInstance=this;
        initialPosition=transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
        animator.SetBool("isAlive",true);
        initialVelocity=rigidBody.velocity;
        initialGravity=rigidBody.gravityScale;
    }
    public static playerController GetInstance()
    {
        return sharedInstance;
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isGrounded",IsOnTheGround());
        if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow)&&GameManager.GetInstance().currentGameState==GameStates.InGame)
        {
            Jump();
        }

    }
    private void FixedUpdate()
    {
         if( rigidBody.velocity.x<runspeed&&(GameManager.GetInstance().currentGameState==GameStates.InGame))
       {
           rigidBody.velocity=new Vector2(runspeed,rigidBody.velocity.y);
       }
       else
       {
           rigidBody.velocity=new Vector2(0,rigidBody.velocity.y);
       
       }
    }
    void Jump()
    {
        
        if(IsOnTheGround()==true)
        {
            rigidBody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
        }
    }
    bool IsOnTheGround()
    {
        bool k=(Physics2D.Raycast(this.transform.position, Vector2.down,
            1.0f, groundLayerMask.value));
        return k ;

    }
    public void KillPlayer()
    {
        animator.SetBool("isAlive",false);
       int highscore =PlayerPrefs.GetInt("highestScore");
       int currentScore=GetDistance();
       if (currentScore>highscore)
       {
           PlayerPrefs.SetInt("highestScore",currentScore);
       }
        rigidBody.gravityScale =0f;
        rigidBody.velocity=Vector2.zero;
        GameManager.GetInstance().GameOver();
    }
    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("highestScore");
    }
}

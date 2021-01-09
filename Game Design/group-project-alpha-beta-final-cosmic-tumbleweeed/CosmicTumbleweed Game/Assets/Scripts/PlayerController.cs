using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region VARIABLES

    ////////////////////////// MOVEMENT RELATED /////////////////////////
    float movementSpeed = 6.0f;
    float x; // where the player is
    bool dontMove;

    ////////////////////////// JUMP RELATED //////////////////////////
    float jumpForce;
    private float gravityScale = 1f;
    bool releasedJump;
    bool pressedJump;
    bool isJumping;
    bool skip;

    private bool startTimer = false;
    private float jumpTimer = 0.5f;
    private float timer; 

    int jumpCount = 2;
    bool isGrounded;
    public bool canDoubleJump;
    Vector2 doubleJumptemp;
    Vector2 counterJumpForce;


    ///////////////////////// Dash Related ////////////////////////////
    float dashForce = 7f;
    public bool canDash;
    bool dashPower = true;
    

    ///////////////////////// Ground Pound Related /////////////////////
    public bool canGroundPound;
    bool isPounding;

    bool win;
    #endregion

    #region EVENTS
    public UnityEvent endGame;
    public UnityEvent endCutscene;
    public UnityEvent dead;
    public UnityEvent checkpoint;
    public UnityEvent preview;
    public UnityEvent skipLevel;
    #endregion

    #region COMPONENT REFERENCES
    public new Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Ghost ghost;
    public Transform cam;
    private GameMaster gm;
    public ParticleSystem dust;
    #endregion

    public static float CalculateJumpForce(float gravityStrength, float jumpHeight){
        return Mathf.Sqrt(2 * gravityStrength * jumpHeight);
    }

    void CreateDust(){
        dust.Play();
    }

    public bool getPound(){
        return isPounding;
    }

    void Move(float a, bool jump, bool twoJump){
        
        if (!dontMove){ 
            if (x < 0) { 
                animator.SetBool("running", true);
                transform.eulerAngles = new Vector3(0,180,0);
                if (rigidbody.velocity.x > 0) rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
                transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            } else if (x > 0){
                animator.SetBool("running", true);
                transform.eulerAngles = new Vector3(0,0,0);
                if (rigidbody.velocity.x < 0) rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
                transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            } else if ((!Input.GetKeyDown(KeyCode.A) && !(Input.GetKeyDown(KeyCode.W)))){
                animator.SetBool("running", false);
            }
        }

        if (rigidbody.velocity.y < -0.1 && !isPounding){
            isGrounded = false;
            animator.SetBool("jumping", false);
            animator.SetBool("falling", true);
        } else if (isGrounded) {
            animator.SetBool("falling", false);
        } else {
            animator.SetBool("running", false);
        }
    }


    public void unlockDouble(){
        canDoubleJump = true;
    }

    //////////////////// COLLISION DETECTIONS /////////////////////////////////////////////////////////////////

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")){
            isGrounded = true;
            jumpCount = 2;
            animator.SetBool("jumping", false);
            animator.SetBool("groundpound", false);
            dashPower = true;
            isPounding = false;
            isJumping = false;
            CreateDust();
        }

        if (other.gameObject.CompareTag("Pound")){
            if (!isPounding){
                isGrounded = true;
                jumpCount = 2;
                animator.SetBool("jumping", false);
                animator.SetBool("groundpound", false);
                isJumping = false;
                dashPower = true;
            } else if (isPounding){
                //animator.SetBool("jumping", false);
                //animator.SetBool("falling", true);
                isJumping = false;
                jumpCount = 2;
                //animator.SetBool("groundpound", true);
            }
        }

        if (other.gameObject.CompareTag("Debris")){
            dontMove = true; 
            animator.SetTrigger("dying");
            StartCoroutine(waitDeath(1f));
            SoundManagerScript.PlaySound("death");

        }

    }

    //////////////////// TRIGGER DETECTIONS /////////////////////////////////////////////////////////////////

    private void OnTriggerEnter2D(Collider2D other) {

        // WIN
        if (other.gameObject.CompareTag("Win")){
            win = true;
            animator.SetBool("running", false);
            endCutscene.Invoke();
            dontMove = true;
            StartCoroutine(waitWin(2f));          
        }

        // SKIP
        if (other.gameObject.CompareTag("Skip")){
            win = true;
            skip = true;
            animator.SetBool("running", false);
            endCutscene.Invoke();
            dontMove = true;
            StartCoroutine(waitWin(2f));          
        }

        // DEATH
        if (other.gameObject.CompareTag("Death") && !win){  
            SoundManagerScript.PlaySound("death");          
            dead.Invoke();
        }

        // CHECKPOINT
        if (other.gameObject.CompareTag("Checkpoint")){
            gm.recentCheck = other.gameObject;
            checkpoint.Invoke();
        }

        if (other.gameObject.CompareTag("Pound")){
            jumpCount = 2;
        }

        // DIALOGUE PREVIEWS
        if (other.gameObject.CompareTag("Dialogue")){
            preview.Invoke();
        }

        
    }

    private IEnumerator waitDeath(float sec){
        yield return new WaitForSeconds(sec);
        dead.Invoke();   
    }
    private IEnumerator waitWin(float sec){
        yield return new WaitForSeconds(sec);
        if (skip){
            skipLevel.Invoke();
        } else {
            endGame.Invoke();  
        }
         
    }

    /////////////////////////////// UNLOCKING ABILITIES /////////////////////////////////////////////

    public void canDouble(){
        canDoubleJump = true;
        //SoundManagerScript.PlaySound("power");
    }

    public void canMove(){
        dontMove = false;
    }

    public void setCanDash(){
        canDash = true;
        //SoundManagerScript.PlaySound("power");
    }

    public void canPound(){
        canGroundPound = true;
        gm.groundPound = true;
        //SoundManagerScript.PlaySound("power");
    }


    public void cannotMove(){
        dontMove = true;
        animator.SetBool("running", false);
        animator.SetBool("jumping", false);
    }

    /////////////////////////////// DURING GAME ////////////////////////////////////////////////////////////////////
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        Debug.Log(gm.currentLevel);
        if(gm.currentLevel == SceneManager.GetActiveScene().buildIndex)
        {
            transform.position = gm.lastCheckPointPos;
            cam.position = gm.lastCheckPointPos;
        }
        else
        {
            gm.currentLevel = SceneManager.GetActiveScene().buildIndex;
            gm.lastCheckPointPos = transform.position;
        }

        dontMove = false;
        win = false;
        jumpForce = CalculateJumpForce(Physics2D.gravity.magnitude, 0.80f);
        timer = jumpTimer;
        skip = false;

    }
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        //jumpDown = Input.GetKeyDown(KeyCode.Space);
        Move(x, pressedJump, canDoubleJump);


        ////// JUMP MECHANICS ///////////////////////////////////////////////////////////////
        
        if (!dontMove){

            if(Input.GetKeyDown(KeyCode.Space)){
                pressedJump = true;

            } else if (Input.GetKeyUp(KeyCode.Space)){
                releasedJump = true;
                pressedJump = false;
            }

            if (pressedJump && (!canDoubleJump && isGrounded)){
                StartJump();
            }

            if (pressedJump && (canDoubleJump && jumpCount != 0)){
                dashPower = true;
                doubleJumptemp = rigidbody.velocity;
                doubleJumptemp.y = 0f;
                rigidbody.velocity = doubleJumptemp;
                //rigidbody.AddForce(Vector2.up * jumpForce * rigidbody.mass, ForceMode2D.Impulse);
                StartJump();
                jumpCount -= 1;
            }

            if (startTimer){
                timer -= Time.deltaTime;
                if (timer <= 0){
                    releasedJump = true;
                }
            }

            if (releasedJump){
                StopJump();
            }

            ////// DASH MECHANICS ////////////////////////////////////////////////
            
            if(Input.GetKeyDown(KeyCode.K) && canDash && x!=0 && dashPower){
                ghost.makeGhost = true;
                CreateDust();
                if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
                    rigidbody.AddForce(Vector2.left * (dashForce - Mathf.Abs(rigidbody.velocity.x)) * rigidbody.mass, ForceMode2D.Impulse);
                    SoundManagerScript.PlaySound("dash");
                    if (isJumping){
                        dashPower = false;
                    }

                }
                if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
                    CreateDust();
                    rigidbody.AddForce(Vector2.right * (dashForce - Mathf.Abs(rigidbody.velocity.x)) * rigidbody.mass, ForceMode2D.Impulse);
                    SoundManagerScript.PlaySound("dash");
                    if (isJumping){
                        dashPower = false;
                    }
                }
                StartCoroutine(NoTrail(0.5f));
            }

            ////// GROUND POUND MECHANICS ////////////////////////////////////////////////
            if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && canGroundPound){
                CreateDust();
                if (isJumping) {
                    ghost.makeGhost = true;
                    rigidbody.AddForce(Vector2.down * (jumpForce*2) * rigidbody.mass, ForceMode2D.Impulse);
                    SoundManagerScript.PlaySound("groundPound");
                    animator.SetBool("jumping", false);
                    animator.SetBool("falling", false);
                    animator.SetBool("groundpound", true);
                    //StartCoroutine(NoTrail(0.2f));
                    isPounding = true;
                }
            }

            if((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))){
                isPounding = false;
                ghost.makeGhost = false;
            }
        }
    }

    private bool isCoroutineExecuting = false;
    IEnumerator NoTrail(float time)
    {

        if (isCoroutineExecuting)
            yield break;
    
        isCoroutineExecuting = true;
    
        yield return new WaitForSeconds(time);
        ghost.makeGhost = false;
        isCoroutineExecuting = false;
    }

    private void StartJump(){
        SoundManagerScript.PlaySound("jump");
        rigidbody.gravityScale = 0;
        rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isJumping = true;
        isGrounded = false;
        startTimer = true;
        pressedJump = false;
        animator.SetBool("jumping", true);
        animator.SetBool("groundpound", false);
        CreateDust();
    }

    private void StopJump(){
        rigidbody.gravityScale = gravityScale;
        releasedJump = false;
        timer = jumpTimer;
        startTimer = false;
    }

    public void resetLevel()
    {
        gm.currentLevel = 0;
        Debug.Log(gm.currentLevel);
    }


}

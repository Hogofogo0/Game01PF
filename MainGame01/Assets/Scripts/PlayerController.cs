using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float MovementSpeed = 10;
    public float JumpForce = 4;
    float movement = 0f;
    int doubleJump = 2;

    private bool lastMenu;

    private Animator anim;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    


    

    private void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        _rigidbody.velocity = new Vector2((MovementSpeed*100) * direction * Time.fixedDeltaTime, _rigidbody.velocity.y);

        if (Input.GetButtonDown("Jump") && (Mathf.Abs(_rigidbody.velocity.y) < 0.001f||doubleJump > 0) && !Attack.isAttacking)
        {

            if(_rigidbody.velocity.y < 0)
            {

                _rigidbody.AddForce(new Vector2(0, JumpForce * 1.75f), ForceMode2D.Impulse);

            }
            else
            {

                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
            
            anim.SetTrigger("Jump");
            doubleJump--;
        }
        if(_rigidbody.velocity.y < -0.001f)
        {
            anim.SetTrigger("fall");
        }

        if (Mathf.Abs(_rigidbody.velocity.y) > 0)
        {
            anim.SetBool("Grounded", false);
        }
        else
        {
            anim.SetBool("Grounded", true);
            doubleJump = 2;
        }

        if(direction < 0)
        {
            transform.localScale = new Vector2(-1.2f,1.2f);
        }
        else
        {
            transform.localScale = new Vector2(1.2f, 1.2f);
        }

        if (Mathf.Abs(_rigidbody.velocity.x) > 0)
        {
            anim.SetInteger("AnimState", 1);
        }
        else
        {
            anim.SetInteger("AnimState", 0);
        }


    }

    private void FixedUpdate()
    {
        
    }

    
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float MovementSpeed = 10;
    public float JumpForce = 4;
    public bool jumping;
    private float lastYVel;

    private Animator anim;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            anim.SetInteger("AirSpeedY", 1);
            anim.SetTrigger("Jump");
            jumping = true;
        }

        else if (movement < 0 && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            anim.SetInteger("AnimState", 1);
            anim.SetBool("Grounded", true);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (movement > 0 && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            anim.SetInteger("AnimState", 1);
            anim.SetBool("Grounded", true);
            transform.localScale = new Vector2(1, 1);
        }
        else if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            anim.SetInteger("AnimState", 0);
            anim.SetBool("Grounded", true);
            transform.localScale = new Vector2(1, 1);
        }

        if(jumping == true && _rigidbody.velocity.y < -0.001f)
        {

            anim.SetTrigger("fall");
            anim.SetBool("Grounded", false);
            jumping = false;
        }
        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("Grounded", true);
    }
}

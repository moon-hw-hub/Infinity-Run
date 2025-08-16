using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    [SerializeField]
    private Sprite fallSprite;

    private bool isGrounded = true; 
    private bool canJumpTwice = false; 

    [SerializeField]
    public float jumpPower;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Fall();
    }

    private void Jump()
    {
        //Animation
        if (rigid.linearVelocity.y != 0) //위로 y축 이동이 있을때 즉 점프를 할 때
        {
            anim.SetBool("onSky", true);
        } else
        {
            anim.SetBool("onSky", false);
        }

        //물리 적용
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, 0);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGrounded = false;
            canJumpTwice = true;

        }
        else if (canJumpTwice && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, 0);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            canJumpTwice = false;

        }
        
    }

    private void Fall()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isGrounded)
        {
            rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, -jumpPower);
        }
       
    }

    



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
        else if (collision.gameObject.tag == "Obs")
        {
            GameManager.instance.SetGameOver(); // 게임 매니저의 SetGameOver 메서드를 호출하여 게임 오버 상태로 전환
            Destroy(gameObject);
            Debug.Log("게임 오버");
        }


    }

}

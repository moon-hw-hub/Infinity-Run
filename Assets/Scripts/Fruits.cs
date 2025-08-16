using UnityEngine;
using System.Collections;


public class Fruits : MonoBehaviour
{
    Animator anim;

    private float minX = -10f;
    private float moveSpeed;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveSpeed = GameManager.instance.gameSpeed; // 추후 게임 진행 상황에 따라 변경될 수 있으므로 Update()에서 정의
        transform.Translate(-1 * moveSpeed * Time.deltaTime, 0, 0); // Move the obstacle to the left

        if (transform.position.x <= minX) // If the obstacle moves out of bounds
        {
            Destroy(gameObject); // Destroy the obstacle
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.IncreaseScore();
            Destroy(gameObject); // 과일이 플레이어와 충돌하면 과일 오브젝트를 제거
        }


    }

    
}

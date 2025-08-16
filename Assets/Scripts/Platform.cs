using UnityEngine;

public class Platform : MonoBehaviour
{
    private float moveSpeed; // 이동 속도

    // Update is called once per frame

    void Awake()
    {
        moveSpeed = GameManager.instance.gameSpeed; // 게임 매니저에서 설정한 게임 속도를 가져옴
    }

    void Update()
    {
        transform.Translate(-1 * moveSpeed * Time.deltaTime, 0, 0); // 왼쪽으로 이동
        if (transform.position.x <= -18) // 플랫폼이 화면 밖으로 나가면
        {
            transform.Translate(18, 0, 0); 
        }
    }
}

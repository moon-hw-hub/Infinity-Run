using UnityEngine;

public class ParallaxBackground : MonoBehaviour // 배경 패럴릭스 스크롤링 구현
{
    [SerializeField]
    private Transform target; // 현재 배경과 이어지는 배경

    private float scrollAmount; // 스크롤 양

    private float moveSpeed;

    [SerializeField]
    private Vector3 moveDirection; // 이동 방향

    void Awake()
    {
        moveSpeed = GameManager.instance.gameSpeed; // 게임 매니저에서 설정한 게임 속도를 가져옴
        moveDirection = moveDirection.normalized; // 이동 방향을 정규화
        scrollAmount = Mathf.Abs(transform.position.x - target.position.x); // 현재 배경과 이어지는 배경의 x좌표 차이
    }


    // Update is called once per frame
    void Update()
    {
        //배경이 moveDirection 방향으로 moveSpeed 속도로 이동
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -scrollAmount)
        {
            transform.position = target.position - moveDirection * scrollAmount; // 현재 배경이 이어지는 배경의 위치로 이동
        }
    }
}

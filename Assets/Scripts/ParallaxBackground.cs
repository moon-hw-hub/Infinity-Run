using UnityEngine;

public class ParallaxBackground : MonoBehaviour // ��� �з����� ��ũ�Ѹ� ����
{
    [SerializeField]
    private Transform target; // ���� ���� �̾����� ���

    private float scrollAmount; // ��ũ�� ��

    private float moveSpeed;

    [SerializeField]
    private Vector3 moveDirection; // �̵� ����

    void Awake()
    {
        moveSpeed = GameManager.instance.gameSpeed; // ���� �Ŵ������� ������ ���� �ӵ��� ������
        moveDirection = moveDirection.normalized; // �̵� ������ ����ȭ
        scrollAmount = Mathf.Abs(transform.position.x - target.position.x); // ���� ���� �̾����� ����� x��ǥ ����
    }


    // Update is called once per frame
    void Update()
    {
        //����� moveDirection �������� moveSpeed �ӵ��� �̵�
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -scrollAmount)
        {
            transform.position = target.position - moveDirection * scrollAmount; // ���� ����� �̾����� ����� ��ġ�� �̵�
        }
    }
}

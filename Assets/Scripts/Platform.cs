using UnityEngine;

public class Platform : MonoBehaviour
{
    private float moveSpeed; // �̵� �ӵ�

    // Update is called once per frame

    void Awake()
    {
        moveSpeed = GameManager.instance.gameSpeed; // ���� �Ŵ������� ������ ���� �ӵ��� ������
    }

    void Update()
    {
        transform.Translate(-1 * moveSpeed * Time.deltaTime, 0, 0); // �������� �̵�
        if (transform.position.x <= -18) // �÷����� ȭ�� ������ ������
        {
            transform.Translate(18, 0, 0); 
        }
    }
}

using UnityEngine;

public class Obs : MonoBehaviour
{
    private float minX = -10f;
    private float moveSpeed; // Speed at which the obstacle moves

    // Update is called once per frame
    void Update()
    {
        moveSpeed = GameManager.instance.gameSpeed; // ���� ���� ���� ��Ȳ�� ���� ����� �� �����Ƿ� Update()���� ����
        transform.Translate(-1 * moveSpeed * Time.deltaTime, 0, 0); // Move the obstacle to the left

        if (transform.position.x <= minX) // If the obstacle moves out of bounds
        {
            Destroy(gameObject); // Destroy the obstacle
        }
    }

    
}

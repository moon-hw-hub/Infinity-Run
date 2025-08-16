using UnityEngine;

public class Obs : MonoBehaviour
{
    private float minX = -10f;
    private float moveSpeed; // Speed at which the obstacle moves

    // Update is called once per frame
    void Update()
    {
        moveSpeed = GameManager.instance.gameSpeed; // 추후 게임 진행 상황에 따라 변경될 수 있으므로 Update()에서 정의
        transform.Translate(-1 * moveSpeed * Time.deltaTime, 0, 0); // Move the obstacle to the left

        if (transform.position.x <= minX) // If the obstacle moves out of bounds
        {
            Destroy(gameObject); // Destroy the obstacle
        }
    }

    
}

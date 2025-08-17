using UnityEngine;

public class Obs : MonoBehaviour
{
    private float minX = -10f;
    private float moveSpeed; 

    void Update()
    {
        moveSpeed = GameManager.instance.gameSpeed; 
        transform.Translate(-1 * moveSpeed * Time.deltaTime, 0, 0); 

        if (transform.position.x <= minX) 
        {
            Destroy(gameObject); // Destroy the obstacle
        }
    }

    
}

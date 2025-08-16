using UnityEngine;
using System.Collections;


public class ObsSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;

    [SerializeField]
    private float spawnInterval; // 장애물 생성 주기

    private float spawnPosY; // 각 장애묻들의 생성 위치 Y 좌표
    private int obsIndex; // 장애물 인덱스                      

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartObsRoutine();
    }
    

    void StartObsRoutine()
    {
        StartCoroutine("ObsRoutine");
    }

    public void StopObsRoutine()
    {
        StopCoroutine("ObsRoutine");
    }

    IEnumerator ObsRoutine()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            SpawnObs();
            Debug.Log("장애물이 생성되었습니다");
            yield return new WaitForSeconds(spawnInterval); // 장애물 생성 간격 대기

            
        }
    }

    void SpawnObs()
    {
        obsIndex = Random.Range(0, obstacles.Length); // 장애물 인덱스 랜덤 생성
        switch (obsIndex)
        {
            case 0:
                spawnPosY = -0.87f; // 장애물 생성 위치 Y 좌표
                break;
            case 1:
                spawnPosY = -0.87f;
                break;
            case 2:
                spawnPosY = -2f;
                break;
            case 3:
                spawnPosY = -0.37f;
                break;
            case 4:
                spawnPosY = -1.3f;
                break;
        }

        GameObject obs = Instantiate(obstacles[obsIndex], new Vector3(transform.position.x, spawnPosY, 1), Quaternion.identity);

    }


}

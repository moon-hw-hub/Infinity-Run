using UnityEngine;
using System.Collections;


public class ObsSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;

    [SerializeField]
    private float spawnInterval; // ��ֹ� ���� �ֱ�

    private float spawnPosY; // �� ��ֹ����� ���� ��ġ Y ��ǥ
    private int obsIndex; // ��ֹ� �ε���                      

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
            Debug.Log("��ֹ��� �����Ǿ����ϴ�");
            yield return new WaitForSeconds(spawnInterval); // ��ֹ� ���� ���� ���

            
        }
    }

    void SpawnObs()
    {
        obsIndex = Random.Range(0, obstacles.Length); // ��ֹ� �ε��� ���� ����
        switch (obsIndex)
        {
            case 0:
                spawnPosY = -0.87f; // ��ֹ� ���� ��ġ Y ��ǥ
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

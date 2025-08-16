using UnityEngine;
using System.Collections;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fruits; // ���� ������Ʈ �迭

    private int currentIndex = 0; // ���� ������ ���� �ε���

    [SerializeField]
    private float spawnInterval = 0.1f; // ���� ���� �ֱ�

    void Awake()
    {
        
    }

    void Start()
    {
        StartFruitsRoutine();
    }


    void StartFruitsRoutine()
    {
        StartCoroutine("FruitsRoutine");
    }

    public void StopFruitsrRoutine()
    {
        StopCoroutine("FruitsRoutine");
    }

    IEnumerator FruitsRoutine()
    {
        while (true)
        {
            SpawnFruits();
            Debug.Log("������ �����Ǿ����ϴ�");
            yield return new WaitForSeconds(spawnInterval); // ��ֹ� ���� ���� ���


        }
    }

    void SpawnFruits()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0); // ���� ���� ��ġ
        //currentIndex = 0;

        if (GameManager.instance.eatCount % 150 == 0 && GameManager.instance.eatCount != 0)
        {
            GameManager.instance.SetGameLevelUp(); //ChangeFruit(); // eatCount�� 150 �̻��̸� ���� ����
        }
        
        GameObject fruitObject = Instantiate(fruits[currentIndex], spawnPos, Quaternion.identity);

    }

    public void ChangeFruit()
    {
        currentIndex++;
        spawnInterval -= 0.01f; // ���� ���� �ֱ� ����
        if (currentIndex >= fruits.Length)
        {
            currentIndex = fruits.Length - 1; // �ε����� �迭 ���̸� �ʰ��ϸ� �ٽ� 0���� �ʱ�ȭ
            spawnInterval = 0.06f; // ���� ���� �ֱ⸦ ����
        }
        
    }

    



}

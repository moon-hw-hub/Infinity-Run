using UnityEngine;
using System.Collections;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fruits; // ���� ������Ʈ �迭

    private int currentIndex = 0; // ���� ������ ���� �ε���

    [SerializeField]
    private float spawnInterval = 0.1f; // ���� ���� �ֱ�

    private int lastLevelUpEatCount = 0; // ������ ������ �� ���� ���� �� �ʱ�ȭ (�� �����ӿ��� ���� ���� ������ ���� �� �����Ƿ� �ʿ�)

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
            //Debug.Log("������ �����Ǿ����ϴ�");
            yield return new WaitForSeconds(spawnInterval); // ��ֹ� ���� ���� ���


        }
    }

    void SpawnFruits()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0); // ���� ���� ��ġ
        //currentIndex = 0;

        if (GameManager.instance.eatCount - lastLevelUpEatCount >= 150) //ũ ���ȴ�
        {
            GameManager.instance.SetGameLevelUp(); //ChangeFruit(); // eatCount�� 150 �̻��̸� ���� ����
            lastLevelUpEatCount = GameManager.instance.eatCount; // ������ ������ �� ���� ���� �� ����
            Debug.Log("������ �� ���� ���� �� ����");
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

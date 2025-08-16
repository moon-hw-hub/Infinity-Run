using UnityEngine;
using System.Collections;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fruits; // 과일 오브젝트 배열

    private int currentIndex = 0; // 현재 생성할 과일 인덱스

    [SerializeField]
    private float spawnInterval = 0.1f; // 과일 생성 주기

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
            Debug.Log("괴일이 생성되었습니다");
            yield return new WaitForSeconds(spawnInterval); // 장애물 생성 간격 대기


        }
    }

    void SpawnFruits()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0); // 과일 생성 위치
        //currentIndex = 0;

        if (GameManager.instance.eatCount % 150 == 0 && GameManager.instance.eatCount != 0)
        {
            GameManager.instance.SetGameLevelUp(); //ChangeFruit(); // eatCount가 150 이상이면 과일 변경
        }
        
        GameObject fruitObject = Instantiate(fruits[currentIndex], spawnPos, Quaternion.identity);

    }

    public void ChangeFruit()
    {
        currentIndex++;
        spawnInterval -= 0.01f; // 과일 생성 주기 감소
        if (currentIndex >= fruits.Length)
        {
            currentIndex = fruits.Length - 1; // 인덱스가 배열 길이를 초과하면 다시 0으로 초기화
            spawnInterval = 0.06f; // 과일 생성 주기를 고정
        }
        
    }

    



}

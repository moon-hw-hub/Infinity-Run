using UnityEngine;
using TMPro; // ���� ǥ�ø� ���� TextMeshPro ���ӽ����̽�
using UnityEngine.SceneManagement; // �� ��ȯ�� ���� ���ӽ����̽� (��ư�� �̺�Ʈ�� �����ϱ� ����)


public class GameManager : MonoBehaviour
{
    public bool isgameOver = false; // ���� ���� ���¸� ��Ÿ���� bool����

    public static GameManager instance = null;

    [SerializeField]
    public float gameSpeed = 10f;

    public int score = 0; // ���� ����

    public int eatCount = 0; // ���� ȹ�� ��


    [SerializeField]
    private TextMeshProUGUI text; // ������ ǥ���� TextMeshProUGUI ������Ʈ

    [SerializeField]
    private GameObject gameOverPanel; // ���� ���� �г�

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void IncreaseScore()
    {
        score += 1; // ���� ȹ�� �� ���� ����
        eatCount += 1; // ���� ȹ�� �� ����
        //Debug.Log("���� ȹ�� ��: " + eatCount);
        text.SetText(score.ToString()); // ���� ǥ�� ������Ʈ
        //Debug.Log("������ �Ծ����ϴ�! ���� ����"); 
    }

    public void SetGameLevelUp() // ������ �� : ��ֹ��� ���� ���� �ֱ� ����, ���� �ӵ� ����, ���� ���� ����
    {
        FruitSpawner fruitSpawner = FindAnyObjectByType<FruitSpawner>();
        if (gameSpeed > 14f)
        {
            gameSpeed = 14f;
        }
        gameSpeed += 1f; // ���� �ӵ� ����

        if (fruitSpawner != null) 
        {
            fruitSpawner.ChangeFruit(); // ���� ���� ����, ���� �ֱ� ����
        }

        Debug.Log("���̵� ��!");

    }

    public void SetGameOver()
    {
        isgameOver = true; // ���� ���� ���¸� true�� ����
        ObsSpawner obsSpawner = FindAnyObjectByType<ObsSpawner>();
        FruitSpawner fruitSpawner = FindAnyObjectByType<FruitSpawner>();
        if (obsSpawner != null)
        {
            obsSpawner.StopObsRoutine(); // ��ֹ� ���� ����
        }

        if (fruitSpawner != null)
        {
            fruitSpawner.StopFruitsrRoutine(); // ���� ���� ����
        }

        Invoke("showGameOverPanel", 1f); // Invoke �޼��带 ����Ͽ� 1�� �Ŀ� ���� ���� �г��� ǥ��

        //gameOverPanel.SetActive(true); // ���� ���� �г� Ȱ��ȭ

    }

    void showGameOverPanel() // ���� ���� �г� Ȱ��ȭ �޼��� ����
    {
        gameOverPanel.SetActive(true); 
    }

    public void PlayAgain() // playagain ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    

}

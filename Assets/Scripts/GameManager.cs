using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public bool isgameOver = false; // ���� ���� ���¸� ��Ÿ���� bool����
    public static GameManager instance = null;

    [SerializeField]
    public float gameSpeed = 10f;

    public int score = 0; // ���� ����
    public int eatCount = 0; // ���� ȹ�� ��

    [SerializeField]
    private TextMeshProUGUI text1; // ������ ǥ���� TextMeshProUGUI ������Ʈ

    [SerializeField]
    private TextMeshProUGUI text2; // ������ ǥ���� TextMeshProUGUI ������Ʈ

    [SerializeField]
    private GameObject gameOverPanel; // ���� ���� �г�

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void IncreaseScore(int value)
    {
        score += value;
        eatCount += 1; // ���� ȹ�� �� ����
        Debug.Log("������ ����! +" + value + "��");
        text1.SetText(score.ToString()); // ���� ǥ�� ������Ʈ
    }
    public void SetGameLevelUp() // ������ �� : ���� ���� �ֱ� ����, ���� �ӵ� ����, ���� ���� ����
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
        Debug.Log("���ӿ��� ���� ����: " + score);
        gameOverPanel.SetActive(true); 
        text2.SetText(score.ToString()); // ���� ���� ǥ�� ������Ʈ
    }

    public void PlayAgain() // playagain ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GameStart() // Ȩȭ�鿡�� ���� ���� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToHome() // ���� ���� �гο��� Ȩ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void QuitGame() // ���� ���� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    {
        Application.Quit(); // ���� ����
        Debug.Log("������ �����մϴ�.");
    }



}

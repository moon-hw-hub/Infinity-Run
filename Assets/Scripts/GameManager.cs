using UnityEngine;
using TMPro; // 점수 표시를 위한 TextMeshPro 네임스페이스
using UnityEngine.SceneManagement; // 씬 전환을 위한 네임스페이스 (버튼의 이벤트를 구현하기 위함)


public class GameManager : MonoBehaviour
{
    public bool isgameOver = false; // 게임 오버 상태를 나타내는 bool변수

    public static GameManager instance = null;

    [SerializeField]
    public float gameSpeed = 10f;

    public int score = 0; // 게임 점수

    public int eatCount = 0; // 과일 획득 수


    [SerializeField]
    private TextMeshProUGUI text; // 점수를 표시할 TextMeshProUGUI 컴포넌트

    [SerializeField]
    private GameObject gameOverPanel; // 게임 오버 패널

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void IncreaseScore()
    {
        score += 1; // 과일 획득 시 점수 증가
        eatCount += 1; // 과일 획득 수 증가
        //Debug.Log("과일 획득 수: " + eatCount);
        text.SetText(score.ToString()); // 점수 표시 업데이트
        //Debug.Log("과일을 먹었습니다! 점수 증가"); 
    }

    public void SetGameLevelUp() // 구현할 것 : 장애물과 젤리 생성 주기 단축, 게임 속도 증가, 과일 종류 변경
    {
        FruitSpawner fruitSpawner = FindAnyObjectByType<FruitSpawner>();
        if (gameSpeed > 14f)
        {
            gameSpeed = 14f;
        }
        gameSpeed += 1f; // 게임 속도 증가

        if (fruitSpawner != null) 
        {
            fruitSpawner.ChangeFruit(); // 과일 종류 변경, 스폰 주기 증가
        }

        Debug.Log("난이도 업!");

    }

    public void SetGameOver()
    {
        isgameOver = true; // 게임 오버 상태를 true로 설정
        ObsSpawner obsSpawner = FindAnyObjectByType<ObsSpawner>();
        FruitSpawner fruitSpawner = FindAnyObjectByType<FruitSpawner>();
        if (obsSpawner != null)
        {
            obsSpawner.StopObsRoutine(); // 장애물 생성 중지
        }

        if (fruitSpawner != null)
        {
            fruitSpawner.StopFruitsrRoutine(); // 과일 생성 중지
        }

        Invoke("showGameOverPanel", 1f); // Invoke 메서드를 사용하여 1초 후에 게임 오버 패널을 표시

        //gameOverPanel.SetActive(true); // 게임 오버 패널 활성화

    }

    void showGameOverPanel() // 게임 오버 패널 활성화 메서드 정의
    {
        gameOverPanel.SetActive(true); 
    }

    public void PlayAgain() // playagain 버튼 클릭 시 호출되는 메서드
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    

}

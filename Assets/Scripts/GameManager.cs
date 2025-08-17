using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public bool isgameOver = false; // 게임 오버 상태를 나타내는 bool변수
    public static GameManager instance = null;

    [SerializeField]
    public float gameSpeed = 10f;

    public int score = 0; // 게임 점수
    public int eatCount = 0; // 과일 획득 수

    [SerializeField]
    private TextMeshProUGUI text1; // 점수를 표시할 TextMeshProUGUI 컴포넌트

    [SerializeField]
    private TextMeshProUGUI text2; // 점수를 표시할 TextMeshProUGUI 컴포넌트

    [SerializeField]
    private GameObject gameOverPanel; // 게임 오버 패널

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
        eatCount += 1; // 과일 획득 수 증가
        Debug.Log("젤리를 먹음! +" + value + "점");
        text1.SetText(score.ToString()); // 점수 표시 업데이트
    }
    public void SetGameLevelUp() // 구현할 것 : 젤리 생성 주기 단축, 게임 속도 증가, 과일 종류 변경
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
        Debug.Log("게임오버 시점 점수: " + score);
        gameOverPanel.SetActive(true); 
        text2.SetText(score.ToString()); // 최종 점수 표시 업데이트
    }

    public void PlayAgain() // playagain 버튼 클릭 시 호출되는 메서드
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GameStart() // 홈화면에서 게임 시작 버튼 클릭 시 호출되는 메서드
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToHome() // 게임 오버 패널에서 홈버튼 클릭 시 호출되는 메서드
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void QuitGame() // 게임 종료 버튼 클릭 시 호출되는 메서드
    {
        Application.Quit(); // 게임 종료
        Debug.Log("게임을 종료합니다.");
    }



}

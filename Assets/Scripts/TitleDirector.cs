using UnityEngine;
using UnityEngine.SceneManagement;
using CommonConstans;

public class TitleDirector : MonoBehaviour
{

    /// <summary>エンドパネル</summary>
    public GameObject EndPanelObj;
    /// <summary>オーディオマネージャーオブジェクト</summary>
    public GameObject AudioManagerObj;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManagerObj.GetComponent<AudioManager>();
    }

    // Use this for initialization
    void Start()
    {
        //BGM再生
        audioManager.PlayTitleSceneBgm();
        EndPanelObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //バックボタンが押された場合
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioManager.PlayBackButtonSe();
            //エンドパネルの表示
            EndPanelObj.SetActive(true);
        }

        //  画面のタップ判定
        if (Input.GetMouseButtonDown(0) && !EndPanelObj.activeSelf)
        {
            audioManager.StopMusic();
            audioManager.PlayMoveSceneSe();
            //ビンゴ画面に遷移
            SceneManager.LoadScene(SceneName.BINGO_SCENE_NAME);
        }
    }

    /// <summary>
    /// アプリ終了
    /// </summary>
    public void EndApplie()
    {
        Application.Quit();
    }

    /// <summary>
    /// ゲームオブジェクトの表示切替を行う
    /// </summary>
    public void SwitchDisplayGameObject(GameObject gameObj)
    {
        //ゲームオブジェクトがアクティブか判別
        if (gameObj.activeSelf)
        {
            //アクティブの場合
            audioManager.PlayNoButtonSe();
            gameObj.SetActive(false);
        }
        else
        {
            //非アクティブの場合
            audioManager.PlayDisplayPanelSe();
            gameObj.SetActive(true);
        }
    }

}

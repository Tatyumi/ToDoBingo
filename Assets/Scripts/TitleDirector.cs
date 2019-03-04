using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{

    /// <summary>エンドパネル</summary>
    public GameObject endPanelObj;
    /// <summary>オーディオボックス</summary>
    public GameObject audioBoxObj;
    /// <summary>オーディオボックスコントローラスクリプト</summary>
    private AudioBoxController audioBoxController;

    // Use this for initialization
    void Start()
    {
        //BGM再生
        audioBoxController = audioBoxObj.GetComponent<AudioBoxController>();
        audioBoxController.PlayTitleSceneBgm();
        endPanelObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //バックボタンが押された場合
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioBoxController.PlayBackButtonSe();
            //エンドパネルの表示
            endPanelObj.SetActive(true);
        }

        //  画面のタップ判定
        if (Input.GetMouseButtonDown(0) && !endPanelObj.activeSelf)
        {
            audioBoxController.StopMusic();
            audioBoxController.PlayMoveSceneSe();
            //ビンゴ画面に遷移
            SceneManager.LoadScene("BingoScene");
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
            audioBoxController.PlayNoButtonSe();
            gameObj.SetActive(false);
        }
        else
        {
            //非アクティブの場合
            audioBoxController.PlayDisplayPanelSe();
            gameObj.SetActive(true);
        }
    }

}

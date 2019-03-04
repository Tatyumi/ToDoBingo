using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EditPanelController : MonoBehaviour
{
    /// <summary>ビンゴディレクターオブジェクト</summary>
    public GameObject BingoDirectorObj;
    /// <summary>ビンゴディレクタースクリプト</summary>
    private BingoDirector BingoDirectorScript;
    /// <summary>エディットコンテント</summary>
    public GameObject editContent;
    /// <summary>ナビテキストフィールド</summary>
    public GameObject naviTextObj;
    /// <summary>ナビテキスト</summary>
    private Text naviText;

    // Use this for initialization
    void Start()
    {
        naviText = naviTextObj.GetComponent<Text>();
        naviText.text = "EditMode";
        BingoDirectorScript = BingoDirectorObj.GetComponent<BingoDirector>();
        
        //アプリが初回表示かどうか判別
        if (PlayerPrefs.GetInt("FIRSTSTART") != 0)
        {
            //初回表示でない場合

            Transform todoList = editContent.GetComponentInChildren<Transform>();
            int count = 0;
            foreach (Transform todo in todoList)
            {
                //保存している値をインプットフィールドに代入
                todo.GetComponent<InputField>().text = PlayerPrefs.GetString("TODOLIST" + count);
                count++;
            }

        }
        else
        {
            //初回表示の場合

            //更新する
            PlayerPrefs.SetInt("FIRSTSTART", 1);
        }

        //テキストフィールド初期表示
        //BingoDirectorScript.textFieldObj.GetComponent<Text>().text = BingoDirectorScript.todoMemo[0];
        BingoDirectorScript.textFieldObj.GetComponent<Text>().text = "マスを選択してください";
    }

    /// <summary>
    /// ToDo項目の内容保存処理
    /// </summary>
    public void SaveTodoList()
    {
        //子要素の取得
        if (editContent != null)
        {
            Transform todoList = editContent.GetComponentInChildren<Transform>();
            int count = 0;

            foreach (Transform todo in todoList)
            {
                //入力フィールドのテキストを保存&ビンゴモードのテキストフィールドに代入できるようtodomemoに代入
                BingoDirectorScript.todoMemo[count] = todo.Find("Text").gameObject.GetComponent<Text>().text;
                PlayerPrefs.SetString("TODOLIST" + count, todo.Find("Text").gameObject.GetComponent<Text>().text);
                count++;
            }
        }

        BingoDirectorScript.audioBoxController.PlaySaveTodoListSe();
        naviText.text = "BingoMode";
        //EditPanelを非表示
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// エディットモードパネルの表示
    /// </summary>
    public void DisplayEditPanel()
    {
        BingoDirectorScript.audioBoxController.PlayDisplayPanelSe();
        this.gameObject.SetActive(true);
        naviText.text = "EditMode";
    }
}

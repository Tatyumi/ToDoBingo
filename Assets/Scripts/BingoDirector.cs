using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using CommonConstans;

public class BingoDirector : MonoBehaviour
{
    /// <summary>マスの穴の状態リスト</summary>
    private bool[] isHolls = new bool[Value.BINGO_SHEET_LENGTH * Value.BINGO_SHEET_RANK];
    /// <summary>TODOリスト</summary>
    public string[] TodoLists = new string[Value.BINGO_SHEET_LENGTH * Value.BINGO_SHEET_RANK];
    /// <summary>TODOテキストフィールドに表示されるテキスト</summary>
    public GameObject TodoTextObj;
    /// <summary>タイトルバックパネル</summary>
    public GameObject TitleBackPanelObj;
    /// <summary>ビンゴシート</summary>
    public GameObject BingoSheetObj;
    /// <summary>ビンゴカウントテキスト</summary>
    public GameObject BingoCountTextObj;
    /// <summary>オーディオボックスコントローラスクリプト</summary>
    public AudioManager AudioManager;
    /// <summary>オーディオボックス</summary>
    private GameObject audioManagerObj;
    /// <summary>選択しているビンゴマスの番号</summary>
    private int cursorNumber = Value.BINGO_SHEET_LENGTH * Value.BINGO_SHEET_RANK;
    /// <summary>ビンゴの最大数</summary>
    private int maxBingoCount = Value.BINGO_SHEET_LENGTH + Value.BINGO_SHEET_RANK + 2;

    // ビンゴマス目(位置)を表す列挙
    public enum ButtonPos
    {
        TopLeft,        //上段左
        TopCenter,      //上段真ん中
        TopRight,       //上段右
        MiddleLeft,     //中段左
        MiddleCenter,   //中段真ん中
        MiddleRight,    //中段右
        BottomLeft,     //下段左
        BottomCenter,   //下段真ん中
        BottomRight     //下段右
    }
    
    void Start()
    {
        // オーディオマネージャーを取得
        audioManagerObj = GameObject.Find(ObjectName.AUDIO_MANAGER);
        AudioManager = audioManagerObj.GetComponent<AudioManager>();

        // バックパネルを非表示
        TitleBackPanelObj.gameObject.SetActive(false);
        Transform bingoButtons = BingoSheetObj.GetComponentInChildren<Transform>();
        int count = 0;

        // アプリが初回表示かどうか判別
        if (PlayerPrefs.GetInt(SaveKey.FIRST_START_KEY) != 0)
        {
            // 前回のビンゴマスの状態を取得
            foreach (Transform button in bingoButtons)
            {
                isHolls[count] = (System.Convert.ToBoolean(PlayerPrefs.GetString("HOLL" + count)));
                button.transform.Find(ObjectName.HOLL_IMAGE).GetComponent<Image>().enabled = isHolls[count];
                count++;
            }

            // 初期状態のビンゴ状態をチェック
            if (PlayerPrefs.GetString(SaveKey.BINGO_COUNT_KEY) != "")
            {
                BingoCountTextObj.GetComponent<Text>().text = PlayerPrefs.GetString(SaveKey.BINGO_COUNT_KEY);
            }
        }
        AudioManager.PlayBingoSceneBgm();
    }

    private void Update()
    {
        // バックボタンが押された場合
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.PlayBackButtonSe();

            // タイトル画面に戻るのを促す画面を表示する
            TitleBackPanelObj.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// ビンゴマスの穴の表示切替
    /// </summary>
    /// <param name="btnObj"></param>
    public void SwitchHoll(GameObject btnObj)
    {
        // ビンゴマスのマスの状態と，番号を取得
        Image holl = btnObj.transform.Find(ObjectName.HOLL_IMAGE).GetComponent<Image>();
        Text number = btnObj.transform.Find("Text").GetComponent<Text>();

        //カーゾルが当たっているマスと同じマスをタップした場合
        if (cursorNumber == int.Parse(number.text) - 1)
        {
            //同じマスだった場合

            AudioManager.PlaySwitchHollSe();

            //マスに穴が表示されているかどうか判別
            if (holl.isActiveAndEnabled)
            {
                holl.enabled = false;
            }
            else
            {
                holl.enabled = true;
            }

            try
            {
                // マスの穴の状態を更新
                isHolls[int.Parse(number.text) - 1] = holl.isActiveAndEnabled;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        else
        {
            //同じでないマスの場合
            AudioManager.PlaySelectedMassSe();
            cursorNumber = int.Parse(number.text) - 1;
        }
        //  タップしたボタンに結びつくTODO項目の内容をテキストフィールドに表示
        TodoTextObj.GetComponent<Text>().text = TodoLists[int.Parse(number.text) - 1];
    }

    /// <summary>
    /// ビンゴチェック，カウント,状態保存処理
    /// </summary>
    public void CheckBingo()
    {
        int bingoCount = 0;
        int massNumber = 0;
        int massCount = Value.BINGO_SHEET_LENGTH * Value.BINGO_SHEET_RANK;

        // 横列のチェック
        while (massNumber < massCount)
        {
            bool isBingo = true;

            //横一列穴があいている状態かチェック
            for (int i = massNumber; i < Value.BINGO_SHEET_LENGTH + massNumber; i++)
            {
                if (!isHolls[i])
                {
                    isBingo = false;
                }
            }

            if (isBingo)
            {
                bingoCount++;
            }

            massNumber += Value.BINGO_SHEET_LENGTH;
        }

        massNumber = 0;

        //  縦列のチェック
        while (massNumber < Value.BINGO_SHEET_RANK)
        {
            bool isBingo = true;

            //縦の列チェック
            for (int i = massNumber; i < massCount; i += Value.BINGO_SHEET_LENGTH)
            {
                //縦列の内1つでも穴が開いていない場合
                if (!isHolls[i])
                {
                    isBingo = false;
                }
            }

            //縦全てに穴が開いている場合
            if (isBingo)
            {
                bingoCount++;
            }
            massNumber++;
        }

        massNumber = 0;
        int trueCount = 0;

        // 斜列のチェック
        for (int i = massNumber; i < Value.BINGO_SHEET_LENGTH * Value.BINGO_SHEET_RANK; i += Value.BINGO_SHEET_LENGTH + 1)
        {

            if (isHolls[i])
            {
                trueCount++;
            }
        }

        if (trueCount == Value.BINGO_SHEET_LENGTH)
        {
            bingoCount++;
        }

        trueCount = 0;

        // BINGO_SHEET_LENGTH-1のパターン
        for (int i = Value.BINGO_SHEET_LENGTH - 1; i < Value.BINGO_SHEET_LENGTH * Value.BINGO_SHEET_RANK - 1; i += Value.BINGO_SHEET_LENGTH - 1)
        {
            if (isHolls[i])
            {
                trueCount++;
            }
        }

        if (trueCount == Value.BINGO_SHEET_LENGTH)
        {
            bingoCount++;
        }

        // ビンゴ数の表示
        Text bingoCountText = BingoCountTextObj.GetComponent<Text>();

        // ビンゴの数がマックス値かどうか
        if (bingoCount == maxBingoCount)
        {
            bingoCountText.text = "ALL BINGO!";
        }
        else
        {
            bingoCountText.text = bingoCount + " BINGO!";
        }

        //ビンゴ数の保存        
        PlayerPrefs.SetString(SaveKey.BINGO_COUNT_KEY, bingoCountText.text);

        //ビンゴ状態の保存
        for (int i = 0; i < isHolls.Length; i++)
        {
            PlayerPrefs.SetString("HOLL" + i, isHolls[i].ToString());
        }

        AudioManager.PlayCheckBingoSe();
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
            AudioManager.PlayNoButtonSe();
            gameObj.SetActive(false);
        }
        else
        {
            //非アクティブの場合
            gameObj.SetActive(true);
        }
    }

    /// <summary>
    /// タイトル画面に遷移する
    /// </summary>
    public void MoveTitle()
    {
        //BGMMを停止
        AudioManager.StopMusic();

        AudioManager.PlayMoveSceneSe();
        SceneManager.LoadScene(SceneName.TITLE_SCENE_NAME);
    }
}

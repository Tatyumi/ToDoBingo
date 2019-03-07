using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /// <summary>タイトルシーンのBGM</summary>
    public AudioClip TitleSceneBGM;
    /// <summary>ビンゴシーンのBGM</summary>
    public AudioClip BingoSceneBGM;
    /// <summary>マスを選択した時のSE</summary>
    public AudioClip SelectedMassSE;
    /// <summary>マスの穴をきりかえるときのSE</summary>
    public AudioClip SwitchHollSE;
    /// <summary>ビンゴチェックのSE</summary>
    public AudioClip CheckBingoSE;
    /// <summary>エディットボタン押下時のSE</summary>
    public AudioClip EditButtonSE;
    /// <summary>バックボタン押下時のSE</summary>
    public AudioClip BackButtonSE;
    /// <summary>パネル表示SE</summary>
    public AudioClip DisplayPanelSE;
    /// <summary>Noボタン押下時SE</summary>
    public AudioClip NoButtonSE;
    /// <summary>TODOリスト保存時SE</summary>
    public AudioClip SaveTodoListSE;
    /// <summary>シーン遷移時SE</summary>
    public AudioClip MoveSceneSE;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Use this for initialization
    void Start()
    {
        //シーンが遷移しても破棄されない
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// タイトルシーンのBGMを再生
    /// </summary>
    public void PlayTitleSceneBgm()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        audioSource.PlayOneShot(TitleSceneBGM);
    }

    /// <summary>
    /// ビンゴシーンのBGMを再生
    /// </summary>
    public void PlayBingoSceneBgm()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        audioSource.PlayOneShot(BingoSceneBGM);
    }

    /// <summary>
    /// ビンゴマスを選択した時のSE
    /// </summary>
    public void PlaySelectedMassSe()
    {
        audioSource.PlayOneShot(SelectedMassSE);
    }

    /// <summary>
    /// ビンゴマスの穴をきりかえるときのSE
    /// </summary>
    public void PlaySwitchHollSe()
    {
        audioSource.PlayOneShot(SwitchHollSE);
    }

    /// <summary>
    /// ビンゴチェック時のSE
    /// </summary>
    public void PlayCheckBingoSe()
    {
        audioSource.PlayOneShot(CheckBingoSE);
    }

    /// <summary>
    /// EDITボタン押下時のSE
    /// </summary>
    public void PlayEditButtonSe()
    {
        audioSource.PlayOneShot(EditButtonSE);
    }

    /// <summary>
    /// バックボタン押下時のSE
    /// </summary>
    public void PlayBackButtonSe()
    {
        audioSource.PlayOneShot(BackButtonSE);
    }

    /// <summary>
    /// パネル表示SE
    /// </summary>
    public void PlayDisplayPanelSe()
    {
        audioSource.PlayOneShot(DisplayPanelSE);
    }

    /// <summary>
    /// Noボタン押下時のSE
    /// </summary>
    public void PlayNoButtonSe()
    {
        audioSource.PlayOneShot(NoButtonSE);
    }

    /// <summary>
    /// TODOリスト保存時SE
    /// </summary>
    public void PlaySaveTodoListSe()
    {
        audioSource.PlayOneShot(SaveTodoListSE);
    }

    /// <summary>
    /// シーン遷移時SE
    /// </summary>
    public void PlayMoveSceneSe()
    {
        audioSource.PlayOneShot(MoveSceneSE);
    }

    /// <summary>
    /// 音を停止
    /// </summary>
    public void StopMusic()
    {
        audioSource.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;

    /// <summary>タイトルシーンのBGM</summary>
    public AudioClip titleSceneBgm;
    /// <summary>ビンゴシーンのBGM</summary>
    public AudioClip bingoSceneBgm;
    /// <summary>マスを選択した時のSE</summary>
    public AudioClip selectedMassSe;
    /// <summary>マスの穴をきりかえるときのSE</summary>
    public AudioClip switchHollSe;
    /// <summary>ビンゴチェックのSE</summary>
    public AudioClip checkBingoSe;
    /// <summary>エディットボタン押下時のSE</summary>
    public AudioClip editButtonSe;
    /// <summary>バックボタン押下時のSE</summary>
    public AudioClip backButtonSe;
    /// <summary>パネル表示SE</summary>
    public AudioClip displayPanelSe;
    /// <summary>Noボタン押下時SE</summary>
    public AudioClip noButtonSe;
    /// <summary>TODOリスト保存時SE</summary>
    public AudioClip saveTodoListSe;
    /// <summary>シーン遷移時SE</summary>
    public AudioClip moveSceneSe;


    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        audioSource.PlayOneShot(titleSceneBgm);
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
        audioSource.PlayOneShot(bingoSceneBgm);
    }

    /// <summary>
    /// ビンゴマスを選択した時のSE
    /// </summary>
    public void PlaySelectedMassSe()
    {
        audioSource.PlayOneShot(selectedMassSe);
    }

    /// <summary>
    /// ビンゴマスの穴をきりかえるときのSE
    /// </summary>
    public void PlaySwitchHollSe()
    {
        audioSource.PlayOneShot(switchHollSe);
    }

    /// <summary>
    /// ビンゴチェック時のSE
    /// </summary>
    public void PlayCheckBingoSe()
    {
        audioSource.PlayOneShot(checkBingoSe);
    }

    /// <summary>
    /// EDITボタン押下時のSE
    /// </summary>
    public void PlayEditButtonSe()
    {
        audioSource.PlayOneShot(editButtonSe);
    }

    /// <summary>
    /// バックボタン押下時のSE
    /// </summary>
    public void PlayBackButtonSe()
    {
        audioSource.PlayOneShot(backButtonSe);
    }

    /// <summary>
    /// パネル表示SE
    /// </summary>
    public void PlayDisplayPanelSe()
    {
        audioSource.PlayOneShot(displayPanelSe);
    }

    /// <summary>
    /// Noボタン押下時のSE
    /// </summary>
    public void PlayNoButtonSe()
    {
        audioSource.PlayOneShot(noButtonSe);
    }

    /// <summary>
    /// TODOリスト保存時SE
    /// </summary>
    public void PlaySaveTodoListSe()
    {
        audioSource.PlayOneShot(saveTodoListSe);
    }

    /// <summary>
    /// シーン遷移時SE
    /// </summary>
    public void PlayMoveSceneSe()
    {
        audioSource.PlayOneShot(moveSceneSe);
    }

    /// <summary>
    /// 音を停止
    /// </summary>
    public void StopMusic()
    {
        audioSource.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;


public class StartButton : MonoBehaviour
{
    //スタートボタンフラグ
    public bool sbf = false;


    // タイマー
    public float timer = 0.0f;

    // カウントダウン用
    public int timeLimit = 5; //制限時間
    public TextMeshProUGUI timerText; //タイマーテキスト


    //ButtonたちObject
    //HeaderのButton
    public GameObject CButtonO;
    public GameObject DButtonO;
    public GameObject EButtonO;
    public GameObject FButtonO;
    public GameObject GButtonO;
    public GameObject AButtonO;
    public GameObject BButtonO;
    //Back,NextButton
    public GameObject BackButtonO;
    public GameObject NextButtonO;

    
    //どのボタンが押されているかを確認
    public ChordButton CB;
    
    //それぞれのコード検知script
    public inputChord IC;


    void Update()
    {
        //スタートボタンが押されているとき
        if(sbf == true){
            timer += Time.deltaTime; //時間計測

            //5秒カウントダウン
            int remaining = timeLimit - (int)timer; //残り時間
            if(remaining > 0){
                //timerText.enabled = true; //timerText表示
                timerText.SetText("{0}", remaining); //Textをセット
            }
        }
    }


    public void OnClickStart()
    {
        //スタートボタンが押された
        sbf = true;

        //他のボタンを押せなくする
        DisInteractable();

        //コードを検知
        IC.EnableC();
    }


    //Rec中他ボタンを押せなくする
    void DisInteractable()
    {
        //コンポーネントの取得
        //Header
        Button CButtonB = CButtonO.GetComponent<Button>();
        Button DButtonB = DButtonO.GetComponent<Button>();
        Button EButtonB = EButtonO.GetComponent<Button>();
        Button FButtonB = FButtonO.GetComponent<Button>();
        Button GButtonB = GButtonO.GetComponent<Button>();
        Button AButtonB = AButtonO.GetComponent<Button>();
        Button BButtonB = BButtonO.GetComponent<Button>();
        //BackNextButton
        Button BackButtonB = BackButtonO.GetComponent<Button>();
        Button NextButtonB = NextButtonO.GetComponent<Button>();


        //Button機能の除去
        //Header
        CButtonB.interactable = false;
        DButtonB.interactable = false;
        EButtonB.interactable = false;
        FButtonB.interactable = false;
        GButtonB.interactable = false;
        AButtonB.interactable = false;
        BButtonB.interactable = false;
        //BackNextButton
        BackButtonB.interactable = false;
        NextButtonB.interactable = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChordButton : MonoBehaviour
{
    //Chordのimage
    private Image ChordImage;
    
    //それぞれのコードの画像
    public Sprite imageC;
    public Sprite imageDm;
    public Sprite imageEm;
    public Sprite imageF;
    public Sprite imageG;
    public Sprite imageAm;
    public Sprite imageBm;


    //コードの名前
    public TextMeshProUGUI ChordName;

    //TextBox
    public TextMeshProUGUI TextBox;

    //各ボタン
    public GameObject NextButton;
    public GameObject BackButton;
    public GameObject NextSceneButton;


    //点数表示用のフラグ(初期値C)
    public int i = 1;



    //スタートボタンのフラグ取得のため
    public StartButton SB;

    //pointText取得のため
    public inputChord IC;


    void Start()
    {
        //Chord(image)のコンポーネントを取得
        ChordImage = GameObject.Find("Chord").GetComponent<Image>();
    }


    void Update()
    {
        //Buttonの表示・非表示
        if(i == 1){
            BackButton.SetActive(false); //BackButton非表示
        }
        else if(i == 7){
            NextButton.SetActive(false); //NextButton非表示
        }
        else{
            BackButton.SetActive(true);
            NextButton.SetActive(true);
        }
    }


    //ButtonCを押したとき
    public void OnClickC()
    {
        Debug.Log("Click C");
        
        //画像，文字を切り替える
        ChordImage.sprite = imageC;
        ChordName.SetText("C");
        TextBox.SetText("Push the Rec Button"); //TextBoxも

        //BackButton.SetActive(false);
        
        //点数表示切替のフラグ
        i = 1;

        //スタートボタン，タイマー，pointTextをリセット
        Reset();
    }

    //ButtonDmを押したとき
    public void OnClickDm()
    {
        Debug.Log("Click Dm");

        ChordImage.sprite = imageDm;
        ChordName.SetText("Dm");
        TextBox.SetText("Push the Rec Button");

        i = 2;

        Reset();
    }

    //ButtonEmを押したとき
    public void OnClickEm()
    {
        Debug.Log("Click Em");

        ChordImage.sprite = imageEm;
        ChordName.SetText("Em");
        TextBox.SetText("Push the Rec Button");//TextBoxも

        i = 3;

        Reset();
    }

    //ButtonFを押したとき
    public void OnClickF()
    {
        Debug.Log("Click F");

        ChordImage.sprite = imageF;
        ChordName.SetText("F");
        TextBox.SetText("Push the Rec Button");//TextBoxも

        i = 4;

        Reset();
    }

    //ButtonGを押したとき
    public void OnClickG()
    {
        Debug.Log("Click G");

        ChordImage.sprite = imageG;
        ChordName.SetText("G");
        TextBox.SetText("Push the Rec Button");//TextBoxも

        i = 5;

        Reset();
    }

    //ButtonAmを押したとき
    public void OnClickAm()
    {
        Debug.Log("Click Am");

        ChordImage.sprite = imageAm;
        ChordName.SetText("Am");
        TextBox.SetText("Push the Rec Button");//TextBoxも

        i = 6;

        Reset();
    }

    //ButtonBmを押したとき
    public void OnClickBm()
    {
        Debug.Log("Click Bm");

        ChordImage.sprite = imageBm;
        ChordName.SetText("Bm");
        TextBox.SetText("Push the Rec Button");//TextBoxも

        i = 7;

        Reset();
    }


    void Reset(){
        SB.sbf = false; //スタートボタンリセット
        SB.timer = 0.0f; //タイマーリセット

        //pointTextリセット
        IC.pointText1.enabled = false;
        IC.pointText2.enabled = false;
        IC.pointText3.enabled = false;
    }
}

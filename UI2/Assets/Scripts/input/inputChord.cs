using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;


public class inputChord : MonoBehaviour
{
    private InputActions _action;
    public StartButton SB;
    public ChordButton CB;

    //音がなっているかのフラグ
    private int j_c6 = 0;
    private int j_c5 = 0;
    private int j_c4 = 0;
    private int j_c3 = 0;
    private int j_c2 = 0;
    private int j_c1 = 0;
    
    //完成度
    private int point1 = 0;
    private int point2 = 0;
    private int point3 = 0;
    private int maxp = 0;

    //コード完成度保存
    public int[] ChordPoint = new int[7]; 


    //時間ごとに処理を行うフラグ
    bool FScoreIn = false;

    bool FScoreCal = false;
    bool SScoreCal = false;
    bool TScoreCal = false;


    //pointテキスト
    public TextMeshProUGUI pointText1;
    public TextMeshProUGUI pointText2;
    public TextMeshProUGUI pointText3;
    //TextBox
    public TextMeshProUGUI TextBox;


    void Update()
    {
        //タイマーによる動作(取得ポイント)の変化
        if(SB.timer < 5.0f){ //5秒待機
            ; //何もしない(違うスクリプト内でカウントダウン表示)
        }
        else if(SB.timer > 5.0f && FScoreIn == false){ //1回目入力中
            //スコア入力を促す
            TextBox.SetText("1 : Play the chord once");

            Debug.Log("1回目");

            //スコア入力テキストフラグ
            FScoreIn = true;
        }
        else if(SB.timer > 8.0f && FScoreCal == false){ //1回目得点計算 / 表示 / ポイントリセット
            TextBox.SetText("2 : Play the chord once");

            Debug.Log("2回目");
            point1 = CalP(); //得点計算(コードごとで異なる)

            pointText1.SetText("{0}", point1); //point表示
            pointText1.enabled = true; //enable false解除

            //フラグリセット
            FReset();

            //1回目得点計算完了フラグ
            FScoreCal = true;
        }
        else if(SB.timer > 11.0f && SScoreCal == false){ //2回目得点計算 / 表示 / ポイントリセット
            TextBox.SetText("3 : Play the chord once");

            Debug.Log("3回目");
            point2 = CalP();

            pointText2.SetText("{0}", point2);
            pointText2.enabled = true;

            FReset();

            SScoreCal = true;
        }
        else if(SB.timer > 14.0f && TScoreCal == false){ //3回目得点計算 / 表示 / / ポイントリセット / 終了
            TextBox.SetText("Congratulation");

            point3 = CalP();

            pointText3.SetText("{0}", point3);
            pointText3.enabled = true;

            FReset();

            TScoreCal = true;

            Debug.Log("fin");
            Finish();
        }
    }





    public void EnableC() //コードを取得可能にする
    {
        _action = new InputActions(); //Actionスクリプトのインスタンス生成

        //入力フラグリセット
        FScoreIn = false;

        FScoreCal = false;
        SScoreCal = false;
        TScoreCal = false;

        //コードごとのActionイベント登録
        if(CB.i == 1){  //C
            _action.C.note_C6.performed += OnPerformedC6;
            _action.C.note_C5.performed += OnPerformedC5;
            _action.C.note_C4.performed += OnPerformedC4;
            _action.C.note_C3.performed += OnPerformedC3;
            _action.C.note_C2.performed += OnPerformedC2;
            _action.C.note_C1.performed += OnPerformedC1;
        }
        else if(CB.i == 2){  //Dm
            _action.Dm.note_D6.performed += OnPerformedD6;
            _action.Dm.note_D5.performed += OnPerformedD5;
            _action.Dm.note_D4.performed += OnPerformedD4;
            _action.Dm.note_D3.performed += OnPerformedD3;
            _action.Dm.note_D2.performed += OnPerformedD2;
            _action.Dm.note_D1.performed += OnPerformedD1;
        }
        else if(CB.i == 3){  //Em
            _action.Em.note_E6.performed += OnPerformedE6;
            _action.Em.note_E5.performed += OnPerformedE5;
            _action.Em.note_E4.performed += OnPerformedE4;
            _action.Em.note_E3.performed += OnPerformedE3;
            _action.Em.note_E2.performed += OnPerformedE2;
            _action.Em.note_E1.performed += OnPerformedE1;
        }
        else if(CB.i == 4){  //F
            _action.F.note_F6.performed += OnPerformedF6;
            _action.F.note_F5.performed += OnPerformedF5;
            _action.F.note_F4.performed += OnPerformedF4;
            _action.F.note_F3.performed += OnPerformedF3;
            _action.F.note_F2.performed += OnPerformedF2;
            _action.F.note_F1.performed += OnPerformedF1;
        }
        else if(CB.i == 5){  //G
            _action.G.note_G6.performed += OnPerformedG6;
            _action.G.note_G5.performed += OnPerformedG5;
            _action.G.note_G4.performed += OnPerformedG4;
            _action.G.note_G3.performed += OnPerformedG3;
            _action.G.note_G2.performed += OnPerformedG2;
            _action.G.note_G1.performed += OnPerformedG1;
        }
        else if(CB.i == 6){  //Am
            _action.Am.note_A6.performed += OnPerformedA6;
            _action.Am.note_A5.performed += OnPerformedA5;
            _action.Am.note_A4.performed += OnPerformedA4;
            _action.Am.note_A3.performed += OnPerformedA3;
            _action.Am.note_A2.performed += OnPerformedA2;
            _action.Am.note_A1.performed += OnPerformedA1;
        }
        else if(CB.i == 7){  //Bm♭5
            _action.Bm.note_B6.performed += OnPerformedB6;
            _action.Bm.note_B5.performed += OnPerformedB5;
            _action.Bm.note_B4.performed += OnPerformedB4;
            _action.Bm.note_B3.performed += OnPerformedB3;
            _action.Bm.note_B2.performed += OnPerformedB2;
            _action.Bm.note_B1.performed += OnPerformedB1;
        }
        

        _action.Enable(); //有効化
    }


    void Finish()
    {   
        //maxpを選ぶ
        maxp = Mathf.Max(point1, point2, point3);

        //point保存 and performed enable
        if(CB.i == 1){ //C
            //maxpointを各コードの完成度とする
            ChordPoint[0] = maxp;

            _action.C.note_C6.performed -= OnPerformedC6;
            _action.C.note_C5.performed -= OnPerformedC5;
            _action.C.note_C4.performed -= OnPerformedC4;
            _action.C.note_C3.performed -= OnPerformedC3;
            _action.C.note_C2.performed -= OnPerformedC2;
            _action.C.note_C1.performed -= OnPerformedC1;
        }
        else if(CB.i == 2){ //Dm
            //maxpointを各コードの完成度とする
            ChordPoint[1] = maxp;

            _action.Dm.note_D6.performed -= OnPerformedD6;
            _action.Dm.note_D5.performed -= OnPerformedD5;
            _action.Dm.note_D4.performed -= OnPerformedD4;
            _action.Dm.note_D3.performed -= OnPerformedD3;
            _action.Dm.note_D2.performed -= OnPerformedD2;
            _action.Dm.note_D1.performed -= OnPerformedD1;
        }
        else if(CB.i == 3){ //Em
            //maxpointを各コードの完成度とする
            ChordPoint[2] = maxp;

            _action.Em.note_E6.performed -= OnPerformedE6;
            _action.Em.note_E5.performed -= OnPerformedE5;
            _action.Em.note_E4.performed -= OnPerformedE4;
            _action.Em.note_E3.performed -= OnPerformedE3;
            _action.Em.note_E2.performed -= OnPerformedE2;
            _action.Em.note_E1.performed -= OnPerformedE1;
        }
        else if(CB.i == 4){ //F
            //maxpointを各コードの完成度とする
            ChordPoint[3] = maxp;

            _action.F.note_F6.performed -= OnPerformedF6;
            _action.F.note_F5.performed -= OnPerformedF5;
            _action.F.note_F4.performed -= OnPerformedF4;
            _action.F.note_F3.performed -= OnPerformedF3;
            _action.F.note_F2.performed -= OnPerformedF2;
            _action.F.note_F1.performed += OnPerformedF1;
        }
        else if(CB.i == 5){ //G
            //maxpointを各コードの完成度とする
            ChordPoint[4] = maxp;

            _action.G.note_G6.performed -= OnPerformedG6;
            _action.G.note_G5.performed -= OnPerformedG5;
            _action.G.note_G4.performed -= OnPerformedG4;
            _action.G.note_G3.performed -= OnPerformedG3;
            _action.G.note_G2.performed -= OnPerformedG2;
            _action.G.note_G1.performed -= OnPerformedG1;
        }
        else if(CB.i == 6){ //Am
            //maxpointを各コードの完成度とする
            ChordPoint[5] = maxp;

            _action.Am.note_A6.performed -= OnPerformedA6;
            _action.Am.note_A5.performed -= OnPerformedA5;
            _action.Am.note_A4.performed -= OnPerformedA4;
            _action.Am.note_A3.performed -= OnPerformedA3;
            _action.Am.note_A2.performed -= OnPerformedA2;
            _action.Am.note_A1.performed += OnPerformedA1;
        }
        else if(CB.i == 7){ //Bm♭5
            //maxpointを各コードの完成度とする
            ChordPoint[6] = maxp;

            _action.Bm.note_B6.performed -= OnPerformedB6;
            _action.Bm.note_B5.performed -= OnPerformedB5;
            _action.Bm.note_B4.performed -= OnPerformedB4;
            _action.Bm.note_B3.performed -= OnPerformedB3;
            _action.Bm.note_B2.performed -= OnPerformedB2;
            _action.Bm.note_B1.performed -= OnPerformedB1;

            //SceneButton表示
            CB.NextSceneButton.SetActive(true);
        }

        _action.Disable(); //無効化

        //スタートボタン，タイマー，ポイントをリセット
        SB.sbf = false;
        SB.timer = 0.0f;
        maxp = 0;

        //Button再開
        EnableInteractable();
    }





    //point，フラグリセット
    void FReset()
    {
        //フラグリセット
        j_c6 = 0;
        j_c5 = 0;
        j_c4 = 0;
        j_c3 = 0;
        j_c2 = 0;
        j_c1 = 0;
    }





    //Interactable復活
    void EnableInteractable()
    {
        //コンポーネントの取得
        //Header
        Button CButtonB = SB.CButtonO.GetComponent<Button>();
        Button DButtonB = SB.DButtonO.GetComponent<Button>();
        Button EButtonB = SB.EButtonO.GetComponent<Button>();
        Button FButtonB = SB.FButtonO.GetComponent<Button>();
        Button GButtonB = SB.GButtonO.GetComponent<Button>();
        Button AButtonB = SB.AButtonO.GetComponent<Button>();
        Button BButtonB = SB.BButtonO.GetComponent<Button>();
        //BackNextButton
        Button BackButtonB = SB.BackButtonO.GetComponent<Button>();
        Button NextButtonB = SB.NextButtonO.GetComponent<Button>();


        //Button機能の除去
        //Header
        CButtonB.interactable = true;
        DButtonB.interactable = true;
        EButtonB.interactable = true;
        FButtonB.interactable = true;
        GButtonB.interactable = true;
        AButtonB.interactable = true;
        BButtonB.interactable = true;
        //BackNextButton
        BackButtonB.interactable = true;
        NextButtonB.interactable = true;
    }





    //ポイント計算
    int CalP() //全体
    {
        int score = 0;

        if(CB.i == 3 || CB.i == 4 || CB.i == 5){ //すべての弦を鳴らすコード(Em,F,G)
            score = CalAllStringsP();
        }
        else if(CB.i == 1 || CB.i == 6){ //6弦を弾かないコード(C,Am)
            score = CalNotOneStringsP();
        }
        else if(CB.i == 2){ //5,6弦を弾かないコード(Dm)
            score = CalNotTwoStringsP();
        }
        else if(CB.i == 7){ //1,6弦を弾かないコード(Bm♭5)
            score = CalNotStringsP();
        }

        return score;
    }


    int CalAllStringsP() //すべての弦を鳴らすコードのポイントを計算
    {
        int point = 0;

        //各弦に対する得点
        point += j_c6;
        point += j_c5;
        point += j_c4;
        point += j_c3;
        point += j_c2;
        point += j_c1;

        return point;
    }

    int CalNotOneStringsP() //6弦を弾かないコードのポイントを計算
    {
        int point = 0;

        //各弦に対する得点
        if(j_c6 == 0){ //鳴っていないとき加点
            point ++;
        }
        point += j_c5;
        point += j_c4;
        point += j_c3;
        point += j_c2;
        point += j_c1;

        return point;
    }

    int CalNotTwoStringsP() //5,6弦を弾かないコードのポイントを計算
    {
        int point = 0;

        //各弦に対する得点
        if(j_c6 == 0){
            point ++;
        }
        if(j_c5 == 0){
            point ++;
        }
        point += j_c4;
        point += j_c3;
        point += j_c2;
        point += j_c1;

        return point;
    }

    int CalNotStringsP() //1,6弦を弾かないコードのポイントを計算
    {
        int point = 0;

        //各弦に対する得点
        if(j_c6 == 0){
            point ++;
        }
        point += j_c5;
        point += j_c4;
        point += j_c3;
        point += j_c2;
        if(j_c1 == 0){
            point ++;
        }

        return point;
    }

    



    //以下入力に対してのフラグ処理

    //Cの処理
    void OnPerformedC6(InputAction.CallbackContext ctx) //6弦
    {
        Debug.Log("OnC6");
        j_c6 = 1;
    }
    void OnPerformedC5(InputAction.CallbackContext ctx) //5弦
    {
        Debug.Log("OnC5");
        j_c5 = 1;
    }

    void OnPerformedC4(InputAction.CallbackContext ctx) //4弦
    {
        Debug.Log("OnC4");
        j_c4 = 1;
    }

    void OnPerformedC3(InputAction.CallbackContext ctx) //3弦
    {
        Debug.Log("OnC3");
        j_c3 = 1;
    }

    void OnPerformedC2(InputAction.CallbackContext ctx) //2弦
    {
        Debug.Log("OnC2");
        j_c2 = 1;
    }

    void OnPerformedC1(InputAction.CallbackContext ctx) //1弦
    {
        Debug.Log("OnC1");
        j_c1 = 1;
    }

    //Dmの処理
    void OnPerformedD6(InputAction.CallbackContext ctx) //6弦
    {
        Debug.Log("OnD6");
        j_c6 = 1;
    }
    void OnPerformedD5(InputAction.CallbackContext ctx) //5弦
    {
        Debug.Log("OnD5");
        j_c5 = 1;
    }

    void OnPerformedD4(InputAction.CallbackContext ctx) //4弦
    {
        Debug.Log("OnD4");
        j_c4 = 1;
    }

    void OnPerformedD3(InputAction.CallbackContext ctx) //3弦
    {
        Debug.Log("OnD3");
        j_c3 = 1;
    }

    void OnPerformedD2(InputAction.CallbackContext ctx) //2弦
    {
        Debug.Log("OnD2");
        j_c2 = 1;
    }

    void OnPerformedD1(InputAction.CallbackContext ctx) //1弦
    {
        Debug.Log("OnD1");
        j_c1 = 1;
    }

    //Emの処理
    void OnPerformedE6(InputAction.CallbackContext ctx) //6弦
    {
        Debug.Log("OnE6");
        j_c6 = 1;
    }
    void OnPerformedE5(InputAction.CallbackContext ctx) //5弦
    {
        Debug.Log("OnE5");
        j_c5 = 1;
    }

    void OnPerformedE4(InputAction.CallbackContext ctx) //4弦
    {
        Debug.Log("OnE4");
        j_c4 = 1;
    }

    void OnPerformedE3(InputAction.CallbackContext ctx) //3弦
    {
        Debug.Log("OnE3");
        j_c3 = 1;
    }

    void OnPerformedE2(InputAction.CallbackContext ctx) //2弦
    {
        Debug.Log("OnE2");
        j_c2 = 1;
    }

    void OnPerformedE1(InputAction.CallbackContext ctx) //1弦
    {
        Debug.Log("OnE1");
        j_c1 = 1;
    }

    //Fの処理
    void OnPerformedF6(InputAction.CallbackContext ctx) //6弦
    {
        Debug.Log("OnF6");
        j_c6 = 1;
    }
    void OnPerformedF5(InputAction.CallbackContext ctx) //5弦
    {
        Debug.Log("OnF5");
        j_c5 = 1;
    }

    void OnPerformedF4(InputAction.CallbackContext ctx) //4弦
    {
        Debug.Log("OnF4");
        j_c4 = 1;
    }

    void OnPerformedF3(InputAction.CallbackContext ctx) //3弦
    {
        Debug.Log("OnF3");
        j_c3 = 1;
    }

    void OnPerformedF2(InputAction.CallbackContext ctx) //2弦
    {
        Debug.Log("OnF2");
        j_c2 = 1;
    }

    void OnPerformedF1(InputAction.CallbackContext ctx) //1弦
    {
        Debug.Log("OnF1");
        j_c1 = 1;
    }

    //Gの処理
    void OnPerformedG6(InputAction.CallbackContext ctx) //6弦
    {
        Debug.Log("OnG6");
        j_c6 = 1;
    }
    void OnPerformedG5(InputAction.CallbackContext ctx) //5弦
    {
        Debug.Log("OnG5");
        j_c5 = 1;
    }

    void OnPerformedG4(InputAction.CallbackContext ctx) //4弦
    {
        Debug.Log("OnG4");
        j_c4 = 1;
    }

    void OnPerformedG3(InputAction.CallbackContext ctx) //3弦
    {
        Debug.Log("OnG3");
        j_c3 = 1;
    }

    void OnPerformedG2(InputAction.CallbackContext ctx) //2弦
    {
        Debug.Log("OnG2");
        j_c2 = 1;
    }

    void OnPerformedG1(InputAction.CallbackContext ctx) //1弦
    {
        Debug.Log("OnG1");
        j_c1 = 1;
    }

    //Amの処理
    void OnPerformedA6(InputAction.CallbackContext ctx) //6弦
    {
        Debug.Log("OnA6");
        j_c6 = 1;
    }
    void OnPerformedA5(InputAction.CallbackContext ctx) //5弦
    {
        Debug.Log("OnA5");
        j_c5 = 1;
    }

    void OnPerformedA4(InputAction.CallbackContext ctx) //4弦
    {
        Debug.Log("OnA4");
        j_c4 = 1;
    }

    void OnPerformedA3(InputAction.CallbackContext ctx) //3弦
    {
        Debug.Log("OnA3");
        j_c3 = 1;
    }

    void OnPerformedA2(InputAction.CallbackContext ctx) //2弦
    {
        Debug.Log("OnA2");
        j_c2 = 1;
    }

    void OnPerformedA1(InputAction.CallbackContext ctx) //1弦
    {
        Debug.Log("OnA1");
        j_c1 = 1;
    }

    //Bm♭5の処理
    void OnPerformedB6(InputAction.CallbackContext ctx) //6弦
    {
        Debug.Log("OnB6");
        j_c6 = 1;
    }
    void OnPerformedB5(InputAction.CallbackContext ctx) //5弦
    {
        Debug.Log("OnB5");
        j_c5 = 1;
    }

    void OnPerformedB4(InputAction.CallbackContext ctx) //4弦
    {
        Debug.Log("OnB4");
        j_c4 = 1;
    }

    void OnPerformedB3(InputAction.CallbackContext ctx) //3弦
    {
        Debug.Log("OnB3");
        j_c3 = 1;
    }

    void OnPerformedB2(InputAction.CallbackContext ctx) //2弦
    {
        Debug.Log("OnB2");
        j_c2 = 1;
    }

    void OnPerformedB1(InputAction.CallbackContext ctx) //1弦
    {
        Debug.Log("OnB1");
        j_c1 = 1;
    }
}
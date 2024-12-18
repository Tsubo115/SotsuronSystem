using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

// using System.IO;
// using System.Text;

public class newSkillGen : MonoBehaviour
{
    System.Random r = new System.Random();

    //Generation Count Text
    public TextMeshProUGUI countText;
    int count = 1;


    public int M = 6; //練習曲数
    public int N = 8; //コード進行のコード数


    //chord progression(度数のみ，M行N列)
    public int[,] skillcp;

    //各評価を動的に定義するため
    int defineCount = 0;
    //難しいコードの配列番号およびグループ番号
    List<List<int>> diffNum = new List<List<int>>();


    //ここに7th入れる！？
    //トニック
    int[] tonic = {1, 3, 6};
    //サブドミナント
    int[] subdominant = {2, 4};
    //ドミナント
    int[] dominant = {5, 7};


    


    void Start()
    {
        skillcp = new int[M, N]; //初期化


        //難しいコード
        Debug.Log("DifficultChord");
        for(int i = 0; i < 3; i++){
            Debug.Log(Data.instance.DiffChord[i]);
        }
        //エリート個体
        Debug.Log("eliteChord");
        for(int i = 0; i < 8; i++){
            Debug.Log(Data.instance.elicp[i]);
        }

        //初期解生成
        SkillInitial();


        //生成されたコード進行
        Debug.Log("ConSlillChord");
        for(int i = 0; i < N; i++){
            Debug.Log(skillcp[0, i]);
        }
        

        //結果
        Debug.Log("確認");
        Debug.Log("diffNum");
        // for(int i = 0; i < diffNum.Count; i++){
        //     Debug.Log(diffNum[i, i]);
        // }
        Debug.Log("defineCount");
        Debug.Log(defineCount);





        // CSVファイルのパスを指定
        // string filePath = "mydata.csv";

        // try
        // {
        //     // StreamWriterを使ってファイルを開く
        //     using (StreamWriter writer = new StreamWriter(filePath))
        //     {
        //         // // ヘッダー行を書き込む
        //         writer.WriteLine("名前,年齢,趣味");

        //         // // データ行を書き込む
        //         writer.WriteLine("山田太郎,28,サッカー");
        //         writer.WriteLine("佐藤花子,32,読書");
        //         writer.WriteLine("鈴木一郎,45,釣り");
        //         // for(int i = 0; i < M; i++){
        //         //     for(int j = 0; j < N; j++){
        //         //         // ヘッダー行を書き込む
        //         //         writer.Write(skillcp[i, j]);

        //         //         // 最後の列でない場合はカンマを書く
        //         //         if (j < N - 1)
        //         //         {
        //         //             writer.Write(","); // カンマ区切り
        //         //         }
        //         //     }
        //         //     // 行の最後に改行を追加
        //         //     writer.WriteLine();
        //         // }
        //     }

        //     Console.WriteLine("CSVファイルの作成が完了しました！");
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine($"エラーが発生しました: {ex.Message}");
        // }



        //Excelあるか確認
        // if(!isExistSaveFile()){
        //     makeSaveData();
        // }
    }


    //NextGenSkillボタンの動作
    public void OnClickNextGenSkill()
    {
        //SkillGen();

        //カウント表示
        count++;
        countText.SetText("Generation {0}", count);
    }



    //初期解生成
    void SkillInitial()
    {
        bool defineFlag = false;

        for(int i = 0; i < M; i++){ //練習曲数
            for(int j = 0; j < N; j++){ //コード数
                if(Data.instance.elicp[j] == Data.instance.DiffChord[0] || Data.instance.elicp[j] == Data.instance.DiffChord[1] || Data.instance.elicp[j] == Data.instance.DiffChord[2]){ //難しいコードの時

                    if(Data.instance.elicp[j] == tonic[0] || Data.instance.elicp[j] == tonic[1] || Data.instance.elicp[j] == tonic[2]){ //トニックの時
                        skillcp[i, j] = iniTonicfunc(Data.instance.elicp[j], i); //トニックのコードに置き換える

                        //1曲目のみ実行
                        if(defineFlag == false){
                            DefinechordScore(0, j); //スコア保存配列の動的定義
                        }
                    }

                    else if(Data.instance.elicp[j] == subdominant[0] || Data.instance.elicp[j] == subdominant[1]){ //サブドミナントの時
                        skillcp[i, j] = iniSubdominantfunc(Data.instance.elicp[j], i);

                        if(defineFlag == false){
                            DefinechordScore(1, j);
                        }
                    }

                    else if(Data.instance.elicp[j] == dominant[0] || Data.instance.elicp[j] == dominant[1]){ //ドミナントの時
                        skillcp[i, j] = iniDominantfunc(Data.instance.elicp[j], i);

                        if(defineFlag == false){
                            DefinechordScore(2, j);
                        }
                    }
                }

                else{ //その他のコードはコピー
                    skillcp[i, j] = Data.instance.elicp[j];
                }
            }

            //1曲目かどうか
            if(defineFlag == false){
                defineFlag = true;
            }
        }
    }

    //配列chordScoreの動的定義
    void DefinechordScore(int groupnum, int j)
    {
        List<int> data = new List<int>();

        //難しいコードを発見した回数・グループに応じて処理
        if(defineCount == 0){
            data.Add(j); //難しいコードの配列番号を保存
            data.Add(groupnum); //難しいコードのグループを保存
            defineCount++;
        }
        else if(defineCount == 1){
            data.Add(j);
            data.Add(groupnum);
            defineCount++;
        }
        else if(defineCount == 2){
            data.Add(j);
            data.Add(groupnum);
            defineCount++;
        }
        else if(defineCount == 3){
            data.Add(j);
            data.Add(groupnum);
            defineCount++;
        }
        else if(defineCount == 4){
            data.Add(j);
            data.Add(groupnum);
            defineCount++;
        }
        else if(defineCount == 5){
            data.Add(j);
            data.Add(groupnum);
            defineCount++;
        }
        else if(defineCount == 6){
            data.Add(j);
            data.Add(groupnum);
            defineCount++;
        }
        else if(defineCount == 7){
            data.Add(j);
            data.Add(groupnum);
            defineCount++;
        }

        //難しいコードの配列番号およびグループを保存
        diffNum.Add(data);
    }


    //各グループでの初期処理
    int iniTonicfunc(int diffchord, int i) //aは変更対象のコード
    {
        int[] removec = new int[tonic.Length - 1]; //このコード群の中から変更
        int index = 0;

        //変更対象から高難易度コードを外す
        for(int j = 0; j < tonic.Length; j++){
            if(tonic[j] != diffchord){ //変更対象以外のコードを代入
                removec[index] = tonic[j];
                index++;
            }
        }

        if(i < tonic.Length - 1){ //すべてのコードを挿入
            return removec[i];
        }
        else{ //すべてコードが挿入できたあと
            int rand = r.Next(0, removec.Length); //変更対象を除いたコードグループ

            return removec[rand]; //変更後のコード群からランダムで選ばれたコードを返す
        }
    }

    int iniSubdominantfunc(int diffchord, int i)
    {
        int[] removec = new int[subdominant.Length - 1];
        int index = 0;

        for(int j = 0; j < subdominant.Length; i++){
            if(subdominant[j] != diffchord){
                removec[index] = subdominant[j];
                index++;
            }
        }

        if(i < subdominant.Length - 1){
            return removec[i];
        }
        else{
            int rand = r.Next(0, removec.Length);
            return removec[rand];
        }
    }

    int iniDominantfunc(int diffchord, int i)
    {
        int[] removec = new int[dominant.Length - 1];
        int index = 0;

        for(int j = 0; j < dominant.Length; i++){
            if(dominant[j] != diffchord){
                removec[index] = dominant[j];
                index++;
            }
        }

        if(i < dominant.Length - 1){
            return removec[i];
        }
        else{
            int rand = r.Next(0, removec.Length);
            return removec[rand];
        }
    }



    // int iniTonicfunc(int diffchord, int i) //aは変更対象のコード
    // {
    //     int[] removec = new int[tonic.Length - 1]; //このコード群の中から変更
    //     int index = 0;

    //     for(int j = 0; j < tonic.Length; j++){
    //         if(tonic[j] != diffchord){ //変更対象以外のコードを代入
    //             removec[index] = tonic[j];
    //             index++;
    //         }
    //     }

    //     //変更対象を除いたコードグループ
    //     int rand = r.Next(0, removec.Length);

    //     //変更後のコード群からランダムで選ばれたコードを返す
    //     return removec[rand];
    // }

    // int iniSubdominantfunc(int diffchord, int i)
    // {
    //     int[] removec = new int[subdominant.Length - 1];
    //     int index = 0;

    //     for(int j = 0; j < subdominant.Length; i++){
    //         if(subdominant[j] != diffchord){
    //             removec[index] = subdominant[j];
    //             index++;
    //         }
    //     }

    //     int rand = r.Next(0, removec.Length);

    //     return removec[rand];
    // }

    // int iniDominantfunc(int diffchord, int i)
    // {
    //     int[] removec = new int[dominant.Length - 1];
    //     int index = 0;

    //     for(int j = 0; j < dominant.Length; j++){
    //         if(dominant[j] != diffchord){
    //             removec[index] = dominant[j];
    //             index++;
    //         }
    //     }

    //     int rand = r.Next(0, removec.Length);

    //     return removec[rand];
    // }
    








    //2回目以降は評価に基づいて進化
    // void SkillGen()
    // {
    //     //得点を反映
    //     CalScore();


    //     for(int i = 0; i < M; i++){ //練習曲数
    //         for(int j = 0; j < defineCount; j++){ //難しいコードのみ変更
    //             skillcp[i, diffNum[j, 0]] = replaceChord();
    //         }

    //     }

    //     // for(int i = 0; i < M; i++){ //練習曲数
    //     //     for(int j = 0; j < N; j++){ //コード数
    //     //         if(skillcp[i, j] == Data.instance.DiffChord[0] || skillcp[i, j] == Data.instance.DiffChord[1] || skillcp[i, j] == Data.instance.DiffChord[2]){ //難しいコードの時

    //     //             if(skillcp[i, j] == tonic[0] || skillcp[i, j] == tonic[1] || skillcp[i, j] == tonic[2]){ //トニックの時
    //     //                 skillcp[i, j] = Tonicfunc(Data.instance.elicp[j]);
    //     //             }

    //     //             else if(skillcp[i, j] == subdominant[0] || skillcp[i, j] == subdominant[1]){ //サブドミナントの時
    //     //                 skillcp[i, j] = Subdominantfunc(Data.instance.elicp[j]);
    //     //             }

    //     //             else if(skillcp[i, j] == dominant[0] || skillcp[i, j] == dominant[1]){ //ドミナントの時
    //     //                 skillcp[i, j] = Dominantfunc(Data.instance.elicp[j]);
    //     //             }
    //     //         }

    //     //         else{ //その他のコードはコピー
    //     //             skillcp[i, j] = Data.instance.elicp[j];
    //     //         }
    //     //     }
    //     // }
    // }

    // void CalScore(){
    //     //各スコアを取得
    //     int[] rank = new int[M];
        
    //     //valueの値は0スタートのため + 1 (1～10)
    //     rank[0] = dd1.value + 1;
    //     rank[1] = dd2.value + 1;
    //     rank[2] = dd3.value + 1;
    //     rank[3] = dd4.value + 1;
    //     rank[4] = dd5.value + 1;
    //     rank[5] = dd6.value + 1;


        
    // }

    // void replaceChord()
    // {
    //     int[] removec = new int[tonic.Length - 1]; //このコード群の中から変更
    //     int index = 0;

    //     for(int i = 0; i < tonic.Length; i++){
    //         if(tonic[i] != a){ //変更対象以外のコードを代入
    //             removec[index] = tonic[i];
    //             index++;
    //         }
    //     }

    //     //変更対象を除いたコードグループ
    //     int rand = r.Next(0, removec.Length);

    //     //変更後のコード群からランダムで選ばれたコードを返す
    //     return removec[rand];
    // }
}
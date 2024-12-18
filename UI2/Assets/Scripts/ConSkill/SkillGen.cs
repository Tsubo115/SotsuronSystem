// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;
// using TMPro;

// public class SkillGen : MonoBehaviour
// {
//     System.Random r = new System.Random();

//     //Generation Count Text
//     public TextMeshProUGUI countText;
//     int count = 1;


//     public int M = 6; //練習曲数
//     public int N = 8; //コード進行のコード数


//     //chord progression(度数のみ，M行N列)
//     public int[,] skillcp;


//     //各グループにおける評価
//     // int[] chordScore1;
//     // int[] chordScore2;
//     // int[] chordScore3;
//     // int[] chordScore4;
//     // int[] chordScore5;
//     // int[] chordScore6;
//     // int[] chordScore7;
//     // int[] chordScore8;

//     //各評価を動的に定義するため
//     int defineCount = 0;
//     //難しいコードの配列番号およびグループ番号
//     List<List<int>> diffNum = new List<List<int>>();


//     //ここに7th入れる！？
//     //トニック
//     int[] tonic = {1, 3, 6};
//     //サブドミナント
//     int[] subdominant = {2, 4};
//     //ドミナント
//     int[] dominant = {5, 7};


    


//     void Start()
//     {
//         skillcp = new int[M, N]; //初期化


//         //難しいコード
//         Debug.Log("DifficultChord");
//         for(int i = 0; i < 3; i++){
//             Debug.Log(Data.instance.DiffChord[i]);
//         }
//         //エリート個体
//         Debug.Log("eliteChord");
//         for(int i = 0; i < 8; i++){
//             Debug.Log(Data.instance.elicp[i]);
//         }

//         //初期解生成
//         SkillInitial();


//         //生成されたコード進行
//         Debug.Log("ConSlillChord");
//         for(int i = 0; i < N; i++){
//             Debug.Log(skillcp[0, i]);
//         }
        

//         //結果
//         Debug.Log("確認");
//         Debug.Log("diffNum");
//         for(int i = 0; i < diffNum.Count; i++){
//             Debug.Log(diffNum[i]);
//         }
//         Debug.Log("defineCount");
//         Debug.Log(defineCount);
//     }


//     //NextGenSkillボタンの動作
//     public void OnClickNextGenSkill()
//     {
//         //SkillGen();

//         //カウント表示
//         count++;
//         countText.SetText("Generation {0}", count);
//     }



//     //初期解生成
//     void SkillInitial()
//     {
//         bool defineFlag = false;

//         for(int i = 0; i < M; i++){ //練習曲数
//             for(int j = 0; j < N; j++){ //コード数
//                 if(Data.instance.elicp[j] == Data.instance.DiffChord[0] || Data.instance.elicp[j] == Data.instance.DiffChord[1] || Data.instance.elicp[j] == Data.instance.DiffChord[2]){ //難しいコードの時

//                     if(Data.instance.elicp[j] == tonic[0] || Data.instance.elicp[j] == tonic[1] || Data.instance.elicp[j] == tonic[2]){ //トニックの時
//                         skillcp[i, j] = iniTonicfunc(Data.instance.elicp[j]); //トニックのコードに置き換える

//                         //1曲目のみ実行
//                         if(defineFlag == false){
//                             DefinechordScore(0, j); //スコア保存配列の動的定義
//                         }
//                     }

//                     else if(Data.instance.elicp[j] == subdominant[0] || Data.instance.elicp[j] == subdominant[1]){ //サブドミナントの時
//                         skillcp[i, j] = iniSubdominantfunc(Data.instance.elicp[j]);

//                         if(defineFlag == false){
//                             DefinechordScore(1, j);
//                         }
//                     }

//                     else if(Data.instance.elicp[j] == dominant[0] || Data.instance.elicp[j] == dominant[1]){ //ドミナントの時
//                         skillcp[i, j] = iniDominantfunc(Data.instance.elicp[j]);

//                         if(defineFlag == false){
//                             DefinechordScore(2, j);
//                         }
//                     }
//                 }

//                 else{ //その他のコードはコピー
//                     skillcp[i, j] = Data.instance.elicp[j];
//                 }
//             }

//             //1曲目かどうか
//             if(defineFlag == false){
//                 defineFlag = true;
//             }
//         }
//     }

//     //配列chordScoreの動的定義
//     void DefinechordScore(int groupnum, int j)
//     {
//         //各グループの要素数を保持
//         int[] chordGroup = {tonic.Length, subdominant.Length, dominant.Length};

//         List<int> data = new List<int>();

//         //難しいコードを発見した回数・グループに応じて処理
//         if(defineCount == 0){
//             chordScore1 = new int[chordGroup[groupnum]]; //配列番号ごとのスコアを保存する配列

//             data.Add(j); //難しいコードの配列番号を保存
//             data.Add(groupnum); //難しいコードのグループを保存
//             defineCount++;

//             //chordScore1[難しいコード番目] = 0　(選ばれる確率を0にする)
//         }
//         else if(defineCount == 1){
//             chordScore2 = new int[chordGroup[groupnum]];

//             data.Add(j);
//             data.Add(groupnum);
//             defineCount++;
//         }
//         else if(defineCount == 2){
//             chordScore3 = new int[chordGroup[groupnum]];

//             data.Add(j);
//             data.Add(groupnum);
//             defineCount++;
//         }
//         else if(defineCount == 3){
//             chordScore4 = new int[chordGroup[groupnum]];

//             data.Add(j);
//             data.Add(groupnum);
//             defineCount++;
//         }
//         else if(defineCount == 4){
//             chordScore5 = new int[chordGroup[groupnum]];

//             data.Add(j);
//             data.Add(groupnum);
//             defineCount++;
//         }
//         else if(defineCount == 5){
//             chordScore6 = new int[chordGroup[groupnum]];

//             data.Add(j);
//             data.Add(groupnum);
//             defineCount++;
//         }
//         else if(defineCount == 6){
//             chordScore7 = new int[chordGroup[groupnum]];

//             data.Add(j);
//             data.Add(groupnum);
//             defineCount++;
//         }
//         else if(defineCount == 7){
//             chordScore8 = new int[chordGroup[groupnum]];

//             data.Add(j);
//             data.Add(groupnum);
//             defineCount++;
//         }

//         //難しいコードの配列番号およびグループを保存
//         diffNum.Add(data);
//     }


//     //各グループでの処理
//     int iniTonicfunc(int a) //aは変更対象のコード
//     {
//         int[] removec = new int[tonic.Length - 1]; //このコード群の中から変更
//         int index = 0;

//         for(int i = 0; i < tonic.Length; i++){
//             if(tonic[i] != a){ //変更対象以外のコードを代入
//                 removec[index] = tonic[i];
//                 index++;
//             }
//         }

//         //変更対象を除いたコードグループ
//         int rand = r.Next(0, removec.Length);

//         //変更後のコード群からランダムで選ばれたコードを返す
//         return removec[rand];
//     }

//     int iniSubdominantfunc(int a)
//     {
//         int[] removec = new int[subdominant.Length - 1];
//         int index = 0;

//         for(int i = 0; i < subdominant.Length; i++){
//             if(subdominant[i] != a){
//                 removec[index] = subdominant[i];
//                 index++;
//             }
//         }

//         int rand = r.Next(0, removec.Length);

//         return removec[rand];
//     }

//     int iniDominantfunc(int a)
//     {
//         int[] removec = new int[dominant.Length - 1];
//         int index = 0;

//         for(int i = 0; i < dominant.Length; i++){
//             if(dominant[i] != a){
//                 removec[index] = dominant[i];
//                 index++;
//             }
//         }

//         int rand = r.Next(0, removec.Length);

//         return removec[rand];
//     }
    








//     //2回目以降は評価に基づいて進化
//     // void SkillGen()
//     // {
//     //     //得点を反映
//     //     CalScore();


//     //     for(int i = 0; i < M; i++){ //練習曲数
//     //         for(int j = 0; j < defineCount; j++){ //難しいコードのみ変更
//     //             skillcp[i, diffNum[j, 0]] = replaceChord();
//     //         }

//     //     }

//     //     // for(int i = 0; i < M; i++){ //練習曲数
//     //     //     for(int j = 0; j < N; j++){ //コード数
//     //     //         if(skillcp[i, j] == Data.instance.DiffChord[0] || skillcp[i, j] == Data.instance.DiffChord[1] || skillcp[i, j] == Data.instance.DiffChord[2]){ //難しいコードの時

//     //     //             if(skillcp[i, j] == tonic[0] || skillcp[i, j] == tonic[1] || skillcp[i, j] == tonic[2]){ //トニックの時
//     //     //                 skillcp[i, j] = Tonicfunc(Data.instance.elicp[j]);
//     //     //             }

//     //     //             else if(skillcp[i, j] == subdominant[0] || skillcp[i, j] == subdominant[1]){ //サブドミナントの時
//     //     //                 skillcp[i, j] = Subdominantfunc(Data.instance.elicp[j]);
//     //     //             }

//     //     //             else if(skillcp[i, j] == dominant[0] || skillcp[i, j] == dominant[1]){ //ドミナントの時
//     //     //                 skillcp[i, j] = Dominantfunc(Data.instance.elicp[j]);
//     //     //             }
//     //     //         }

//     //     //         else{ //その他のコードはコピー
//     //     //             skillcp[i, j] = Data.instance.elicp[j];
//     //     //         }
//     //     //     }
//     //     // }
//     // }

//     // void CalScore(){
//     //     //各スコアを取得
//     //     int[] rank = new int[M];
        
//     //     //valueの値は0スタートのため + 1 (1～10)
//     //     rank[0] = dd1.value + 1;
//     //     rank[1] = dd2.value + 1;
//     //     rank[2] = dd3.value + 1;
//     //     rank[3] = dd4.value + 1;
//     //     rank[4] = dd5.value + 1;
//     //     rank[5] = dd6.value + 1;


        
//     // }

//     // void replaceChord()
//     // {
//     //     int[] removec = new int[tonic.Length - 1]; //このコード群の中から変更
//     //     int index = 0;

//     //     for(int i = 0; i < tonic.Length; i++){
//     //         if(tonic[i] != a){ //変更対象以外のコードを代入
//     //             removec[index] = tonic[i];
//     //             index++;
//     //         }
//     //     }

//     //     //変更対象を除いたコードグループ
//     //     int rand = r.Next(0, removec.Length);

//     //     //変更後のコード群からランダムで選ばれたコードを返す
//     //     return removec[rand];
//     // }
// }
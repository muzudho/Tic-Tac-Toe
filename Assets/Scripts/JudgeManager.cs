using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class JudgeManager : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] GameResults gameResult;

    /// <summary>
    /// 対局結果（読取専用）
    /// </summary>
    public GameResults GameResult => gameResult;

    static readonly int[,] winPatterns = new int[,]
    {
        // ***
        // ...
        // ...
        { 0, 1, 2},
        // ...
        // ***
        // ...
        { 3, 4, 5},
        // ...
        // ...
        // ***
        { 6, 7, 8},
        // *..
        // *..
        // *..
        { 0, 3, 6},
        // .*.
        // .*.
        // .*.
        { 1, 4, 7},
        // ..*
        // ..*
        // ..*
        { 2, 5, 8},
        // *..
        // .*.
        // ..*
        { 0, 4, 8},
        // ..*
        // .*.
        // *..
        { 2, 4, 6},
    };

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    /// <summary>
    /// 勝ち判定
    /// 
    /// - 負けは判定しません
    /// - 結果は GameResult プロパティに入れます
    /// </summary>
    /// <param name="piece"></param>
    /// <returns>判定が変わったか？</returns>
    public bool SetupJudge(Pieces piece)
    {
        var pos = gameManager.Position;

        // 勝ちパターンにマッチするか判定
        for (int num = 0; num < winPatterns.GetLength(0); num++)
        {
            if (pos.GetPiece(winPatterns[num, 0]) == piece &&
                pos.GetPiece(winPatterns[num, 1]) == piece &&
                pos.GetPiece(winPatterns[num, 2]) == piece)
            {
                // ３つ並んだ
                var old = gameResult;
                gameResult = GameResults.Win;
                return gameResult != old;
            }
        }

        if (pos.MovesCount == pos.GetBoardLength() - 1) // インクリメントする前に判定するから -1 する
        {
            //マスを埋め尽くしたなら満局（引き分け）
            var old = gameResult;
            gameResult = GameResults.Draw;
            return gameResult != old;
        }

        var old1 = gameResult;
        gameResult = GameResults.None;
        return gameResult != old1;
    }

    /// <summary>
    /// ゲームの初期化
    /// </summary>
    public void Clear()
    {
        gameResult = GameResults.None;
    }
}

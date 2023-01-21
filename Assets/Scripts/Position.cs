using Assets.Scripts;
using UnityEngine;

/// <summary>
/// 局面
/// </summary>
class Position : MonoBehaviour
{
    /// <summary>
    /// 盤
    /// </summary>
    [SerializeField] Pieces[] board;

    /// <summary>
    /// 何手目か
    /// </summary>
    [SerializeField] int movesCount;

    /// <summary>
    /// 何手目か（読取専用）
    /// </summary>
    public int MovesCount => movesCount;

    [SerializeField] Pieces turn;

    /// <summary>
    /// 手番
    /// </summary>
    public Pieces Turn
    {
        get
        {
            return turn;
        }

        set
        {
            turn = value;
        }
    }


    /// <summary>
    /// 初期化します
    /// </summary>
    public void Clear()
    {
        // マスを全部空欄にする
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = Pieces.None;
        }

        movesCount = 0;
        Turn = Pieces.Nought;
    }

    public Pieces GetPiece(int square)
    {
        return board[square];
    }

    /// <summary>
    /// 駒を置く
    /// </summary>
    /// <param name="square">マス番号</param>
    /// <param name="piece">駒</param>
    /// <returns>変更があったか？</returns>
    public bool SetPiece(int square, Pieces piece)
    {
        if (board[square] != piece)
        {
            board[square] = piece;
            return true;
        }

        return false;
    }

    public int GetBoardLength()
    {
        return board.Length;
    }

    /// <summary>
    /// 手番を進める
    /// </summary>
    public void NextTurn()
    {
        switch (turn)
        {
            case Pieces.Nought:
                turn = Pieces.Cross;
                break;

            case Pieces.Cross:
                turn = Pieces.Nought;
                break;
        }

        // インクリメント
        movesCount++;
    }
}

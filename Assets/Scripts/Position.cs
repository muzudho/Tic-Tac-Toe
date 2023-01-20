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
    /// 何手目か
    /// </summary>
    public int MovesCount
    {
        get
        {
            return movesCount;
        }

        set
        {
            movesCount = value;
        }
    }

    /// <summary>
    /// マスを全部空欄にする
    /// </summary>
    public void Clear()
    {
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = Pieces.None;
        }
    }

    public Pieces GetPiece(int square)
    {
        return board[square];
    }

    public void SetPiece(int square, Pieces piece)
    {
        board[square] = piece;
    }

    public int GetBoardLength()
    {
        return board.Length;
    }
}

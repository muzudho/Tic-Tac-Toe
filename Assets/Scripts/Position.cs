using Assets.Scripts;
using UnityEngine;

/// <summary>
/// ‹Ç–Ê
/// </summary>
class Position : MonoBehaviour
{
    /// <summary>
    /// ”Õ
    /// </summary>
    [SerializeField] Pieces[] board;

    /// <summary>
    /// ‰½Žè–Ú‚©
    /// </summary>
    [SerializeField] int movesCount;

    /// <summary>
    /// ‰½Žè–Ú‚©
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
    /// ƒ}ƒX‚ð‘S•”‹ó—“‚É‚·‚é
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

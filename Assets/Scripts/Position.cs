using Assets.Scripts;
using UnityEngine;

/// <summary>
/// �ǖ�
/// </summary>
class Position : MonoBehaviour
{
    /// <summary>
    /// ��
    /// </summary>
    [SerializeField] Pieces[] board;

    /// <summary>
    /// ����ڂ�
    /// </summary>
    [SerializeField] int movesCount;

    /// <summary>
    /// ����ڂ�
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
    /// �}�X��S���󗓂ɂ���
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

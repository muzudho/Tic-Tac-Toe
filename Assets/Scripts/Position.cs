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
    /// ����ڂ��i�ǎ��p�j
    /// </summary>
    public int MovesCount => movesCount;

    [SerializeField] Pieces turn;

    /// <summary>
    /// ���
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
    /// ���������܂�
    /// </summary>
    public void Clear()
    {
        // �}�X��S���󗓂ɂ���
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
    /// ���u��
    /// </summary>
    /// <param name="square">�}�X�ԍ�</param>
    /// <param name="piece">��</param>
    /// <returns>�ύX�����������H</returns>
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
    /// ��Ԃ�i�߂�
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

        // �C���N�������g
        movesCount++;
    }
}

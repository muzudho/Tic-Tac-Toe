using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class JudgeManager : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] GameResults gameResult;

    /// <summary>
    /// �΋ǌ��ʁi�ǎ��p�j
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
    /// ��������
    /// 
    /// - �����͔��肵�܂���
    /// - ���ʂ� GameResult �v���p�e�B�ɓ���܂�
    /// </summary>
    /// <param name="piece"></param>
    /// <returns>���肪�ς�������H</returns>
    public bool SetupJudge(Pieces piece)
    {
        var pos = gameManager.Position;

        // �����p�^�[���Ƀ}�b�`���邩����
        for (int num = 0; num < winPatterns.GetLength(0); num++)
        {
            if (pos.GetPiece(winPatterns[num, 0]) == piece &&
                pos.GetPiece(winPatterns[num, 1]) == piece &&
                pos.GetPiece(winPatterns[num, 2]) == piece)
            {
                // �R����
                var old = gameResult;
                gameResult = GameResults.Win;
                return gameResult != old;
            }
        }

        if (pos.MovesCount == pos.GetBoardLength() - 1) // �C���N�������g����O�ɔ��肷�邩�� -1 ����
        {
            //�}�X�𖄂ߐs�������Ȃ疞�ǁi���������j
            var old = gameResult;
            gameResult = GameResults.Draw;
            return gameResult != old;
        }

        var old1 = gameResult;
        gameResult = GameResults.None;
        return gameResult != old1;
    }

    /// <summary>
    /// �Q�[���̏�����
    /// </summary>
    public void Clear()
    {
        gameResult = GameResults.None;
    }
}

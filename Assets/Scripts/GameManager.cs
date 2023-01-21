using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 空きマス
    /// </summary>
    [SerializeField] Material square;

    /// <summary>
    /// ○印
    /// </summary>
    [SerializeField] Material nought;

    /// <summary>
    /// ×印
    /// </summary>
    [SerializeField] Material cross;

    /// <summary>
    /// 局面
    /// </summary>
    internal Position Position { get; private set; }
    JudgeManager judgeManager;
    [SerializeField] GameObject goNoughtWin;
    [SerializeField] GameObject goCrossWin;
    [SerializeField] GameObject goDraw;
    [SerializeField] GameObject goFrontCover;
    [SerializeField] GameObject goRestartButton;
    List<GameObject> goSquares = new();

    bool dirtyJudgement;
    HashSet<int> dirtySquares = new();

    // Start is called before the first frame update
    void Start()
    {
        Position = GameObject.Find("Position Manager").GetComponent<Position>();
        judgeManager = GameObject.Find("Judge Manager").GetComponent<JudgeManager>();

        // 全部のマス
        for (int i = 0; i < Position.GetBoardLength(); i++)
        {
            goSquares.Add(GameObject.Find($"Square {i}"));
        }

        // ゲームを初期化
        Clear();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSquareView();
        UpdateGameResultView();
    }

    /// <summary>
    /// 駒を置く
    /// </summary>
    /// <param name="squareName"></param>
    public void DoMove(string squareName)
    {
        // "Square 1" の 1 の部分を取る。必ず成功するものとして、チェックを省きます
        var square = StaticHelper.GetSquareByName(squareName);
        if (Position.SetPiece(square, Position.Turn))
        {
            dirtySquares.Add(square);
        }

        if (judgeManager.SetupJudge(Position.Turn))
        {
            dirtyJudgement = true;
        }

        if (judgeManager.GameResult == GameResults.None)
        {
            // インクリメント
            Position.NextTurn();
        }
    }

    /// <summary>
    /// マス表示更新
    /// </summary>
    public void UpdateSquareView()
    {
        foreach (var sq in dirtySquares)
        {
            Material material;
            var piece = Position.GetPiece(sq);

            switch (piece)
            {
                case Pieces.Nought:
                    material = nought;
                    break;

                case Pieces.Cross:
                    material = cross;
                    break;

                case Pieces.None:
                    material = square;
                    break;

                default:
                    throw new System.Exception("unexpected piece:{piece}");
            }

            goSquares[sq].GetComponent<MeshRenderer>().material = material;
        }

        dirtySquares.Clear();
    }

    /// <summary>
    /// 対局結果表示更新
    /// </summary>
    public void UpdateGameResultView()
    {
        if (dirtyJudgement)
        {
            dirtyJudgement = false;

            switch (judgeManager.GameResult)
            {
                case GameResults.Win:
                    // `Nought win` または `Cross win` 表示
                    if (Position.Turn == Pieces.Nought)
                    {
                        goNoughtWin.SetActive(true);
                        goFrontCover.SetActive(true);
                        goRestartButton.SetActive(true);
                    }
                    else
                    {
                        goCrossWin.SetActive(true);
                        goFrontCover.SetActive(true);
                        goRestartButton.SetActive(true);
                    }
                    break;

                case GameResults.Draw:
                    // `Draw` 表示
                    goDraw.SetActive(true);
                    goFrontCover.SetActive(true);
                    goRestartButton.SetActive(true);
                    break;
            }
        }
    }

    /// <summary>
    /// ゲームを初期化
    /// </summary>
    public void Clear()
    {
        Position.Clear();
        judgeManager.Clear();

        goNoughtWin.SetActive(false);
        goCrossWin.SetActive(false);
        goDraw.SetActive(false);
        goFrontCover.SetActive(false);
        goRestartButton.SetActive(false);

        // マスを全部、再描画させる
        for (int i = 0; i < Position.GetBoardLength(); i++)
        {
            dirtySquares.Add(i);
        }
    }
}

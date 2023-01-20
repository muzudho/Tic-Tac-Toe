using Assets.Scripts;
using System.Text.RegularExpressions;
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

    Regex regexSquareN = new Regex(@"^Square (\d+)", RegexOptions.Compiled);

    // Start is called before the first frame update
    void Start()
    {
        Position = GameObject.Find("Position Manager").GetComponent<Position>();
        judgeManager = GameObject.Find("Judge Manager").GetComponent<JudgeManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoMove(string squareName)
    {
        var material = (Position.MovesCount % 2 == 0) ? nought : cross;
        GameObject.Find(squareName).GetComponent<MeshRenderer>().material = material;

        // "Square 1" の 1 の部分を取る。必ず成功するものとして、チェックを省きます
        var square = int.Parse(regexSquareN.Match(squareName).Groups[1].Value);
        var piece = (Position.MovesCount % 2 == 0) ? Pieces.Nought : Pieces.Cross;
        Position.SetPiece(square, piece);

        judgeManager.SetupJudge(piece);
        switch (judgeManager.GameResult)
        {
            case GameResults.Win:
                // `Nought win` または `Cross win` 表示
                if (piece == Pieces.Nought)
                {
                    goNoughtWin.SetActive(true);
                    goFrontCover.SetActive(true);
                }
                else
                {
                    goCrossWin.SetActive(true);
                    goFrontCover.SetActive(true);
                }
                break;

            case GameResults.Draw:
                // `Draw` 表示
                goDraw.SetActive(true);
                goFrontCover.SetActive(true);
                break;
        }

        // インクリメント
        Position.MovesCount++;
    }
}

using System.Collections;
using System.Collections.Generic;
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
    /// 何手目か
    /// </summary>
    int movesCount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoMove(string squareName)
    {
        var material = (movesCount % 2 == 0) ? nought : cross;
        GameObject.Find(squareName).GetComponent<MeshRenderer>().material = material;
        movesCount++;
    }
}

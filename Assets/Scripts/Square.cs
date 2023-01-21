using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        var squareNum = StaticHelper.GetSquareByName(transform.name);

        Debug.Log($"{squareNum} 番マスでマウスボタンを押しました");

        if (StaticValidator.ValidateMove(gameManager.Position, squareNum))
        {
            gameManager.DoMove(transform.name);
        }
    }
}

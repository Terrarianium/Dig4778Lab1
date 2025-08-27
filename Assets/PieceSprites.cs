using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChessPiecesEnum
{
    Bishop,
    King,
    Queen,
    Pawn,
    Rook,
    Knight
}

public class PieceSprites : MonoBehaviour
{
    [HideInInspector]
    public Sprite king, queen, bishop, pawn, knight, rook;
    public ChessPiecesEnum piece;
    SpriteRenderer sprite;

    private void OnDrawGizmos()
    {
        if (sprite == null)
        {
            sprite = gameObject.AddComponent<SpriteRenderer>();
        }
        sprite = gameObject.GetComponent<SpriteRenderer>();   
        switch (piece)
        {
            case ChessPiecesEnum.Bishop:
                sprite.sprite = bishop;
                break;
            case ChessPiecesEnum.Queen: 
                sprite.sprite = queen;
                break;
            case ChessPiecesEnum.King:
                sprite.sprite = king;
                break;
            case ChessPiecesEnum.Pawn:
                sprite.sprite = pawn;
                break;
            case ChessPiecesEnum.Rook:
                sprite.sprite = rook;
                break;
            case ChessPiecesEnum.Knight:
                sprite.sprite = knight;
                break;
        }
    }
}

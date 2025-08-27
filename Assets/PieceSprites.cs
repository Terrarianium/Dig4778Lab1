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
    
    private Sprite king, queen, bishop, pawn, knight, rook;
    public ChessPiecesEnum piece;
    SpriteRenderer sprite;

    [ColorUsage(true, true)]
    public Color spriteColor;

    private void OnDrawGizmos()
    {
        if (gameObject.GetComponent<SpriteRenderer>() == null)
        {
            gameObject.AddComponent<SpriteRenderer>();
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
                KingMoves();
                break;
            case ChessPiecesEnum.Pawn:
                sprite.sprite = pawn;
                PawnMoves();
                break;
            case ChessPiecesEnum.Rook:
                sprite.sprite = rook;
                break;
            case ChessPiecesEnum.Knight:
                sprite.sprite = knight;
                KnightMoves();
                break;
        }
        UpdateSpriteColor();
    }

    void UpdateSpriteColor()
    {
        sprite.color = spriteColor;
    }

    private void PawnMoves()
    {
        // Regular movement and also initial movement where it is possible to move 2 spaces forward
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(this.transform.position.x - 0.15f, this.transform.position.y, this.transform.position.z), new Vector3(this.transform.position.x - 0.15f, this.transform.position.y + 1, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x - 0.15f, this.transform.position.y + 1, this.transform.position.z), 0.15f);
        Gizmos.DrawLine(new Vector3(this.transform.position.x + 0.15f, this.transform.position.y, this.transform.position.z), new Vector3(this.transform.position.x + 0.15f, this.transform.position.y + 2, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x + 0.15f, this.transform.position.y + 2, this.transform.position.z), 0.15f);

        // Pawn can take diagonally
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x + 1, this.transform.position.y + 1, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x + 1, this.transform.position.y + 1, this.transform.position.z), 0.15f);
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x - 1, this.transform.position.y + 1, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x - 1, this.transform.position.y + 1, this.transform.position.z), 0.15f);
    }

    private void KnightMoves()
    {
        Gizmos.color = Color.green;
        // Up
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z));
        Gizmos.DrawLine(new Vector3(this.transform.position.x - 1, this.transform.position.y + 2, this.transform.position.z), new Vector3(this.transform.position.x + 1, this.transform.position.y + 2, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x - 1, this.transform.position.y + 2, this.transform.position.z), 0.15f);
        Gizmos.DrawSphere(new Vector3(this.transform.position.x + 1, this.transform.position.y + 2, this.transform.position.z), 0.15f);

        // Right
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x + 2, this.transform.position.y, this.transform.position.z));
        Gizmos.DrawLine(new Vector3(this.transform.position.x + 2, this.transform.position.y + 1, this.transform.position.z), new Vector3(this.transform.position.x + 2, this.transform.position.y - 1, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x + 2, this.transform.position.y + 1, this.transform.position.z), 0.15f);
        Gizmos.DrawSphere(new Vector3(this.transform.position.x + 2, this.transform.position.y - 1, this.transform.position.z), 0.15f);

        // Left
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x - 2, this.transform.position.y, this.transform.position.z));
        Gizmos.DrawLine(new Vector3(this.transform.position.x - 2, this.transform.position.y + 1, this.transform.position.z), new Vector3(this.transform.position.x - 2, this.transform.position.y - 1, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x - 2, this.transform.position.y + 1, this.transform.position.z), 0.15f);
        Gizmos.DrawSphere(new Vector3(this.transform.position.x - 2, this.transform.position.y - 1, this.transform.position.z), 0.15f);

        // Down
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y - 2, this.transform.position.z));
        Gizmos.DrawLine(new Vector3(this.transform.position.x - 1, this.transform.position.y - 2, this.transform.position.z), new Vector3(this.transform.position.x + 1, this.transform.position.y - 2, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x - 1, this.transform.position.y - 2, this.transform.position.z), 0.15f);
        Gizmos.DrawSphere(new Vector3(this.transform.position.x + 1, this.transform.position.y - 2, this.transform.position.z), 0.15f);
    }

    private void KingMoves()
    {
        Gizmos.color = Color.green;

        // Up
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), 0.15f);

        // Down
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.z), 0.15f);

        // Right
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z), 0.15f);

        // Left
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z), 0.15f);

        // Up Right
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x + 1, this.transform.position.y + 1, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x + 1, this.transform.position.y + 1, this.transform.position.z), 0.15f);

        // Up Left
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x - 1, this.transform.position.y + 1, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x - 1, this.transform.position.y + 1, this.transform.position.z), 0.15f);

        // Down Right
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x + 1, this.transform.position.y - 1, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x + 1, this.transform.position.y - 1, this.transform.position.z), 0.15f);

        // Down Left
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x - 1, this.transform.position.y - 1, this.transform.position.z));
        Gizmos.DrawSphere(new Vector3(this.transform.position.x - 1, this.transform.position.y - 1, this.transform.position.z), 0.15f);
    }
}

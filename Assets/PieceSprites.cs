using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

[ExecuteInEditMode]
public class PieceSprites : MonoBehaviour
{
    
    private Sprite[] sprites = new Sprite[6];

    public ChessPiecesEnum piece;
    SpriteRenderer sprite;

    [ColorUsage(true, true)]
    public Color spriteColor;

    private void Update()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprites[0] = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/BishopSprite.png");
        sprites[1] = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/QueenSprite.png");
        sprites[2] = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/KingSprite.png");
        sprites[3] = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/PawnSprite.png");
        sprites[4] = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/RookSprite.png");
        sprites[5] = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/KnightSprite.png");
    }

    void OnDrawGizmosSelected()
    {   
        switch (piece)
        {
            case ChessPiecesEnum.Bishop:
                sprite.sprite = sprites[0];
                BishopMoves();
                break;
            case ChessPiecesEnum.Queen: 
                sprite.sprite = sprites[1];
                RookMoves();
                BishopMoves();
                break;
            case ChessPiecesEnum.King:
                sprite.sprite = sprites[2];
                KingMoves();
                break;
            case ChessPiecesEnum.Pawn:
                sprite.sprite = sprites[3];
                PawnMoves();
                break;
            case ChessPiecesEnum.Rook:
                sprite.sprite = sprites[4];
                RookMoves();
                break;
            case ChessPiecesEnum.Knight:
                sprite.sprite = sprites[5];
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

    private void RookMoves()
    {
        Gizmos.color = Color.green;

        // Up
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, 7, 0));

        // Down
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -7, 0));

        // Left
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-7, 0, 0));

        // Right
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(7, 0, 0));
    }

    private void BishopMoves()
    {
        Gizmos.color = Color.green;

        // Up Left
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-7, 7, 0));

        // Up Right
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(7, 7, 0));

        // Down Left
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-7, -7, 0));

        // Down Right
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(7, -7, 0));
    }
}

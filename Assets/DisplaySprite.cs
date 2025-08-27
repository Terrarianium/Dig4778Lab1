using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DisplaySprite : MonoBehaviour
{
    // Variables
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private ChessPieces pieceType;
    [SerializeField]
    [ColorUsage(true, true)]
    private Color spriteColor;
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        pieceType = ChessPieces.Pawn;
        spriteColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum ChessPieces
{
    King,
    Queen,
    Bishop,
    Knight,
    Rook,
    Pawn
}

[CustomEditor(typeof(DisplaySprite))]
public class DisplaySpriteEditor : Editor
{
    [ColorUsage(true, true)]
    public Color colorUsage;
    void OnEnable()
    {
        
    }
}

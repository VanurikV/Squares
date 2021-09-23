using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public Sprite[] Sprites;
    private SpriteRenderer sr;

    private Color FinishColor;

    private void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    public Color GetColor()
    {
        return FinishColor;
    }

    
    public void Init(string type)
    {
        Color col = Color.Blue;

        switch (type[1])
        {
            case 'R':
                col = Color.Red;
                break;
            case 'G':
                col = Color.Green;
                break;
            case 'B':
                col = Color.Blue;
                break;
            case 'P':
                col = Color.Purple;
                break;
        }

        FinishColor = col;
        sr.sprite = Sprites[(int)col - 1];

    }

}

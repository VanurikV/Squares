using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace squares
{
    public class SquareScript : MonoBehaviour
    {

        public Color SquareColor;
        public Direction SquareDirection;

        public GameObject Arrow;
        public Sprite[] SquareSprites;


        private SpriteRenderer sr;
        private void Awake()
        {
            sr = gameObject.GetComponentInChildren<SpriteRenderer>();
        }


        public void SetDirection(Direction dir)
        {
            SquareDirection = dir;
            Arrow.transform.rotation=new Quaternion(0,0,0,0);
            Arrow.transform.Rotate(0, 0, 90 * ((int)dir - 1));
        }

        public void Init(string s_type)
        {
            switch (s_type[0])
            {
                case 'R':
                    SquareColor = Color.Red;
                    break;
                case 'B':
                    SquareColor = Color.Blue;
                    break;
                case 'G':
                    SquareColor = Color.Green;
                    break;
                case 'P':
                    SquareColor = Color.Purple;
                    break;
            }

            sr.sprite = SquareSprites[(int)SquareColor - 1];

            switch (s_type[1])
            {
                case 'U':
                    SquareDirection = Direction.Up;
                    break;
                case 'D':
                    SquareDirection = Direction.Down;
                    break;
                case 'L':
                    SquareDirection = Direction.Left;
                    break;
                case 'R':
                    SquareDirection = Direction.Right;
                    break;
            }

            SetDirection(SquareDirection);
        }

        public void Init(Color col, Direction dir)
        {
            SquareColor = col;
            sr.sprite = SquareSprites[(int)SquareColor - 1];

            SetDirection(dir);
        }





    }
}

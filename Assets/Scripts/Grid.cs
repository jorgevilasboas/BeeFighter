using UnityEngine;
using System.Collections;
using System;

public class Grid : MonoBehaviour
{
    

    public Transform hexPrefab;

   
    public int gridWidth = 11;
    public int gridHeight = 11;

    float hexWidth = 1.082f;
    float hexHeight = 1.24f;
    public float gap = 0.0f;

    public Sprite home;

    public Sprite collected;

    ArrayList coletados;
    ArrayList casa;

    Vector3 startPos;

    Cell[,] malha;
    System.Collections.Generic.Dictionary<GameObject, Vector2> map;

    void Start()
    {
        malha = new Cell[gridHeight,gridWidth];
        map = new System.Collections.Generic.Dictionary<GameObject, Vector2>();
        coletados = new ArrayList();
        casa = new ArrayList();
        AddGap();
        CalcStartPos();
        CreateGrid();
    }

    void AddGap()
    {
        hexWidth += hexWidth * gap;
        hexHeight += hexHeight * gap;

        
    }

    void CalcStartPos()
    {
        float offset = 0;
        if (gridHeight / 2 % 2 != 0)
            offset = hexWidth / 2;

        float x = -hexWidth * (gridWidth / 2) - offset;
        float y = hexHeight * 0.75f * (gridHeight / 2);

        startPos = new Vector3(x, y, 0);
    }

    Vector3 CalcWorldPos(Vector2 gridPos)
    {
        float offset = 0;
        if (gridPos.y % 2 != 0)
            offset = hexWidth / 2;

        float x = startPos.x + gridPos.x * hexWidth + offset;
        float y = startPos.y - gridPos.y * hexHeight * 0.75f;

        return new Vector3(x, y, 0);
    }

    public void trataColisao(GameObject hex)
    {
        SpriteRenderer sr = hex.GetComponent<SpriteRenderer>();
        sr.sprite = collected;
        if ((!coletados.Contains(hex))&&(!casa.Contains(hex)))
            coletados.Add(hex);
        else if (casa.Contains(hex)&&coletados.Count>0 )
        {
            fazcasa();
        }
        Debug.Log(hex.name);
    }

    private void fazcasa()
    {
        
    }

    void CreateGrid()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                Transform hex = Instantiate(hexPrefab) as Transform;
                Vector2 gridPos = new Vector2(x, y);
                hex.position = CalcWorldPos(gridPos);
                hex.parent = this.transform;
                hex.name = "Hexagon" + x + "|" + y;

                //Fora do original:
                GameObject hexgameob = hex.gameObject;
                malha[x,y] = new Cell(x,y,hexgameob);
                map.Add(hexgameob,new Vector2(x,y));
                if (x==5 && y == 5){
                       SpriteRenderer sr = hexgameob.GetComponent<SpriteRenderer>();
                    sr.sprite = home;
                }
            }
        }
    }

    public class Cell
    {
        GameObject hex;

        int x;
        int y;

        public Cell(int x, int y, GameObject hex)
        {
            this.X = x;
            this.Y = y;
        }

        public GameObject Hex
        {
            get
            {
                return hex;
            }

            set
            {
                hex = value;
            }
        }

        int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
    }
}





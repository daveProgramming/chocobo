using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SetupGameBoard : MonoBehaviour {

    public GameObject Reference_Sprite;
    public Vector3 Step_Size_Vector;
    public Vector3 Board_Bottom_Left;
    public Vector3 Board_Top_Left;
    public float Board_Width;
    public float Board_Height;
    public float Grid_Width;
    public float Grid_Height;
    public float Square_Length;

    public List<Vector3> Game_Grid = new List<Vector3>();

    void Awake()
    {
        Step_Size_Vector = new Vector3(Reference_Sprite.GetComponent<SpriteRenderer>().bounds.size.x, Reference_Sprite.GetComponent<SpriteRenderer>().bounds.size.x);
        Board_Bottom_Left = Vector3.zero - Camera.main.ScreenToWorldPoint(Camera.main.pixelRect.size) / 2;

        Square_Length = Reference_Sprite.GetComponent<SpriteRenderer>().sprite.bounds.size.x * Reference_Sprite.GetComponent<Transform>().localScale.x * .4f;     

        foreach (Transform Tile in GetComponentsInChildren<Transform>())
        {
            Game_Grid.Add((Tile.position));
        }
        //Game_Grid.Sort((a, b) => a.y.CompareTo(b.y));
    }
}

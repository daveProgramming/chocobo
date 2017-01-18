using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityScript : MonoBehaviour {

    public float Step_Size;
    public List<Vector3> City_Nodes;
    public Rect Zone;
    public List<GameObject> Surrounding_Tiles;
    

    void Awake()
    {
        Step_Size = GameObject.Find("Land_Tiles").GetComponent<SetupGameBoard>().Step_Size_Vector.x;

        GetComponent<GameTile>().DetermineActiveNodes();

        City_Nodes = GetComponent<GameTile>().Active_Nodes;

        Zone = new Rect(GetComponent<Transform>().position, new Vector2(1.25f, 1.25f));
        Zone.center = GetComponent<Transform>().position;
    }
}

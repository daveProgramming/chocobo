using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameTile : MonoBehaviour {

    public SetupGameBoard Game_Board;

    public Vector3 Top_Node;
    public Vector3 Bottom_Node;
    public Vector3 Right_Node;
    public Vector3 Left_Node;

    public List<Vector3> Nodes;

    public List<Vector3> Active_Nodes;

    void Awake()
    {
        Game_Board = GameObject.Find("Land_Tiles").GetComponent<SetupGameBoard>();
    }

    void Start()
    {
        DetermineActiveNodes();
    }

    void Update()
    {
        Top_Node = this.gameObject.transform.position + new Vector3(0.0f, .3125f, 0.0f);
        Bottom_Node = this.gameObject.transform.position - new Vector3(0.0f, .3125f, 0.0f);
        Right_Node = this.gameObject.transform.position + new Vector3(.3125f, 0.0f, 0.0f);
        Left_Node = this.gameObject.transform.position - new Vector3(.3125f, 0.0f, 0.0f);    
    }

    public void DetermineActiveNodes()
    {
        Top_Node = this.gameObject.transform.position + new Vector3(0.0f, .3125f, 0.0f);
        Bottom_Node = this.gameObject.transform.position - new Vector3(0.0f, .3125f, 0.0f);
        Right_Node = this.gameObject.transform.position + new Vector3(.3125f, 0.0f, 0.0f);
        Left_Node = this.gameObject.transform.position - new Vector3(.3125f, 0.0f, 0.0f);

        Nodes.Clear();

        Nodes.Add(Top_Node);
        Nodes.Add(Bottom_Node);
        Nodes.Add(Right_Node);
        Nodes.Add(Left_Node);

        Active_Nodes.Clear();

        switch(GetComponent<SpriteRenderer>().sprite.name)
        {
            case "Road_OneWay_Vertical_1":
                Active_Nodes.Add(Top_Node);
                Active_Nodes.Add(Bottom_Node);
                break;
            case "Road_OneWay_Horizontal_1":
                Active_Nodes.Add(Left_Node);
                Active_Nodes.Add(Right_Node);
                break;
            case "Road_TwoWay_UpLeft_1":
                Active_Nodes.Add(Bottom_Node);
                Active_Nodes.Add(Left_Node);
                break;
            case "Road_TwoWay_UpRight_1":
                Active_Nodes.Add(Bottom_Node);
                Active_Nodes.Add(Right_Node);
                break;
            case "Road_TwoWay_DownLeft_1":
                Active_Nodes.Add(Top_Node);
                Active_Nodes.Add(Left_Node);
                break;
            case "Road_TwoWay_DownRight_1":
                Active_Nodes.Add(Top_Node);
                Active_Nodes.Add(Right_Node);
                break;
            case "Road_ThreeWay_UpLeftRight_1":
                Active_Nodes.Add(Bottom_Node);
                Active_Nodes.Add(Right_Node);
                Active_Nodes.Add(Left_Node);
                break;
            case "Road_ThreeWay_DownLeftRight_1":
                Active_Nodes.Add(Top_Node);
                Active_Nodes.Add(Right_Node);
                Active_Nodes.Add(Left_Node);
                break;
            case "Road_ThreeWay_UpDownLeft_1":
                Active_Nodes.Add(Top_Node);
                Active_Nodes.Add(Bottom_Node);
                Active_Nodes.Add(Left_Node);
                break;
            case "Road_ThreeWay_UpDownRight_1":
                Active_Nodes.Add(Top_Node);
                Active_Nodes.Add(Bottom_Node);
                Active_Nodes.Add(Right_Node);
                break;
            case "Road_FourWay_3":
                Active_Nodes.Add(Top_Node);
                Active_Nodes.Add(Bottom_Node);
                Active_Nodes.Add(Right_Node);
                Active_Nodes.Add(Left_Node);
                break;
            default:
                Active_Nodes.Add(Top_Node);
                Active_Nodes.Add(Bottom_Node);
                Active_Nodes.Add(Right_Node);
                Active_Nodes.Add(Left_Node);
                break;
        }
    }
}
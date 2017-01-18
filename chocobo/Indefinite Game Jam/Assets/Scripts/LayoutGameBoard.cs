using UnityEngine;
using System.Collections;

public class LayoutGameBoard : MonoBehaviour {

    public SetupGameBoard Game_Board;
    public Vector3 Start_Position;
    public Vector3 End_Position;

    public GameObject Start_Object;
    public GameObject End_Object;
    public GameObject Blocked_Object;

    void Awake()
    {
        Game_Board = GetComponent<SetupGameBoard>();

        Start_Object = Resources.Load<GameObject>("Game Objects/Start");
        End_Object = Resources.Load<GameObject>("Game Objects/End");
        Blocked_Object = Resources.Load<GameObject>("Game Objects/Blocked");
    }

    void Start()
    {
        Start_Position = Game_Board.Game_Grid[Random.Range(0,10)];
        End_Position = Game_Board.Game_Grid[Game_Board.Game_Grid.Count - Random.Range(1,10)];
        Start_Object = Instantiate(Start_Object, Start_Position, Quaternion.identity) as GameObject;
        End_Object = Instantiate(End_Object, End_Position, Quaternion.identity) as GameObject;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaceSquare : MonoBehaviour {

    public enum RoadType { Land, Water}
    public RoadType currentRoadType;
    public int LandRoadBuildCost;
    public int WaterRoadBuildCost;

    PlayerResourceManager playerResourceManager;

    InputHandler ih;
    SetupGameBoard Water_Board;
    SetupGameBoard Land_Board;
    SetupGameBoard Game_Board;

    public int current_sprite_index;

    public GameObject Reference_Tile;

    public GameObject Selected_Piece;
    public Vector3 target_position;
    public float snap_distance;
    public float test_distance;
    public int Grid_Snap_Location;
    public bool position_is_snapped;
    GameObject Tile;
    public List<GameObject> Placed_Tiles;
    public List<Vector3> Placed_Road_Positions;
    private List<GameObject> Tiles_To_Place;
    bool Tile_Added;

    GameObject Land;
    
    public List<Sprite> Sprite_List = new List<Sprite>();
    public Sprite Road_OneWay_A, Road_OneWay_B;
    public Sprite Road_TwoWay_A, Road_TwoWay_B, Road_TwoWay_C, Road_TwoWay_D;
    public Sprite Road_ThreeWay_A, Road_ThreeWay_B, Road_ThreeWay_C, Road_ThreeWay_D;
    public Sprite Road_FourWay_A;

    public Color Road_Color;
    public Color WaterRoad_Color;
    public List<Color>Color_List;

    public List<CityScript> Cities;

    void Awake()
    {
        currentRoadType = RoadType.Land;
        Road_Color = new Color(.2f, 0, 0, 1);
        WaterRoad_Color = new Color(1, 0, 0, 1);
        Color_List.Add(Road_Color);
        Color_List.Add(WaterRoad_Color);

        playerResourceManager = GetComponent<PlayerResourceManager>();
        ih = FindObjectOfType<InputHandler>();
        Land = GameObject.Find("Land_Tiles");
        Land_Board = Land.GetComponent<SetupGameBoard>();

        Water_Board = GameObject.Find("Water_Tiles").GetComponent<SetupGameBoard>();
        Game_Board = Land_Board;

        Sprite_List.Add(Road_OneWay_A);
        Sprite_List.Add(Road_OneWay_B);
        Sprite_List.Add(Road_TwoWay_A);
        Sprite_List.Add(Road_TwoWay_B);
        Sprite_List.Add(Road_TwoWay_C);
        Sprite_List.Add(Road_TwoWay_D);
        Sprite_List.Add(Road_ThreeWay_A);
        Sprite_List.Add(Road_ThreeWay_B);
        Sprite_List.Add(Road_ThreeWay_C);
        Sprite_List.Add(Road_ThreeWay_D);
        Sprite_List.Add(Road_FourWay_A);

        Reference_Tile = Resources.Load<GameObject>("Road_Land");       

        Placed_Tiles = new List<GameObject>();
        Tiles_To_Place = new List<GameObject>();

        Placed_Tiles.Add(GameObject.Find("City A"));

        foreach(CityScript obj in GameObject.Find("Cities").GetComponentsInChildren<CityScript>())
        {
            Cities.Add(obj);
        }
    }


    void Update()
    {
        if(Selected_Piece && Input.GetKeyDown(KeyCode.C))
        {
            if(Selected_Piece.GetComponent<SpriteRenderer>().color == Color_List[0])
            {
                Game_Board = Water_Board;
                currentRoadType = RoadType.Water;
                Selected_Piece.GetComponent<SpriteRenderer>().color = Color_List[1];
            }
            else
            {
                Game_Board = Land_Board;
                currentRoadType = RoadType.Land;
                Selected_Piece.GetComponent<SpriteRenderer>().color = Color_List[0];
            }

            Debug.Log(Selected_Piece.GetComponent<SpriteRenderer>().color);
        }

        snap_distance = Game_Board.Square_Length * 2;

        target_position = Camera.main.ScreenToWorldPoint(ih.Mouse_Position);
        target_position.z = 0;

        CheckGridForSnapPosition();

        if (Input.GetMouseButtonDown(1) && position_is_snapped)  //right mouse click and position snapped
        {
            if (Placed_Tiles.Find(t => t.transform.position == target_position))
            {
                int index;
                index = Placed_Tiles.FindIndex(t => t.transform.position == target_position);
                Destroy(Placed_Tiles.Find(t => t.transform.position == target_position));
                Placed_Tiles.Remove(Placed_Tiles[index].gameObject);
            }
        }

        if (Selected_Piece)
        {
            
            Selected_Piece.transform.position = target_position;
            DetermineCurrentSprite();



                if (Input.GetMouseButtonDown(0) && position_is_snapped)  //left mouse click and position snapped
                {
                Selected_Piece.GetComponent<GameTile>().DetermineActiveNodes();  //find linkable nodes of piece held

                if (Placed_Tiles.Find(t => t.transform.position == target_position))
                {                
                    Debug.Log(Placed_Tiles.Find(t => t.transform.position == target_position));

                    //Debug.Log("Placed Road Nodes: " + (Placed_Tiles.Find(t => t.transform.position == target_position).GetComponent<GameTile>().Active_Nodes.Count));
                    //Debug.Log("Held Road Nodes: " + (Selected_Piece.GetComponent<GameTile>().Active_Nodes.Count));

                    
                    if (Placed_Tiles.Find(t => t.transform.position == target_position).GetComponent<GameTile>().Active_Nodes.Count < Selected_Piece.GetComponent<GameTile>().Active_Nodes.Count)
                    {
           
                    }
                    else
                    {
          
                    }
                }
                else
                {                   
                    foreach (Vector3 Active_Node in Selected_Piece.GetComponent<GameTile>().Active_Nodes)  //iterate through each node of piece held
                    {
                        foreach (GameObject Game_Tile in Placed_Tiles)  //iterate through each linkable tile on the board
                        {
                            foreach (Vector3 Linkable_Node in Game_Tile.GetComponent<GameTile>().Active_Nodes)  //iterate through each node of current linkable tile
                            {
                                switch(currentRoadType)
                                {
                                    case RoadType.Land:
                                        if (Active_Node == Linkable_Node && !Tile_Added && playerResourceManager.MountainAmount >= LandRoadBuildCost * Selected_Piece.GetComponent<GameTile>().Active_Nodes.Count)  //if nodes match on piece held and linkable tile, drop piece
                                        {
                                            Tile = Instantiate(Selected_Piece, target_position, Quaternion.identity) as GameObject;
                                            Tile.GetComponent<GameTile>().DetermineActiveNodes();
                                            Tiles_To_Place.Add(Tile);
                                            Tile_Added = true;

                                            playerResourceManager.MountainAmount -= LandRoadBuildCost * Selected_Piece.GetComponent<GameTile>().Active_Nodes.Count;
                                            Placed_Road_Positions.Add(target_position);
                                        }
                                        break;
                                    case RoadType.Water:
                                        if (Active_Node == Linkable_Node && !Tile_Added && playerResourceManager.ForestAmount >= WaterRoadBuildCost * Selected_Piece.GetComponent<GameTile>().Active_Nodes.Count)  //if nodes match on piece held and linkable tile, drop piece
                                        {
                                            Tile = Instantiate(Selected_Piece, target_position, Quaternion.identity) as GameObject;
                                            Tile.GetComponent<GameTile>().DetermineActiveNodes();
                                            Tiles_To_Place.Add(Tile);
                                            Tile_Added = true;

                                            playerResourceManager.ForestAmount -= WaterRoadBuildCost * Selected_Piece.GetComponent<GameTile>().Active_Nodes.Count;
                                            Placed_Road_Positions.Add(target_position);
                                        }
                                        break;
                                    default:
                                        break;
                                }

                            }
                        }
                    }
                    foreach (GameObject Game_Tile in Tiles_To_Place)
                    {
                        Placed_Tiles.Add(Game_Tile);

                        foreach (CityScript c in Cities)
                        {
                            if (!Placed_Tiles.Contains(c.gameObject))
                            {
                                foreach (Vector3 City_Node in c.City_Nodes)
                                {
                                    foreach (Vector3 Active_Node in Game_Tile.GetComponent<GameTile>().Active_Nodes)  //iterate through each node of piece held
                                    {
                                        if (Active_Node == City_Node)
                                        {
                                            Placed_Tiles.Add(c.gameObject);
                                            playerResourceManager.AddTileToCollection(c);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    Tiles_To_Place.Clear();

                    Tile_Added = false;
                }
                
            }

            if (Input.GetMouseButtonDown(1))
            {
                Destroy(Selected_Piece);
            }
        }

        if (Input.GetMouseButtonDown(0) && !Selected_Piece)
        {
            Selected_Piece = Instantiate(Reference_Tile, target_position, Quaternion.identity) as GameObject;
            Selected_Piece.GetComponent<SpriteRenderer>().color = Color_List[0];
            current_sprite_index = Sprite_List.IndexOf(Selected_Piece.GetComponent<SpriteRenderer>().sprite);
        }
    }

    private void CheckGridForSnapPosition()
    {
        foreach (Vector3 vector in Game_Board.Game_Grid)
        {
            test_distance = Mathf.Abs((target_position - vector).magnitude);

            if (test_distance <= snap_distance)
            {
                target_position = vector;

                Grid_Snap_Location = Game_Board.Game_Grid.IndexOf(vector);
            }
        }

        CheckIfSnappedToSGrid();
    }

    private void CheckIfSnappedToSGrid()
    {
        if (target_position == Game_Board.Game_Grid[Grid_Snap_Location])
        {
            position_is_snapped = true;
        }
        else
        {
            position_is_snapped = false;
        }
    }

    private void DetermineCurrentSprite()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            current_sprite_index++;

            if (current_sprite_index > Sprite_List.Count - 1)
            {
                current_sprite_index = 0;
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            current_sprite_index--;

            if (current_sprite_index < 0)
            {
                current_sprite_index = Sprite_List.Count - 1;
            }
        }

        Selected_Piece.GetComponent<SpriteRenderer>().sprite = Sprite_List[current_sprite_index];
    }
}

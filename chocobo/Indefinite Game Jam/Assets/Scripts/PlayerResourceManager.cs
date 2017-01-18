using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerResourceManager : MonoBehaviour {

    public Canvas myCanvas;
    public Text MountainText;
    public Text ForestText;
    public Text FarmText;
    public List<GameObject> Placed_Tiles;
    public List<CityScript> Cities;

    public float tickTime;
    public int MountainAmount;
    public int ForestAmount;
    public int FarmAmount;
    void Awake()
    {
        tickTime = 1f;
    }

    void Start()
    {
        Cities.Add(GetComponent<PlaceSquare>().Placed_Tiles[0].GetComponent<CityScript>());
    }
    void Update()
    {
        MountainText.text = MountainAmount.ToString();
        ForestText.text = ForestAmount.ToString();
        FarmText.text = FarmAmount.ToString();

        tickTime -= Time.deltaTime;

        if (tickTime <= 0)
        {
            tickTime = 1f;

            foreach (CityScript city in Cities)
            {
                foreach (GameObject resource in city.Surrounding_Tiles)
                {
                    switch(resource.GetComponent<ResourceScript>().resourceProvided)
                    {
                        case (ResourceScript.Resource.Stone):
                            MountainAmount++;
                            break;
                        case (ResourceScript.Resource.Logs):
                            ForestAmount++;
                            break;
                        case (ResourceScript.Resource.Wheat):
                            FarmAmount++;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

    }

    public void AddTileToCollection(CityScript city)
    {
        Cities.Add(city);
    }
}

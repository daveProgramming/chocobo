using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceScript : MonoBehaviour
{

    public List<CityScript> Cities;
    public List<Rect> City_Bounds;
    public Rect rectangle;
    public List<CityScript> Overlapping_Cities;

    public enum Resource { None, Stone, Logs, Wheat, Fish, OliveOil }
    public Resource resourceProvided;

    void Start()
    {
        foreach (CityScript city in GameObject.Find("Cities").GetComponentsInChildren<CityScript>())
        {
            Cities.Add(city);
        }

        foreach (CityScript city in Cities)
        {
            City_Bounds.Add(city.Zone);
        }

        rectangle = new Rect(GetComponent<Transform>().position, new Vector2(0.3125f, .3125f));
        rectangle.center = GetComponent<Transform>().position;

        switch (gameObject.tag)
        {
            case ("Default_Tile"):
                resourceProvided = Resource.None;
                break;
            case ("Mountain"):
                resourceProvided = Resource.Stone;
                break;
            case ("Forest"):
                resourceProvided = Resource.Logs;
                break;
            case ("Field"):
                resourceProvided = Resource.Wheat;
                break;
            case ("Water"):
                resourceProvided = Resource.Fish;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        foreach (CityScript city in Cities)
        {
            if (rectangle.Overlaps(city.Zone) && !city.Surrounding_Tiles.Contains(this.gameObject))
            {
                Overlapping_Cities.Add(city.GetComponent<CityScript>());
                city.Surrounding_Tiles.Add(this.gameObject);
            }
        }

    }
}

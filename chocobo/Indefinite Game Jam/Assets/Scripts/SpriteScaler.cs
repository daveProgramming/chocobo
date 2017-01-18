using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteScaler : MonoBehaviour {

    public enum ScaleDirection { Up, Down }
    public ScaleDirection currentScaleDirection;
    public float myScale;
    public float scaleStep;
    public float scaleController;
    public List<CityScript> cities;

    public 
	// Use this for initialization
	void Start () {
        currentScaleDirection = ScaleDirection.Up;

        cities = GameObject.Find("Player").GetComponent<PlayerResourceManager>().Cities;
	}
	
	// Update is called once per frame
	void Update () {

        if(cities.Contains(this.GetComponent<CityScript>()))
        {
            myScale += scaleStep;
            transform.localScale = new Vector3(myScale, myScale, myScale);

            if (myScale >= .3f)
            {
                myScale = 0.25f;
            }
        }
       

        //while (scaleController < 3)
        //{
        //    if(myScale > 1 && currentScaleDirection == ScaleDirection.Up)
        //    {
        //        currentScaleDirection = ScaleDirection.Down;
        //    }

        //    if (myScale < .25 && currentScaleDirection == ScaleDirection.Down)
        //    {
        //        currentScaleDirection = ScaleDirection.Up;
        //    }

        //    if (currentScaleDirection == ScaleDirection.Up)
        //    {
        //        myScale += scaleStep;
        //        transform.localScale = new Vector3(myScale, myScale, myScale);

        //        scaleController += scaleStep;
        //    }

        //    if (currentScaleDirection == ScaleDirection.Down)
        //    {
        //        myScale -= scaleStep;
        //        transform.localScale = new Vector3(myScale, myScale, myScale);

        //        scaleController += scaleStep;
        //    }
        //}
    }
}

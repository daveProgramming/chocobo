using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Menu : MonoBehaviour {

    bool paused;
    public List<Image> imageList;
    public List<Text> textList;

    void Start()
    {
        paused = true;
        foreach(Text txt in GetComponentsInChildren<Text>())
        {
            textList.Add(txt);
        }
        foreach (Image img in GetComponentsInChildren<Image>())
        {
            imageList.Add(img);
        }
    }

    void Update()
    {
        if(paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (paused)
            {
                paused = false;

                foreach(Text txt in textList)
                {
                    txt.color -= new Color(0, 0, 0, 1);
                }

                foreach (Image img in imageList)
                {
                    img.color -= new Color(0, 0, 0, 1);
                }

            }
            else
            {
                paused = true;

                foreach (Text txt in GetComponentsInChildren<Text>())
                {
                    txt.color += new Color(0, 0, 0, 1);
                }

                foreach (Image img in GetComponentsInChildren<Image>())
                {
                    img.color += new Color(0, 0, 0, 1);
                }
            }

        }
    }
}

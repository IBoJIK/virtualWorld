using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Range : MonoBehaviour
{
    private float sec=0;
    private float min=0;
    private int point = 0;

    public Text range_time, range_point;
    public bool start;

    // Start is called before the first frame update

    public void StartRange()
    {
        if (range_point.text == "0")
        {
            start = true;
            range_point.text = (++point).ToString();
        }
        else
        {
            range_point.text = (++point).ToString();
        }
    }
    public void Time_range()
    {
        sec += Time.deltaTime;
        if(sec >59)
        {
            min++;
            sec = 0;
        }
        range_time.text = min + " : " + Mathf.Round(sec);
    }
    public void Finish()
    {
        start = false;
        sec = 0;
        min = 0;
        point = 0;
        range_time.text = 0 + " : " + 0;
        range_point.text = "0";
    }
    void Update()
    {
        if (start)
        {
            Time_range();
        }
    }
}

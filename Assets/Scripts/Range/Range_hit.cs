using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range_hit : MonoBehaviour
{
    public GameObject range;
    public GameObject gm;
    public void Hit()
    {
        if (range.activeInHierarchy)
        {
            gm.GetComponent<Range>().StartRange();
        }
    }
}

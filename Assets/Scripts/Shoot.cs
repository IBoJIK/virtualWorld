using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    private string pickTag = "object";
    private float curTimeout = 0;
    private GameObject clone;
    private float force = 500;
    private RaycastHit hit;

    public bool isFight = false;
    public GameObject rock; 
    public Transform spawn;
    public Text pick_quest;
    public Text shoot_quest;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && curTimeout <= 0)
        {
            clone = Instantiate(rock, spawn.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce(spawn.transform.forward * force);
            Destroy(clone, 10);
            curTimeout = 1.5f;
        }
        if (curTimeout > 0)
        {
            curTimeout -= Time.deltaTime;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (pickTag == hit.transform.tag)
                {
                    Destroy(hit.collider.gameObject);
                    pick_quest.color = new Color(0, 200, 20, 255);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColliderPlayer : MonoBehaviour
{
    private int hp_player = 100;
    private float time = 10;

    public Text ui_hp;
    public Text loc;
    public Text[] sp;
    public GameObject gm;
    public GameObject range;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Elect")
        {
            hp_player -= 20;
        }
        if (other.tag == "location")
        {
            loc.enabled = true;
            loc.text = "Добро пожаловать в локацию \"" + other.name + "\"";
            for (int i = 0; i < sp.Length; i++)
            {
                if (sp[i].name == other.name)
                {
                    sp[i].color = new Color(0, 200, 20, 255);
                }
            }
        }
        if (other.tag == "range")
        {
            range.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "location")
        {
            loc.enabled = false;
            time = 10;
        }
        if (other.tag == "range")
        {
            range.SetActive(false);
            gm.GetComponent<Range>().Finish();
        }
    }

    private void UI_HP()
    {
        ui_hp.text = hp_player.ToString();
    }

    private void Death()
    {
        if (hp_player <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void Update()
    {
        Death();
        UI_HP();
        if (loc.enabled && time >= 0)
        {
            time -= Time.deltaTime;
        }
        if (time < 0)
        {
            time = 10;
            loc.enabled = false;
        }
        if(gm.GetComponent<Range>().start)
        {
            sp[3].color = new Color(0, 200, 20, 255);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tracker : MonoBehaviour
{
    //Text
    public Text text;

    //Variables
    public float heartRate = 70;
    public int score = 0;

    //For dynamic text
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //access player script
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        text.text = "Health: " + player.GetComponent<Player>().health + "\nScore: " + player.GetComponent<Player>().score + "\nHeartrate: " + heartRate;
    }
}

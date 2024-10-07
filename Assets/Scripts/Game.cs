
using UnityEngine;

using UnityEngine.SocialPlatforms.Impl;

public class Game : MonoBehaviour
{

    public GameObject Player;
    public GameObject button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        Player =GameObject.Find("Player");
        


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnStart()
    {
        
        Player.SetActive(true);
        button.SetActive(false);
    }
}


using UnityEngine;

using UnityEngine.SocialPlatforms.Impl;

public class Game : MonoBehaviour
{

    public GameObject Player;
    public GameObject button;
    public bool iSstartPlay=false;

    // this method is called when the player clicks the start button    
    public void OnStart()
    { 
        button.SetActive(false);
        iSstartPlay = true;
    }
}

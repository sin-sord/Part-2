using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public void HurtPlayer(float thorn)  //if the player touches a thorn then they get hurt
    {
        SendMessage("HurtPlayer", 1);
    }
}
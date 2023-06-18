using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSearch : MonoBehaviour
{
    [SerializeField] private Canvas HUD;
    void Start()
    {
        HUD.worldCamera = Camera.main;
    }

    // Update is called once per frame
   
}

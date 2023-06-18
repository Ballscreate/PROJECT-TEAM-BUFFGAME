using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cinemachine;
public class CameraMovment : NetworkBehaviour
{
  private Camera _playerCam;
  private void Start() 
  {
    if(!isLocalPlayer) return;
    _playerCam = Camera.main;
  }
  private void Update() 
  {
    if(!isLocalPlayer) return;
    CameraMovmentToPlayer();
  }
  public void CameraMovmentToPlayer()
  {
   _playerCam.transform.position = new Vector3(transform.position.x,transform.position.y + 5,-10);
   
  
  }
}

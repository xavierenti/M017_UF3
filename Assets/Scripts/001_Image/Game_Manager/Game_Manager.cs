using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] private GameObject spaunPlayer1;
    [SerializeField] private GameObject spaunPlayer2;

    private void Awake()
    {
        if (PhotonNetwork.IsMasterClient){
            PhotonNetwork.Instantiate("Player", spaunPlayer1.transform.position, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate("Player", spaunPlayer2.transform.position, Quaternion.identity);
        }
    }
    
}

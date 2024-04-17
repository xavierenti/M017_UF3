using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bala : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody rb;

    private PhotonView pv;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pv = GetComponent<PhotonView>();
    }

    private void Start()
    {
        rb.velocity = new Vector3(speed, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        pv.RPC("NetworkDestroy", RpcTarget.All);
        collision.gameObject.GetComponent<Character>().Damage();
    }

    [PunRPC]
    public void NetworkDestroy()
    {
        Destroy(this.gameObject);
    }
}

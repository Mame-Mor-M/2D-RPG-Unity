using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireProjectile : MonoBehaviour
{
    public GameObject fireBallPrefab;
    public float projectileDamage;

    PlayerController playerctrl;
    public GameObject player;
    private GameObject clone;

    private float timer;
    public float time;

    public bool startTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        playerctrl = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
         

        
        Destroy(clone, 10f);
        Quaternion plyRot = player.transform.rotation;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Fire();
            timer = time;
            startTimer = true;
        }
    }

    void Fire()
    {
        if (playerctrl.horizontal < 0 || player.transform.rotation == new Quaternion(player.transform.rotation.x,0,player.transform.rotation.z,player.transform.rotation.w))
        {
            clone = Instantiate(fireBallPrefab, transform.position, fireBallPrefab.transform.rotation * Quaternion.Euler(0f, 0f, 180f));
            
        }
        else
        {
            Instantiate(fireBallPrefab, transform.position, fireBallPrefab.transform.rotation);
                                
            
        }
        
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossState : MonoBehaviour
{
    // Start is called before the first frame update
    public DefaultEnemy defaultEnemy;
    public EnemyHealthManager eHealthMan;
    public playerMovement playMove;
    public ShakeBehavior shakebake;
    public float SlamTime;
    public float SlamStartTime;
    public Fire fire;
    public GameObject loader;
    public GameObject wall;
    bool unloaded;
    void Start()
    {
        loader.SetActive(false);
        shakebake = FindObjectOfType<ShakeBehavior>();
        playMove = FindObjectOfType<playerMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Slam();
        if (eHealthMan.currentHealth <= 0)
        {


            playMove.setCanRanged(true);
            wall.SetActive(false);
            loader.SetActive(true);
            Destroy(gameObject);
        }


        
    }
    public void fistShot()
    {
        fire.shoot();
    }
    public void Slam()
    {
        if (defaultEnemy.melee != true)
        {
            SlamTime = 0;
            defaultEnemy.animator.SetBool("Slam", false);
        }
        else
        {
            SlamTime += Time.deltaTime;
        }
        if (SlamTime>=SlamStartTime)
        {
            Debug.Log("should slam");
            defaultEnemy.animator.SetBool("Slam", true);
            shakebake.TriggerShake();
            soundManager.PlaySound("BossOneSound");
            SlamTime = 0;
        }
        else
        {
            defaultEnemy.animator.SetBool("Slam", false);
            
        }
    }
}

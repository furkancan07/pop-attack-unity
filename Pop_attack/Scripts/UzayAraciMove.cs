using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;


public class UzayAraciMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject mermi;
    private Rigidbody2D mermiRb;
    [SerializeField]GameObject spawn;
    [SerializeField] private float mermiHiz;
    private float mermiZaman;
    public int gSkor;
    public Text gText;
    public int canlar;
    public GameObject[] can;
    public GameObject gameOver;
    public Text bestScore;
    
   
    
    void Start()
    {
        
       
        bestScore.text = PlayerPrefs.GetInt("bestScore").ToString();
        Time.timeScale = 1;
        mermiZaman = 0.3f;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(mermiAtmaSuresi());
        canlar = 3;
        gameOver.SetActive(false);
        
    }


    void Update()
    {
        bestScore.text = PlayerPrefs.GetInt("bestScore").ToString();
        if (gSkor>PlayerPrefs.GetInt("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore",gSkor);
        }
       hareket();
        gText.text = gSkor.ToString();
        


    }

    void hareket()
    {
        
        var x = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(x, 0);
        rb.velocity = move * (speed);
        
    }

    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator mermiAtmaSuresi()
    {
        while (true)
        {
            mermiat();
            yield return new WaitForSeconds(mermiZaman);
        }
        
    }

    void mermiat()
    {
        
        mermi=Instantiate(mermi, spawn.transform.position,transform.rotation);
        mermiRb = mermi.GetComponent<Rigidbody2D>();
        mermiRb.AddForce(transform.up*mermiHiz);
        Destroy(mermi.gameObject,2f);
    }

    
}

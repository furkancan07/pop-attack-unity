using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class Balon : MonoBehaviour
{
    [SerializeField] private float maxY,minY;
     public Text skorText;
     
    private int skor;
    Rigidbody2D balonRb;
    [SerializeField] private float ziplama;
    private UzayAraciMove _uzayAraciMove;

    private void Awake()
    {
        _uzayAraciMove = Object.FindObjectOfType<UzayAraciMove>();
    }

    void Start()
    {
        
        int[] skorlar = {5,10,20,25,30};
        int i = Random.Range(0, skorlar.Length);
        skor = skorlar[i];
        balonRb = gameObject.GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        skorText.transform.position = gameObject.transform.position;
        skorText.text = skor.ToString();
       
        
        var y = transform.position.y;
         y = Mathf.Clamp(y, minY, maxY);
         transform.position = new Vector2(transform.position.x, y);
         if (skor == 0)
         {
             Destroy(gameObject);
             Destroy(skorText);
         }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("mermi"))
        {
            _uzayAraciMove.gSkor++;
            skor--;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            
            print(_uzayAraciMove.canlar--);
            Destroy(_uzayAraciMove.can[_uzayAraciMove.canlar]);
            if (_uzayAraciMove.canlar == 0)
            {
                Debug.Log("Game Over"); 
                // game Over ekrani Yapma
                _uzayAraciMove.gameOver.SetActive(true);
                Time.timeScale = 0;
            }
            
        }

        if (other.gameObject.CompareTag("asagi"))
        {
            balonRb.velocity=Vector2.up*ziplama;
        }
        
        
    }
}


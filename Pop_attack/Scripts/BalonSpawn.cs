using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class BalonSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Balon[] balonlar;
    private Balon balon;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Text _text;
    private Text klonText;
    private Balon _balon;
    [SerializeField] int  minX, maxX;

    private void Awake()
    {
        
        _balon = Object.FindObjectOfType<Balon>();
    }    
    void Start()
    {
        var x=Random.Range(minX,maxX);
       
        transform.position = new Vector2(x,transform.position.y);
        StartCoroutine(balonSpawn());
        
    }
    
    IEnumerator balonSpawn()
    {
        while (true)
        {
            int random = Random.Range(0, balonlar.Length);
            balon = balonlar[random];
           balon= Instantiate(balon,transform.position,transform.rotation);
           klonText= Instantiate(_text,transform.position,transform.rotation);
           klonText.transform.parent = canvas.transform;
           klonText.transform.localScale = new Vector3(1, 1, 1);
           _balon = balon;
           _balon.skorText = klonText;
            yield return new WaitForSeconds(10);
        }
    }
}

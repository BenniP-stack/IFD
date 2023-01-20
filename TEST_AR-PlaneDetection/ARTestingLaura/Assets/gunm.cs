using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunm : MonoBehaviour
{
    public Sprite off_texture;
    public Sprite on_texture;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootInit()
    {
        StartCoroutine(Shoot());
    }
    public IEnumerator Shoot()
    {
        this.gameObject.GetComponent<Image>().sprite = off_texture;
        yield return new WaitForSeconds(1.5f);
        this.gameObject.GetComponent<Image>().sprite = on_texture;
    }
}

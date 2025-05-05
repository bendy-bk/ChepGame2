using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    [SerializeField] private GameObject hit_VFX;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();        
    }

    public void OnInit()
    {
        rb.velocity = transform.right * speed;
        Invoke(nameof(OnDesSpawn), 3f);
    }

    public void OnDesSpawn()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("destroy kunai");
            collision.GetComponent<Character>().OnHit(30f);
            Instantiate(hit_VFX, transform.position, transform.rotation);
            OnDesSpawn();
        }
    }


}

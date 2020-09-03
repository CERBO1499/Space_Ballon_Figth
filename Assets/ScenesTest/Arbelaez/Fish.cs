using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] float time;


    // Start is called before the first frame update
    void Start()
    {
        time = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}

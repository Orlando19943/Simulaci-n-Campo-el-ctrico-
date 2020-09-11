using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particula : MonoBehaviour
{
    private Transform tr;
    Rigidbody rb;
    public float mass = 9.11e-31f;
    public float charge = -1.6e-19f;
    public float electricField = 525f;
    public float velocity = 3f;
    public float time = 1e+13f; //Hay que hacer muchas pruebas para saber que tiempo ponerle (reducir el tiempo de Unity no funciona)

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(new Vector3(velocity * Time.deltaTime, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("campo"))
        {
            Physics.gravity = new Vector3 (0f,gravity(mass, charge, electricField, time),0f);
            rb.useGravity = true;
        }
    }

    private float gravity(float m, float c, float E,float t)
    {
        float gravity = (E*c)/(m*time);
        return gravity;
    }
}

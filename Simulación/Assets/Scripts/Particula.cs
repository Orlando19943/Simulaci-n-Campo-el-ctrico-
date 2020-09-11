using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particula : MonoBehaviour
{
    private Transform tr;
    Rigidbody rb;
    public float Masa = 9.11e-31f;
    public float Carga = -1.6e-19f;
    public float CampoElectrico = 525f;
    public float VelocidadX = 3f;
    public float VelocidadY = 0f;
    public float time = 1e+13f; //Este tiempo solo se utiliza para saber la trayectoria que tomará la particula ya que da problemas si se reduce el tiempo del programa

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(new Vector3(VelocidadX * Time.deltaTime, VelocidadY * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("campo"))
        {
            Physics.gravity = new Vector3 (0f,gravity(Masa, Carga, CampoElectrico, time),0f);
            rb.useGravity = true;
        }
        else if (other.gameObject.CompareTag("noCampo"))
        {
            time = 1;
            Physics.gravity = new Vector3(0f, gravity(Masa, Carga, CampoElectrico, time), 0f);
            rb.useGravity = false;
            Time.timeScale = 0f;
        }

    }

    private float gravity(float m, float c, float E,float t)
    {
        float gravity = (E*c)/(m*time);
        return gravity;
    }
}

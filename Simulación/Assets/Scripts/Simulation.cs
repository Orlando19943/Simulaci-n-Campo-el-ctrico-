using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simulation : MonoBehaviour
{
    private Transform tr;
    Rigidbody rb;
    public Text velocity;
    public Text angle;
    public Text mass;
    public Text charge;
    public Text field;
    public Text width;
    public Canvas canvas;
    public GameObject fieldSimulator;
    float xVelocity = 0;
    float yVelocity = 0;
    float acceleration = 0;
    float delay = 1e-14f;
    float field_width = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    /*void Update()
    {
        fieldSimulator.transform.position = new Vector3((field_width / 2) - 7, tr.localPosition.y, -11.05421f);

    }*/

    public void Simulate()
    {
        float fVelocity = float.Parse(velocity.text);
        float fangle = float.Parse(angle.text);
        float ffield = float.Parse(field.text);
        float fmass = float.Parse(mass.text);
        float fcharge = float.Parse(charge.text);
        Time.timeScale = delay;
        field_width = float.Parse(width.text);
        CalculateVelocity(fVelocity, fangle);
        CalculateAcceleration(fmass, fcharge, ffield, delay);
        canvas.enabled = false;
        fieldSimulator.transform.localScale = new Vector3(field_width,fieldSimulator.transform.localScale.y);
        fieldSimulator.transform.position = new Vector3((field_width / 2) - 7, 19.76f, -11.05421f);
        //fieldSimulator.transform.position = new Vector3((field_width / 2) - 7, tr.localPosition.y, -11.05421f);

        print(fcharge);
        print(fmass);
        print(fVelocity);
        print(yVelocity);
        print(acceleration);


    }


    private void CalculateVelocity(float velocity, float angle)
    {
        float radians = Mathf.Deg2Rad * angle;
        xVelocity = velocity * Mathf.Cos(radians);
        yVelocity = velocity * Mathf.Sin(radians);
    }


    private void CalculateAcceleration(float mass, float charge, float field, float delay)
    {
        acceleration = ((charge * field) / mass) * 1;

    }

    private void Update()
    {
        tr.Translate(new Vector3(xVelocity * Time.fixedDeltaTime, (yVelocity * Time.fixedDeltaTime), 0f));
        if (tr.position.x >= -7 && tr.position.x <= (field_width - 7))
        {
            Physics.gravity = new Vector3(0f, acceleration, 0f);
            rb.useGravity = true;
            fieldSimulator.transform.position = new Vector3((field_width / 2) - 7, tr.localPosition.y, -11.05421f);
            print("prueba");
        }
        else if (tr.position.x > (field_width - 7))
        {
            xVelocity = 0;
            yVelocity = 0;
            rb.useGravity = false;
            Time.timeScale = 0f;
            print("hola");
        }

    }


}

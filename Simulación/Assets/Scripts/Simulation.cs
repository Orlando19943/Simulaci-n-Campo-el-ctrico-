using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Simulation : MonoBehaviour
{
    private Transform tr;
    Rigidbody rb;
    TrailRenderer TR;
    public Text velocity;
    public Text angle;
    public Text mass;
    public Text charge;
    public Text field;
    public Text width;
    public Canvas canvas;
    public Canvas canvas2;
    public GameObject fieldSimulator;
    public GameObject x_Axis;
    float xVelocity = 0;
    float yVelocity = 0;
    float acceleration = 0;
    public float delay = 1f;
    float field_width = 0;
    float time;
    float finalDistance;
    RaycastHit hitInfo;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        TR = GetComponent<TrailRenderer>();
        canvas2.enabled = false;
    }

    public void Carga(string nivel)
    {
        Physics.gravity = new Vector3(0f, 1f, 0f);
        SceneManager.LoadScene(nivel);
    }

    public void Simulate()
    {
        float fVelocity = float.Parse(velocity.text);
        float fangle = float.Parse(angle.text);
        float ffield = float.Parse(field.text);
        float fmass = float.Parse(mass.text);
        float fcharge = float.Parse(charge.text);
        field_width = float.Parse(width.text);
        CalculateVelocity(fVelocity, fangle);
        CalculateAcceleration(fmass, fcharge, ffield, delay);
        CalculateTime(field_width, xVelocity);
        CalculateFinalDistance(time);
        CalculateDelay(finalDistance);
        Last();
        print("Delay = "+ delay +"Velocidad X = " + xVelocity + "Velocidad Y = " + xVelocity + "Aceleracion = "+ acceleration);
        canvas.enabled = false;
        canvas2.enabled = true;
        fieldSimulator.transform.localScale = new Vector3(field_width,fieldSimulator.transform.localScale.y);
        fieldSimulator.transform.position = new Vector3((field_width / 2) - 7, 19.76f, -11.05421f);
        Physics.gravity = new Vector3(0f, acceleration, 0f);
        rb.useGravity = true;
        //fieldSimulator.transform.position = new Vector3((field_width / 2) - 7, tr.localPosition.y, -11.05421f);

        //print(fcharge);
        //print(fmass);
        //print(fVelocity);
        //print(yVelocity);
        //print(acceleration);
    }


    private void CalculateVelocity(float velocity, float angle)
    {
        float radians = Mathf.Deg2Rad * angle;
        xVelocity = velocity * Mathf.Cos(radians);
        yVelocity = velocity * Mathf.Sin(radians);
        
    }

    private void CalculateTime (float distance, float velocityX)
    {
        time = distance / velocityX;
        print("Time = " + time);
    }
    private void CalculateFinalDistance(float time)
    {
        finalDistance = yVelocity * time+ 0.5f * acceleration * time * time;
        print("finalDistance = " + finalDistance);
    }

    private void CalculateDelay(float distance)
    {
        int n = 0;
        float finalDistance = Mathf.Abs(distance);
        if (finalDistance < 1)
        {
            while (finalDistance < 100)
            {
                n--;
                finalDistance *= 10;
            }
        }else
        {
            while (finalDistance > 100)
            {
                n++;
                finalDistance /= 10;
            }
        }
        
        print("n = " + n);
        delay = Mathf.Pow(10, n);
    }

    private void Last()
    {
        yVelocity = yVelocity * delay;
        xVelocity = xVelocity * delay;
        acceleration = acceleration * delay;
    }

    private void CalculateAcceleration(float mass, float charge, float field, float delay)
    {
        acceleration = ((charge * field) / mass);

    }

    private void Update()
    {
        tr.Translate(new Vector3(xVelocity * Time.fixedDeltaTime, (yVelocity * Time.fixedDeltaTime), 0f));
        if (tr.position.x >= -70 && tr.position.x <= (field_width - 70))
        {
            //print(Time.deltaTime/delay);
            fieldSimulator.transform.position = new Vector3((field_width / 2) - 7, tr.localPosition.y, -11.05421f);
            //x_Axis.transform.position = new Vector3(tr.localPosition.x, x_Axis.transform.localPosition.y, -11.05421f);
            //print("prueba");
        }
        else if (tr.position.x > (field_width - 7))
        {
            print(Time.deltaTime);
            xVelocity = 0;
            yVelocity = 0;
            rb.useGravity = false;
            print(tr.localPosition.x);
        }
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        

        if (Physics.Raycast(myRay, out hitInfo))
        {

            if (hitInfo.collider.gameObject.CompareTag("particle") & Physics.gravity.y != 1f)
            {
                print("Funciona");
            }
                
        }
            


        

    }


}

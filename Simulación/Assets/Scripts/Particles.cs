using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Particles : MonoBehaviour
{
    public Dropdown dropdown;
    public Text mass;
    public Text charge;
    List<string> particles = new List<string>()
    {"Particulas", "Electron", "Proton","Particual Alfa" ,"Nucleo de Deuterio", "Particula de Muon", "Nucleo de Berilio", "Nucleo de Oro", "Nucleo de Hierro","Nucleo de Litio" };
    List<string> particlesMass = new List<string>()
    {"", "9.11e-31","1.67e-27","6.64e-27","3.33e-27","1.88e-28","1.49e-26","1.49e-26","3.27e-25","9.29e-26","1.16e-26" };
    List<string> particleCarge = new List<string>()
    {"","-1.6e-19","1.6e-19", "3.2e-19","1.6e-19","-1.6e-19","6.4e-19","1.26e-17","4.16e-18","4.8e-19"};
   
    // Start is called before the first frame update
    void Start()
    {
        dropdown.AddOptions(particles);
    }

    public void SelectedItemn(int index)
    {
        mass.text = particlesMass[index];
        charge.text = particleCarge[index];
    }

}

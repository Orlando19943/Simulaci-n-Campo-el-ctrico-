using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Particles : MonoBehaviour
{
    public Dropdown dropdown;
    public Text mass;
    List<string> particles = new List<string>()
    {"Particulas", "Electron", "Proton", "Neutron", "Nucleo de Deuterio", "Particula de Muon", "Nucleo de Berilio", "Nucleo de Oro" };
    List<string> particlesMass = new List<string>()
    {"", "try","","","","","","","","","" };
   
    // Start is called before the first frame update
    void Start()
    {
        dropdown.AddOptions(particles);
    }

    public void SelectedItemn(int index)
    {
        mass.text = particlesMass[index];
    }


}

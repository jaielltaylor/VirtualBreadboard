using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public void BreadboardSim() { SceneManager.LoadScene("SampleScene"); }
    public void Reload() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
    public void LogicSim() { SceneManager.LoadScene("LogicScene"); }
    public void ModuleSelect() { SceneManager.LoadScene("ModuleSelect"); }
    public void Menu() { SceneManager.LoadScene("Main Menu"); }
    public void Module1() { SceneManager.LoadScene("Module1"); }
    public void Module2() { SceneManager.LoadScene("Module2"); }
    public void Module3() { SceneManager.LoadScene("Module3"); }
    public void Module4() { SceneManager.LoadScene("Module4"); }
    public void Module5() { SceneManager.LoadScene("Module5"); }
    public void Module6() { SceneManager.LoadScene("Module6"); }
    public void Quit() { Application.Quit(); }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            string curScene = SceneManager.GetActiveScene().name;
            
            if (curScene == "ModuleSelect") { Menu(); }
            else if (curScene.Contains("Module")) { ModuleSelect(); }
            else if (curScene.Contains("Scene")) { Menu(); }
        }
    }
}

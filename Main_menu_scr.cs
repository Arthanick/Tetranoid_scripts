using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_menu_scr : MonoBehaviour
{
    public GameObject settings_panel;
    public Slider width_slide;
    public Slider height_slide;
    public Toggle Controller_toggle;
    public Text w_txt;
    public Text h_txt;
    public Text Toggle_txt;
    // Рисуем кнопки главного меню
    private void OnGUI()
    {
        if (GUI.Button(new Rect(15, 15, 150, 50), "New game"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
        if (GUI.Button(new Rect(15, 75, 150, 50), "Settings"))
        {
            settings_panel.SetActive(!settings_panel.activeSelf);
        }
        if (GUI.Button(new Rect(15, 135, 150, 50), "Exit"))
        {
            Application.Quit();
        }
    }
    // Выводим начальные значения параметров игры
    public void Start()
    {
        w_txt.text = "Width: " + (int)width_slide.value;
        h_txt.text = "Height: " + (int)height_slide.value;
        Global.width = (int)width_slide.value;
        Global.height = (int)height_slide.value;
        Global.set_Controller = true;
    }
    // Если в главном меню нажать ESC, то приложение закроется
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
    // Установка ширины
    public void setwidth()
    {
        Global.width = (int)width_slide.value;
        w_txt.text = "Width: " + Global.width;
    }
    // Установка высоты
    public void setheight()
    {
        Global.height = (int)height_slide.value;
        h_txt.text = "Height: " + Global.height;
    }
    // Установка контроллера
    public void setController()
    {
        if(Controller_toggle.isOn)
        {
            Toggle_txt.text = "Mouse";
            Global.set_Controller = true;
        }
        if (!Controller_toggle.isOn)
        {
            Toggle_txt.text = "Keyboard";
            Global.set_Controller = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Основной скрипт, который строит поле, отвечает за создание блоков и инициализацию переменных
public class Field_creator_scr : MonoBehaviour
{
    private int w;
    private int h;

    public Vector3 start_point;
    public GameObject border_prefab;
    public GameObject block_prefab;
    public Text Score_txt;

    private GameObject br;
    public void Start () 
    {
        w = Global.width;
        h = Global.height;
        Global.difficulty = 0.1f;
        Global.Answer = 0;
        Global.Score = 0;
        Global.Lose = false;
        Global.start_pos = start_point;
        Score_txt.text = "Score: " + Global.Score.ToString();
        // Строим границы стакана
        for (int i = 0; i < h; i++)
        {
            br = Instantiate(border_prefab, start_point, Quaternion.identity) as GameObject;
            br = Instantiate(border_prefab, new Vector3(start_point.x + w, start_point.y, start_point.z), Quaternion.identity) as GameObject;
            start_point.y += 0.5f;
        }
        // И Ставим первый кубик
        br = Instantiate(block_prefab, new Vector3(Random.Range(start_point.x + 1, start_point.x + w - 1), start_point.y, start_point.z), Quaternion.identity) as GameObject;
        Global.Block_here = true;
	}
    private void FixedUpdate()
    {
        // При нажатии ESC возвращаемся в главное меню
        if (Input.GetKeyDown(KeyCode.Escape))
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main_menu");
        // Проверка на наличиет кубиков в игре, если их нет, то создаем
        if(!Global.Block_here)
        {
            br = Instantiate(block_prefab, new Vector3(Random.Range(start_point.x + 1, start_point.x + w - 1), start_point.y, start_point.z), Quaternion.identity) as GameObject;
            Global.Block_here = true;
        }
        // Постоянно выводим счет
        Score_txt.text = "Score: " + Global.Score.ToString();
    }

}

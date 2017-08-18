using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_play_scr : MonoBehaviour
{
    public TextMesh task;
    private int a;
    private int b;
    private int queue_a_b;

	void Start ()
    {

        a = Random.Range(-10, 0); // Зарандомили числа
        b = Random.Range(0, 10);
        Global.Answer = a + b; // Сложили их, чтобы получить ответ(лайт версия)
        queue_a_b = Random.Range(0, 2); // Случайно выбираем одно из 3 уравнений
        //a + b = x
        //x - b = a
        //a - x = -b
        switch (queue_a_b)
        {
            case 0:
                task.text = a.ToString() + " + " + b.ToString() + " = x";
                Global.Switch_task = false;
                break;
            case 1:
                task.text = "x - " + b.ToString() + " = " + a.ToString();
                Global.Switch_task = false;
                break;
            case 2:
                task.text = a.ToString() + " - x = -" + b.ToString();
                Global.Switch_task = false;
                break;
        }

	}
	
	void Update ()
    {
		if(Global.Switch_task)
        {
            a = Random.Range(-10, 0);
            b = Random.Range(0, 10);
            Global.Answer = a + b;
            queue_a_b = Random.Range(0, 2);
            switch (queue_a_b)
            {
                case 0:
                    task.text = a.ToString() + " + " + b.ToString() + " = x";
                    Global.Switch_task = false;
                    break;
                case 1:
                    task.text = "x - " + b.ToString() + " = " + a.ToString();
                    Global.Switch_task = false;
                    break;
                case 2:
                    task.text = a.ToString() + " - x = -" + b.ToString();
                    Global.Switch_task = false;
                    break;
            }
        }
	}
}

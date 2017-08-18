using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт, отвечающий за движение платформы
public class Platform_controller_scr : MonoBehaviour
{
    public GameObject obj;
    public GameObject score_txt;
    public TextMesh Lose_txt;
    private Vector3 Look_target;
    private Vector3 left_border; // Левая граница, за которую платформа не может выходить
    private void Start()
    {
        left_border = Global.start_pos;
    }
    void FixedUpdate()
    {
        Look_target = Camera.main.ScreenToWorldPoint(Input.mousePosition);// Считываем координаты курсора
        if (Global.set_Controller) // Если контроллер мышка(true), то двигаемся до её координат, при этом не выходя за рамки стакана
        {
            if ((Look_target.x < obj.transform.position.x) && (obj.transform.position.x - 0.7 > left_border.x))
                obj.transform.Translate(Vector2.left * 2f * Time.fixedDeltaTime);
            if ((Look_target.x > obj.transform.position.x) && (obj.transform.position.x + 0.7 < left_border.x + Global.width))
                obj.transform.Translate(Vector2.right * 2f * Time.fixedDeltaTime);
        }
        else // Если контроллер клавиатура, то двигаемся по стрелкам, при этом также не выходя за границы стакана
        {
            if (Input.GetKey(KeyCode.LeftArrow) && (obj.transform.position.x - 0.7 > left_border.x))
                obj.transform.Translate(Vector2.left * 2f * Time.fixedDeltaTime);
            if (Input.GetKey(KeyCode.RightArrow) && (obj.transform.position.x + 0.7 < left_border.x + Global.width))
                obj.transform.Translate(Vector2.right * 2f * Time.fixedDeltaTime);
        }
        if (Global.Lose) // При неправильном варианте вы проигрывается и выводится сообщение об этом
        {
            Lose_txt.text = "You lose! \nYour score is: " + Global.Score.ToString();
            Global.Block_here = true;
            score_txt.SetActive(false);
            Destroy(obj.gameObject);
        }
    }
}

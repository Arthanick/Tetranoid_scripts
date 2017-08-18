using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Скрипт-контроллер движения блока.
public class Block_controller_scr : MonoBehaviour
{

    public TextMesh current_num_txt;
    private int current_num;
    private Rigidbody2D rb;
	void Start ()
    {
        // Блок движется за счет компонента RigidBody, под действием силы тяжести.
        rb = GetComponent<Rigidbody2D>();
        current_num = Random.Range(-2, 2) + Global.Answer;// Выводимое число на блоке это сам ответ + разброс(разброс может быть равен 0)
        current_num_txt.text = current_num.ToString(); // Вывод этого значения
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Platform")// Если блок столкнулся с платформой, то происходит проверка выражения
        {
            // Если выражение верное, то удаляем блок, засчитываем очко, разрешаем программе сменить уравнение и увеличиваем сложность
            if (current_num == Global.Answer)
            {
                Destroy(this.gameObject);
                Global.Block_here = false;
                Global.Score++;
                Global.Switch_task = true;
                rb.gravityScale += Global.difficulty;
            }
            else
                Global.Lose = true;
        }
        if(collision.gameObject.name == "Hole")// Если блок попадает в дырку, то он просто уничтожается и вместо него появляется другой
        {
            Destroy(this.gameObject);
            Global.Block_here = false;
        }
    }
}

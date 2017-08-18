using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global
{
    public static int width; // Ширина стакана
    public static int height; // Высота стакана
    public static int Answer; // Ответ на выражение
    public static int Score; // Счет
    public static float difficulty; // Множитель сложности
    public static bool Switch_task;
    public static bool set_Controller; // Выбранный контроллер
    public static bool Lose; // Проигрыш
    public static bool Block_here; // Наличие блока
    public static Vector3 start_pos; // Точка отсчета построения стакана и возникновения блоков
}

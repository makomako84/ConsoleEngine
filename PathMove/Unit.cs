/*
    Некий исполнитель
    Что хочет этот исполнитель?
    Достичь данной ему точки.
    Вернее, исполнитель всего лишь движется.
    Это его компонента - двигаться.
*/

using System.Numerics;
using System.Collections.Generic;

public class Unit
{
    private float speed = 0.1f;
    private Vector2 targetPosition;
    private Vector2 currentPosition;

    /*
        Некоторый источник CurrentPosition
        Не обязательно внутри класса.
    */
    protected Vector2 CurrentPosition
    {
        get => currentPosition;
    }
    
    public void Move()
    {
        if(CurrentPosition == targetPosition)
        {
            targetPosition = GetNext();
        }
        else
        {
            Vector2 dir = currentPosition - targetPosition;
            dir = Vector2.Normalize(dir);
            currentPosition += dir * speed;
        }
        System.Console.WriteLine($"cur: {currentPosition}, targ: {targetPosition}");
    }


    private static int index = 0;
    private static List<Vector2> source = new List<Vector2>()
    {
        new Vector2(0,0),
        new Vector2(1,1),
        new Vector2(1,2)
    };

    private Vector2 GetNext()
    {
        index++;
        return source[index]; 
    }

    
}
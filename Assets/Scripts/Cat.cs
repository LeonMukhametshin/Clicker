using System;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public event Action Down, Up, ClicksChanged;

    private int _clicks;

    public int Clicks => _clicks;

    public void AddClicks(int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));
        
        _clicks += count;
        ClicksChanged?.Invoke();
    }

    private void OnMouseDown()
    {
        Down?.Invoke();
    }

    private void OnMouseUp()
    {
        AddClicks(1);
        Up?.Invoke();
    }
}

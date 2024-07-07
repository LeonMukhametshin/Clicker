using TMPro;
using UnityEngine;

public class CatView : MonoBehaviour
{
    [SerializeField] private Sprite _down, _up;
    [SerializeField] private TextMeshProUGUI _clicksView;
            
    private Cat _cat;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _cat = GetComponent<Cat>(); 
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _cat.Up += OnUp;
        _cat.Down += OnDown;
        _cat.ClicksChanged += OnClicksChanged;
    }

    private void OnDisable()
    {
        _cat.Up -= OnUp;
        _cat.Up -= OnDown;
        _cat.ClicksChanged -= OnClicksChanged;
    }

    private void OnClicksChanged()
    {
        _clicksView.text = _cat.Clicks.ToString();
    }

    private void OnDown()
    {
        _spriteRenderer.sprite = _down;
    }

    private void OnUp()
    {
        _spriteRenderer.sprite = _up;
    }
}

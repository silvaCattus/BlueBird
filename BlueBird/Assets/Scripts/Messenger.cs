using UnityEngine;
using UnityEngine.UI;

public class Messenger : MonoBehaviour
{
    [SerializeField] private Text _message;
    [SerializeField] private float _textColorAlpha;
    private Color _textColor;
    private bool _isDisappearing;

    private void Start()
    {
        _textColor = _message.GetComponent<Text>().color;
        _textColorAlpha = _message.GetComponent<Text>().color.a;
    }

    public void SetMessage(string message)
    {
        _message.text = message;
    }

    private void Update()
    {
        if (_isDisappearing)
            Disappear();
    }

    private void Disappear()
    {
        _textColor.a = Mathf.Lerp(_textColor.a, 0, 0.01f);
    }

    private void OnDisable()
    {
        _textColor.a = _textColorAlpha;
    }
}

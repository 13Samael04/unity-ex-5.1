using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;
    private bool _isEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isEnter = true;
        _signaling.ChangeSignal(_isEnter);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isEnter = false;
        _signaling.ChangeSignal(_isEnter);
    }
}

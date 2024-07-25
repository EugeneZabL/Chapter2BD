using UnityEngine;


[CreateAssetMenu(fileName = "Ghost", menuName = "ScriptableObj/Ghost", order = 51)]
public class GhostType : ScriptableObject
{
    [SerializeField]
    private string _name;

    [SerializeField]
    public float _speed, _delay;

    [SerializeField]
    private Sprite _sprite;



    public string Name => _name;

    public float Speed => _speed;
    public float Delay => _delay;

    public Sprite Sprite => _sprite;

    public void DebugData()
    {
        Debug.Log(_name + " ///  Speed - " + _speed + " Delay - "+_delay);
    }

}

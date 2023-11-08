using UnityEngine;

public class Variable<T> 
    : ScriptableObject
{
    [SerializeField] private T value;

    public T Value => value;
}
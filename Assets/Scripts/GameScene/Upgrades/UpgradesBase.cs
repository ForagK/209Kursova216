using UnityEngine;

public class UpgradesBase : ScriptableObject
{
    public string UpName { get; protected set; }
    public string Description { get; protected set; }
    public float Value { get; protected set; }
    public virtual void Apply() {}
}

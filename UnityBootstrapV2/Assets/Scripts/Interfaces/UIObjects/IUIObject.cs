using UnityEngine;

namespace Assets.Scripts.Interfaces.UIObjects
{
    public interface IUIObject
    {
        // most of the time Main and Container will be different. For example you could have IUIHoverableObject with Main, Hover and Container props
        GameObject Main { get; }
        GameObject Container { get; }
    }
}

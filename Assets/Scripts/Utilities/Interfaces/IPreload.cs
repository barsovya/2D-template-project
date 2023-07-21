using System.Threading.Tasks;
using UnityEngine;

[SerializeField]
public interface IPreload
{
    public Task Preload();
}

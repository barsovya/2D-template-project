using System.Threading.Tasks;
using UnityEngine;

[SerializeField]
public interface ICleanUp
{
    public Task CleanUp();
}

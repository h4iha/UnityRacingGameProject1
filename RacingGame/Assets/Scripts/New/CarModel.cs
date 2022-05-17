using UnityEngine;

public class CarModel : MonoBehaviour
{
    [SerializeField] private GameObject[] carModels;

    [SerializeField] private float px;
    [SerializeField] private float py;
    [SerializeField] private float pz;

    [SerializeField] private float rx;
    [SerializeField] private float ry;
    [SerializeField] private float rz;

    private void Awake()
    {
        ChooseCarModel(SaveManager.instance.currentCarIndex);
    }
    private void ChooseCarModel(int _index)
    {
        //Instantiate(carModels[_index], transform.position, Quaternion.identity, transform);
        Instantiate(carModels[_index], new Vector3(px, py, pz), Quaternion.Euler(rx, ry, rz), transform);
    }
}

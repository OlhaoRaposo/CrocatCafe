using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MyGrid : MonoBehaviour
{
    public MyCell cellBase;
    public int sizeX, sizeZ;
    public GameObject obj;
    public LayerMask mask;

    void Start()
    {
        for (int z = 0; z < sizeZ; z++){
            for (int x = 0; x < sizeX; x++){
                Vector3 pos = transform.position + new Vector3(x, 0, z);
                MyCell cell = Instantiate<MyCell>(cellBase, pos, transform.rotation);
                cell.transform.SetParent(transform);
                cell.SetCellFree(true);
            }
        }
    }

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, mask)){
            obj.transform.position = transform.position + GetGridPosition(hit.point);
        }

        if (Input.GetMouseButtonDown(1)){
            obj.transform.rotation *= Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetMouseButtonDown(0)){
            InsertObject();
        }
    }

    void InsertObject(){
        Collider[] cols = Physics.OverlapBox(obj.transform.position, getRotationScale(obj.transform)*0.5f);
        if (CheckFree(cols)){
            Instantiate(obj, obj.transform.position, obj.transform.rotation);
            FillCells(cols);
        }
    }

    Vector3 GetGridPosition(Vector3 p){
        return new Vector3(Mathf.Floor(p.x)+0.5f, p.y, Mathf.Floor(p.z)+0.5f);
    }

    Vector3 getRotationScale(Transform t){
        Vector3 s = t.localScale;
        Matrix4x4 m = Matrix4x4.Rotate(t.rotation);
        s = m.MultiplyPoint3x4(s);
        return new Vector3(Mathf.Abs(s.x), Mathf.Abs(s.y), Mathf.Abs(s.z));
    }

    bool CheckFree(Collider[] col){
        foreach(Collider c in col){
            if (c.transform.parent.TryGetComponent<MyCell>(out MyCell cell)){
                if (!cell.IsFree()) {
                    Debug.Log("Not free: " + cell.gameObject.name);
                    return false;
                }
            }
        }
        Debug.Log("Cells free");
        return true;
    }

    void FillCells(Collider[] col){
        foreach(Collider c in col){
            if (c.transform.parent.TryGetComponent<MyCell>(out MyCell cell)){
                cell.SetCellFree(false);
            }
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(obj.transform.position, getRotationScale(obj.transform));
    }
}

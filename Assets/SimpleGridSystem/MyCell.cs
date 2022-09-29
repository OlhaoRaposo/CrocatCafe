using UnityEngine;

public class MyCell : MonoBehaviour {
    
    bool isFree;
    public MeshRenderer render;
    
    public void SetCellFree(bool b){
        isFree = b;
        if (isFree){
            render.material.color = Color.gray;
        } else {
            render.material.color = Color.red;
        }
    }

    public bool IsFree(){
        return isFree;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {

	public GameObject preObj;       //預製物件
	private Queue<GameObject> pool = new Queue<GameObject>();

	// Use this for initialization
	void Start()
	{
		creatObj(20);
	}

	//產生物件池中的物件
	private void creatObj(int poolSize = 5)
	{
		for (int i = 0; i < poolSize; i++)
		{
			GameObject _obj;
			_obj = Instantiate(preObj);
			_obj.SetActive(false);
			_obj.transform.SetParent(transform, false);
			pool.Enqueue(_obj);
		}
	}

	//取出物件
	public void reuse(Vector3 iniPosition)
	{
		if (pool.Count == 0)
			creatObj();
		GameObject _reuse = pool.Dequeue();
		_reuse.transform.position = iniPosition;    //定義物件位置
		_reuse.SetActive(true);                         //顯示物件 
	}

	//回收物件，使用下方註解回收物件
	//GameObject.Find("掛載ObjPool的物件名稱").GetComponent<ObjPool>().recovery(gameObject);
	public void recovery(GameObject reObj)   //回收物件
	{
		pool.Enqueue(reObj);
		reObj.SetActive(false);
	}
}

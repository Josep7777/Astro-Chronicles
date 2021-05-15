using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Muerte : MonoBehaviour
{
	public Button yourButton;

	void Start()
	{
		
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		VariablesController.Muerto = true;
		if(VariablesController.Nivel2) SceneManager.LoadScene("Nivel2");
		else SceneManager.LoadScene("NIvel1");
	}
}
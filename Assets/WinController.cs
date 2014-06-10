using UnityEngine;
using System.Collections;

public class WinController : MonoBehaviour {
	private int 	activeCoffee;
	public 	string 	nextLevel;

	public void AddCoffee() {
		activeCoffee++;
	}

	public void SubCoffee() {
		activeCoffee--;
		if (activeCoffee <= 0) {
			Win ();
		}
	}

	void Win() {
		Application.LoadLevel (nextLevel);
	}
}

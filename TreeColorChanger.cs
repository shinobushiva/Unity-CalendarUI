using UnityEngine;
using System.Collections;

public class TreeColorChanger : MonoBehaviour {

	public bool noLeaves = false;

	public Color[] colors;// = {Color.red, Color.red, Color.yellow};

	public Tree[] trees;
	private Shader transShader;
	private Color trans;
	private bool changeColor;

	// Use this for initialization
	void Start () {
		transShader = Shader.Find ("Transparent/Cutout/Diffuse");
		trans = new Color (0, 0, 0, 0);

		trees = FindObjectsOfType<Tree> ();
	}

	private void UpdateTrees(){
		
		foreach (Tree t in trees) {
			Material[] mats = t.GetComponent<Renderer> ().materials;
			Color c = colors[Random.Range(0, colors.Length)];
			foreach (Material mat in mats) {
				if (mat.name.ToLower ().Contains ("leaf")) {
					if (!noLeaves) {
						if (changeColor) {
							mat.color = c;
						} else {
							mat.color = Color.white;
						}
					} else {
						mat.color = trans;
						mat.shader = transShader;
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetNoLeaves(bool b){
		noLeaves = b;
		UpdateTrees ();
	}

	public void SetLeavesRed(bool b){
		changeColor = b;
		UpdateTrees ();
	}

}

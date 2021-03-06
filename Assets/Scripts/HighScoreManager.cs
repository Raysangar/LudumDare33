﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HighScoreManager{
	
	public void SaveScore(float score){
		List<float> highScores = LoadAllScores ();
		string temp="";
		highScores.Add (score);
		for(int i=0;i< highScores.Count;i++) { 
			if(i!=highScores.Count-1){ 
				temp+=highScores[i].ToString()+"*";//note that the last character you add //is important 
			}
			else{ 
				temp+=highScores[i].ToString(); 
			}
		}
		PlayerPrefs.SetString ("HighScores", temp);
	}

	public List<float> LoadAllScores(){
		List<float> highScores = new List<float>();
		string temp=PlayerPrefs.GetString("HighScores",null); 
		if (temp != null && temp != "") {
			string[] tempArray=temp.Split("*".ToCharArray());

			for(int i=0;i<tempArray.Length;i++) { 
				highScores.Add(float.Parse(tempArray[i])); 
			}
		}
		return highScores;
	}
}

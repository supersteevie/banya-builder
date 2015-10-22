using UnityEngine;
using System.Collections;

public class BuildingAI : MonoBehaviour {

	public int Id;
	
	public string Name;
	public string Description;
	public BuildingTypes buildingType;
	public int auraAWE;
	public int auraACH;
	public int auraTHG;
	public int costPerSquare;

	public void SetStats(string name)
	{
		Id = BuildingBase.Get (name).Id;
		Name = name;
		Description = BuildingBase.Get (name).Description;
		auraAWE = BuildingBase.Get (name).auraAWE;
		auraACH = BuildingBase.Get (name).auraACH;
		auraTHG = BuildingBase.Get (name).auraTHG;
		buildingType = BuildingBase.Get (name).buildingType;
		costPerSquare = BuildingBase.Get (name).costPerSquare;
	}

	public int GetAuraAWE()
	{
		return auraAWE;
	}
	public int GetAuraACH()
	{
		return auraACH;
	}
	public int GetAuraTHG()
	{
		return auraTHG;
	}
}

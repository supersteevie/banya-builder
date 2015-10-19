using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//Building Type and its varibles
public class BuildingType
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
		public BuildingTypes buildingType { get; set; } 
        public int auraAWE { get; set; }
		public int auraACH { get; set; }
		public int auraFUN { get; set; }
		public int auraHGR { get; set; }
		public int auraTRF { get; set; }
		public int auraTHG { get; set; }

		public GameObject BasePrefab {get; set;}
		public GameObject TransPrefab {get; set;}

		public Texture2D Icon {get; set;}
   
 	}

public enum BuildingTypes
{
	None,
	Body,
	Spirit,
	Mind,
}
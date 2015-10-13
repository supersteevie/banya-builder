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
        public int IncreaseAWE { get; set; }
		public int IncreaseACH { get; set; }
		public int IncreaseFUN { get; set; }
		public int IncreaseHGR { get; set; }
		public int IncreaseTRF { get; set; }
		public int IncreaseTHG { get; set;}

        public bool IsMaleOnly { get; set; }
        public bool IsSlidingDoor { get; set; }

		public int Width { get; set; }
		public int Length { get; set; }

		public GameObject BasePrefab {get; set;}
		public GameObject TransPrefab {get; set;}

		public Texture2D Icon {get; set;}
   
 	}
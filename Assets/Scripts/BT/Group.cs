using UnityEngine;
using System.Collections;

namespace AI
{
	public class Group : Node 
	{
		[SerializeField]
		protected Node[] children;

		public override void Execute ()
		{
			foreach (Node child in children) {
               
                child.Execute ();
			}
		}
	}
}
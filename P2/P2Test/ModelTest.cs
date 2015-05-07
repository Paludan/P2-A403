using System;
using P2;
using NUnit.Framework;

namespace P2Test
{
	public class ModelTest
	{
		[Test]
		public void TestUpdate_Hydrogen10000Nitrogen10000Temp750WithCatalyst1Second_GeneratesAmmonia()
		{
			//Arrange
			DataPoint start = new DataPoint (0, 10000, 10000, 750, 0, true);
			P2.AmmoniaModel m = new AmmoniaModel (start);

			//Act
			DataPoint update = m.Update (1);

			//Assert
			Assert.IsTrue (update.nAmmonia > start.nAmmonia);
		}

		[Test]
		public void TestUpdate_Ammonia10000Temp750WithCatalyst1Second_GeneratesNitrogenHydrogenConsumesAmmonia()
		{
			//Arrange
			DataPoint start = new DataPoint (10000, 0, 0, 750, 0, true);
			P2.AmmoniaModel m = new AmmoniaModel (start);

			//Act
			DataPoint update = m.Update (1);

			//Assert
			Assert.IsTrue ((update.nAmmonia < start.nAmmonia) && (update.nHydrogen > start.nHydrogen) && (update.nNitrogen > start.nNitrogen));
		}

		[Test]
		public void TestUpdate_Ammonia30000Hydrogen30000Nitrogen30000Temp750WithCatalyst1Second_GenerateAmmonia()
		{
			//Arrange
			DataPoint start = new DataPoint (30000, 30000, 30000, 750, 0, true);
			P2.AmmoniaModel m = new AmmoniaModel (start);

			//Act
			DataPoint update = m.Update (1);

			//Assert
			Assert.IsTrue ((update.nAmmonia > start.nAmmonia) && (update.nHydrogen < start.nHydrogen) && (update.nNitrogen < start.nNitrogen));
		}

		/* Mængden af ammoniak påvirker ikke reaktionen fra ammoniak mod reaktanterne, fordi der er
		 * en 0 ordens reaktion.
		 * Mængden af nitrogen påvirker reaktionen fra reaktanterne mod ammoniak, fordi det er 
		 * en 1 ordens reaktion.
		 */
		[Test]
		public void TestUpdate_Ammonia2000Hydrogen2000Nitrogen2000Temp750WithCatalyst1Second_GenerateAmmonia()
		{
			//Arrange
			DataPoint start = new DataPoint (2000, 2000, 2000, 750, 0, true);
			P2.AmmoniaModel m = new AmmoniaModel (start);

			//Act
			DataPoint update = m.Update (1);

			//Assert
			Assert.IsTrue ((update.nAmmonia < start.nAmmonia) && (update.nHydrogen > start.nHydrogen) && (update.nNitrogen > start.nNitrogen));
		}
	}
}


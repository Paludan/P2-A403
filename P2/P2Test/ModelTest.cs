using System;
using P2;
using NUnit.Framework;
using System.Collections.Generic;

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
			Assert.IsTrue ((update.nAmmonia > start.nAmmonia) && (update.nNitrogen < start.nNitrogen) && (update.nHydrogen < start.nHydrogen));
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
		public void TestUpdate_NoNitrogenNoAmmoniaTemp750WithCatalystNoProgress()
		{
			//Arrange
			DataPoint start = new DataPoint (0, 10000, 0, 750, 0, true);
			P2.AmmoniaModel m = new AmmoniaModel (start);

			//Act
			DataPoint update = m.Update (1);

			//Assert
			Assert.IsTrue ((update.nAmmonia == start.nAmmonia) && (update.nHydrogen == start.nHydrogen) && (update.nNitrogen == start.nNitrogen));
		}

		[Test]
		public void TestUpdate_NoHydrogenNoAmmoniaTemp750WithCatalystNoProgress()
		{
			//Arrange
			DataPoint start = new DataPoint (0, 0, 10000, 750, 0, true);
			P2.AmmoniaModel m = new AmmoniaModel (start);

			//Act
			DataPoint update = m.Update (1);

			//Assert
			Assert.IsTrue ((update.nAmmonia == start.nAmmonia) && (update.nHydrogen == start.nHydrogen) && (update.nNitrogen == start.nNitrogen));
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

        [Test]
        public void TestLoadingFromFile()
        {
            //Arrange
            DataPoint start = new DataPoint(0, 0, 0, 0, 0, true);
            P2.AmmoniaModel m = new AmmoniaModel (start);

            //Act
            List<DataPoint> update = SaveLoadTools.load("SaveData1.eqsave");

            //Assert
            Assert.IsTrue((update[update.Count - 1]).nAmmonia > start.nAmmonia && (update[update.Count - 1]).nHydrogen > start.nHydrogen && (update[update.Count - 1]).nNitrogen > start.nNitrogen);
        }
        [Test]
        public void TestSavingToFile()
        {
            //Arrange
            List<DataPoint> start = new List<DataPoint>();
            start.Add(new DataPoint(1, 2, 3, 4, 5, true));
            
            //Act
            SaveLoadTools.save(start);
            List<DataPoint> update = SaveLoadTools.load("SaveData2.eqsave");

            //Assert
            Assert.IsTrue (start[0].nAmmonia == update[0].nAmmonia && start[0].nHydrogen == update[0].nHydrogen && start[0].nNitrogen == update[0].nNitrogen);
            
        }
        [Test]
        public void TestDataHandlerAddDataPoint()
        {
            //Arrange
            DataHandler dh = new DataHandler();
            DataPoint start = new DataPoint(1, 2, 3, 4, 5, true);

            //Act
            dh.addDataPoint(start);
            dh.addDataPoint(new DataPoint(5, 4, 3, 2, 1, false));

            //Assert
            Assert.IsTrue(dh.SimulationData[0].Equals(start) && !dh.SimulationData[1].Equals(start));
        }
	}
}


using System;
using P2;
using NUnit.Framework;

namespace P2Test
{
	public class ModelTest
	{
		[Test]
		public void TestUpdate_Hydrogen100Nitrogen100Temp500WithCatalyst1Second_GeneratesAmmonia(){
			//Arrange
			DataPoint start = new DataPoint (0, 100, 100, 500, 0, true);
			P2.AmmoniaModel m = new AmmoniaModel (start);

			//Act
			DataPoint update = m.Update (1);

			//Assert
			Assert.IsTrue (update.nAmmonia > start.nAmmonia);
		}

		[Test]
		public void TestUpdate_Hydrogen100Nitrogen100Temp500WithCatalyst1Second_ConsumesHydrogen(){
			//Arrange
			DataPoint start = new DataPoint (0, 100, 100, 500, 0, true);
			P2.AmmoniaModel m = new AmmoniaModel (start);

			//Act
			DataPoint update = m.Update (1);

			//Assert
			Assert.IsTrue (update.nHydrogen < start.nHydrogen);
		}

		[Test]
		public void TestUpdate_Hydrogen100Nitrogen100Temp500WithCatalyst1Second_ConsumesNitrogen(){
			//Arrange
			DataPoint start = new DataPoint (0, 100, 100, 500, 0, true);
			P2.AmmoniaModel m = new AmmoniaModel (start);

			//Act
			DataPoint update = m.Update (1);

			//Assert
			Assert.IsTrue (update.nNitrogen < start.nNitrogen);
		}

		[Test]
		public void TestUpdate_200Ammonia0Hydrogen0Nitrogen500TempWithCatalyst1Second_ConsumesAmmonia(){
			//Arrange
			DataPoint start = new DataPoint (200, 0, 0, 500, 0, true);
			P2.AmmoniaModel m = new AmmoniaModel (start);

			//Act
			DataPoint update = m.Update (1);

			//Assert
			Assert.IsTrue (update.nAmmonia < start.nAmmonia, string.Format("Updated to: {0}, started at: {1}", update.nHydrogen, start.nHydrogen));
		}

		[Test]
		public void TestUpdate_200Ammonia0Hyd0Nit500TempWithCatalyst1Second_GeneratesHydrogen(){
			//Arrange
			DataPoint start = new DataPoint (200, 0, 0, 500, 0, true);
			P2.AmmoniaModel m = new AmmoniaModel (start);

			//Act
			DataPoint update = m.Update (1);

			//Assert
			Assert.IsTrue (update.nHydrogen > start.nHydrogen, string.Format("Updated to: {0}, started at: {1}", update.nHydrogen, start.nHydrogen));
		}

		[Test]
		public void TestUpdate_200Ammonia0Hyd0Nit500TempWithCatalyst1Second_GeneratesNitrogen(){
			//Arrange
			DataPoint start = new DataPoint (200, 0, 0, 500, 0, true);
			P2.AmmoniaModel m = new AmmoniaModel (start);

			//Act
			DataPoint update = m.Update (1);

			//Assert
			Assert.IsTrue (update.nNitrogen > start.nNitrogen, string.Format("Updated to: {0}, started at: {1}", update.nHydrogen, start.nHydrogen));
		}

		[Test]
		public void TestFetch_DataPoint_ReturnsSame(){
			//Arrange
			DataPoint start = new DataPoint (100, 100, 200, 500, 0, true);
			P2.AmmoniaModel m = new AmmoniaModel (start);

			//Act & Assert
			Assert.AreEqual (start, m.Fetch ());
		}

		[Test]
		public void TestUpdate_100Nitrogen0Hydrogen0Ammonia_NoReaction(){
			//Arrange
			DataPoint start = new DataPoint (0, 0, 100, 500, 0, true);
			AmmoniaModel m = new AmmoniaModel (start);

			//Act
			DataPoint update = m.Update (1);

			//Assert
			bool s1 = (start.nAmmonia == update.nAmmonia);
			bool s2 = (start.nHydrogen == update.nHydrogen);
			bool s3 = (start.nNitrogen == update.nNitrogen);

			string mes = string.Format ("   Start:           Slut:\nAmm: {0}       {1}\nHyd:   {2}        {3}\nNit:  {4}       {5}", start.nAmmonia, update.nAmmonia, start.nHydrogen, update.nHydrogen, start.nNitrogen, update.nNitrogen);

			Assert.IsTrue (s1 && s2 && s3, mes);
		}
	}
}


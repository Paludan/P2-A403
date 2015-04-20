using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2
{
	public struct CalculationData
	{
		private double _equiConst, _activationEnergy, _reactionRateConst;


		public CalculationData (double equibriConst, double activationE, double reactRateConst)
		{
			this._equiConst = equibriConst;
			this._activationEnergy = activationE;
			this._reactionRateConst = reactRateConst;
		}

		public double equiConst
		{
			get {
				return _equiConst;
			}
		}

		public double activationEnergy
		{
			get {
				return _activationEnergy;
			}
		}

		public double reactionRateConst
		{
			get {
				return _reactionRateConst;
			}
		}
	}
}


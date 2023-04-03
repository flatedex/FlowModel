using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FlowModel
{
    internal class Calculations
    {
        readonly double _R = 8.314; // J/(mole*K) - universal gas constant

        // parameters given in SI
        readonly double _W = 0.13; // Width of canal
        readonly double _H = 0.008; // Height of canal
        readonly double _L = 4.5; // Length of canal

        readonly double _p = 830; // density
        readonly double _c = 2900; // cpecific heat capasity

        readonly double _T0 = 120; // temperature of melting
        readonly double _Vu = 0.9; // velocity of cap
        readonly double _Tu = 160; // temperature of cap

        readonly double _mu0 = 50000; //
        readonly double _Ea = 42000; //
        readonly double _Tr = 130; // temperature of Casper
        readonly double _n = 0.37; // index of material flow
        readonly double _alphaU = 500; // coefficient of heat transfer between cap & material

        private double _T;

        public Calculations(double T)
        {
            _T = T;
        }
        public Calculations(double T, double width, double height, double length)
        { 
            _T = T;
            _W = width;
            _H = height;
            _L = length;
        }

        public double CoefficientOfConsistensy()
        {
            return _mu0*Math.Pow(Math.E,-((_Ea)/(_R*(_T0+20+273)*(_Tr+273)*(_T - _Tr))));
        }
        public double Viscosity()
        {
            return CoefficientOfConsistensy() * Math.Pow(Gamma(_Vu, _H), _n-1);
        }
        private double Gamma(double Vu, double H) { return Vu / H; }

    }
}

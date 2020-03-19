using System;

namespace Programowanie
{
    public class Part
    {
        public int ID_os            { get; set; }
        public string IMIĘ_os       { get; set; }
        public string NAZWISKO_os   { get; set; }
        public int WIEK_os          { get; set; }

        public override string ToString()
        {
            return String.Format("| {0,2} | {1,10} | {2,10} | {3,3} |", (ID_os + "."), IMIĘ_os, NAZWISKO_os, WIEK_os);
        }
    }

}

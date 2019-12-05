using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolinomTask {
    
    class Polinom {
        private int[] odds;
        private int power;

        public int[] Odds {
            get { return this.odds; }
        }

        public int Power {
            get { return this.power; }
        }


        public int this[int i] {
            set {
                if (i > 0 && i < odds.Length)
                    odds[i] = value;
                else throw new IndexOutOfRangeException();
            }
            get {
                if (i > 0 && i < odds.Length)
                    return odds[i];
                else throw new IndexOutOfRangeException();
            }
        }

        public Polinom(int power) {
            this.power = power;
            this.odds = new int[power + 1];
        }

        public Polinom(params int[] ods) {
            power = ods.Length - 1;
            this.odds = new int[ods.Length];
            for (int i = 0; i < ods.Length; i++) {
                this.odds[i] = ods[i];
            }
            
        }

        public void printPolinom() {
            Console.WriteLine();
            for(int i = 0; i < odds.Length; i++) {
                if (i == 0 && odds[i] != 0)
                    Console.Write(odds[i]);
                else if(odds[i] != 0)
                    Console.Write(" + " + odds[i] + "x^" + i + " ");
            }
            Console.WriteLine();
        }

        public static Polinom operator+(Polinom first, Polinom second) {
            if (first.Power > second.Power) {
                Polinom resPolinom = new Polinom(first.Power);
                for (int i = 0; i < first.Odds.Length; i++) {
                    if (i < second.Odds.Length)
                        resPolinom.Odds[i] = first.Odds[i] + second.Odds[i];
                    else resPolinom.Odds[i] = first.Odds[i];
                }
                return resPolinom;
            } else {
                Polinom resPolinom = new Polinom(second.Power);
                for (int i = 0; i < second.Odds.Length; i++) {
                    if (i < first.Odds.Length)
                        resPolinom.Odds[i] = first.Odds[i] + second.Odds[i];
                    else resPolinom.Odds[i] = second.Odds[i];
                }
                return resPolinom;
            }
            
        }

        public static Polinom operator-(Polinom first, Polinom second) {
            if (first.Power > second.Power) {
                Polinom resPolinom = new Polinom(first.Power);
                for (int i = 0; i < first.Odds.Length; i++) {
                    if (i < second.Odds.Length)
                        resPolinom.Odds[i] = first.Odds[i] - second.Odds[i];
                    else resPolinom.Odds[i] = first.Odds[i];
                }
                return resPolinom;
            }
            else {
                Polinom resPolinom = new Polinom(second.Power);
                for (int i = 0; i < second.Odds.Length; i++) {
                    if (i < first.Odds.Length)
                        resPolinom.Odds[i] = first.Odds[i] - second.Odds[i];
                    else resPolinom.Odds[i] = second.Odds[i];
                }
                return resPolinom;
            }
        }

        public static Polinom operator*(Polinom polinom, int num) {
            Polinom resPolinom = new Polinom(polinom.Odds);
            for (int i = 0; i < polinom.Odds.Length; i++) {
                resPolinom.Odds[i] = polinom.Odds[i] * num;
            }
            return resPolinom;
        }

        public static Polinom operator*(Polinom first, Polinom second) {
            Polinom resPolinom = new Polinom(first.Power + second.Power);
            for (int i = 0; i < first.Odds.Length; i++) {
                for (int j = 0; j < second.Odds.Length; j++) {
                    resPolinom.Odds[i + j] += first.Odds[i] * second.Odds[j];
                }
            }
            return resPolinom;
        }
    }
}

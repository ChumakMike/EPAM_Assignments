using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prak2_Console {

    public class Student : IComparable {
        private string name;
        private string surname;
        private string testName;
        private int testResult;

        public Student(string name, string surname, string testName, int testRes) {
            this.name = name;
            this.surname = surname;
            this.testName = testName;
            this.testResult = testRes;
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string Surname {
            get { return surname; }
            set { surname = value; }
        }

        public string TestName {
            get { return testName; }
            set { testName = value; }
        }

        public int TestResult {
            get { return testResult; }
            set {
                if (value > 100 || value < 0)
                    throw new StudentTestException("Uncorrect test result! Check if this less then 100 and more than 0");
                else testResult = value;
            }
        }

        public void Print() {
            Console.WriteLine($"Student [{name}] has passed test [{testName}] on mark : [{testResult}]");
        }

        public int CompareTo(object o) {
            Student incomeSt = (Student) o;
            int comparisson = testResult.CompareTo(incomeSt.TestResult);
            if(comparisson == 0) {
                comparisson = surname.CompareTo(incomeSt.Surname);
                if (comparisson == 0)
                    comparisson = name.CompareTo(incomeSt.Name);
            }
            return comparisson;
        }
    }
}

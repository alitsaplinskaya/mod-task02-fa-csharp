using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans {
    public class State {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }


    public class FA1 {
        public static State a = new State() {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State() {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State() {
            Name = "c",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State d = new State() {
            Name = "d",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public State e = new State() {
            Name = "e",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State f = new State() {
            Name = "f",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        State InitialState = a;

        public FA1() {
            a.Transitions['0'] = b;
            a.Transitions['1'] = c;
            b.Transitions['1'] = d;
            b.Transitions['0'] = e;
            c.Transitions['0'] = d;
            c.Transitions['1'] = c;
            d.Transitions['0'] = e;
            d.Transitions['1'] = d;
            e.Transitions['1'] = e;
            e.Transitions['0'] = f;
            f.Transitions['1'] = f;
            f.Transitions['0'] = e;
        }

        public bool? Run(IEnumerable<char> s) {
            State current = InitialState;
            foreach (var c in s) {
                current = current.Transitions[c];
                if (current == null)
                    return null;

            }
            return current.IsAcceptState;
        }
    }

    public class FA2 {
        public static State a = new State() {
            Name = "a",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State() {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State() {
            Name = "c",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State d = new State() {
            Name = "d",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        State InitialState = a;

        public FA2() {
            a.Transitions['0'] = b;
            a.Transitions['1'] = c;
            b.Transitions['0'] = a;
            b.Transitions['1'] = d;
            c.Transitions['0'] = d;
            c.Transitions['1'] = a;
            d.Transitions['0'] = c;
            d.Transitions['1'] = b;
        }

        public bool? Run(IEnumerable<char> s) {
            State current = InitialState;
            foreach (var c in s) {
                current = current.Transitions[c];
                if (current == null)
                    return null;

            }
            return current.IsAcceptState;
        }
    }

    class Program {
        static void Main(string[] args) {
            String s = "01111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
        }
    }
}
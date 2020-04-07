namespace Entanglement {

    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Intrinsic;
    

    operation Entanglement() : (Result, Result) {
        mutable s1 = Zero;
        mutable s2 = Zero;
        using ((q1, q2) = (Qubit(), Qubit())) {
            H(q1);
            CNOT(q1, q2);
            set s1 = M(q1);
            set s2 = M(q2);
            ResetAll([q1, q2]);
        }
        return (s1, s2);
    }
}


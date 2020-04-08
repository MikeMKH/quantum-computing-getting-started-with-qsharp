namespace Teleportation {
    
    open Microsoft.Quantum.Arrays;
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Diagnostics;
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Logical;

    operation Teleportation (sentMessage : Bool) : Bool {
        mutable recievedMessage = false;
        using (register = Qubit[3]) {
            let message = register[0];
            
            if (sentMessage) {
                X(message);
            }
            
            let a = register[1];
            let b = register[2];
            
            H(a);
            CNOT(a, b);
            
            CNOT(message, a);
            H(message);
            
            let messageState = M(message);
            let aState = M(a);
            
            if (messageState == One) {
                Z(b);
            }
            
            if (aState == One) {
                X(b);
            }
            
            if (M(b) == One) {
                set recievedMessage = true;
            } else {
                set recievedMessage = false;
            }
            
            ResetAll(register);
        }
        
        return recievedMessage;
    }

    @Test("QuantumSimulator")
    operation GivenFalseItMustTeleportFalse () : Unit {
        let message = Teleportation(false);
        
        Fact(message == false, "Teleportation did not return false");
    }

    @Test("QuantumSimulator")
    operation GivenTrueItMustTeleportTrue () : Unit {
        let message = Teleportation(true);
        
        Fact(message == true, "Teleportation did not return true");
    }

    @Test("QuantumSimulator")
    operation GivenSequenceOfValuesItMustTeleportSequenceOfValues () : Unit {
        let values = [true, false, false, true, true, false];
        let results = ForEach(Teleportation, values);
        
        Fact(EqualA(EqualB, values, results), "Teleportation did not return same value");
    }
}
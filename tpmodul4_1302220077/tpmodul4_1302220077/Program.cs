public class KodePos {
    public enum Kelurahan{ Batununggal, Kujangsari, Mengger, Wates, Cijaura, Jatisari, Margasari, Sekejati, Kebonwaru, Maleer, Samoja}
    public static int GetKodePos(Kelurahan poscode)
    {
        int[] kodeposkelurahan = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273 };

        return kodeposkelurahan[(int)poscode];
    }
}


public class DoorMachine
{
    private DoorState currentState;

    public DoorMachine()
    {

        currentState = new LockedState(this);
    }

    public void SetState(DoorState state)
    {
        currentState = state;
    }

    public void ChangeState()
    {
        currentState.ChangeState();
    }

    public abstract class DoorState
    {
        protected DoorMachine doorMachine;

        public DoorState(DoorMachine doorMachine)
        {
            this.doorMachine = doorMachine;
        }

        public abstract void ChangeState();
    }

    public class LockedState : DoorState
    {
        public LockedState(DoorMachine doorMachine) : base(doorMachine) { }

        public override void ChangeState()
        {
            Console.WriteLine("Pintu terkunci");
            doorMachine.SetState(new UnlockedState(doorMachine));
        }
    }

    public class UnlockedState : DoorState
    {
        public UnlockedState(DoorMachine doorMachine) : base(doorMachine) { }

        public override void ChangeState()
        {
            Console.WriteLine("Pintu tidak terkunci");
            doorMachine.SetState(new LockedState(doorMachine));
        }
    }
}



public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Masukkan nama kelurahan:");
        string inputKelurahan = Console.ReadLine();

        KodePos.Kelurahan kelurahan;
        if (Enum.TryParse(inputKelurahan, true, out kelurahan))
        {
            int kodePos = KodePos.GetKodePos(kelurahan);
            Console.WriteLine($"Kode Pos untuk kelurahan {kelurahan} adalah {kodePos}");
        }
        else
        {
            Console.WriteLine("Kelurahan tidak valid.");

        }

        DoorMachine doorMachine = new DoorMachine();
        doorMachine.ChangeState(); 
        doorMachine.ChangeState(); 

    }
}


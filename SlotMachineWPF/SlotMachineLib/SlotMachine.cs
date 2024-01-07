using System;

public class SlotMachine
{
    public int Balance { get; set; }
    public int LastWin { get; set; }
    public char Rell1 { get; set; }
    public char Rell2 { get; set; }
    public char Rell3 { get; set; }

    private const int JackpotValue = 100;
    private const int HardWinValue = 50;

    public SlotMachine()
    {
        Reset();
    }

    public void SpinSlotMachine(bool lock1 = false, bool lock2 = false, bool lock3 = false)
    {
        CheckBalance();

        Balance--;

        Random r = new Random();

        Rell1 = !lock1 ? (char)r.Next('A', 'Z' + 1) : Rell1;
        Rell2 = !lock2 ? (char)r.Next('A', 'Z' + 1) : Rell2;
        Rell3 = !lock3 ? (char)r.Next('A', 'Z' + 1) : Rell3;

        EvaluateResult();
    }

    private void CheckBalance()
    {
        if (Balance == 0)
            throw new InvalidOperationException("Hai finito il credito a disposizione.");
    }

    private void EvaluateResult()
    {
        if (Jackpot())
            AddWin(JackpotValue);
        else if (HardWin())
            AddWin(HardWinValue);
        else if (SimpleWin())
            AddWin((int)Rell1 - 'A' + 1);
        else if (NoLost())
            AddWin(1);
        else
            LastWin = 0;
    }

    private void Reset()
    {
        Balance = 10;
        LastWin = 0;
        Rell1 = Rell2 = Rell3 = 'A';
    }

    private bool Jackpot()
    {
        return (Rell1 == 'Z' && Rell2 == 'Z' && Rell3 == 'Z');
    }

    private bool HardWin()
    {
        return (Rell2 == Rell1 + 1 && Rell3 == Rell2 + 1);
    }

    private bool SimpleWin()
    {
        return (Rell1 == Rell2 && Rell2 == Rell3);
    }

    private bool NoLost()
    {
        return (Rell1 == Rell2 || Rell2 == Rell3 || Rell3 == Rell1);
    }

    private void AddWin(int win)
    {
        Balance += win;
        LastWin = win;
    }
}

public class Program
{
    static void Main()
    {
        SlotMachine slotMachine = new SlotMachine();

        try
        {
            slotMachine.SpinSlotMachine();
            Console.WriteLine($"Balance: {slotMachine.Balance}, Last Win: {slotMachine.LastWin}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}


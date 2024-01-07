using System;
using SlotMachineWPF;
using Figgle;

internal partial class Program
{
    private readonly SlotMachine _slotMachine = new();
    private int _count1 = 0;
    private int _count2 = 0;
    private int _count3 = 0;
    private bool _rell1 = false;
    private bool _rell3 = false;
    private bool _rell2 = false;

    private static void Main()
    {
        Program program = new();
        program.RunMainProgram();
    }

    private void RunMainProgram()
    {
        bool showMenu = true;

        Console.WriteLine(FiggleFonts.Standard.Render("SlotMachine"));

        while (showMenu)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(FiggleFonts.Standard.Render($"\t {_slotMachine.Rell1} | {_slotMachine.Rell2} | {_slotMachine.Rell3}"));
            Console.ResetColor();

            Console.WriteLine($"\t Credito rimasto {_slotMachine.Balance}");
            Console.WriteLine($"\t Ultima vincita {_slotMachine.LastWin}");
            Console.WriteLine();

            Console.WriteLine("1- Gira la Ruota");
            Console.WriteLine("2- Blocca la prima lettera");
            Console.WriteLine("3- Blocca la seconda lettera");
            Console.WriteLine("4- Blocca la terza lettera");
            Console.WriteLine();

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    try
                    {
                        _slotMachine.SpinSlotMachine(_rell1, _rell2, _rell3);
                        CheckBlockCounters();
                        Console.Clear();
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Vuoi ricominciare da capo? (y / n)");

                    RepeatChoice:
                        switch (Console.ReadKey().KeyChar)
                        {
                            case 'y':
                                _slotMachine = new SlotMachine();
                                break;

                            case 'n':
                                Console.Clear();
                                Console.WriteLine(FiggleFonts.Standard.Render("Arrivederci"));
                                Console.ReadKey();
                                showMenu = false;
                                break;

                            default:
                                Console.WriteLine("Devi scegliere tra y (si) e n (no)");
                                goto RepeatChoice;
                        }
                    }
                    break;

                case '2':
                    ToggleBlocking(ref _rell1, _rell2, _rell3);
                    Console.WriteLine(" - Hai bloccato la prima lettera per 2 turni");
                    break;

                case '3':
                    ToggleBlocking(ref _rell2, _rell1, _rell3);
                    Console.WriteLine(" - Hai bloccato la seconda lettera per 2 turni");
                    break;

                case '4':
                    ToggleBlocking(ref _rell3, _rell1, _rell2);
                    Console.WriteLine(" - Hai bloccato la terza lettera per 2 turni");
                    break;
            }
        }
    }

    private void ToggleBlocking(ref bool rell, bool other1, bool other2)
    {
        if (!rell && !(other1 && other2))
            rell = true;
        else
            rell = false;
    }

    private void CheckBlockCounters()
    {
        if (_rell1)
            _count1++;

        if (_count1 == 2)
        {
            _rell1 = false;
            _count1 = 0;
        }

        if (_rell2)
            _count2++;

        if (_count2 == 2)
        {
            _rell2 = false;
            _count2 = 0;
        }

        if (_rell3)
            _count3++;

        if (_count3 == 2)
        {
            _rell3 = false;
            _count3 = 0;
        }
    }
}

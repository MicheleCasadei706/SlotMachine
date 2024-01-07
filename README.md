# SlotMachine

## Descrizione
Questo progetto simula una slot machine

## Contenuti

1. [Logica della Slot Machine](#logica-della-slot-machine)
    - [Descrizione](#descrizione)
    - [Classe `SlotMachine`](#classe-slotmachine)
2. [Applicazione Console](#applicazione-console)
    - [Descrizione](#descrizione-1)
    - [Classe `Program`](#classe-program)
3. [WPF MainWindow](#wpf-mainwindow)
    - [Descrizione](#descrizione-2)
    - [Markup XAML](#markup-xaml)

## Logica della Slot Machine

### Descrizione
Il componente `SlotMachine` è la base per la simulazione della slot machine. Gestisce il saldo, le vincite e il funzionamento dei rulli. La slot machine offre diverse possibilità di vincita in base alle combinazioni di lettere ottenute nei rulli.

### Classe `SlotMachine`

#### Proprietà
- `Balance`: rappresenta il saldo attuale del giocatore.
- `LastWin`: rappresenta l'importo dell'ultima vincita.
- `Rell1`, `Rell2`, `Rell3`: rappresentano le lettere visualizzate sui rulli.

#### Metodi Principali
- `SpinSlotMachine(bool lock1 = false, bool lock2 = false, bool lock3 = false)`: simula il giro dei rulli, gestendo il blocco delle lettere.
- `Reset()`: reimposta la slot machine allo stato iniziale.
- Altri metodi privati per valutare diverse condizioni di vincita.

## Applicazione Console

### Descrizione
Il componente `Program` rappresenta l'interfaccia utente a console per interagire con la slot machine. L'utente può girare i rulli, bloccare singole lettere per due turni e monitorare il saldo e le vincite.

### Classe `Program`

#### Proprietà e Variabili
- `_slotMachine`: istanza della classe `SlotMachine` che gestisce la logica della slot machine.
- `_count1`, `_count2`, `_count3`: contatori per il blocco delle lettere.
- `_rell1`, `_rell2`, `_rell3`: variabili booleane che indicano se le rispettive lettere sono bloccate.

#### Metodi Principali
- `RunMainProgram()`: gestisce l'interazione con l'utente, consentendo di girare i rulli, bloccare lettere e visualizzare le informazioni sulla slot machine.
- `ToggleBlocking(ref bool rell, bool other1, bool other2)`: gestisce il blocco delle lettere in base alle condizioni specificate.
- `CheckBlockCounters()`: verifica e gestisce il conteggio dei blocchi delle lettere.


## WPF MainWindow

### Descrizione
Il file `MainWindow.xaml.cs` contiene il codice dietro l'interfaccia utente WPF. 






using System.IO;
using System.Threading;
using System;

namespace multithreads
{
    class TwoInt{
        public int _firstNumber,_secondNumber;
    }

    class Program{
    public static void Main(){
        TwoInt dataObject=new TwoInt();
        Console.WriteLine("Defaults at intialization:{0} and {1}",dataObject._firstNumber,dataObject._secondNumber);
        
        Thread firstThread=new Thread(delegate(){
            dataObject._firstNumber=2222;
           CheckReference(ref dataObject);
            Console.WriteLine("After reference function:{0}",dataObject._firstNumber);
        });
        firstThread.Start();
        
        Thread secondThread=new Thread(delegate()
        {
            dataObject._secondNumber=2020;
            CheckOut(out dataObject);
            Console.WriteLine("After out function:{0}",dataObject._secondNumber);
        });
        secondThread.Start();
        Thread.Sleep(5000);
        dataObject._secondNumber=4545;
        Console.WriteLine("Value before intiatlization in out function:{0}",dataObject._secondNumber);
        Console.ReadKey();
    }
        
        public static void CheckReference(ref TwoInt inputArg){
        Console.WriteLine("Starting of REF:{0}",inputArg._firstNumber);
        inputArg._firstNumber=3333;
        Console.WriteLine("First change in REF:{0}",inputArg._firstNumber);
        inputArg=new TwoInt();
        Console.WriteLine("Reintialization of class in ref:{0}",inputArg._firstNumber);
    }
    
     public static void CheckOut(out TwoInt inputArg){
            Thread.Sleep(5000);
            inputArg=new TwoInt();
            inputArg._secondNumber=6666;
            Thread.Sleep(2000);
            Console.WriteLine("Starting of OUT:{0}",inputArg._secondNumber);
            inputArg._secondNumber=5555;
            Console.WriteLine("First change in OUT:{0}",inputArg._secondNumber);
            inputArg._secondNumber=9999;
        }
        

    }

}

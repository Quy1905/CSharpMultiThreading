# CSharp Multi Threading

#### This code using SemaphoreSlim to make multi thread very easily

SemaphoreSlim can be useful in limiting concurrency — preventing too many threads from executing a particular piece of code at once. In the following example, five threads try to enter a nightclub that allows only three threads in at once

# Example
    class TheClub      // No door lists!
    {
      static SemaphoreSlim _sem = new SemaphoreSlim (3);    // Capacity of 3

      static void Main()
      {
        for (int i = 1; i <= 5; i++) new Thread (Enter).Start (i);
      }

      static void Enter (object id)
      {
        Console.WriteLine (id + " wants to enter");
        _sem.Wait();
        Console.WriteLine (id + " is in!");           // Only three threads
        Thread.Sleep (1000 * (int) id);               // can be here at
        Console.WriteLine (id + " is leaving");       // a time.
        _sem.Release();
      }
    }
#### Output
    1 wants to enter
    1 is in!
    2 wants to enter
    2 is in!
    3 wants to enter
    3 is in!
    4 wants to enter
    5 wants to enter
    1 is leaving
    4 is in!
    2 is leaving
    5 is in!

using System;
using System.Collections.Generic;
using System.Text;

namespace eventhandling
{
    public delegate void Notify();  // delegate

    public class TestEvent
    {
        public event Notify ProcessCompleted; // event

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            // some code here..
            OnProcessCompleted();
        }

        protected virtual void OnProcessCompleted() //protected virtual method
        {
            //if ProcessCompleted is not null then call delegate
            ProcessCompleted?.Invoke();
        }
    }
}
